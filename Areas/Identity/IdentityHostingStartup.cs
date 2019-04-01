using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ticketApp.Areas.Identity.Data;
using ticketApp.Models;

[assembly: HostingStartup(typeof(ticketApp.Areas.Identity.IdentityHostingStartup))]
namespace ticketApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ticketAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ticketAppContextConnection")));

                services.AddDefaultIdentity<ticketAppUser>()
                    .AddEntityFrameworkStores<ticketAppContext>();
            });
        }
    }
}