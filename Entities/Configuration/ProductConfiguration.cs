using Entities.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {       
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
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
                    },
                    new Product
                    {
                        Id = 15,
                        Name = "Osh",
                        Description = "Uzbek national food",
                        Price = 10.99M,
                        FoodPlaceId = 6,
                    },
                    new Product
                    {
                        Id = 16,
                        Name = "Cutlet Afsona",
                        Description = "Special meat Cutlets",
                        Price = 19.99M,
                        FoodPlaceId = 6,
                    },
                    new Product
                    {
                        Id = 17,
                        Name = "Lavash",
                        Description = "Lavash special one",
                        Price = 7.99M,
                        FoodPlaceId = 5,
                    },
                    new Product
                    {
                        Id = 18,
                        Name = "CheezeBurger",
                        Description = "Burger with cheeze",
                        Price = 8.19M,
                        FoodPlaceId = 5,
                    },
                    new Product
                    {
                        Id = 19,
                        Name = "Shaurma",
                        Description = "Meat, fries, souses in the bread",
                        Price = 7.59M,
                        FoodPlaceId = 5,
                    },
                    new Product
                    {
                        Id = 20,
                        Name = "Double Burger",
                        Description = "Two special burgers",
                        Price = 10.99M,
                        FoodPlaceId = 5,
                    }
                );
        }       
    }
}

