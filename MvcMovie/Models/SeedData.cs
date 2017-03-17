using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "17 Miracles",
                         ReleaseDate = DateTime.Parse("2011-6-3"),
                         Genre = "Adventure",
                         Rating = "PG",
                         Price = 17.99M
                     },

                     new Movie
                     {
                         Title = "Ephraim's Rescue",
                         ReleaseDate = DateTime.Parse("2013-5-31"),
                         Genre = "Adventure",
                         Rating = "PG",
                         Price = 18.99M
                     },

                     new Movie
                     {
                         Title = "The Best Two Years",
                         ReleaseDate = DateTime.Parse("2004-2-20"),
                         Genre = "Comedy",
                         Rating = "PG",
                         Price = 9.99M
                     },

                   new Movie
                   {
                       Title = "The Saratov Approach",
                       ReleaseDate = DateTime.Parse("2013-10-9"),
                       Genre = "Drama",
                       Rating = "PG-13",
                       Price = 13.99M
                   }
                );
                context.SaveChanges();
            }
        }
    }
}