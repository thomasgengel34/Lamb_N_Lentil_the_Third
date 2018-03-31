using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lamb_N_Lentil.Tests.Views
{
    [TestClass]
    public class IngredientsIndexShould:BaseViewTests
    {
        private static string filePath = @"C:\Dev\TGE\Lamb_N_Lentil\Lamb_N_Lentil\Views\Ingredients\Index.cshtml";

        public IngredientsIndexShould()
        {
            ObtainFileAsString(filePath);
        }


        [TestMethod]
        public void HaveCorrectSearchForm() => HaveCorrectText(
            "\n    @using (Html.BeginForm(\"ShowResults\", \"Ingredients\", new { Controller = \"Ingredients\", searchText = \"searchText\" }))",
            "@using (Html.BeginForm(\"ShowResults\", \"Ingredients\", new { Controller = \"Ingredients\", searchText = \"searchText\" }))");

        [TestMethod]
        public void HaveCorrectLabelForTextSearch() => HaveCorrectText(
        "\n <p>  <label>Enter text to search for ingredients from the branded food database:</label></p>", "<p>  <label>Enter text to search for ingredients from the branded food database:</label></p>");


        [TestMethod]
        public void HaveCorrectLineForItemManufacturerOrFoodGroup() => HaveCorrectText(
           "\n @Html.DisplayFor(model => item.ManufacturerOrFoodGroup)", "@Html.DisplayFor(model => item.ManufacturerOrFoodGroup)"); 
    }
}
