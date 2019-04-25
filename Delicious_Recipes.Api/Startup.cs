using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delicious_Recipes.Dal.Abstract;
using Delicious_Recipes.Dal.Concreate;
using Delicious_Recipes.Dal.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Delicious_Recipes.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<Delicious_RecipeContext>((provider, builder) =>
                {
                    builder.UseSqlServer(
                        "data source=TBICAKCIW10;initial catalog=Delicious_Recipe;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
                });
            services.AddSingleton<ITariflerRepo, TariflerRepo>();
            services.AddMvc()
                .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();


            app.UseMvc();

         
        }
    }
}
