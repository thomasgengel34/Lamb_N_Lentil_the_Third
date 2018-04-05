using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Views
{
    [TestClass]
    public class HomeAboutViewShould : BaseViewTests
    {
        // filePath =  "C:\\Dev\\TGE\\Lamb_N_Lentil\\Lamb_N_Lentil\\Views\\Home\\Index.cshtml";
        private static string filePath = @"C:\Dev\TGE\Lamb_N_Lentil\Lamb_N_Lentil\Views\Home\About.cshtml";

        public HomeAboutViewShould()
        {
            ObtainFileAsString(filePath);
        }


        [TestMethod]
        public void HaveCorrectReferenceAndLinkToUsdaDB_1()
        {  
            string testString = "<p>Look up ingredients on :<a href=\"";
            HaveCorrectText(testString); 
        }

        [TestMethod]
        public void HaveCorrectReferenceAndLinkToUsdaDB_2()
        {
            string testString = "<p>Look up ingredients on :<a href=\"https://ndb.nal.usda.gov/ndb\"";  
            HaveCorrectText(testString);
        }

        [TestMethod]
        public void HaveCorrectReferenceAndLinkToUsdaDB_3()
        {
            string testString = "<p>Look up ingredients on :<a href=\"https://ndb.nal.usda.gov/ndb\" target=\"";
            HaveCorrectText(testString);
        }

        [TestMethod]
        public void HaveCorrectReferenceAndLinkToUsdaDB_4()
        {
            string testString = "<p>Look up ingredients on :<a href=\"https://ndb.nal.usda.gov/ndb\" target=\"_blank\">";
            HaveCorrectText(testString);
        }

        [TestMethod]
        public void HaveCorrectReferenceAndLinkToUsdaDB_5()
        {
            string testString = "<p>Look up ingredients on :<a href=\"https://ndb.nal.usda.gov/ndb\" target=\"_blank\">the USDA nutritional site";
            HaveCorrectText(testString);
        }

        [TestMethod]
        public void HaveCorrectReferenceAndLinkToUsdaDB_6()
        {
            string testString = "<p>Look up ingredients on :<a href=\"https://ndb.nal.usda.gov/ndb\" target=\"_blank\">the USDA nutritional site</a>";
            HaveCorrectText(testString);
        }

        [TestMethod]
        public void HaveCorrectReferenceAndLinkToUsdaDB_7()
        {
            string testString = "<p>Look up ingredients on :<a href=\"https://ndb.nal.usda.gov/ndb\" target=\"_blank\">the USDA nutritional site</a><";
            HaveCorrectText(testString);
        }

        [TestMethod]
        public void HaveCorrectReferenceAndLinkToUsdaDB_8()
        {
            string testString = "<p>Look up ingredients on :<a href=\"https://ndb.nal.usda.gov/ndb\" target=\"_blank\">the USDA nutritional site</a></p>";
            HaveCorrectText(testString);
        }
    }
}
