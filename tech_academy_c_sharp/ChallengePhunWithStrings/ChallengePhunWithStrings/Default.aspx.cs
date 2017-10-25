using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePhunWithStrings
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1. Reverse your name
            string name = "Bob Tabor";
            string reversedName = "";
            for (int i = name.Length - 1; i >= 0; i-- )
            {
                reversedName += name[i].ToString();
            }
            reverseNameLabel.Text = reversedName;

            // 2. Reverse this sequence
            string names = "Luke,Leia,Han,Chewbacca";
            string[] arrayOfNames = names.Split(',');
            string reversedSequence = "";
            for (int i = arrayOfNames.Length - 1; i >= 0; i-- )
            {
                reversedSequence += arrayOfNames[i];
                if (i != 0) { reversedSequence += ',';  }
            }
            reverseSequenceLabel.Text = reversedSequence;

            // 3. Use the sequence to create ascii art:
            string asciiArt = "";
            int totalLength = 14;
            for (int i = 0; i < arrayOfNames.Length; i++)
            {
                int asciis = (totalLength - arrayOfNames[i].Length) / 2 + arrayOfNames[i].Length;
                asciiArt += arrayOfNames[i].PadLeft(asciis, '*').PadRight(totalLength, '*') + "<br />";
            }
            asciiLabel.Text = asciiArt;

            // 4. Solve this puzzle:
            // output should be: Now is the time for all good men to come to the aid of their country. 
            string puzzle = "NOW IS ZHEremove-me ZIME FOR ALL GOOD MEN ZO COME ZO ZHE AID OF ZHEIR COUNZRY.";
            string removeString = "remove-me";
            int removeMeIndex = puzzle.IndexOf(removeString);
            puzzleLabel.Text = puzzle.Replace('Z', 'T')
                .ToLower()
                .Remove(removeMeIndex, removeString.Length)
                .Remove(0, 1)
                .Insert(0, "N");
        }
    }
}