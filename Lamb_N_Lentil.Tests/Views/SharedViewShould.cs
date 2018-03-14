using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Views
{
    [TestClass]
    public class SharedViewShould: BaseViewTests
    { 
        public SharedViewShould()
        {
            ObtainFileAsString(@"C:\Dev\TGE\Lamb_N_Lentil\Lamb_N_Lentil\Views\Shared\_Layout.cshtml");
        }
         

        [TestMethod]
        public void HaveCorrectNameInTitle() => HaveCorrectText("\n<title>@ViewBag.Title-", applicationName);

        [TestMethod]
        public void HaveCorrectNameInActionLink() => HaveCorrectText("\n@Html.ActionLink", applicationName);

        [TestMethod]
        public void HaveCorrectNameInFooter() => HaveCorrectText("\n<p>&copy;@DateTime.Now.Year", applicationName);

        [TestMethod]
        public void HaveCorrectRevisionDateInFooter() => HaveCorrectText("\n<p>ReleaseDate:", "<p>Release Date: 3/14/2018</p>");
    }
}
