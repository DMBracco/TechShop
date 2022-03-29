using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;

namespace TechShop.Data.Entities
{

    public static class SeedData {

        public static void EnsurePopulated(IApplicationBuilder app) {
            StoreDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }

            if (!context.TypeProducts.Any())
            {
                context.TypeProducts.AddRange(
                    new TypeProduct {
                        Name = "Строительная",
                        Sort = 1
                    },
                    new TypeProduct
                    {
                        Name = "Производственная",
                        Sort = 2
                    }, 
                    new TypeProduct
                    {
                        Name = "Военная",
                        Sort = 3
                    }
                );

                context.SaveChanges();
            }

            if (!context.Products.Any()) {
                context.Products.AddRange(
                    new Product {
                        Name = "MSI NVIDIA GeForce 210", 
                        DetailedDescription= "Видеочипсет NVIDIA GeForce 210; Частота графического процессора 460 МГц", 
                        Description = "Видеочипсет",
                        TypeProductId = 1, Price = 275
                    },
                    new Product {
                        Name = "ASUS NVIDIA GeForce RTX 3090",
                        DetailedDescription = "Видеочипсет NVIDIA GeForce RTX 3090; Частота графического процессора 1695 МГц (1725 МГц, в режиме Boost)",
                        Description = "Видеочипсет",
                        TypeProductId = 1, Price = 48
                    },
                    new Product {
                        Name = "AMD A6 9500E",
                        DetailedDescription = "Ядро Excavator; Гнездо процессора SocketAM4",
                        Description = "Видеочипсет",
                        TypeProductId = 2, Price = 19
                    },
                    new Product {
                        Name = "Intel Core i9 10980XE",
                        DetailedDescription = "Ядро Cascade Lake; Гнездо процессора LGA 2066",
                        Description = "Видеочипсет",
                        TypeProductId = 2, Price = 34
                    },
                    new Product {
                        Name = "Stadium",
                        DetailedDescription = "Flat-packed 35,000-seat stadium",
                        Description = "Видеочипсет",
                        TypeProductId = 2, Price = 79500
                    },
                    new Product {
                        Name = "GIGABYTE B450M S2H",
                        DetailedDescription = "Гнездо процессора SocketAM4 Чипсет AMD B450",
                        Description = "Видеочипсет",
                        TypeProductId = 3, Price = 16
                    },
                    new Product {
                        Name = "GIGABYTE Z690 GAMING X DDR4",
                        DetailedDescription = "Гнездо процессора LGA 1700 Чипсет Intel Z690",
                        Description = "Видеочипсет",
                        TypeProductId = 3, Price = 29
                    },
                    new Product {
                        Name = "ASUS TUF GAMING B550-PLUS",
                        DetailedDescription = "Гнездо процессора SocketAM4 Чипсет AMD B550",
                        Description = "Видеочипсет",
                        TypeProductId = 3, Price = 75
                    },
                    new Product {
                        Name = " GIGABYTE H410M S2H",
                        DetailedDescription = "Гнездо процессора LGA 1200 Чипсет Intel H510",
                        Description = "Видеочипсет",
                        TypeProductId = 3, Price = 1200
                    }
                );
                context.SaveChanges();
            }

            if (!context.Comments.Any())
            {
                context.Comments.AddRange(
                    new Comment
                    {
                        Text = "Привет мир",
                        DateOfCreat =new DateTime(2015, 7, 20),
                        ProductID = 1
                    },
                    new Comment
                    {
                        Text = "Привет мир2",
                        DateOfCreat = new DateTime(2016, 7, 20),
                        ProductID = 2
                    },
                    new Comment
                    {
                        Text = "Привет мир3",
                        DateOfCreat = new DateTime(2015, 7, 22),
                        ProductID = 3
                    }
                );
            }
        }
    }
}
