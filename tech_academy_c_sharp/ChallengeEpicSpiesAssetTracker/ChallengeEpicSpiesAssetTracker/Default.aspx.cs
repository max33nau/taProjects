using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeEpicSpiesAssetTracker
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState.Add("Names", new string[0]);
                ViewState.Add("Elections", new int[0]);
                ViewState.Add("Subterfuges", new int[0]);
            }
        }

        protected void addAssetButton_Click(object sender, EventArgs e)
        {
            string[] names = (string[])ViewState["Names"];
            int[] elections = (int[])ViewState["Elections"];
            int[] subterfuges = (int[])ViewState["Subterfuges"];

            if (string.IsNullOrEmpty(assetNameInput.Text) ||
                string.IsNullOrEmpty(electionsRiggedInput.Text) ||
                string.IsNullOrEmpty(actsOfSubterfugeInput.Text) )
                return;

            string assetName = assetNameInput.Text;
            int electionsRigged = int.Parse(electionsRiggedInput.Text);
            int subterfugesPerformed = int.Parse(actsOfSubterfugeInput.Text);

            int newArrayLength = names.Length + 1;
            
            Array.Resize(ref names, newArrayLength);
            int lastIndex = names.GetUpperBound(0);
            names[lastIndex] = assetName;

            Array.Resize(ref elections, newArrayLength);
            elections[lastIndex] = electionsRigged;

            Array.Resize(ref subterfuges, newArrayLength);
            subterfuges[lastIndex] = subterfugesPerformed;

            resultLabel.Text = string.Format("Total Elections Rigged: {0} <br /> Average Acts of Subterfuge per Asset {1:N2} <br /> (Last Asset you Added: {2})", 
                elections.Sum(),
                subterfuges.Average(),
                names[lastIndex]
                );

            ViewState.Add("Names", names);
            ViewState.Add("Elections", elections);
            ViewState.Add("Subterfuges", subterfuges);

            assetNameInput.Text = "";
            electionsRiggedInput.Text = "";
            actsOfSubterfugeInput.Text = "";
        
        }
    }
}