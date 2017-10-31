using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeSimpleDarts
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void startGameButton_Click(object sender, EventArgs e)
        {
            Game game = new Game("Frank", "Bob");
            resultLabel.Text = game.Play();
        }
    }
}