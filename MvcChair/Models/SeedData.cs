using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcChair.Data;
using MvcChair.Models;
using System;
using System.Linq;

namespace MvcChair.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcChairContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcChairContext>>()))
            {
                // Look for any movies.
                if (context.Chair.Any())
                {
                    return;   // DB has been seeded
                }
                context.Chair.AddRange(
                    new Chair
                    {
                        Brand = "IKEA",
                        Type = "Office",
                        Color = "Black",
                        Material = "Leather",
                        Capacity = 120,
                        Price = 199.99M,
                        Rating = 4.5M
                    },
                new Chair
                {
                    Brand = "Herman Miller",
                    Type = "Ergonomic",
                    Color = "Gray",
                    Material = "Mesh",
                    Capacity = 150,
                    Price = 899.99M,
                    Rating = 4.8M
                },
                new Chair
                {
                    Brand = "Steelcase",
                    Type = "Task",
                    Color = "Blue",
                    Material = "Fabric",
                    Capacity = 130,
                    Price = 499.99M,
                    Rating = 4.2M
                }
            // Add more chairs if you want
            );
                context.SaveChanges();
            }
        }
    }
}
