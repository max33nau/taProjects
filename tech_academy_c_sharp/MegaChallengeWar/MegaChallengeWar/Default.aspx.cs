using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeWar
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void startGameButton_Click(object sender, EventArgs e)
        {
            List<Player> players = new List<Player>()
            {
                new Player("Aquaman", "blue"),
                new Player("Superman", "red")
            };
            Random random = new Random();
            Game game = new Game(random);
            dealCardsLabel.Text = game.dealCards(players);
            Battle battle = new Battle(players);
            beginBattleLabel.Text = battle.beginBattle();
        }
    }
}