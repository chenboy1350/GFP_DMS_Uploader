using DMSUpload_Helper.Service.Implement;
using DMSUpload_Helper.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;

namespace DMSUpload_Helper
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;
            //ServiceProvider.GetRequiredService<FrmMain>();
            ServiceProvider.GetRequiredService<FrmLogin>();

            Application.Run(new FrmLogin());
        }

        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddTransient<DMS_IAddGovUnit, DMS_AddGovUnit>();
                    //services.AddTransient<FrmMain>();
                    services.AddTransient<FrmLogin>();
                });
        }
    }
}
