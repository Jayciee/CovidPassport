using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CovidPassport.Pages.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PassportTrackerContext(
                serviceProvider.GetRequiredService<DbContextOptions<PassportTrackerContext>>()))
            {
                if (context.Addresses.Any())
                {
                    return;
                }
                #region Address SeedData
                context.Addresses.AddRange(
                    new Address
                    {
                        AddressId = 1,
                        HouseNumber = "55",
                        StreetName = " Gordon Medical Centre, Eastside Lane",
                        City = "Birkenhead",
                        Postcode = "PO19 6YQ"
                    },
                    new Address
                    {
                        AddressId = 2,
                        HouseNumber = "1",
                        StreetName = "Orchard Croft Medical Centre, Cluntergate Street",
                        City = "Horbury",
                        Postcode = "WF4 5BY"
                    },
                    new Address
                    {
                        AddressId = 3,
                        HouseNumber = "823",
                        StreetName = "Chimera Close",
                        City = "Woodsville",
                        Postcode = "GU21 3QQ"
                    },
                    new Address
                    {
                        AddressId = 4,
                        HouseNumber = "73",
                        StreetName = "Dinkle Drive",
                        City = "Woodsville",
                        Postcode = "GU25 4HL"
                    },

                    new Address
                    {
                        AddressId = 5,
                        HouseNumber = "11",
                        StreetName = "Copperas House Terrace",
                        City = "Todmorden",
                        Postcode = "OL14 7PU"
                    }
                    );
                #endregion
                #region Person SeedData
                context.People.AddRange(
                    new Person
                    {

                    }

                    )
                #endregion
                context.SaveChanges();

            }
        }
    }
}
