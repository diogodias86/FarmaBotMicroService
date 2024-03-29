﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace FarmaBotMicroService.PedidoService.Service.WebJob
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new HostBuilder();

            builder.ConfigureAppConfiguration(c =>
            {
                c.AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
                c.AddEnvironmentVariables();
            });

            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddAzureStorage(a =>
                {
                    a.BatchSize = 8;
                    a.NewBatchThreshold = 4;
                    a.MaxDequeueCount = 4;
                    a.MaxPollingInterval = TimeSpan.FromSeconds(15);
                });
            });

            builder.ConfigureLogging((context, b) =>
            {
                b.AddConsole();
            });

            var host = builder.Build();
            using (host)
            {
                host.Run();
            }
        }
    }
}
