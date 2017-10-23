using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePostalCalculatorHelperMethods
{
    public partial class Defaultaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void widthInput_TextChanged(object sender, EventArgs e)
        {
            handleTextChange();
        }

        protected void heightInput_TextChanged(object sender, EventArgs e)
        {
            handleTextChange();
        }

        protected void lengthInput_TextChanged(object sender, EventArgs e)
        {
            handleTextChange();
        }

        protected void groundRadio_CheckedChanged(object sender, EventArgs e)
        {
            groundRadioSelected();
        }

        protected void airRadio_CheckedChanged(object sender, EventArgs e)
        {
            airRadioSelected();
        }

        protected void nextDayRadio_CheckedChanged(object sender, EventArgs e)
        {
            nextDayRadioSelected();
        }

        protected void handleTextChange()
        {
            if (groundRadio.Checked) groundRadioSelected();
            else if (airRadio.Checked) airRadioSelected();
            else if (nextDayRadio.Checked) nextDayRadioSelected();
        }

        protected void groundRadioSelected()
        {
            determinePackagePrice(.15, "Ground");
        }

        protected void airRadioSelected()
        {
            determinePackagePrice(.25, "Air");
        }

        protected void nextDayRadioSelected()
        {
            determinePackagePrice(.45, "Next Day");
        }

        protected void determinePackagePrice(double multiplier, string shippingMethod)
        {
            string widthText = widthInput.Text;
            string heightText = heightInput.Text;
            string lengthText = lengthInput.Text;
            if (hasRequiredPackageInputs(widthText, heightText))
            {
                double width = 0.0;
                double height = 0.0;
                double length = 1.0; // defaults to 1 for when no value is passed
                if (
                    !packageInputIsNumber(widthText, "width", out width) ||
                    !packageInputIsNumber(heightText, "height", out height) ||
                    (stringHasValue(lengthText) && !packageInputIsNumber(lengthText, "length", out length))
                )
                    return;


                double finalPrice = getFinalPrice(width, height, multiplier, length);
                string finalResult = String.Format("Your parcel will cost <strong> {0:C} </strong> for shipping method {1}", finalPrice, shippingMethod);
                setResultText(finalResult);
            }
        }

        protected bool hasRequiredPackageInputs(string width, string height)
        {
            if (!stringHasValue(width) || !stringHasValue(height))
            {
                setResultText("Package must have a specified width and height.");
                return false;
            } else
            {
                return true;
            }
                
        }

        protected bool packageInputIsNumber(string input, string type, out double convertedInput)
        {
            if (!Double.TryParse(input, out convertedInput))
            {
                setResultText(String.Format("Input value <strong> {0} </strong> for package input <strong> {1} </strong> is not a valid number.", input, type));
                return false;
            } else
            {
                return true;
            }
        }

        protected double getFinalPrice(double width, double height, double multiplier, double length = 1.0)
        {
            return (width * height *multiplier * length);
        }

        protected void setResultText(string result)
        {
            resultLabel.Text = result;
        }

        protected bool stringHasValue(string input)
        {
            return (input.Trim().Length != 0);
        }

    }
}