using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Views
{
    [TestClass]
    public class ErrorViewShould:BaseViewTests
    {
        private static string answer = "  <!DOCTYPE html>" +
"<html>" +
"<head>" +
"    < meta name=\"viewport\" content=\"width=device-width\" />" +
"    <title>Error</title>" +
"</head>" +
"<body>" +
 "   <hgroup>" +
  "      <h1>Error.</h1>" +
 "       <h2>An error occurred while processing your request.</h2>" +
"    </hgroup>" +
"</body>" +
"</html>";
        private static string filePath = @"C:\Dev\TGE\Lamb_N_Lentil\Lamb_N_Lentil\Views\Error\Error.cshtml";

        public ErrorViewShould()
        {
            StreamReader reader = File.OpenText(filePath);
            fileContents = reader.ReadToEnd();
            reader.Close(); 
        }

        [TestMethod]
        public void HaveContentsMatchingTheAnswer()
        {
            string f = fileContents.Replace("\n", "").Replace(" ", "").Replace("\r", "");  
            string a = answer.Replace("\n", "").Replace(" ","").Replace("\r", "");
            Assert.AreEqual(f,a);
        }
    }
}
