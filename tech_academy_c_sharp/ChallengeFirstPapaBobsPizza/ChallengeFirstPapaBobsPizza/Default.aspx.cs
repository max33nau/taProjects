using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeFirstPapaBobsPizza
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void purchaseButton_Click(object sender, EventArgs e)
        {
            double totalPrice = 0.00;
            errorLabel.Text = "";

            if (babyRadioButton.Checked) { totalPrice += 10;  }
            else if (mamaRadioButton.Checked) { totalPrice += 13; }
            else if (papaRadioButton.Checked) { totalPrice += 16; }
            else { errorLabel.Text = "Please select a pizza size"; return;  }

            if (deepDishCrustRadioButton.Checked) { totalPrice += 2; }
            else if (thinCrustRadioButton.Checked) { totalPrice += 0; } 
            else { errorLabel.Text = "Please select a type of crust."; return;  }

            if (pepperoniCheckbox.Checked)
                totalPrice += 1.50;
            if (onionsCheckbox.Checked)
                totalPrice += 0.75;
            if (greenPeppersCheckbox.Checked)
                totalPrice += 0.50;
            if (redPeppersCheckbox.Checked)
                totalPrice += 0.75;
            if (anchoviesCheckbox.Checked)
                totalPrice += 2;

            if (
                pepperoniCheckbox.Checked
                && (greenPeppersCheckbox.Checked && anchoviesCheckbox.Checked
                    || redPeppersCheckbox.Checked && onionsCheckbox.Checked)
              )
                totalPrice -= 2;

            totalLabel.Text = totalPrice.ToString();
        }
    }
}