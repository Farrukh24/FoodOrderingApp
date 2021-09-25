using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineFoodOrderingSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FoodPlace> FoodPlaces { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FoodPlace>(entity =>
            {
                entity.HasData(
                    new FoodPlace
                    {
                        Id = 1,
                        Name = "KFC",
                        FoodNationality = "American",
                        SmallDescription = "Fast Food",
                        FoodPictureUrlPath = "https://i.pinimg.com/564x/84/9a/2d/849a2d6561194b8c9675371cac8bac4e.jpg",
                        BrandPictureUrlPath = "https://i.pinimg.com/564x/08/49/bc/0849bc1b9e2ac21acb66ceb9fff27bcd.jpg",
                        CategoryId = 1
                    },
                    new FoodPlace
                    {
                        Id = 2,
                        Name = "Max Way",
                        FoodNationality = "American",
                        SmallDescription = "Fast Food",
                        FoodPictureUrlPath = "https://www.afisha.uz/ui/materials/2020/04/0577662_b.jpeg",
                        BrandPictureUrlPath = "https://media-cdn.tripadvisor.com/media/photo-p/1c/bf/3b/28/caption.jpg",
                        CategoryId = 1
                    },
                    new FoodPlace
                    {
                        Id = 3,
                        Name = "Pasternak",
                        FoodNationality = "Italian",
                        SmallDescription = "Restaurant",
                        FoodPictureUrlPath = "https://media-cdn.tripadvisor.com/media/photo-s/1c/ec/43/86/caption.jpg",
                        BrandPictureUrlPath = "https://www.afisha.uz/ui/catalog/2018/01/0375347.jpeg",
                        CategoryId = 2
                    },
                    new FoodPlace
                    {
                        Id = 4,
                        Name = "Yapona Mama",
                        FoodNationality = "Japanese",
                        SmallDescription = "Restaurant",
                        FoodPictureUrlPath = "https://fastly.4sqi.net/img/general/200x200/18754087_77qAsyd3iMp8lH2W_Plb4gBwnNCIeslk9k3dmvM93co.jpg",
                        BrandPictureUrlPath = "https://resto.uz/data/resto/43/4280/yapona-mama-2922.jpg",
                        CategoryId = 2
                    }
                );
            }

            );

            builder.Entity<Product>(entity =>
            {
                entity.HasData(
                    new Product
                    {
                        Id = 1,
                        Name = "ChiefBurger",
                        Description = "Chiken, tomato, salads, souse",
                        Price = 7.99M,
                        FoodPlaceId = 1,
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Twister",
                        Description = "bitter chiken, cheese, souse, salad",
                        Price = 8.99M,
                        FoodPlaceId = 1,
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "LunchBox",
                        Description = "CheeseBurgur, Frees, Coca Cola, souse, stripes",
                        Price = 10.99M,
                        FoodPlaceId = 1,
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "FriendsBox",
                        Description = "5 stripes, feet of chiken, 10 rings, frees and more",
                        Price = 17.99M,
                        FoodPlaceId = 1,
                    },
                    new Product
                    {
                        Id = 5,
                        Name = "FirstCombo",
                        Description = "club sandvich chiken, frees, coca cola",
                        Price = 5.99M,
                        FoodPlaceId = 2,
                    },
                    new Product
                    {
                        Id = 6,
                        Name = "SecondCombo",
                        Description = "Lavash, frees, Coca cola",
                        Price = 6.19M,
                        FoodPlaceId = 2,
                    },
                    new Product
                    {
                        Id = 7,
                        Name = "ThirdCombo",
                        Description = "Shaurma, frees, coca cola",
                        Price = 6.09M,
                        FoodPlaceId = 2,
                    },
                    new Product
                    {
                        Id = 8,
                        Name = "FourthCombo",
                        Description = "burger, frees, coca cola",
                        Price = 6.09M,
                        FoodPlaceId = 2,
                    },
                    new Product
                    {
                        Id = 9,
                        Name = "Seytan Set",
                        Description = "Unagi light, fujiyama, akibuto, malibu, americano, losos",
                        Price = 35.99M,
                        FoodPlaceId = 4,
                    },
                    new Product
                    {
                        Id = 10,
                        Name = "Asian Chiken",
                        Description = "chiken, soup, salad, rice",
                        Price = 7.99M,
                        FoodPlaceId = 4,
                    },
                    new Product
                    {
                        Id = 11,
                        Name = "Fish and Chips",
                        Description = "potato, souse, fish",
                        Price = 7.29M,
                        FoodPlaceId = 4,
                    },
                    new Product
                    {
                        Id = 12,
                        Name = "Farel",
                        Description = "Just Eat..  Fish",
                        Price = 60.99M,
                        FoodPlaceId = 3,
                    },
                    new Product
                    {
                        Id = 13,
                        Name = "Welington",
                        Description = "meat, salads, decoration",
                        Price = 57.99M,
                        FoodPlaceId = 3,
                    },
                    new Product
                    {
                        Id = 14,
                        Name = "GoodMan",
                        Description = "Pizza special one",
                        Price = 15.99M,
                        FoodPlaceId = 3,
                    }
                                    
                    );
                
            }
                      

            );

            builder.Entity<Category>(entity =>
            {
                entity.HasData(
                    new Category
                    {
                        Id = 1,
                        Name = "Fast Foods"
                    },
                    new Category
                    {
                         Id = 2,
                         Name = "Restaurants"
                    }
                    );
            }

            );
        }
    }
}


