using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema;
using NSwag.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;

namespace Template21
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
            services
                .AddSwagger()
                .AddSwaggerGen(options =>
                {
                    //options.DescribeAllEnumsAsStrings();
                    options.SwaggerDoc("swashbuckle", new Info { Title = "title is required", Version = "and so is version" });
                })
                .AddMvc()
                .AddXmlDataContractSerializerFormatters()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseHsts();
            }

            app
                //.UseHttpsRedirection()
                .UseSwaggerWithApiExplorer(settings => settings.SwaggerRoute = "/nswagApiExplorer.json")
                .UseSwaggerWithApiExplorer(settings =>
                {
                    settings.GeneratorSettings.DefaultEnumHandling = EnumHandling.String;
                    settings.SwaggerRoute = "/nswagApiExplorerString.json";
                })
                .UseSwagger(options => options.RouteTemplate = "/{documentName}.json")
                .Map("/basePath", application => application.UseMvc());
        }
    }
}
