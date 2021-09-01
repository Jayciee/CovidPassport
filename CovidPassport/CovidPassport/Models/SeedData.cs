using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CovidPassport.Pages.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PassportTrackerContext(
                serviceProvider.GetRequiredService<DbContextOptions<PassportTrackerContext>>()))
            {
                
            }
        }
    }
}
