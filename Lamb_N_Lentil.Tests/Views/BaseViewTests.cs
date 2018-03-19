using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Views
{
    public class BaseViewTests
    {
        protected string fileContents;
        protected string[] lines;
        protected string[] linesCompressed;
        protected string applicationName = "Lamb 'N' Lentil";

        internal void HaveCorrectText(string lineBeginning, string textOfInterest, int lineNumber=-1)
        {
            bool titleHasName = false;
            int i = 0;
            foreach (string line in linesCompressed)
            {
                if (line.StartsWith(lineBeginning))
                {
                    if (lines[i].Contains(textOfInterest))
                    {
                        titleHasName = true;
                    }
                }
                i++;
            }
           Assert.IsTrue(titleHasName);
            //if (lineNumber>-1)
            //{
            //    Assert.AreEqual(i, lineNumber);
            //}
        }

        protected void ObtainFileAsString(string path)
        {
            StreamReader reader = File.OpenText(path);
            fileContents = reader.ReadToEnd();
            reader.Close();
            lines = fileContents.Split('\r');
            string fileContentsCompressed = Regex.Replace(fileContents, " ", "");
            linesCompressed = fileContentsCompressed.Split('\r');
        }
    }
}
