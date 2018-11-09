﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema;
using NSwag.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;

namespace Template22
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
                .AddSwaggerDocument(settings => settings.DefaultEnumHandling = EnumHandling.String)
                .AddSwaggerGen(options =>
                {
                    options.DescribeAllEnumsAsStrings();
                    options.SwaggerDoc("swashbuckleString", new Info { Title="swashbuckleString", Version="v1" });
                })
                .AddMvc()
                .AddXmlDataContractSerializerFormatters()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app
                .UseHttpsRedirection()
                .UseSwagger(settings => settings.PostProcess = null)
                .UseSwagger(options => options.RouteTemplate = "/{documentName}.json");
        }
    }
}
