using FoodWeb_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodWeb_API.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<MenuItem>().HasData(

                new MenuItem
                {
                    Id = 1,
                    Name = "Bánh Mì Thịt Nướng ",
                    Description = "Bánh Mì Thịt Nướng - Vietnamese Grilled Pork Sandwich:\r\nIndulge in the delightful flavors of Vietnam with our Bánh Mì Thịt Nướng. This sandwich features succulent grilled pork, fresh vegetables, and a burst of unique flavors that will transport your taste buds to the streets of Vietnam"
,
                    Image = "https://foodstoragepic.blob.core.windows.net/foodpic/banhmithitnuong.jpg",
                    Price = 2.99,
                    Category = "Bread Sandwich",
                    SpecialTag = ""
                }, new MenuItem
                {
                    Id = 2,
                    Name = "Bánh Xèo",
                    Description = "Bánh Xèo - Crispy Vietnamese Pancake:\r\nDiscover the crispy delight of Bánh Xèo, a Vietnamese pancake filled with a savory blend of pork, shrimp, and fragrant herbs. This iconic dish offers a taste of Vietnam's culinary charm, all in one crispy bite.",
                    Image = "https://foodstoragepic.blob.core.windows.net/foodpic/banhxeo.jpg",
                    Price = 4.99,
                    Category = "Pancakes",
                    SpecialTag = ""
                }, new MenuItem
                {
                    Id = 3,
                    Name = "Bún Chả",
                    Description = "Bún Chả - Grilled Pork Vermicelli:\r\nIndulge in the tantalizing flavors of Vietnam with our Bún Chả. This dish features succulent grilled pork served with fresh herbs, vermicelli noodles, and a side of dipping sauce. It's a delicious combination that captures the essence of Vietnamese cuisine in every bite.",
                    Image = "https://foodstoragepic.blob.core.windows.net/foodpic/buncha.jpg",
                    Price = 5.99,
                    Category = "Noodle",
                    SpecialTag = "Obama's Approval"
                }, new MenuItem
                {
                    Id = 4,
                    Name = "Bún Đậu Mắm Tôm",
                    Description = "Bún Đậu Mắm Tôm - Tofu and Shrimp Paste Vermicelli:\r\nExperience the rich and flavorful world of Vietnamese cuisine with our Bún Đậu Mắm Tôm. This dish combines crispy tofu, fresh herbs, vermicelli noodles, and a side of shrimp paste dipping sauce, delivering a delightful blend of textures and tastes that will transport you to the heart of Vietnam.",
                    Image = "https://foodstoragepic.blob.core.windows.net/foodpic/bundaumamtom.jpg",
                    Price = 5.99,
                    Category = "Noodle",
                    SpecialTag = ""
                }, new MenuItem
                {
                    Id = 5,
                    Name = "Bún Riêu",
                    Description = "Bún Riêu - Crab Noodle Soup:\r\nTreat your taste buds to the comforting flavors of Vietnam with our Bún Riêu. This heartwarming noodle soup features a rich, flavorful broth made from crab and tomatoes, served with fresh herbs, vermicelli noodles, and tender crab or shrimp meat. It's a soul-soothing dish that embodies the essence of Vietnamese cuisine.",
                    Image = "https://foodstoragepic.blob.core.windows.net/foodpic/bunrieu.jpg",
                    Price = 4.99,
                    Category = "Noodle",
                    SpecialTag = "Top Rated"
                }, new MenuItem
                {
                    Id = 6,
                    Name = "Chả Giò",
                    Description = "Chả Giò - Vietnamese Spring Rolls:\r\nSavor the crispy delight of Vietnamese cuisine with our Chả Giò, also known as Vietnamese spring rolls. These golden-fried rolls are filled with a delectable mixture of ground meat, vegetables, and aromatic spices, creating a mouthwatering appetizer that captures the essence of Vietnamese flavors in every bite.",
                    Image = "https://foodstoragepic.blob.core.windows.net/foodpic/chagio.jpg",
                    Price = 3.99,
                    Category = "Spring Rolls",
                    SpecialTag = ""
                }, new MenuItem
                {
                    Id = 7,
                    Name = "Cháo Lòng",
                    Description = "Cháo Lòng - Pork Organ Congee:\r\nWarm your soul with a bowl of Cháo Lòng, a Vietnamese pork organ congee. This comforting dish features a hearty blend of rice porridge, tender pork organs, and aromatic herbs, providing a satisfying and flavorful taste of Vietnamese comfort food.",
                    Image = "https://foodstoragepic.blob.core.windows.net/foodpic/chaolong.jpg",
                    Price = 4.99,
                    Category = "Rice Dish",
                    SpecialTag = "Chef's Special"
                }, new MenuItem
                {
                    Id = 8,
                    Name = "Cơm Tấm",
                    Description = "Cơm Tấm - Broken Rice with Grilled Pork:\r\nIndulge in the classic flavors of Vietnam with our Cơm Tấm, a delicious dish featuring fragrant broken rice served with perfectly grilled pork and a medley of fresh herbs. It's a Vietnamese favorite that offers a taste of culinary excellence.",
                    Image = "https://foodstoragepic.blob.core.windows.net/foodpic/comtam.jpg",
                    Price = 5.99,
                    Category = "Rice Dishes",
                    SpecialTag = "Chef's Special"
                }, new MenuItem
                {
                    Id = 9,
                    Name = "Gỏi Cuốn",
                    Description = "Gỏi Cuốn - Fresh Spring Rolls:\r\nExperience the refreshing taste of our Gỏi Cuốn, Vietnamese fresh spring rolls. These healthy, translucent rolls are filled with a delightful combination of shrimp, herbs, rice vermicelli, and served with a side of peanut dipping sauce.",
                    Image = "https://foodstoragepic.blob.core.windows.net/foodpic/goicuon.jpg",
                    Price = 4.99,
                    Category = "Spring Rolls",
                    SpecialTag = ""
                }, new MenuItem
                {
                    Id = 10,
                    Name = "Phở Bò",
                    Description = "Phở Bò - Beef Pho:\r\nSavor the iconic flavors of Vietnam with our Phở Bò, a hearty and aromatic beef noodle soup. It features tender slices of beef, rice noodles, and a savory broth infused with herbs and spices, offering a truly authentic Vietnamese experience.",
                    Image = "https://foodstoragepic.blob.core.windows.net/foodpic/phobo.jpg",
                    Price = 3.99,
                    Category = "Noodle",
                    SpecialTag = "Top Rated"
                });
        }


    }
}
