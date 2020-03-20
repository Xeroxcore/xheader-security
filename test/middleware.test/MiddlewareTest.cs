using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xheaderSecurity;
using xheaderSecurity.Interface;

namespace middleware.test
{
    [TestClass]
    public class UnitTest1
    {

        private SecureHeaderMiddleware CreateSecurityMiddleware(IHeaderPolicy policy, bool stopOnException = true)
        {
            return new SecureHeaderMiddleware(
            next: (innerHttpContext) =>
            {
                innerHttpContext.Response.WriteAsync(CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
                return Task.CompletedTask;
            }, policy, stopOnException);
        }

        private DefaultHttpContext CreateDefaultHttpContext()
            => new DefaultHttpContext();

        [TestMethod]
        public async Task InjectPolyciesToHeader()
        {
            //Create a new instance of the middleware
            var middleware = CreateSecurityMiddleware(new TestHeaderPolicy());

            var context = CreateDefaultHttpContext();
            await middleware.Invoke(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var header = context.Response.Headers;

            Assert.AreEqual(2, header.Count);
        }

        [TestMethod]
        public async Task InsertNullParameterToConstructor()
        {
            Exception catchError = new Exception("");
            try
            {
                var middleware = CreateSecurityMiddleware(null);
                var context = CreateDefaultHttpContext();
                await middleware.Invoke(context);
            }
            catch (Exception error)
            {
                catchError = error;
            }
            Assert.AreEqual("Error: The Constructor input parameter policy is null", catchError.Message);
        }

        [TestMethod]
        public async Task PolicyHeaderListIsNull()
        {
            Exception catchError = new Exception("");
            try
            {
                var middleware = CreateSecurityMiddleware(new BrokenTestHeaderPolicy());
                var context = CreateDefaultHttpContext();
                await middleware.Invoke(context);
            }
            catch (Exception error)
            {
                catchError = error;
            }

            Assert.AreEqual("Error: Assigned list of header policies in your policy is null", catchError.Message);
        }

        [TestMethod]
        public async Task PolicyHeaderListIsEmpty()
        {
            Exception catchError = new Exception("");
            try
            {
                var middleware = CreateSecurityMiddleware(new EmptyTestHeaderPolicy());
                var context = CreateDefaultHttpContext();
                await middleware.Invoke(context);
            }
            catch (Exception error)
            {
                catchError = error;
            }

            Assert.AreEqual("Warning: Assigned list of header policies in your policy is empty", catchError.Message);
        }

        [TestMethod]
        public async Task PolicyHeaderListWithDublicateHeaders()
        {

            var middleware = CreateSecurityMiddleware(new DublicateTestHeaderPolicy());

            var context = CreateDefaultHttpContext();
            await middleware.Invoke(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var header = context.Response.Headers;

            Assert.AreEqual(2, header.Count);
        }


        [TestMethod]
        public async Task MakeSureMiddlewareContinuesWithoutCrash()
        {

            var middleware = CreateSecurityMiddleware(new BrokenTestHeaderPolicy(), false);

            var context = CreateDefaultHttpContext();
            await middleware.Invoke(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var header = context.Response.Headers;

            Assert.AreEqual(0, header.Count);
        }
    }
}
