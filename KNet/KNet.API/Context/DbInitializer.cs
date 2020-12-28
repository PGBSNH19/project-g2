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

            var adverts = new AdvertModel[]
            {
                new AdvertModel{UserId = allUsers[0], CategoryId = allCategories[0], Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), IsActive = true, IsFlagged = false, Heading = "Lorem ipsum , consectetur adipiscing elit", Location = "", Price = 9999.99 },
                new AdvertModel{UserId = allUsers[1], CategoryId = allCategories[1], Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), IsActive = true, IsFlagged = false, Heading = "Lorem adipiscing elit", Location = "", Price = 9999.99 },
                new AdvertModel{UserId = allUsers[2], CategoryId = allCategories[2], Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), IsActive = true, IsFlagged = false, Heading = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Location = "", Price = 9999.99 },
                new AdvertModel{UserId = allUsers[3], CategoryId = allCategories[3], Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), IsActive = true, IsFlagged = false, Heading = "Lorem dolor sit amet, consectetur adipiscing elit", Location = "", Price = 9999.99 },
                new AdvertModel{UserId = allUsers[4], CategoryId = allCategories[4], Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), IsActive = true, IsFlagged = false, Heading = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Location = "", Price = 9999.99 },
                new AdvertModel{UserId = allUsers[5], CategoryId = allCategories[5], Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), IsActive = true, IsFlagged = false, Heading = "Lorem ipsum dolor sit amet", Location = "", Price = 9999.99 },
                new AdvertModel{UserId = allUsers[6], CategoryId = allCategories[6], Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), IsActive = true, IsFlagged = false, Heading = "Lorem ipsum consectetur adipiscing elit", Location = "", Price = 9999.99 },
                new AdvertModel{UserId = allUsers[7], CategoryId = allCategories[7], Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), IsActive = true, IsFlagged = false, Heading = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Location = "", Price = 9999.99 },
                new AdvertModel{UserId = allUsers[8], CategoryId = allCategories[8], Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), IsActive = false, IsFlagged = true, Heading = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Location = "", Price = 9999.99 },
            };

            foreach (var a in adverts)
            {
                context.Adverts.Add(a);
            }
            context.SaveChanges();
        }

        private void AddCategories(AppDbContext context)
        {
            var categories = new CategoryModel[]
            {
                new CategoryModel{Name="Music"},
                new CategoryModel{Name="Programming"},
                new CategoryModel{Name="Painting"},
                new CategoryModel{Name="Cooking"},
                new CategoryModel{Name="Roofing"},
                new CategoryModel{Name="Gardening"},
                new CategoryModel{Name="Fishing"},
                new CategoryModel{Name="Health & Lifestyle"},
                new CategoryModel{Name="Dancing"},
                new CategoryModel{Name="Homeopathy"},
                new CategoryModel{Name="Gambling & Gaming"}
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
                new User{FirstName = "Benjamin", LastName = "Ytterström", Email = "bytt@fakemail.se", Password = "Ostbollar123", PhoneNumber = 0123456789, IsActive = true},
                new User{FirstName = "Bosse", LastName = "Hassesson", Email = "bhan@fakemail.se", Password = "Kebabmosglass7", PhoneNumber = 0000000000, IsActive = true},
                new User{FirstName = "Alice", LastName = "Bengtsson", Email = "aben@fakemail.se", Password = "Greklandsresa8", PhoneNumber = 0000000001, IsActive = true},
                new User{FirstName = "Bob", LastName = "Oobama", Email = "boob@fakemail.se", Password = "ölkasdölkasdölkasd2", PhoneNumber = 0000000002, IsActive = true},
                new User{FirstName = "Stella", LastName = "Östman", Email = "sost@fakemail.se", Password = "ölkasdölkasdölkasd3", PhoneNumber = 0000000003, IsActive = true},
                new User{FirstName = "Vera", LastName = "Blåtera", Email = "vbla@fakemail.se", Password = "ölkasdölkasdölkasd4", PhoneNumber = 0000000004, IsActive = true},
                new User{FirstName = "Alma", LastName = "Persson", Email = "aper@fakemail.se", Password = "ölkasdölkasdölkasd5", PhoneNumber = 0000000005, IsActive = true},
                new User{FirstName = "William", LastName = "Shakespeare", Email = "wsha@testfake.com", Password = "ölkasdölkasdölkasd6", PhoneNumber = 0000000006, IsActive = true},
                new User{FirstName = "Hugo", LastName = "Trollsson", Email = "htro@bossesbilar.se", Password = "ölkasdölkasdölkasd7", PhoneNumber = 0000000007, IsActive = true},
                new User{FirstName = "Al", LastName = "Gren", Email = "algren@bilar.se", Password = "ölkasdölkasdölkasd8", PhoneNumber = 0000000008, IsActive = true},
                new User{FirstName = "Leo", LastName = "Axelsson", Email = "axel@bank.se", Password = "ölkasdölkasdölkasd9", PhoneNumber = 0000000009, IsActive = true},
                new User{FirstName = "Noah", LastName = "Hngh", Email = "Noah@modell.se", Password = "ölkasdölkasdölkasd10", PhoneNumber = 0000000010, IsActive = false}
            };

            foreach (var u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();
        }
    }
}
