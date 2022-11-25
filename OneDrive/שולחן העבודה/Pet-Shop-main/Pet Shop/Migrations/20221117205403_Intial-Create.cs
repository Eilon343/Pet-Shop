using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetShop.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PictureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animals_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Dogs" },
                    { 2, "Cats" },
                    { 3, "Fishes" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "CategoryId", "Description", "Name", "PictureName" },
                values: new object[,]
                {
                    { 1, 2, 1, "The American Pit Bull Terrier has been known by many names, including the Pit Bull and the American Bull Terrier. It is often confused with the American Staffordshire Terrier, however, the United Kennel Club recognizes the American Pit Bull Terrier as its own distinct breed. Affectionately known as \"Pitties,\" the Pit Bull is known for being a loyal, protective, and athletic canine breed.", "American Pit Bull Terrier", "American Pit Bull Terrier.jpg" },
                    { 2, 1, 1, "The Boxer as it is known today was imported to the United States from Germany in the 1930s. They were used for bull-baiting and to chase wild game. This history means they are excellent runners and playful jumpers. The Boxer is used today by the police and military. Interestingly, in 2005, a Boxer’s DNA was used to sequence the canine genome.\r\n\r\nThe Boxer dog breed is deep-chested and is usually well-muscled under its smooth coat. They are considered a medium-sized dog breed—weighing in around 65-80 pounds with an average height of 21-23 inches.", "Boxer", "Boxer.jpg" },
                    { 3, 3, 1, "The English Cocker Spaniel is often described as “merry” because of his charming and happy personality. The dogs are popular across the world because of their hunting abilities and will work tirelessly to retrieve game birds. Their eager-to-please nature in the field is carried into the home as well, making them wonderful companions.", "English Cocker Spaniel", "English Cocker Spaniel.jpg" },
                    { 4, 2, 1, "First known as the Ainu, this dog breed was named after the people it lived with and later the area of Japan it was believed to have originated in. The Hokkaido is known as a great hunter as well as loveable and loyal pet.", "Hokkaido", "Hokkaido.jpg" },
                    { 5, 4, 1, "The Pug is an ancient dog breed that originated in China around 2,000 years ago. The Pug became a favorite of royals around the world, and today they are a very popular dog breed. They are easily identifiable due to their flat, wrinkly face, curly tail, and snorty, loud breathing.\r\n\r\nA Pug is typically 10 to 13 inches tall and weighs 14 to 18 pounds. They have short coats that are typically fawn (tan) or black.", "Pug", "Pug.jpg" },
                    { 6, 1, 2, "In the initial years of breeding, the Balinese had heavier bones and apple shaped heads, more akin to the former standard Siamese. They also had much longer coats than the Balinese breed today, with full ruffs and britches. Over the years, Balinese breeders have improved the physical form of the breed by outcrossing it with the parent breed, the Siamese, and the features of the Balinese have become leaner and longer, just as the modern Siamese has. The breed standard for the Balinese is identical to the standard for the Siamese in most respects, including overall body type and color, with the obvious differences being in overall coat length, and in the full plume tail. The coat is single coated, with only minimal shedding. In fact, the Balinese is noted for its lack of shedding amongst long coated cats.", "Balinese", "Balinese.jpg" },
                    { 7, 3, 2, "The Russian Blue is a robust breed, with firm muscles and an overall dose of good looks. It is physically in the same class as the Korat and Oriental Shorthair -- long, slender, elegant. It is of a medium size, and muscular, but compared to a swimmer in the compactness of its musculature. When it is in full motion and stretched out, one can see that it has a long, graceful neck, but the neck is hidden by thick fur and high set shoulder blades when the cat is sitting, making it look as though it has a short, thick neck.", "Russian Blue", "Russian Blue.jpg" },
                    { 8, 4, 2, "The Siamese cat breed has strikingly large ears and attractive baby blue eyes. Their sleek, slim figure is accentuated by their short, fine coat with long tapering lines. The coat comes in four traditional colors: seal, chocolate, blue, and lilac point -- a pale body color with relatively darker extremities; i.e., the face, ears, feet and tail.", "Siamese Cat", "Siamese Cat.jpg" },
                    { 9, 1, 2, "The Bengal cat is a long, muscular, medium- to  large-sized  cat, with a broad head and muzzle, high cheekbones, and pronounced whisker pads. The eyes are round and wide, with dark markings around the eyes (mascara) and the ears small and rounded at the tips. The grace of a jungle cat is held as one of the positive characteristics, along with the ability to move quietly and with stealth. The back legs are slightly longer than the front legs, making the hind end a bit higher than the shoulders, and emphasizing the Bengal's wild-cat appearance. The Bengal's muscular, athletic build is one of its most defining features; it is never delicate.", "Bengal House Cat", "Bengal House Cat.jpg" },
                    { 10, 2, 2, "Colorpoint Shorthairs are the first-cousins of the Siamese, and are distinguished by their 16 different \"point\" colors beyond the four Siamese colors. Seldom quiet, they love entertaining and being entertained.", "Colorpoint Shorthair", "Colorpoint Shorthair.jpg" },
                    { 11, 1, 3, "Betta fish are native to Asia, where they live in the shallow water of marshes, ponds, or slow-moving streams. Male bettas are devoted fathers who build bubble nests for their young with their mouths and fiercely protect their babies from predators. Just like us, betta fish are diurnal. That means they’re active during the day and sleep at night, requiring darkness to get a good night’s rest.", "Siamese fighting fish", "Siamese fighting fish.jpg" },
                    { 12, 2, 3, "Goldfish have two sets of paired fins and three sets of single fins. They don’t have barbels, sensory organs some fish have that act like taste buds. Nor do they have scales on their heads. They also don’t have teeth and instead crush their food in their throats.\r\n\r\nThe fish are known for having large eyes and great senses of smell and hearing. Their ability to hear comes from small bones near their skull that link their swim bladder and their inner ear.", "Goldfish", "Goldfish.jpg" },
                    { 13, 1, 3, "The Achilles Tang, also known as the Red-tailed Surgeon, or Achilles Surgeonfish, is very dark brown to purple. It has bright highlights of white and orange around the dorsal, caudal, and anal fins. A white marking is also present on the gill covers and a striking orange teardrop is found near the caudal fin. The juveniles of this species have an orange marking by the tail in the shape of a streak instead of being teardrop in shape.\r\nA 180 gallon aquarium or larger is necessary to provide plenty of swimming room,and these fishes require strong water flow as they are normally found in surge zones. It is aggressive towards other Tangs and Surgeonfish, but peaceful with other fish.", "Achilles Tang", "Achilles Tang.jpg" },
                    { 14, 2, 3, "The red wagtail platy is a pleasant and peaceful freshwater fish that's both hardy and active. It's also small, pretty, and a great fish for hobbyists of any level; in fact, it's one of the most popular in the fishkeeping industry. You can find platies in several different colors which make for an eye-catching tank. The platy has two goals in life: eating and breeding. They will circle the tank eating anything, including algae, and their breeding can't be stopped. Like guppies, platies are livebearing fish.", "Red Platy", "Red Platy.jpg" },
                    { 15, 1, 3, "The glowlight tetra is absolutely gorgeous and surprisingly easy to care for. Originating in the rivers of Guyana, it is easygoing and peaceful and can survive in a fairly wide range of aquarium environments. Because they are schooling fish, you'll want to keep at least six glowlight tetras.", "Glowlight Tetra Fish", "Glowlight Tetra Fish.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "AnimalId", "Text" },
                values: new object[,]
                {
                    { 1, 1, "Pitbulls are Awesome!" },
                    { 2, 1, "Pitbulls are relaible." },
                    { 3, 2, "I love boxers!" },
                    { 4, 2, "Amazing dog." },
                    { 5, 2, "Good with childrens." },
                    { 6, 3, "Easy to train." },
                    { 7, 4, "Very smart dog." },
                    { 8, 4, "Like to be active." },
                    { 9, 5, "Beatiful dog." },
                    { 10, 6, "Quiet and playful cat." },
                    { 11, 6, "They Are Extremely Smart Cats." },
                    { 12, 7, "The Russian Blue are lovely cats" },
                    { 13, 8, "They’re one of the oldest cat breeds" },
                    { 14, 8, "Their coloring comes from albinism" },
                    { 15, 8, "A Siamese cat lived in the White House" },
                    { 16, 8, "Siamese kittens are born all white" },
                    { 17, 9, "Bengal cats tend to be medium to large in size." },
                    { 18, 9, "They might weigh between 8-15 pounds or more and range in height anywhere from about 13-16 inches tall." },
                    { 19, 10, "They have amazing eyes!" },
                    { 20, 11, "Siamese fighting fish can live in tiny tanks, because they live in little creeks in the wild" },
                    { 21, 11, "Betta fish don't need a filter because in the wild they live in muddy water" },
                    { 22, 11, "Bettas can breathe air, unlike other fish" },
                    { 23, 12, "Goldfish have been known to live for over 40 years" },
                    { 24, 12, "Goldfish can recognize peoples faces" },
                    { 25, 12, "Goldfish have a memory-span of at least three months" },
                    { 26, 12, "Goldfish can grow to over a foot long" },
                    { 27, 13, "Very expensive fish but beautiful" },
                    { 28, 14, "Red platy live for 3-4 years" },
                    { 29, 15, "Glowlight tetras are very peaceful and easy-going." },
                    { 30, 15, "A single female can produce 50 or more eggs in one spawn. " }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CategoryId",
                table: "Animals",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnimalId",
                table: "Comments",
                column: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
