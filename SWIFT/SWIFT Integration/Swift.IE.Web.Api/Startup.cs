using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using NSwag.AspNet.Owin;
using Owin;

[assembly: OwinStartup(typeof(Swift.IE.Web.Api.Startup))]

namespace Swift.IE.Web.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();

            app.UseSwaggerUi(typeof(Startup).Assembly, new SwaggerUiSettings());
            app.UseWebApi(config);
            app.UseFileServer(new FileServerOptions
            {
                RequestPath = PathString.Empty,
                EnableDefaultFiles = true,
                FileSystem = new PhysicalFileSystem(
                    AppDomain.CurrentDomain.BaseDirectory
                ),
                StaticFileOptions =
                {
                    FileSystem = new PhysicalFileSystem(
                        AppDomain.CurrentDomain.BaseDirectory
                    ),
                    ServeUnknownFileTypes = false
                },
            });
        }
    }
}
