using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcChair.Data;
using System;
using System.Linq;

namespace MvcChair.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcChairContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcChairContext>>()))
            {
                // Check if data already exists
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
                    },
                    new Chair
                    {
                        Brand = "Urban Ladder",
                        Type = "Dining",
                        Color = "Brown",
                        Material = "Wood",
                        Capacity = 100,
                        Price = 149.99M,
                        Rating = 4.0M
                    },
                    new Chair
                    {
                        Brand = "Wayfair",
                        Type = "Lounge",
                        Color = "White",
                        Material = "Velvet",
                        Capacity = 110,
                        Price = 299.99M,
                        Rating = 3.9M
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
