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
                        StreetName = "Eastside Lane",
                        City = "Birkenhead",
                        Postcode = "PO19 6YQ"
                    },
                    new Address
                    {
                        AddressId = 2,
                        HouseNumber = "1",
                        StreetName = "Cluntergate Street",
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
                    },
                    new Address
                    {
                        AddressId = 6,
                        HouseNumber = "97",
                        StreetName = "Dover Road",
                        City = "Westhoughton",
                        Postcode = "BL5 6GD"
                    }
                    );
                #endregion
                #region Person SeedData
                context.People.AddRange(
                    new Person
                    {
                        PersonId = 646913492,
                        AddressId = 3,
                        Surname = "Howell",
                        FirstName = "Tyler",
                        NoOfVaccines = "1",
                        Dob = Convert.ToDateTime("22/11/1996")
                    },
                    new Person
                    {
                        PersonId = 109223597,
                        AddressId = 3,
                        Surname = "Roger",
                        FirstName = "Tyler",
                        NoOfVaccines = "0",
                        Dob = Convert.ToDateTime("11/05/1989")
                    },
                    new Person
                    {
                        PersonId = 977472186,
                        AddressId = 4,
                        Surname = "Zara",
                        FirstName = "Barrett",
                        NoOfVaccines = "2",
                        Dob = Convert.ToDateTime("27/04/1966")
                    },
                    new Person
                    {
                        PersonId = 496814338,
                        AddressId = 5,
                        Surname = "Howell",
                        FirstName = "Tyler",
                        NoOfVaccines = "1",
                        Dob = Convert.ToDateTime("27/04/1966")
                    },
                    new Person
                    {
                        PersonId = 175126944,
                        AddressId = 6,
                        Surname = "Katherine",
                        FirstName = "Nelson",
                        NoOfVaccines = "2",
                        Dob = Convert.ToDateTime("30/07/1939")
                    }
                    );
                #endregion
                #region HealthCentre SeedData
                context.HealthCentres.AddRange(
                   new HealthCentre
                   {
                       HealthCentreId=1,
                       AddressId = 1,
                       Name = "Gordon Medical Centre"
                   },
                   new HealthCentre
                   {
                       HealthCentreId = 2,
                       AddressId = 2,
                       Name = "Orchard Croft Medical Centre"
                   }
                );
                #endregion
                #region Passport SeedData
                context.Passports.AddRange(
                   new Passport
                   {
                       PassportId = 977472186,
                       PersonId = 977472186,
                       HealthCentreId = 1
                   },
                   new Passport
                   {
                       PassportId = 175126944,
                       PersonId = 175126944,
                       HealthCentreId = 2
                   }
                );
                #endregion
                context.SaveChanges();

            }
        }
    }
}
