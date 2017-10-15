using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleCalculatorChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            int firstValue = int.Parse(firstValueInput.Text);
            int secondValue = int.Parse(secondValueInput.Text);

            int result = firstValue + secondValue;

            resultLabel.Text = result.ToString();
        }

        protected void subtractButton_Click(object sender, EventArgs e)
        {
            int firstValue = int.Parse(firstValueInput.Text);
            int secondValue = int.Parse(secondValueInput.Text);

            int result = firstValue - secondValue;

            resultLabel.Text = result.ToString();
        }

        protected void multiplyButton_Click(object sender, EventArgs e)
        {
            int firstValue = int.Parse(firstValueInput.Text);
            int secondValue = int.Parse(secondValueInput.Text);

            int result = firstValue * secondValue;

            resultLabel.Text = result.ToString();
        }

        protected void divideButton_Click(object sender, EventArgs e)
        {
            double firstValue = double.Parse(firstValueInput.Text);
            double secondValue = double.Parse(secondValueInput.Text);

            double result = firstValue / secondValue;

            resultLabel.Text = result.ToString();
        }
    }
}