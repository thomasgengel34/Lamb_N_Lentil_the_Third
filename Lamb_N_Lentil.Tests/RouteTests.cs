using System;
using System.Reflection;
using System.Web;
using System.Web.Routing;
using Lamb_N_Lentil.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Lamb_N_Lentil.Tests
{
    [TestClass]
    public class RouteTests
    {
        private HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET")
        {
            // create the mock request
            Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath)
                .Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            // create the mock response
            Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

            // create the mock context, using the request and response
            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            // return the mocked context
            return mockContext.Object;
        }

        private void TestRouteMatch(string url, string Controller, string action,
             object routeProperties = null, string httpMethod = "GET")
        { 
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            RouteData result
                = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result, Controller,
                action, routeProperties));
        }


        private bool TestIncomingRouteResult(RouteData routeResult,
            string Controller, string action, object propertySet = null)
        {

            Func<object, object, bool> valCompare = (v1, v2) =>
            {
                return StringComparer.InvariantCultureIgnoreCase
                    .Compare(v1, v2) == 0;
            };

            bool result = valCompare(routeResult.Values["Controller"], Controller)
                && valCompare(routeResult.Values["action"], action);

            if (propertySet != null)
            {
                PropertyInfo[] propInfo = propertySet.GetType().GetProperties();
                foreach (PropertyInfo pi in propInfo)
                {
                    if (!(routeResult.Values.ContainsKey(pi.Name)
                            && valCompare(routeResult.Values[pi.Name],
                            pi.GetValue(propertySet, null))))
                    {

                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        private void TestRouteFail(string url)
        { 
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
           
            RouteData result = routes.GetRouteData(CreateHttpContext(url));
          
            Assert.IsTrue(result == null || result.Route == null);
        }

        [TestMethod]
        public void Routes_TestIncomingDefaultRoute()
        {
            TestRouteMatch("~/", "Home", "Index");
        }

        [TestMethod]
        public void Routes_TestIncomingHomeControllerIndexRoutes()
        {
            TestRouteMatch("~/Home", "Home", "Index");
            TestRouteMatch("~/Home/Index", "Home", "Index");
        }

        [TestMethod]
        public void Routes_TestIncomingHomeControllerAboutRoute()
        {    
            TestRouteMatch("~/Home/About", "Home", "About");  
        }

        [TestMethod]
        public void Routes_TestIncomingHomeControllerContactRoute()
        { 
            TestRouteMatch("~/Home/Contact", "Home", "Contact");
        }

        [TestMethod]
        public void Routes_TestIncomingIngredientsControllerIndexRoutes()
        { 
            TestRouteMatch("~/Ingredients/Index", "Ingredients", "Index"); 
            TestRouteMatch("~/Ingredients", "Ingredients", "Index"); 
        }

        [TestMethod]
        public void Routes_TestIncomingIngredientsControllerShowResultsRoute()
        { 
            TestRouteMatch("~/Ingredients/ShowResults", "Ingredients", "ShowResults");
        }
    }
}
