using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pet_Shop.Models;
using System.Threading;
using static System.Net.WebRequestMethods;

namespace Pet_Shop.Data
{
    public class PetShopContext : IdentityDbContext<IdentityUser>
    {
        public PetShopContext(DbContextOptions<PetShopContext> options) : base(options)
        {
        }

        public virtual DbSet<Animal>? Animals { get; set; }
        public virtual DbSet<Category>? Categories { get; set; }
        public virtual DbSet<Comment>? Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Animal>().HasKey(animal => animal.AnimalId);
            modelBuilder.Entity<Category>().HasKey(Category => Category.CategoryId);
            modelBuilder.Entity<Comment>().HasKey(comment => comment.CommentId);
            modelBuilder.Entity<IdentityUser>().HasKey(user => user.Id);
            modelBuilder.Entity<IdentityRole>().HasKey(role => role.Id);
            var PathEnd = ".jpg";
            modelBuilder.Entity<Animal>().HasData(
                new { AnimalId = 1, Name = "American Pit Bull Terrier", Age = 2, PictureName = ("American Pit Bull Terrier" + PathEnd), Description = "The American Pit Bull Terrier has been known by many names, including the Pit Bull and the American Bull Terrier. It is often confused with the American Staffordshire Terrier, however, the United Kennel Club recognizes the American Pit Bull Terrier as its own distinct breed. Affectionately known as \"Pitties,\" the Pit Bull is known for being a loyal, protective, and athletic canine breed.", CategoryId = 1 },
                new { AnimalId = 2, Name = "Boxer", Age = 1, PictureName = ("Boxer" + PathEnd), Description = "The Boxer as it is known today was imported to the United States from Germany in the 1930s. They were used for bull-baiting and to chase wild game. This history means they are excellent runners and playful jumpers. The Boxer is used today by the police and military. Interestingly, in 2005, a Boxer’s DNA was used to sequence the canine genome.\r\n\r\nThe Boxer dog breed is deep-chested and is usually well-muscled under its smooth coat. They are considered a medium-sized dog breed—weighing in around 65-80 pounds with an average height of 21-23 inches.", CategoryId = 1 },
                new { AnimalId = 3, Name = "English Cocker Spaniel", Age = 3, PictureName = ("English Cocker Spaniel" + PathEnd), Description = "The English Cocker Spaniel is often described as “merry” because of his charming and happy personality. The dogs are popular across the world because of their hunting abilities and will work tirelessly to retrieve game birds. Their eager-to-please nature in the field is carried into the home as well, making them wonderful companions.", CategoryId = 1 },
                new { AnimalId = 4, Name = "Hokkaido", Age = 2, PictureName = ("Hokkaido" + PathEnd), Description = "First known as the Ainu, this dog breed was named after the people it lived with and later the area of Japan it was believed to have originated in. The Hokkaido is known as a great hunter as well as loveable and loyal pet.", CategoryId = 1 },
                new { AnimalId = 5, Name = "Pug", Age = 4, PictureName = ("Pug" + PathEnd), Description = "The Pug is an ancient dog breed that originated in China around 2,000 years ago. The Pug became a favorite of royals around the world, and today they are a very popular dog breed. They are easily identifiable due to their flat, wrinkly face, curly tail, and snorty, loud breathing.\r\n\r\nA Pug is typically 10 to 13 inches tall and weighs 14 to 18 pounds. They have short coats that are typically fawn (tan) or black.", CategoryId = 1 },

                new { AnimalId = 6, Name = "Balinese", Age = 1, PictureName = ("Balinese" + PathEnd), Description = "In the initial years of breeding, the Balinese had heavier bones and apple shaped heads, more akin to the former standard Siamese. They also had much longer coats than the Balinese breed today, with full ruffs and britches. Over the years, Balinese breeders have improved the physical form of the breed by outcrossing it with the parent breed, the Siamese, and the features of the Balinese have become leaner and longer, just as the modern Siamese has. The breed standard for the Balinese is identical to the standard for the Siamese in most respects, including overall body type and color, with the obvious differences being in overall coat length, and in the full plume tail. The coat is single coated, with only minimal shedding. In fact, the Balinese is noted for its lack of shedding amongst long coated cats.", CategoryId = 2 },
                new { AnimalId = 7, Name = "Russian Blue", Age = 3, PictureName = ("Russian Blue" + PathEnd), Description = "The Russian Blue is a robust breed, with firm muscles and an overall dose of good looks. It is physically in the same class as the Korat and Oriental Shorthair -- long, slender, elegant. It is of a medium size, and muscular, but compared to a swimmer in the compactness of its musculature. When it is in full motion and stretched out, one can see that it has a long, graceful neck, but the neck is hidden by thick fur and high set shoulder blades when the cat is sitting, making it look as though it has a short, thick neck.", CategoryId = 2 },
                new { AnimalId = 8, Name = "Siamese Cat", Age = 4, PictureName = ("Siamese Cat" + PathEnd), Description = "The Siamese cat breed has strikingly large ears and attractive baby blue eyes. Their sleek, slim figure is accentuated by their short, fine coat with long tapering lines. The coat comes in four traditional colors: seal, chocolate, blue, and lilac point -- a pale body color with relatively darker extremities; i.e., the face, ears, feet and tail.", CategoryId = 2 },
                new { AnimalId = 9, Name = "Bengal House Cat", Age = 1, PictureName = ( "Bengal House Cat" + PathEnd), Description = "The Bengal cat is a long, muscular, medium- to  large-sized  cat, with a broad head and muzzle, high cheekbones, and pronounced whisker pads. The eyes are round and wide, with dark markings around the eyes (mascara) and the ears small and rounded at the tips. The grace of a jungle cat is held as one of the positive characteristics, along with the ability to move quietly and with stealth. The back legs are slightly longer than the front legs, making the hind end a bit higher than the shoulders, and emphasizing the Bengal's wild-cat appearance. The Bengal's muscular, athletic build is one of its most defining features; it is never delicate.", CategoryId = 2 },
                new { AnimalId = 10, Name = "Colorpoint Shorthair", Age = 2, PictureName = ("Colorpoint Shorthair" + PathEnd), Description = "Colorpoint Shorthairs are the first-cousins of the Siamese, and are distinguished by their 16 different \"point\" colors beyond the four Siamese colors. Seldom quiet, they love entertaining and being entertained.", CategoryId = 2 },

                new { AnimalId = 11, Name = "Siamese fighting fish", Age = 1, PictureName = ("Siamese fighting fish" + PathEnd), Description = "Betta fish are native to Asia, where they live in the shallow water of marshes, ponds, or slow-moving streams. Male bettas are devoted fathers who build bubble nests for their young with their mouths and fiercely protect their babies from predators. Just like us, betta fish are diurnal. That means they’re active during the day and sleep at night, requiring darkness to get a good night’s rest.", CategoryId = 3 },
                new { AnimalId = 12, Name = "Goldfish", Age = 2, PictureName = ("Goldfish" + PathEnd), Description = "Goldfish have two sets of paired fins and three sets of single fins. They don’t have barbels, sensory organs some fish have that act like taste buds. Nor do they have scales on their heads. They also don’t have teeth and instead crush their food in their throats.\r\n\r\nThe fish are known for having large eyes and great senses of smell and hearing. Their ability to hear comes from small bones near their skull that link their swim bladder and their inner ear.", CategoryId = 3 },
                new { AnimalId = 13, Name = "Achilles Tang", Age = 1, PictureName = ("Achilles Tang" + PathEnd), Description = "The Achilles Tang, also known as the Red-tailed Surgeon, or Achilles Surgeonfish, is very dark brown to purple. It has bright highlights of white and orange around the dorsal, caudal, and anal fins. A white marking is also present on the gill covers and a striking orange teardrop is found near the caudal fin. The juveniles of this species have an orange marking by the tail in the shape of a streak instead of being teardrop in shape.\r\nA 180 gallon aquarium or larger is necessary to provide plenty of swimming room,and these fishes require strong water flow as they are normally found in surge zones. It is aggressive towards other Tangs and Surgeonfish, but peaceful with other fish.", CategoryId = 3 },
                new { AnimalId = 14, Name = "Red Platy", Age = 2, PictureName = ("Red Platy" + PathEnd), Description = "The red wagtail platy is a pleasant and peaceful freshwater fish that's both hardy and active. It's also small, pretty, and a great fish for hobbyists of any level; in fact, it's one of the most popular in the fishkeeping industry. You can find platies in several different colors which make for an eye-catching tank. The platy has two goals in life: eating and breeding. They will circle the tank eating anything, including algae, and their breeding can't be stopped. Like guppies, platies are livebearing fish.", CategoryId = 3 },
                new { AnimalId = 15, Name = "Glowlight Tetra Fish", Age = 1, PictureName = ("Glowlight Tetra Fish" + PathEnd), Description = "The glowlight tetra is absolutely gorgeous and surprisingly easy to care for. Originating in the rivers of Guyana, it is easygoing and peaceful and can survive in a fairly wide range of aquarium environments. Because they are schooling fish, you'll want to keep at least six glowlight tetras.", CategoryId = 3 }
                );

            modelBuilder.Entity<Category>().HasData(
                new { CategoryId = 1, Name = "Dogs" },
                new { CategoryId = 2, Name = "Cats" },
                new { CategoryId = 3, Name = "Fishes" }
                );

            modelBuilder.Entity<Comment>().HasData(
                new { CommentId = 1, AnimalId = 1 , Text = "Pitbulls are Awesome!" },
                new { CommentId = 2, AnimalId = 1, Text = "Pitbulls are relaible." },

                new { CommentId = 3, AnimalId = 2, Text = "I love boxers!" },
                new { CommentId = 4, AnimalId = 2, Text = "Amazing dog." },
                new { CommentId = 5, AnimalId = 2, Text = "Good with childrens." },

                new { CommentId = 6, AnimalId = 3, Text = "Easy to train." },

                new { CommentId = 7, AnimalId = 4, Text = "Very smart dog." },
                new { CommentId = 8, AnimalId = 4, Text = "Like to be active." },

                new { CommentId = 9, AnimalId = 5, Text = "Beatiful dog." },

                new { CommentId = 10, AnimalId = 6, Text = "Quiet and playful cat." },
                new { CommentId = 11, AnimalId = 6, Text = "They Are Extremely Smart Cats." },

                new { CommentId = 12, AnimalId = 7, Text = "The Russian Blue are lovely cats" },

                new { CommentId = 13, AnimalId = 8, Text = "They’re one of the oldest cat breeds" },
                new { CommentId = 14, AnimalId = 8, Text = "Their coloring comes from albinism" },
                new { CommentId = 15, AnimalId = 8, Text = "A Siamese cat lived in the White House" },
                new { CommentId = 16, AnimalId = 8, Text = "Siamese kittens are born all white" },

                new { CommentId = 17, AnimalId = 9, Text = "Bengal cats tend to be medium to large in size." },
                new { CommentId = 18, AnimalId = 9, Text = "They might weigh between 8-15 pounds or more and range in height anywhere from about 13-16 inches tall." },

                new { CommentId = 19, AnimalId = 10, Text = "They have amazing eyes!" },

                new { CommentId = 20, AnimalId = 11, Text = "Siamese fighting fish can live in tiny tanks, because they live in little creeks in the wild" },
                new { CommentId = 21, AnimalId = 11, Text = "Betta fish don't need a filter because in the wild they live in muddy water" },
                new { CommentId = 22, AnimalId = 11, Text = "Bettas can breathe air, unlike other fish" },

                new { CommentId = 23, AnimalId = 12, Text = "Goldfish have been known to live for over 40 years" },
                new { CommentId = 24, AnimalId = 12, Text = "Goldfish can recognize peoples faces" },
                new { CommentId = 25, AnimalId = 12, Text = "Goldfish have a memory-span of at least three months" },
                new { CommentId = 26, AnimalId = 12, Text = "Goldfish can grow to over a foot long" },

                new { CommentId = 27, AnimalId = 13, Text = "Very expensive fish but beautiful" },

                new { CommentId = 28, AnimalId = 14, Text = "Red platy live for 3-4 years" },

                new { CommentId = 29, AnimalId = 15, Text = "Glowlight tetras are very peaceful and easy-going." },
                new { CommentId = 30, AnimalId = 15, Text = "A single female can produce 50 or more eggs in one spawn. " }
                );

        }
    }
}
