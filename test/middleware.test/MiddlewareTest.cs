using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace middleware.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task InjectPolyciesToHeader()
        {
            //Create a new instance of the middleware
            var middleware = new SecureHeaderMiddleware(
            next: (innerHttpContext) =>
            {
                innerHttpContext.Response.WriteAsync(CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
                return Task.CompletedTask;
            }, new TestHeaderPolicy());

            var context = new DefaultHttpContext();
            await middleware.Invoke(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var header = context.Response.Headers;

            Assert.AreEqual(2, header.Count);
        }
    }
}
