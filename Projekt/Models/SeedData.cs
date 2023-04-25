using Microsoft.EntityFrameworkCore;
using Projekt.Context;
using Projekt.Models.Films;
using Projekt.Models.Rents;
using Projekt.Models.Users;

namespace Projekt.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FilmContext(serviceProvider.GetRequiredService<DbContextOptions<FilmContext>>()))
            {
                if (context.Films.Any())
                {
                    return;
                }
                context.Films.AddRange(
                    new FilmsModel()
                    {
                        Id = 1,
                        Title = "AVATAR: ISTOTA WODY",
                        Desc = "Pandorę znów napada wroga korporacja w poszukiwaniu cennych minerałów. Jack i Neytiri wraz z rodziną zmuszeni są opuścić wioskę i szukać pomocy u innych plemion zamieszkujących planetę.",
                        Director = "James Cameron",
                        YearOfProduction = 2022
                    },
                    new FilmsModel()
                    {
                        Id = 2,
                        Title = "KOT W BUTACH: OSTATNIE ŻYCZENIE",
                        Desc = "Kot w Butach wyrusza w podróż, aby odnaleźć mityczne \"ostatnie życzenie\", dzięki któremu odzyska swoje dziewięć żyć.",
                        Director = "Joel Crawford",
                        YearOfProduction = 2022
                    },
                    new FilmsModel()
                    {
                        Id = 3,
                        Title = "ZIELONA MILA",
                        Desc = "Emerytowany strażnik więzienny opowiada przyjaciółce o niezwykłym mężczyźnie, którego skazano na śmierć za zabójstwo dwóch 9-letnich dziewczynek.",
                        Director = "Frank Darabont",
                        YearOfProduction = 1999
                    }
                );
                context.SaveChanges();
            }

            //Users

            using (var context = new FilmContext(serviceProvider.GetRequiredService<DbContextOptions<FilmContext>>()))
            {
                if (context.Users.Any())
                {
                    return;
                }
                context.Users.AddRange(
                    new UserModel()
                    {
                        Id = 1,
                        FirstName = "Piotr",
                        LastName = "Kolat",
                        Email = "pkol@gmail.com"
                    }
                );
                context.SaveChanges();
            }

            //Rents

            using (var context = new FilmContext(serviceProvider.GetRequiredService<DbContextOptions<FilmContext>>()))
            {
                if (context.Rents.Any())
                {
                    return;
                }
                context.Rents.AddRange(
                new RentsModel()
                {
                    Id = 1,
                    FilmId = 1,
                    UserId = 1,
                    RentalDate = new DateTime(2022, 12, 1),
                    ReturnDate = new DateTime(2022, 12, 8),
                    IsReturned = true
                },
                new RentsModel()
                {
                    Id = 2,
                    FilmId = 2,
                    UserId = 1,
                    RentalDate = new DateTime(2022, 12, 15),
                    ReturnDate = new DateTime(2022, 12, 22),
                    IsReturned = true
                },
                new RentsModel()
                {
                    Id = 3,
                    FilmId = 3,
                    UserId = 1,
                    RentalDate = new DateTime(2022, 12, 29),
                    ReturnDate = new DateTime(2023, 1, 5),
                    IsReturned = false
                }
                );
                context.SaveChanges();
            }
        }
    }
}
