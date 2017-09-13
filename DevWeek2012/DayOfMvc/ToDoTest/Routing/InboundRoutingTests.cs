using NUnit.Framework;
using System.Web.Routing;
using ToDoTest.Extensions;

namespace ToDoTest.Routing
{
    [TestFixture]
    public class InboundRoutingTests
    {
        [Test]
        public void GivenACorrectRoutesCollection_WhenIAskForTheDefaultRoute_ThenIGetTheTodoControllerAndTheIndexAction()
        {
            TestRoute("~/", new
            {
                controller = "Todo",
                action = "Index"
            },
            "GET");
        }

        [Test]
        public void GivenACorrectRoutesCollection_WhenIAskForANewTodo_ThenIGetTheTodoControllerAndTheNewAction()
        {
            TestRoute("~/todo/new", new
            {
                controller = "Todo",
                action = "New"
            },
            "GET");
        }

        [Test]
        public void GivenACorrectRoutesCollection_WhenIAskToCreateATodo_ThenIGetTheTodoControllerAndTheCreateAction()
        {
            TestRoute("~/todo/create", new
            {
                controller = "Todo",
                action = "Create"
            },
            "POST");
        }

        [Test]
        public void GivenACorrectRoutesCollection_WhenIAskToCreateATodoUsingGet_ThenThereIsNoRoute()
        {
            string url = "~/todo/create";
            RouteData routeData = url.GetRouteData("GET");

            Assert.That(routeData, Is.Null);
        }

        //[Test]
        //public void GivenACorrectRoutesCollection_WhenIAskForTheLatestRoute_ThenIGetTheLatestView()
        //{
        //    TestRoute("~/todo/latest", new
        //    {
        //        controller = "Todo",
        //        action = "latest"
        //    },
        //    "GET");
        //}

        private void TestRoute(string url, object expectedValues, string httpMethod)
        {
            RouteData routeData = url.GetRouteData(httpMethod);

            Assert.That(routeData, Is.Not.Null, "Route data not set for this HttpMethod");
            var routeValueDictionaryExpected = new RouteValueDictionary(expectedValues);
            foreach (var expectedRouteValue in routeValueDictionaryExpected)
            {
                if (expectedRouteValue.Value == null)
                {
                    Assert.That(routeData.Values[expectedRouteValue.Key], Is.Null);
                }
                else
                {
                    Assert.That(expectedRouteValue.Value.ToString(), Is.EqualTo(
                        routeData.Values[expectedRouteValue.Key].ToString()).IgnoreCase);
                }
            }
        }

    }
}