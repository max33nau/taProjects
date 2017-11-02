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
            Player player1 = new Player("Bob", "blue");
            Player player2 = new Player("Fred", "red");
            Random random = new Random();
            Game game = new Game(random);
            Battle battle = new Battle(player1, player2);
            dealCardsLabel.Text = game.dealCards(player1, player2);
            beginBattleLabel.Text = battle.beginBattle();
        }
    }
}