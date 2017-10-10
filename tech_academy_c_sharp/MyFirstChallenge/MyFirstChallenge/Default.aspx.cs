using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFirstChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            string yourAge = yourAgeTextBox.Text;
            string yourChange = yourChangeTextBox.Text;

            string result = "At " + yourAge + " years old, I would have expect you to have more than " + yourChange + " in your pocket.";

            yourFortuneLabel.Text = result;
        }
    }
}