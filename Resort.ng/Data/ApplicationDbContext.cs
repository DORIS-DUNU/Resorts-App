using Microsoft.EntityFrameworkCore;
using Resort.ng.Model;

namespace Resort.ng.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Resorts> Resorts_Db { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resorts>().HasData(

                    new Resorts
                    {
                        Id = 1,
                        Name = "Royal Villa",
                        Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                        ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg",
                        Occupancy = 4,
                        CreatedDate = DateTime.Now,
                        Rate = 200,
                        Sqft = 550,
                        Amenity = ""
                    },
                  new Resorts
                  {
                      Id = 2,
                      Name = "Premium Pool Villa",
                      Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                      ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg",
                      Occupancy = 4,
                      CreatedDate = DateTime.Now,
                      Rate = 300,
                      Sqft = 550,
                      Amenity = ""
                  },
               new Resorts
               {
                   Id = 3,
                   Name = "Luxury Pool Villa",
                   Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                   ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg",
                   Occupancy = 4,
                   CreatedDate = DateTime.Now,
                   Rate = 400,
                   Sqft = 750,
                   Amenity = ""
               },
                new Resorts
                {
                    Id = 4,
                    Name = "Diamond Villa",
                    Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg",
                    Occupancy = 4,
                    CreatedDate = DateTime.Now,
                    Rate = 550,
                    Sqft = 900,
                    Amenity = ""
                },
                    new Resorts
                    {

                        Id = 5,
                        Name = "Diamond Pool Villa",
                        Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                        ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg",
                        Occupancy = 4,
                        Rate = 600,
                        Sqft = 1100,
                        Amenity = ""
                    }
                    );

        }
    }
}
