using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodWeb_API.Migrations
{
    /// <inheritdoc />
    public partial class MenuTable_and_SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialTag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price", "SpecialTag" },
                values: new object[,]
                {
                    { 1, "Bread Sandwich", "Bánh Mì Thịt Nướng - Vietnamese Grilled Pork Sandwich:\r\nIndulge in the delightful flavors of Vietnam with our Bánh Mì Thịt Nướng. This sandwich features succulent grilled pork, fresh vegetables, and a burst of unique flavors that will transport your taste buds to the streets of Vietnam", "https://foodstoragepic.blob.core.windows.net/foodpic/banhmithitnuong.jpg", "Bánh Mì Thịt Nướng ", 2.9900000000000002, "" },
                    { 2, "Pancakes", "Bánh Xèo - Crispy Vietnamese Pancake:\r\nDiscover the crispy delight of Bánh Xèo, a Vietnamese pancake filled with a savory blend of pork, shrimp, and fragrant herbs. This iconic dish offers a taste of Vietnam's culinary charm, all in one crispy bite.", "https://foodstoragepic.blob.core.windows.net/foodpic/banhxeo.jpg", "Bánh Xèo", 4.9900000000000002, "" },
                    { 3, "Noodle", "Bún Chả - Grilled Pork Vermicelli:\r\nIndulge in the tantalizing flavors of Vietnam with our Bún Chả. This dish features succulent grilled pork served with fresh herbs, vermicelli noodles, and a side of dipping sauce. It's a delicious combination that captures the essence of Vietnamese cuisine in every bite.", "https://foodstoragepic.blob.core.windows.net/foodpic/buncha.jpg", "Bún Chả", 5.9900000000000002, "Obama's Approval" },
                    { 4, "Noodle", "Bún Đậu Mắm Tôm - Tofu and Shrimp Paste Vermicelli:\r\nExperience the rich and flavorful world of Vietnamese cuisine with our Bún Đậu Mắm Tôm. This dish combines crispy tofu, fresh herbs, vermicelli noodles, and a side of shrimp paste dipping sauce, delivering a delightful blend of textures and tastes that will transport you to the heart of Vietnam.", "https://foodstoragepic.blob.core.windows.net/foodpic/bundaumamtom.jpg", "Bún Đậu Mắm Tôm", 5.9900000000000002, "" },
                    { 5, "Noodle", "Bún Riêu - Crab Noodle Soup:\r\nTreat your taste buds to the comforting flavors of Vietnam with our Bún Riêu. This heartwarming noodle soup features a rich, flavorful broth made from crab and tomatoes, served with fresh herbs, vermicelli noodles, and tender crab or shrimp meat. It's a soul-soothing dish that embodies the essence of Vietnamese cuisine.", "https://foodstoragepic.blob.core.windows.net/foodpic/bunrieu.jpg", "Bún Riêu", 4.9900000000000002, "Top Rated" },
                    { 6, "Spring Rolls", "Chả Giò - Vietnamese Spring Rolls:\r\nSavor the crispy delight of Vietnamese cuisine with our Chả Giò, also known as Vietnamese spring rolls. These golden-fried rolls are filled with a delectable mixture of ground meat, vegetables, and aromatic spices, creating a mouthwatering appetizer that captures the essence of Vietnamese flavors in every bite.", "https://foodstoragepic.blob.core.windows.net/foodpic/chagio.jpg", "Chả Giò", 3.9900000000000002, "" },
                    { 7, "Rice Dish", "Cháo Lòng - Pork Organ Congee:\r\nWarm your soul with a bowl of Cháo Lòng, a Vietnamese pork organ congee. This comforting dish features a hearty blend of rice porridge, tender pork organs, and aromatic herbs, providing a satisfying and flavorful taste of Vietnamese comfort food.", "https://foodstoragepic.blob.core.windows.net/foodpic/chaolong.jpg", "Cháo Lòng", 4.9900000000000002, "Chef's Special" },
                    { 8, "Rice Dishes", "Cơm Tấm - Broken Rice with Grilled Pork:\r\nIndulge in the classic flavors of Vietnam with our Cơm Tấm, a delicious dish featuring fragrant broken rice served with perfectly grilled pork and a medley of fresh herbs. It's a Vietnamese favorite that offers a taste of culinary excellence.", "https://foodstoragepic.blob.core.windows.net/foodpic/comtam.jpg", "Cơm Tấm", 5.9900000000000002, "Chef's Special" },
                    { 9, "Spring Rolls", "Gỏi Cuốn - Fresh Spring Rolls:\r\nExperience the refreshing taste of our Gỏi Cuốn, Vietnamese fresh spring rolls. These healthy, translucent rolls are filled with a delightful combination of shrimp, herbs, rice vermicelli, and served with a side of peanut dipping sauce.", "https://foodstoragepic.blob.core.windows.net/foodpic/goicuon.jpg", "Gỏi Cuốn", 4.9900000000000002, "" },
                    { 10, "Noodle", "Phở Bò - Beef Pho:\r\nSavor the iconic flavors of Vietnam with our Phở Bò, a hearty and aromatic beef noodle soup. It features tender slices of beef, rice noodles, and a savory broth infused with herbs and spices, offering a truly authentic Vietnamese experience.", "https://foodstoragepic.blob.core.windows.net/foodpic/phobo.jpg", "Phở Bò", 3.9900000000000002, "Top Rated" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");
        }
    }
}
