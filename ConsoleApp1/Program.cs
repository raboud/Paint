﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Paint.Data;
using Paint.Domain;
using RandREng.Paging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }
        static void Configure()
        {
            var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");

            var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) ||
                                devEnvironmentVariable.ToLower() == "development";
            //Determines the working environment as IHostingEnvironment is unavailable in a console app

            var builder = new ConfigurationBuilder();
            // tell the builder to look for the appsettings.json file
            builder
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            //only add secrets in development
            if (isDevelopment)
            {
                builder.AddUserSecrets<Program>();
            }

            Configuration = builder.Build();

            IServiceCollection services = new ServiceCollection();

            //Map the implementations of your classes here ready for DI
            services
//                .Configure<SecretStuff>(Configuration.GetSection(nameof(SecretStuff)))
                .AddOptions()
                .AddLogging()
//                .AddSingleton<ISecretRevealer, SecretRevealer>()
                .BuildServiceProvider();

            var serviceProvider = services.BuildServiceProvider();
        }


        static void Main(string[] args)
        {
            using (Context ctx = new Context())
            {
                ctx.Database.EnsureCreated();
                Populate();
                int page = 1;
                int pageSize = 100;
                PagedResult<Job> jobs;

                do
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    List<int> ids = new List<int> { 1, 2 };
                    jobs = ctx.Jobs
                        .Where(j => ids.Contains(j.ClientId))
                        .OrderBy(j => j.Id)
                        .GetPaged<Job>(page, pageSize);
                    stopwatch.Stop();
                    System.Console.WriteLine($"{page} - {stopwatch.ElapsedMilliseconds}");
                    page += 1;
                } while (jobs.PageSize == jobs.Results.Count());

            }
        }

        const int JOB_COUNT = 10000;

        static void Populate()
        {
            using (Context ctx = new Context())
            {
//                ctx.Database.EnsureCreated();
                //ctx.ChangeTracker.Tracked += ChangeTracker_Tracked;
                //ctx.ChangeTracker.StateChanged += ChangeTracker_StateChanged;

//                Client client = ctx.Clients.AsTracking().FirstOrDefault(c => c.Id == 2);
                int start = ctx.Jobs.Count() + 1;
                for (int i = start; i <= JOB_COUNT; i++)
                {
                    Job job1 = new Job();
                    job1.Address = new Address();
                    job1.Address.Line1 = $"{i} MadeUp Way";
                    job1.ClientId = 2;
                    ctx.Jobs.Add(job1);
                    if (i % 1000 == 0)
                    {
                        int y = ctx.SaveChanges();
                        System.Console.WriteLine($"{i} - Created");
                    }
                }
                int x = ctx.SaveChanges();
            }
        }

        private static void ChangeTracker_StateChanged(object sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityStateChangedEventArgs e)
        {
            System.Console.WriteLine($"StateChanged - {e.Entry.Entity.GetType().Name}");
        }

        private static void ChangeTracker_Tracked(object sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityTrackedEventArgs e)
        {
            System.Console.WriteLine($"Tracked - {e.Entry.Entity.GetType().Name}");
        }
    }
}
