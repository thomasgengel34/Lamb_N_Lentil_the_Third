using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Views
{
    [TestClass]
    public class HomeIndexViewShould: BaseViewTests
    { 
        public HomeIndexViewShould()
        {
            ObtainFileAsString(@"C:\Dev\TGE\Lamb_N_Lentil\Lamb_N_Lentil\Views\Home\Index.cshtml");
        }
         

        [TestMethod]
        public void HaveCorrectNameInHeader() => HaveCorrectText("\n<h1>", applicationName);
         
    }
}
