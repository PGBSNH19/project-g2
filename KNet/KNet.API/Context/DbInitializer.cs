using KNet.API.Models;
using System;
using System.Linq;

namespace KNet.API.Context
{
    public class DbInitializer
    {
        public void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

#if DEBUG
            // Adds data to the tables if they dont contain any data in debug mode.
            if (!context.Categories.Any())
            {
                AddCategories(context); 
            }
            else
            {
                // TODO - How do we handle existing data?
            }

            if (!context.Users.Any()) 
            { 
                AddUsers(context); 
            }
            else
            {
                // TODO - How do we handle existing data?
            }

            if (!context.Adverts.Any()) 
            { 
                AddAdverts(context); 
            }
            else
            {
                // TODO - How do we handle existing data?
            }
#endif
        }

        private void AddAdverts(AppDbContext context)
        {
            var allUsers = context.Users
                .Select(x => x.Id)
                .ToList();
            var allCategories = context.Categories
                .Select(x => x.Id)
                .ToList();

            var adverts = new Advert[]
            {
                new Advert{UserId = allUsers[0], CategoryId = allCategories[0], Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), IsActive = true, IsDeleted = false, Heading = "Lorem ipsum , consectetur adipiscing elit", Location = "", Price = 9999.99 },
                new Advert{UserId = allUsers[1], CategoryId = allCategories[1], Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), IsActive = true, IsDeleted = false, Heading = "Lorem adipiscing elit", Location = "", Price = 9999.99 },
                new Advert{UserId = allUsers[2], CategoryId = allCategories[2], Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), IsActive = true, IsDeleted = false, Heading = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Location = "", Price = 9999.99 },
                new Advert{UserId = allUsers[3], CategoryId = allCategories[3], Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), IsActive = true, IsDeleted = false, Heading = "Lorem dolor sit amet, consectetur adipiscing elit", Location = "", Price = 9999.99 },
                new Advert{UserId = allUsers[4], CategoryId = allCategories[4], Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), IsActive = true, IsDeleted = false, Heading = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Location = "", Price = 9999.99 },
                new Advert{UserId = allUsers[5], CategoryId = allCategories[5], Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), IsActive = true, IsDeleted = false, Heading = "Lorem ipsum dolor sit amet", Location = "", Price = 9999.99 },
                new Advert{UserId = allUsers[6], CategoryId = allCategories[6], Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), IsActive = true, IsDeleted = false, Heading = "Lorem ipsum consectetur adipiscing elit", Location = "", Price = 9999.99 },
                new Advert{UserId = allUsers[7], CategoryId = allCategories[7], Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), IsActive = true, IsDeleted = false, Heading = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Location = "", Price = 9999.99 },
                new Advert{UserId = allUsers[8], CategoryId = allCategories[8], Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), IsActive = false, IsDeleted = true, Heading = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Location = "", Price = 9999.99 },
            };

            foreach (var a in adverts)
            {
                context.Adverts.Add(a);
            }
            context.SaveChanges();
        }

        private void AddCategories(AppDbContext context)
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
                context.Categories.Add(c);
            }
            context.SaveChanges();
        }

        private void AddUsers(AppDbContext context)
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
                context.Users.Add(u);
            }
            context.SaveChanges();
        }
    }
}
