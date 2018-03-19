using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace Lamb_N_Lentil.Tests.Views
{
    [TestClass]
    public class HomeIndexViewShould : BaseViewTests
    {
        // filePath =  "C:\\Dev\\TGE\\Lamb_N_Lentil\\Lamb_N_Lentil\\Views\\Home\\Index.cshtml";
        private static string filePath = @"C:\Dev\TGE\Lamb_N_Lentil\Lamb_N_Lentil\Views\Home\Index.cshtml";

        public HomeIndexViewShould()
        {
            ObtainFileAsString(filePath);
        }


        [TestMethod]
        public void HaveCorrectNameInJumbotron() => HaveCorrectText("\n<h1>Lamb", applicationName);  
    }
}
