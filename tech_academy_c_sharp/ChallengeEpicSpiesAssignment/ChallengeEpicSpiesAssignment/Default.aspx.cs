using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeEpicSpiesAssignment
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateTime today = DateTime.Now.Date;
                previousAssignment.SelectedDate = today;
                startNewAssignment.SelectedDate = today.AddDays(14);
                startNewAssignment.VisibleDate = startNewAssignment.SelectedDate;
                endNewAssignment.SelectedDate = today.AddDays(21);
                endNewAssignment.VisibleDate = endNewAssignment.SelectedDate;
            }
        }

        protected void assignSpyButton_Click(object sender, EventArgs e)
        {
            TimeSpan assignmentDiff = startNewAssignment.SelectedDate.Subtract(previousAssignment.SelectedDate);
            if (assignmentDiff.TotalDays >= 14)
            {
                TimeSpan assignmentLength = endNewAssignment.SelectedDate.Subtract(startNewAssignment.SelectedDate);
                double totalCost = assignmentLength.TotalDays * 500;
                totalCost = (assignmentLength.TotalDays > 21) ? totalCost + 1000 : totalCost;
                assignmentLabel.Text = String.Format(
                    "Assignment name {0} for spy {1} is authorized. <br /> Budget total: {2:C} <br /> <br />",
                    newAssignmentInput.Text,
                    codeNameInput.Text,
                    totalCost
                );
            } else
            {
                assignmentLabel.Text = "Error: Must allow at least two weeks between previous assignment and new assignment.";
                startNewAssignment.SelectedDate = previousAssignment.SelectedDate.Date.AddDays(14);
                startNewAssignment.VisibleDate = startNewAssignment.SelectedDate;
            }
        }
    }
}