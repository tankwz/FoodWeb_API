﻿// <auto-generated />
using System;
using FoodWeb_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodWeb_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231031054504_cart")]
    partial class cart
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FoodWeb_API.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("FoodWeb_API.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("FoodWeb_API.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("SpecialTag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Bread Sandwich",
                            Description = "Bánh Mì Thịt Nướng - Vietnamese Grilled Pork Sandwich:\r\nIndulge in the delightful flavors of Vietnam with our Bánh Mì Thịt Nướng. This sandwich features succulent grilled pork, fresh vegetables, and a burst of unique flavors that will transport your taste buds to the streets of Vietnam",
                            Image = "https://foodstoragepic.blob.core.windows.net/foodpic/banhmithitnuong.jpg",
                            Name = "Bánh Mì Thịt Nướng ",
                            Price = 2.9900000000000002,
                            SpecialTag = ""
                        },
                        new
                        {
                            Id = 2,
                            Category = "Pancakes",
                            Description = "Bánh Xèo - Crispy Vietnamese Pancake:\r\nDiscover the crispy delight of Bánh Xèo, a Vietnamese pancake filled with a savory blend of pork, shrimp, and fragrant herbs. This iconic dish offers a taste of Vietnam's culinary charm, all in one crispy bite.",
                            Image = "https://foodstoragepic.blob.core.windows.net/foodpic/banhxeo.jpg",
                            Name = "Bánh Xèo",
                            Price = 4.9900000000000002,
                            SpecialTag = ""
                        },
                        new
                        {
                            Id = 3,
                            Category = "Noodle",
                            Description = "Bún Chả - Grilled Pork Vermicelli:\r\nIndulge in the tantalizing flavors of Vietnam with our Bún Chả. This dish features succulent grilled pork served with fresh herbs, vermicelli noodles, and a side of dipping sauce. It's a delicious combination that captures the essence of Vietnamese cuisine in every bite.",
                            Image = "https://foodstoragepic.blob.core.windows.net/foodpic/buncha.jpg",
                            Name = "Bún Chả",
                            Price = 5.9900000000000002,
                            SpecialTag = "Obama's Approval"
                        },
                        new
                        {
                            Id = 4,
                            Category = "Noodle",
                            Description = "Bún Đậu Mắm Tôm - Tofu and Shrimp Paste Vermicelli:\r\nExperience the rich and flavorful world of Vietnamese cuisine with our Bún Đậu Mắm Tôm. This dish combines crispy tofu, fresh herbs, vermicelli noodles, and a side of shrimp paste dipping sauce, delivering a delightful blend of textures and tastes that will transport you to the heart of Vietnam.",
                            Image = "https://foodstoragepic.blob.core.windows.net/foodpic/bundaumamtom.jpg",
                            Name = "Bún Đậu Mắm Tôm",
                            Price = 5.9900000000000002,
                            SpecialTag = ""
                        },
                        new
                        {
                            Id = 5,
                            Category = "Noodle",
                            Description = "Bún Riêu - Crab Noodle Soup:\r\nTreat your taste buds to the comforting flavors of Vietnam with our Bún Riêu. This heartwarming noodle soup features a rich, flavorful broth made from crab and tomatoes, served with fresh herbs, vermicelli noodles, and tender crab or shrimp meat. It's a soul-soothing dish that embodies the essence of Vietnamese cuisine.",
                            Image = "https://foodstoragepic.blob.core.windows.net/foodpic/bunrieu.jpg",
                            Name = "Bún Riêu",
                            Price = 4.9900000000000002,
                            SpecialTag = "Top Rated"
                        },
                        new
                        {
                            Id = 6,
                            Category = "Spring Rolls",
                            Description = "Chả Giò - Vietnamese Spring Rolls:\r\nSavor the crispy delight of Vietnamese cuisine with our Chả Giò, also known as Vietnamese spring rolls. These golden-fried rolls are filled with a delectable mixture of ground meat, vegetables, and aromatic spices, creating a mouthwatering appetizer that captures the essence of Vietnamese flavors in every bite.",
                            Image = "https://foodstoragepic.blob.core.windows.net/foodpic/chagio.jpg",
                            Name = "Chả Giò",
                            Price = 3.9900000000000002,
                            SpecialTag = ""
                        },
                        new
                        {
                            Id = 7,
                            Category = "Rice Dish",
                            Description = "Cháo Lòng - Pork Organ Congee:\r\nWarm your soul with a bowl of Cháo Lòng, a Vietnamese pork organ congee. This comforting dish features a hearty blend of rice porridge, tender pork organs, and aromatic herbs, providing a satisfying and flavorful taste of Vietnamese comfort food.",
                            Image = "https://foodstoragepic.blob.core.windows.net/foodpic/chaolong.jpg",
                            Name = "Cháo Lòng",
                            Price = 4.9900000000000002,
                            SpecialTag = "Chef's Special"
                        },
                        new
                        {
                            Id = 8,
                            Category = "Rice Dish",
                            Description = "Cơm Tấm - Broken Rice with Grilled Pork:\r\nIndulge in the classic flavors of Vietnam with our Cơm Tấm, a delicious dish featuring fragrant broken rice served with perfectly grilled pork and a medley of fresh herbs. It's a Vietnamese favorite that offers a taste of culinary excellence.",
                            Image = "https://foodstoragepic.blob.core.windows.net/foodpic/comtam.jpg",
                            Name = "Cơm Tấm",
                            Price = 5.9900000000000002,
                            SpecialTag = "Chef's Special"
                        },
                        new
                        {
                            Id = 9,
                            Category = "Spring Rolls",
                            Description = "Gỏi Cuốn - Fresh Spring Rolls:\r\nExperience the refreshing taste of our Gỏi Cuốn, Vietnamese fresh spring rolls. These healthy, translucent rolls are filled with a delightful combination of shrimp, herbs, rice vermicelli, and served with a side of peanut dipping sauce.",
                            Image = "https://foodstoragepic.blob.core.windows.net/foodpic/goicuon.jpg",
                            Name = "Gỏi Cuốn",
                            Price = 4.9900000000000002,
                            SpecialTag = ""
                        },
                        new
                        {
                            Id = 10,
                            Category = "Noodle",
                            Description = "Phở Bò - Beef Pho:\r\nSavor the iconic flavors of Vietnam with our Phở Bò, a hearty and aromatic beef noodle soup. It features tender slices of beef, rice noodles, and a savory broth infused with herbs and spices, offering a truly authentic Vietnamese experience.",
                            Image = "https://foodstoragepic.blob.core.windows.net/foodpic/phobo.jpg",
                            Name = "Phở Bò",
                            Price = 3.9900000000000002,
                            SpecialTag = "Top Rated"
                        });
                });

            modelBuilder.Entity("FoodWeb_API.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("shoppingCarts");
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

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
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

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
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

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FoodWeb_API.Models.CartItem", b =>
                {
                    b.HasOne("FoodWeb_API.Models.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodWeb_API.Models.ShoppingCart", null)
                        .WithMany("CartItems")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");
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
                    b.HasOne("FoodWeb_API.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FoodWeb_API.Models.AppUser", null)
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

                    b.HasOne("FoodWeb_API.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FoodWeb_API.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodWeb_API.Models.ShoppingCart", b =>
                {
                    b.Navigation("CartItems");
                });
#pragma warning restore 612, 618
        }
    }
}
