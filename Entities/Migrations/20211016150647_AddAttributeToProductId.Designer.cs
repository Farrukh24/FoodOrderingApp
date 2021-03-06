// <auto-generated />
using System;
using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entities.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211016150647_AddAttributeToProductId")]
    partial class AddAttributeToProductId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Data.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Entities.Models.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fast Foods"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Restaurants"
                        });
                });

            modelBuilder.Entity("Entities.Models.Entities.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("Entities.Models.Entities.FoodPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandPictureUrlPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("FoodNationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodPictureUrlPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmallDescription")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("FoodPlaces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandPictureUrlPath = "https://i.pinimg.com/564x/08/49/bc/0849bc1b9e2ac21acb66ceb9fff27bcd.jpg",
                            CategoryId = 1,
                            FoodPictureUrlPath = "https://i.pinimg.com/564x/84/9a/2d/849a2d6561194b8c9675371cac8bac4e.jpg",
                            Name = "KFC",
                            SmallDescription = "Fast Food"
                        },
                        new
                        {
                            Id = 2,
                            BrandPictureUrlPath = "https://media-cdn.tripadvisor.com/media/photo-p/1c/bf/3b/28/caption.jpg",
                            CategoryId = 1,
                            FoodPictureUrlPath = "https://www.afisha.uz/ui/materials/2020/04/0577662_b.jpeg",
                            Name = "Max Way",
                            SmallDescription = "Fast Food"
                        },
                        new
                        {
                            Id = 3,
                            BrandPictureUrlPath = "https://www.afisha.uz/ui/catalog/2018/01/0375347.jpeg",
                            CategoryId = 2,
                            FoodPictureUrlPath = "https://media-cdn.tripadvisor.com/media/photo-s/1c/ec/43/86/caption.jpg",
                            Name = "Pasternak",
                            SmallDescription = "Restaurant"
                        },
                        new
                        {
                            Id = 4,
                            BrandPictureUrlPath = "https://resto.uz/data/resto/43/4280/yapona-mama-2922.jpg",
                            CategoryId = 2,
                            FoodPictureUrlPath = "https://fastly.4sqi.net/img/general/200x200/18754087_77qAsyd3iMp8lH2W_Plb4gBwnNCIeslk9k3dmvM93co.jpg",
                            Name = "Yapona Mama",
                            SmallDescription = "Restaurant"
                        },
                        new
                        {
                            Id = 5,
                            BrandPictureUrlPath = "https://dostavkainfo.uz/wp-content/uploads/2020/03/evos-768x768.png",
                            CategoryId = 1,
                            FoodPictureUrlPath = "https://scontent.ftas1-1.fna.fbcdn.net/v/t1.6435-9/p640x640/88307190_1962819137184306_5868838897475125248_n.jpg?_nc_cat=108&ccb=1-5&_nc_sid=e3f864&_nc_ohc=WT2jzXgB9pYAX9ACyTG&_nc_ht=scontent.ftas1-1.fna&oh=39380039897666d25950a2170c0e9009&oe=617A2176",
                            Name = "EVOS",
                            SmallDescription = "Fast Food"
                        },
                        new
                        {
                            Id = 6,
                            BrandPictureUrlPath = "https://scontent.ftas1-1.fna.fbcdn.net/v/t1.6435-9/93763812_2715252408600163_3272490291839369216_n.jpg?_nc_cat=106&ccb=1-5&_nc_sid=09cbfe&_nc_ohc=-WsWw5H8fdIAX8fDoQ3&tn=ozEfXBCfCcG1aK_R&_nc_ht=scontent.ftas1-1.fna&oh=6d74badca52df34d6d31d265a4f82d1f&oe=6178AA14",
                            CategoryId = 2,
                            FoodPictureUrlPath = "https://media-cdn.tripadvisor.com/media/photo-s/1c/e8/83/90/afsona.jpg",
                            Name = "Afsona",
                            SmallDescription = "Restaurant"
                        });
                });

            modelBuilder.Entity("Entities.Models.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeliverType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Entities.Models.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Entities.Models.Entities.OrderedItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderDetailId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderDetailId");

                    b.ToTable("OrderedItems");
                });

            modelBuilder.Entity("Entities.Models.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("FoodPlaceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FoodPlaceId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Chiken, tomato, salads, souse",
                            FoodPlaceId = 1,
                            Name = "ChiefBurger",
                            Price = 7.99m
                        },
                        new
                        {
                            Id = 2,
                            Description = "bitter chiken, cheese, souse, salad",
                            FoodPlaceId = 1,
                            Name = "Twister",
                            Price = 8.99m
                        },
                        new
                        {
                            Id = 3,
                            Description = "CheeseBurgur, Frees, Coca Cola, souse, stripes",
                            FoodPlaceId = 1,
                            Name = "LunchBox",
                            Price = 10.99m
                        },
                        new
                        {
                            Id = 4,
                            Description = "5 stripes, feet of chiken, 10 rings, frees and more",
                            FoodPlaceId = 1,
                            Name = "FriendsBox",
                            Price = 17.99m
                        },
                        new
                        {
                            Id = 5,
                            Description = "club sandvich chiken, frees, coca cola",
                            FoodPlaceId = 2,
                            Name = "FirstCombo",
                            Price = 5.99m
                        },
                        new
                        {
                            Id = 6,
                            Description = "Lavash, frees, Coca cola",
                            FoodPlaceId = 2,
                            Name = "SecondCombo",
                            Price = 6.19m
                        },
                        new
                        {
                            Id = 7,
                            Description = "Shaurma, frees, coca cola",
                            FoodPlaceId = 2,
                            Name = "ThirdCombo",
                            Price = 6.09m
                        },
                        new
                        {
                            Id = 8,
                            Description = "burger, frees, coca cola",
                            FoodPlaceId = 2,
                            Name = "FourthCombo",
                            Price = 6.09m
                        },
                        new
                        {
                            Id = 9,
                            Description = "Unagi light, fujiyama, akibuto, malibu, americano, losos",
                            FoodPlaceId = 4,
                            Name = "Seytan Set",
                            Price = 35.99m
                        },
                        new
                        {
                            Id = 10,
                            Description = "chiken, soup, salad, rice",
                            FoodPlaceId = 4,
                            Name = "Asian Chiken",
                            Price = 7.99m
                        },
                        new
                        {
                            Id = 11,
                            Description = "potato, souse, fish",
                            FoodPlaceId = 4,
                            Name = "Fish and Chips",
                            Price = 7.29m
                        },
                        new
                        {
                            Id = 12,
                            Description = "Just Eat..  Fish",
                            FoodPlaceId = 3,
                            Name = "Farel",
                            Price = 60.99m
                        },
                        new
                        {
                            Id = 13,
                            Description = "meat, salads, decoration",
                            FoodPlaceId = 3,
                            Name = "Welington",
                            Price = 57.99m
                        },
                        new
                        {
                            Id = 14,
                            Description = "Pizza special one",
                            FoodPlaceId = 3,
                            Name = "GoodMan",
                            Price = 15.99m
                        },
                        new
                        {
                            Id = 15,
                            Description = "Uzbek national food",
                            FoodPlaceId = 6,
                            Name = "Osh",
                            Price = 10.99m
                        },
                        new
                        {
                            Id = 16,
                            Description = "Special meat Cutlets",
                            FoodPlaceId = 6,
                            Name = "Cutlet Afsona",
                            Price = 19.99m
                        },
                        new
                        {
                            Id = 17,
                            Description = "Lavash special one",
                            FoodPlaceId = 5,
                            Name = "Lavash",
                            Price = 7.99m
                        },
                        new
                        {
                            Id = 18,
                            Description = "Burger with cheeze",
                            FoodPlaceId = 5,
                            Name = "CheezeBurger",
                            Price = 8.19m
                        },
                        new
                        {
                            Id = 19,
                            Description = "Meat, fries, souses in the bread",
                            FoodPlaceId = 5,
                            Name = "Shaurma",
                            Price = 7.59m
                        },
                        new
                        {
                            Id = 20,
                            Description = "Two special burgers",
                            FoodPlaceId = 5,
                            Name = "Double Burger",
                            Price = 10.99m
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("Entities.Models.Entities.Feedback", b =>
                {
                    b.HasOne("Entities.Models.Entities.Product", "Product")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.Models.Entities.FoodPlace", b =>
                {
                    b.HasOne("Entities.Models.Entities.Category", "Category")
                        .WithMany("Places")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Entities.Models.Entities.OrderDetail", b =>
                {
                    b.HasOne("Entities.Models.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Entities.Models.Entities.OrderedItems", b =>
                {
                    b.HasOne("Entities.Models.Entities.OrderDetail", "OrderDetail")
                        .WithMany("OrderedItems")
                        .HasForeignKey("OrderDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderDetail");
                });

            modelBuilder.Entity("Entities.Models.Entities.Product", b =>
                {
                    b.HasOne("Entities.Models.Entities.FoodPlace", "Place")
                        .WithMany("Products")
                        .HasForeignKey("FoodPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Entities.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Entities.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Entities.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Entities.Category", b =>
                {
                    b.Navigation("Places");
                });

            modelBuilder.Entity("Entities.Models.Entities.FoodPlace", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Models.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Entities.Models.Entities.OrderDetail", b =>
                {
                    b.Navigation("OrderedItems");
                });

            modelBuilder.Entity("Entities.Models.Entities.Product", b =>
                {
                    b.Navigation("Feedbacks");
                });
#pragma warning restore 612, 618
        }
    }
}
