using KNet.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNet.API.Context
{
    public class DbInitializer
    {
        public object User { get; private set; }

        public void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any()
                && context.Category.Any()
                && context.Advert.Any())
            { return; }

            AddCategories(context);
            AddUsers(context);

            var allUsers = context.Users
                .Select(x => x.Id)
                .ToList();
            var allCategories = context.Category
                .Select(x => x.Id)
                .ToList();

            var adverts = new Advert[]
            {
                new Advert{UserId = allUsers[0], CategoryId = allCategories[0], Content = "", StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(2), IsActive = true, IsDeleted = false, Heading = "", Location = "", Price = 0 },
            };
        }

        private static void AddCategories(AppDbContext context)
        {
            var categories = new Category[]
            {
                new Category{Name="Music"},
                new Category{Name="Programming"},
                new Category{Name="Painting"},
                new Category{Name="Cooking"},
                new Category{Name="Roofing"},
                new Category{Name="Gardening"},
                new Category{Name="Fishing"},
                new Category{Name="Health & Lifestyle"},
                new Category{Name="Dancing"},
                new Category{Name="Homeopathy"},
                new Category{Name="Gambling & Gaming"}
            };

            foreach (var c in categories)
            {
                context.Add(c);
            }
            context.SaveChanges();
        }

        private static void AddUsers(AppDbContext context)
        {
            var users = new User[]
            {
                new User{FirstName = "Benjamin", LastName = "Ytterström", Email = "bytt@fakemail.se", Password = "Ostbollar123", PhoneNumber = 0123456789},
                new User{FirstName = "Bosse", LastName = "Hassesson", Email = "bhan@fakemail.se", Password = "", PhoneNumber = 0000000000},
                new User{FirstName = "Alice", LastName = "Bengtsson", Email = "aben@fakemail.se", Password = "ölkasdölkasdölkasd1", PhoneNumber = 0000000001},
                new User{FirstName = "Bob", LastName = "Oobama", Email = "boob@fakemail.se", Password = "ölkasdölkasdölkasd2", PhoneNumber = 0000000002},
                new User{FirstName = "Stella", LastName = "Östman", Email = "sost@fakemail.se", Password = "ölkasdölkasdölkasd3", PhoneNumber = 0000000003},
                new User{FirstName = "Vera", LastName = "Blåtera", Email = "vbla@fakemail.se", Password = "ölkasdölkasdölkasd4", PhoneNumber = 0000000004},
                new User{FirstName = "Alma", LastName = "Persson", Email = "aper@fakemail.se", Password = "ölkasdölkasdölkasd5", PhoneNumber = 0000000005},
                new User{FirstName = "William", LastName = "Shakespeare", Email = "wsha@testfake.com", Password = "ölkasdölkasdölkasd6", PhoneNumber = 0000000006},
                new User{FirstName = "Hugo", LastName = "Trollsson", Email = "htro@bossesbilar.se", Password = "ölkasdölkasdölkasd7", PhoneNumber = 0000000007},
                new User{FirstName = "Al", LastName = "Gren", Email = "algren@bilar.se", Password = "ölkasdölkasdölkasd8", PhoneNumber = 0000000008},
                new User{FirstName = "Leo", LastName = "Axelsson", Email = "axel@bank.se", Password = "ölkasdölkasdölkasd9", PhoneNumber = 0000000009},
                new User{FirstName = "Noah", LastName = "Hngh", Email = "Noah@modell.se", Password = "ölkasdölkasdölkasd10", PhoneNumber = 0000000010}
            };

            foreach (var u in users)
            {
                context.Add(u);
            }
            context.SaveChanges();
        }
    }
}
