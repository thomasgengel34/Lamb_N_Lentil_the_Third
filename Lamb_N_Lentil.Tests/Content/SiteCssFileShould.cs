using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lamb_N_Lentil.Tests.Views;

namespace Lamb_N_Lentil.Tests.Content
{
    [TestClass]
    public class SiteCssFileShould : BaseViewTests
    { 
        static string testFileContents = @"body {
    padding-top: 50px;
    padding-bottom: 20px;
    background: linear-gradient(90deg,rgba(250,207,78,0) 12%, transparent 0, transparent 99%, #dca 0);
    background-size: 100px 100px;
    font-family: 'Lucida Handwriting';
    color: green;
    margin: 0;
    border-width: 0;
}

.container .body-content {
    margin-bottom: 0;
    padding-bottom: 0;
    min-height: 80vh;
}

.jumbotron {
    background-color: white;
}

/* Set padding to keep content from hitting the edges */
.body-content {
    padding-left: 15px;
    padding-right: 15px;
}

/* Override the default bootstrap behavior where horizontal description lists 
   will truncate terms that are too long to fit in the left column 
*/
.dl-horizontal dt {
    white-space: normal;
}

/* Set width on the form input elements since they're 100% wide by default */
input,
select,
textarea {
    max-width: 280px;
}


.nav, .menu, .navbar-header, .navbar-collapse, .collapse, .navbar, .navbar-inverse, .navbar-fixed-top, .li {
    background-color: green;
    color: white;
}

#navA a, #navB a, #navC a {
    color: white;
}

    #navA a:hover, #navB a:hover, #navC a:hover, .col-md-4 {
        background-color: white;
        color: green;
    }

.navbar {
    margin-left: 0;
}


h1, h2, h3, h4, h5, h6, table, a {
    font-family: 'Lucida Handwriting';
    background: #ffd800;
    background-color: rgba(250,207,78,0);
    color: green;
}

a {
    text-decoration: underline;
}

.alert-container {
    position: fixed;
    left: 0;
    right: 0;
    padding-left: 3em;
    padding-right: 3em;
}

.container.body-content {
    padding-left: 100px;
    background-color: lightgoldenrodyellow;
    background-image: linear-gradient(90deg, transparent 79px, pink 79px, pink 80px, transparent 81px), linear-gradient(#eee .1em, transparent .4em);
    background-size: 100% 2.4em;
    min-height: 90vh;
}

h1 {
    padding-top: 19px;
}

h2 {
    padding-top: 20px;
}

p {
    line-height: 2.4em;
    margin-top: -10px;
}

.IngredientsIndexTable {
    background-color: white;
    width: 60%;
}

    .IngredientsIndexTable .rightJustify {
        text-align: right;
    }

tr td:first-of-type {
    width: 40%;
    padding-left: 2%;
}

tr td:last-of-type {
    padding-right: 2%;
}

tr .leftpadding10 {
    padding-left: 10%;
}

.ingredientTextBox {
    padding: 1px;
    padding-left: 5px;
    width: 450px;
    max-width: 450px;
}

h2.no_results {
    color: red;
}

#IngredientsIndexTable tr th:last-child, #IngredientsIndexTable tr td:last-child {
    width: 5%;
}

/* Nutrition Label - begin*/
#NutritionLabel {
    border: solid black 1px;
    background: white;
    padding: 1%;
    font-family: Arial;
    color: black;
    width: 50%;
    padding: 0;
    border: 0;
    margin: 0;
}

    #NutritionLabel hr {
        width: 100%;
        height: 20px;
        margin: 0;
    } 
        #NutritionLabel hr:first-of-type {
            background: black;
            height: 20px;
        }

        #NutritionLabel hr:nth-of-type(2) {
            background: black;
            height: 11px;
            margin-top:-5px;
        }



    #NutritionLabel h2:first-of-type {
        margin-bottom: 0;
        padding-bottom: 0;
    }

    #NutritionLabel p {
        margin-bottom: 0;
        padding-bottom: 0;
    }

        #NutritionLabel p:first-of-type, #NutritionLabel hr:nth-of-type(2) {
            margin-top: 0;
            padding-top: 0;
        }


    #NutritionLabel h1, #NutritionLabel h2, #NutritionLabel p, #NutritionLabel dd, #NutritionLabel dt, #NutritionLabel dl, #NutritionLabel td, t {
        background: white;
        padding: 1%;
        font-family: Arial;
        color: black;
    }


    #NutritionLabel .bold {
        font-weight: 800;
    }
    #NutritionLabel .indented { 
      padding-left:5%;
    }
/* Nutrition Label - end*/";


private static string filePath = @"C:\Dev\TGE\Lamb_N_Lentil\Lamb_N_Lentil\Content\Site.css";
                                           

        public SiteCssFileShould()
        {
            ObtainFileAsString(filePath);
        }

        [TestMethod]
        public void LookLikeThis()
        { 
          Assert.AreEqual(testFileContents,fileContents); 
        } 
    }
} 
