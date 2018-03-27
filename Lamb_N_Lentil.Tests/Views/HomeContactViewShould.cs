using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Views
{
    [TestClass]
    public class HomeContactViewShould : BaseViewTests
    {
        // filePath =  "C:\\Dev\\TGE\\Lamb_N_Lentil\\Lamb_N_Lentil\\Views\\Home\\Index.cshtml";
        private static string filePath = @"C:\Dev\TGE\Lamb_N_Lentil\Lamb_N_Lentil\Views\Home\Contact.cshtml";

        public HomeContactViewShould()
        {
            ObtainFileAsString(filePath);
        }


        [TestMethod]
        public void HaveCorrectH1() => HaveCorrectText("\n<h1>@ViewBag.Title</h1>", "<h1>@ViewBag.Title</h1>");  
    }
}
