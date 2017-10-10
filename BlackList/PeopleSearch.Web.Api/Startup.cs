using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nest;
using PeopleSearch.Web.Api.Infrastructure;
using Swashbuckle.AspNetCore.Swagger;

namespace PeopleSearch.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.Configure<ElasticsearchConfig>(Configuration.GetSection("elasticsearch"));

            //https://www.elastic.co/guide/en/elasticsearch/client/net-api/current/lifetimes.html
            services
                .AddSingleton(
                    sp => new ElasticClient(
                            new ConnectionSettings(
                                new Uri(ElasticsearchConfig().Uri)
                            ).DefaultIndex(ElasticsearchConfig().Index)
                        )
                );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private ElasticsearchConfig ElasticsearchConfig()
        {
            return Configuration.GetSection("elasticsearch").Get<ElasticsearchConfig>();
        }
    }
}
