using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConditionalRadioButtonChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            string selectedImageUrl;
            if (pencilRadioButton.Checked) { selectedImageUrl = "pencil.png"; }
            else if (penRadioButton.Checked) { selectedImageUrl = "pen.png"; }
            else if (phoneRadioButton.Checked) { selectedImageUrl = "phone.png"; }
            else if (tabletRadioButton.Checked) { selectedImageUrl = "tablet.png"; }
            else { selectedImageUrl = ""; }

            resultLabel.Text = (selectedImageUrl.Length == 0) ? "Please select a option." : "You selected: ";
            resultImage.ImageUrl = (selectedImageUrl.Length == 0) ? "" : "Assets/" + selectedImageUrl;
        }
    }
}