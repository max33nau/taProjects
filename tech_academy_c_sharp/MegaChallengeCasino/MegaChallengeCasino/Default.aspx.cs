using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeCasino
{
    public partial class Default : System.Web.UI.Page
    {
        string[] imageUrls = new string[12] 
            { "Bar.png", "Bell.png", "Cherry.png", "Clover.png", "Diamond.png",
              "HorseShoe.png", "Lemon.png", "Orange.png", "Plum.png", "Seven.png",
              "Strawberry.png", "Watermellon.png" };


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Image[] imageIds = getImageIds();
                spinImages(imageIds);
                setPlayersMoney(100);
            }
        }

        protected void pullLeverButton_Click(object sender, EventArgs e)
        {
            double playersBet = 0.0;
            if (!validBet(betAmmountInput.Text, out playersBet)) return;
            Image[] imageIds = getImageIds();
            spinImages(imageIds);
            evalSpin(playersBet, imageIds);
        }

        protected bool validBet(string betAmmount, out double playersBet)
        {
            double playersTotalMoney = getPlayersTotalMoney();
            if (!Double.TryParse(betAmmountInput.Text, out playersBet))
            { resultLabel.Text = "Invalid Bet"; return false; }
            else if (playersTotalMoney - playersBet < 0)
            { resultLabel.Text = "Insufficient Funds"; return false; }
            else return true;
        }

        protected Image[] getImageIds()
        {
            Image[] imageIds = { image1, image2, image3 };
            return imageIds;
        }

        protected void spinImages(Image[] imageIds)
        {
            for (int i = 0; i < imageIds.Length; i++)
            {
                int randomNumber = getRandomNumber(0, imageUrls.Length - 1);
                setImage(imageIds[i], imageUrls[randomNumber]);
            }
        }

        Random random = new Random();
        protected int getRandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        protected void setImage(Image image, string imageUrl)
        {
            string imageFullPath = "Images/" + imageUrl;
            image.ImageUrl = imageFullPath;
        }

        protected string stripImageUrl(string imageUrl)
        {
            int start = imageUrl.IndexOf("/") + 1;
            int end = imageUrl.IndexOf(".") - start;
            return imageUrl.Substring(start, end);
        }

        protected void evalSpin(double playersBet, Image[] imageIds)
        {
            double winnings = 0.0;
            if (barImageFound(imageIds)) winnings = -playersBet;
            else if (jackbpotFound(imageIds)) winnings = playersBet * 100;
            else { winnings = numberOfCherries(imageIds, playersBet); }
            evalWinnings(winnings, playersBet);
        }

        protected bool barImageFound(Image[] imageIds)
        {
            for (int i = 0; i < imageIds.Length; i++)
            {
                string imageType = stripImageUrl(imageIds[i].ImageUrl);
                if (imageType == "Bar") return true;
            }
            return false;
        }

        protected bool jackbpotFound(Image[] imageIds)
        {
            for (int i = 0; i < imageIds.Length; i++)
            {
                string imageType = stripImageUrl(imageIds[i].ImageUrl);
                if (imageType != "Seven") return false;
            }
            return true;
        }

        protected double numberOfCherries(Image[] imageIds, double playersBet)
        {
            int cherries = 0;
            for (int i = 0; i < imageIds.Length; i++)
            {
                string imageType = stripImageUrl(imageIds[i].ImageUrl);
                if (imageType == "Cherry") cherries++;
            }
            return priceWinningsByCherries(playersBet, cherries);
        }

        protected double priceWinningsByCherries(double playersBet, int numberOfCherries)
        {
            if (numberOfCherries == 0) return -playersBet;
            else return playersBet * (numberOfCherries + 1);
        }


        protected void evalWinnings(double winnings, double playersBet)
        {
            double playersTotalMoney = getPlayersTotalMoney();
            setPlayersMoney(playersTotalMoney + winnings);
            if (winnings < 0) userLostMoney(winnings);
            else userWonMoney(winnings, playersBet);
        }

        protected void userLostMoney(double ammountLost)
        {
            resultLabel.Text = String.Format("Sorry, you lost {0:C2}. Better luck next time.", Math.Abs(ammountLost));
        }

        protected void userWonMoney(double ammountWon, double playersBet)
        {
            resultLabel.Text = String.Format("You bet {0:C2} and won {1:C2}", playersBet, ammountWon);
        }

        protected double getPlayersTotalMoney()
        {
            return Double.Parse(playersTotalMoney.Text, System.Globalization.NumberStyles.Currency);
        }

        protected void setPlayersMoney(double ammount)
        {
            playersTotalMoney.Text = String.Format("{0:C2}", ammount);
        }

    }
}