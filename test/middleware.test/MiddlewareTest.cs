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
        public void TestMethod1()
        {
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            //Create a new instance of the middleware
            var middleware = new SecureHeaderMiddleware(
            next: (innerHttpContext) =>
            {
                innerHttpContext.Response.WriteAsync(CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
                return Task.CompletedTask;
            }, null);

        }
    }
}
