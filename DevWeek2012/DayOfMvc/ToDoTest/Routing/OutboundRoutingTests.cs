using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using NUnit.Framework;
using ToDo;
using ToDoTest.Helpers;

namespace ToDoTest.Routing
{
    [TestFixture]
    public class OutboundRoutingTests
    {
        [Test]
        public void GivenACorrectRoutesCollection_WhenIAskToCreateAUrlForTheTodoPageIndexView_ThenIGetTheCorrectUrl()
        {
            Assert.AreEqual("/", GetOutboundUrl(new
            {
                controller = "Todo",
                action = "Index"
            }));
        }

        [Test]
        public void GivenACorrectRoutesCollection_WhenIAskToCreateAUrlForTheLatestView_ThenIGetTheCorrectUrl()
        {
            Assert.AreEqual("/todo/latest", GetOutboundUrl(new
            {
                controller = "todo",
                action = "Latest"
            }));
        }

        string GetOutboundUrl(object routeValues)
        {
            // Get route configuration and mock request context
            RouteCollection routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);
            var mockHttpContext = new Mock<HttpContextBase>();
            var mockRequest = new Mock<HttpRequestBase>();
            var fakeResponse = new FakeResponse();
            mockHttpContext.Setup(x => x.Request).Returns(mockRequest.Object);
            mockHttpContext.Setup(x => x.Response).Returns(fakeResponse);
            mockRequest.Setup(x => x.ApplicationPath).Returns("/");

            // Generate the outbound URL
            var ctx = new RequestContext(mockHttpContext.Object, new RouteData());
            return routes
                .GetVirtualPath(ctx, new RouteValueDictionary(routeValues))
                .VirtualPath;
        }

        static UrlHelper GetUrlHelper(string appPath = "/", RouteCollection routes = null)
        {
            if (routes == null)
            {
                routes = new RouteCollection();
                MvcApplication.RegisterRoutes(routes);
            }

            HttpContextBase httpContext = new StubHttpContextForRouting(appPath);
            RouteData routeData = new RouteData();
            routeData.Values.Add("controller", "defaultcontroller");
            routeData.Values.Add("action", "defaultaction");
            RequestContext requestContext = new RequestContext(httpContext, routeData);
            UrlHelper helper = new UrlHelper(requestContext, routes);
            return helper;
        }

        public class StubHttpContextForRouting : HttpContextBase
        {
            StubHttpRequestForRouting _request;
            StubHttpResponseForRouting _response;

            public StubHttpContextForRouting(string appPath = "/", string requestUrl = "~/")
            {
                _request = new StubHttpRequestForRouting(appPath, requestUrl);
                _response = new StubHttpResponseForRouting();
            }

            public override HttpRequestBase Request
            {
                get { return _request; }
            }

            public override HttpResponseBase Response
            {
                get { return _response; }
            }
        }

        public class StubHttpRequestForRouting : HttpRequestBase
        {
            string _appPath;
            string _requestUrl;

            public StubHttpRequestForRouting(string appPath, string requestUrl)
            {
                _appPath = appPath;
                _requestUrl = requestUrl;
            }

            public override string ApplicationPath
            {
                get { return _appPath; }
            }

            public override string AppRelativeCurrentExecutionFilePath
            {
                get { return _requestUrl; }
            }

            public override string PathInfo
            {
                get { return ""; }
            }

            public override NameValueCollection ServerVariables
            {
                get { return new NameValueCollection(); }
            }
        }

        public class StubHttpResponseForRouting : HttpResponseBase
        {
            public override string ApplyAppPathModifier(string virtualPath)
            {
                return virtualPath;
            }
        }
    }
}