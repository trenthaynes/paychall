using PayChall.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using PayChall.API.Repository;
using PayChall.API.Repository.Entities;
using System;
using System.Collections.Generic;

namespace PayChall.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            //    options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials());
            //});
            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()));

            services.AddTransient<IMailService, LocalMailService>();
            services.AddDbContext<BenefitsContext>(o => o.UseInMemoryDatabase("db"));
            services.AddScoped<IBenefitsRepository, BenefitsRepository>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            BenefitsContext ctx)
        {
            loggerFactory.AddNLog();

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyOrigin().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            SeedData(ctx);
            app.UseStatusCodePages();
            app.UseMvc();
        }

        private void SeedData(BenefitsContext ctx)
        {
            var People = new List<Person>()
            {
                new Person()
                {
                    PersonId = 1,
                    FirstName = "Fred",
                    LastName = "Flintstone",
                    DateOfBirth = DateTime.Parse("1/2/1960"),
                    IsEmployee = true,
                    PayPeriods = 26,
                    Salary = 2000
                },
                new Person()
                {
                    PersonId = 2,
                    FirstName = "Wilma",
                    LastName = "Flintstone",
                    DateOfBirth = DateTime.Parse("1/2/1965"),
                    IsEmployee = true,
                    PayPeriods = 26,
                    Salary = 2000
                },
                new Person()
                {
                    PersonId = 3,
                    FirstName = "Barney",
                    LastName = "Rubble",
                    DateOfBirth = DateTime.Parse("1/2/1962"),
                    IsEmployee = true,
                    PayPeriods = 26,
                    Salary = 2000
                },
                new Person()
                {
                    PersonId = 4,
                    FirstName = "Conrad",
                    LastName = "Hailstone",
                    DateOfBirth = DateTime.Parse("1/2/1995"),
                    IsEmployee = true,
                    PayPeriods = 26,
                    Salary = 2000
                },
                new Person()
                {
                    PersonId = 5,
                    FirstName = "Stony",
                    LastName = "Curtis",
                    DateOfBirth = DateTime.Parse("3/2/1965"),
                    IsEmployee = true,
                    PayPeriods = 26,
                    Salary = 2000
                },
                new Person()
                {
                    PersonId = 6,
                    FirstName = "Rock",
                    LastName = "Hudstone",
                    DateOfBirth = DateTime.Parse("4/2/1965"),
                    IsEmployee = true,
                    PayPeriods = 26,
                    Salary = 2000
                },
                new Person()
                {
                    PersonId = 7,
                    FirstName = "Daisy",
                    LastName = "Kilgranite",
                    DateOfBirth = DateTime.Parse("5/2/1985"),
                    IsEmployee = true,
                    PayPeriods = 26,
                    Salary = 2000
                },
                new Person()
                {
                    PersonId = 8,
                    FirstName = "Jackie",
                    LastName = "Kennerock",
                    DateOfBirth = DateTime.Parse("6/2/1975"),
                    IsEmployee = true,
                    PayPeriods = 26,
                    Salary = 2000
                }
            };

            ctx.People.AddRange(People);

            var RecipTypes = new List<BenefitRecipientType>()
            {
                new BenefitRecipientType()
                {
                    BenefitRecipientTypeId = 1,
                    Cost = 1000,
                    Description = "Employee annual benefit cost",
                    Label = "Employee"
                },
                new BenefitRecipientType()
                {
                    BenefitRecipientTypeId = 2,
                    Cost = 500,
                    Description = "Dependent annual benefit cost",
                    Label = "Dependent"
                }
            };

            ctx.BenefitRecipientTypes.AddRange(RecipTypes);

            var Discs = new List<Discount>()
            {
                new Discount()
                {
                    DiscountId = 1,
                    DiscountName = "Name begins with 'A'",
                    Condition = "startswith('A')",
                    Field = "name",
                    Expression = "{cost} - ({cost} * .1)",
                    DiscountAmount = 0.1m
                }
            };

            ctx.Discounts.AddRange(Discs);

            ctx.Meta.Add(new Meta());

            ctx.SaveChanges();
        }
    }
}