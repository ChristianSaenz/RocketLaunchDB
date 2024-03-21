using Microsoft.EntityFrameworkCore;
using Rocket_Launch_Database__2_.Models;


namespace Rocket_Launch_Database__2_.Data
{
    public class RocketLaunchDbContext : DbContext
    {
        internal readonly object LaunchSites;

        public RocketLaunchDbContext(DbContextOptions<RocketLaunchDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<User> User { get; set; }
        public DbSet<LaunchSite> LaunchSite { get; set; }
        public DbSet<LaunchVehicle> LaunchVehicle { get; set; }
        public DbSet<Payload> Payload { get; set; }
        public DbSet<RocketLaunch> RocketLaunches { get; set; }
        
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User { Id = 1, Name = "Alice", Email = "alice@example.com" },
                    new User { Id = 2, Name = "Bob", Email = "bob@example.com" },
                    new User { Id = 3, Name = "Charlie", Email = "charlie@example.com" },
                    new User { Id = 4, Name = "David", Email = "david@example.com" },
                    new User { Id = 5, Name = "Eve", Email = "eve@example.com" },
                    new User { Id = 6, Name = "Frank", Email = "frank@example.com" },
                    new User { Id = 7, Name = "Grace", Email = "grace@example.com" },
                    new User { Id = 8, Name = "Hannah", Email = "hannah@example.com" },
                    new User { Id = 9, Name = "Ivan", Email = "ivan@example.com" },
                    new User { Id = 10, Name = "Judy", Email = "judy@example.com" },
                    new User { Id = 11, Name = "Kevin", Email = "kevin@example.com" },
                    new User { Id = 12, Name = "Laura", Email = "laura@example.com" },
                    new User { Id = 13, Name = "Mike", Email = "mike@example.com" },
                    new User { Id = 14, Name = "Nina", Email = "nina@example.com" },
                    new User { Id = 15, Name = "Oscar", Email = "oscar@example.com" },
                    new User { Id = 16, Name = "Pam", Email = "pam@example.com" },
                    new User { Id = 17, Name = "Quinn", Email = "quinn@example.com" },
                    new User { Id = 18, Name = "Rob", Email = "rob@example.com" },
                    new User { Id = 19, Name = "Sara", Email = "sara@example.com" },
                    new User { Id = 20, Name = "Tom", Email = "tom@example.com" }
            );

            modelBuilder.Entity<LaunchSite>().HasData(
                new LaunchSite { Id = 1, Name = "Site A", Location = "USA" },
                new LaunchSite { Id = 2, Name = "Site B", Location = "Russia" },
                new LaunchSite { Id = 3, Name = "Cape Canaveral", Location = "USA" },
                new LaunchSite { Id = 4, Name = "Vandenberg", Location = "USA" },
                new LaunchSite { Id = 5, Name = "Plesetsk", Location = "Russia" },
                new LaunchSite { Id = 6, Name = "Baikonur", Location = "Kazakhstan" },
                new LaunchSite { Id = 7, Name = "Guiana Space Centre", Location = "French Guiana" },
                new LaunchSite { Id = 8, Name = "Tanegashima", Location = "Japan" },
                new LaunchSite { Id = 9, Name = "Satish Dhawan", Location = "India" },
                new LaunchSite { Id = 10, Name = "Jiuquan", Location = "China" },
                new LaunchSite { Id = 11, Name = "Taiyuan", Location = "China" },
                new LaunchSite { Id = 12, Name = "Wallops Flight Facility", Location = "USA" },
                new LaunchSite { Id = 13, Name = "Omelek Island", Location = "Marshall Islands" },
                new LaunchSite { Id = 14, Name = "Kodiak Launch Complex", Location = "USA" },
                new LaunchSite { Id = 15, Name = "Mid-Atlantic Regional Spaceport", Location = "USA" },
                new LaunchSite { Id = 16, Name = "Naro Space Center", Location = "South Korea" },
                new LaunchSite { Id = 17, Name = "Palmachim Airbase", Location = "Israel" },
                new LaunchSite { Id = 18, Name = "Sohae Satellite Launching Station", Location = "North Korea" },
                new LaunchSite { Id = 19, Name = "Vostochny Cosmodrome", Location = "Russia" },
                new LaunchSite { Id = 20, Name = "Wenchang Satellite Launch Center", Location = "China" }
            );

            modelBuilder.Entity<LaunchVehicle>().HasData(
                new LaunchVehicle { Id = 1, Name = "Falcon 9", Manufacturer = "SpaceX" },
                new LaunchVehicle { Id = 2, Name = "Soyuz", Manufacturer = "Roscosmos" },
                new LaunchVehicle { Id = 3, Name = "Atlas V", Manufacturer = "ULA" },
                new LaunchVehicle { Id = 4, Name = "Delta IV", Manufacturer = "ULA" },
                new LaunchVehicle { Id = 5, Name = "Ariane 5", Manufacturer = "Arianespace" },
                new LaunchVehicle { Id = 6, Name = "Vega", Manufacturer = "Arianespace" },
                new LaunchVehicle { Id = 7, Name = "H-IIA", Manufacturer = "Mitsubishi Heavy Industries" },
                new LaunchVehicle { Id = 8, Name = "H-IIB", Manufacturer = "Mitsubishi Heavy Industries" },
                new LaunchVehicle { Id = 9, Name = "Antares", Manufacturer = "Northrop Grumman" },
                new LaunchVehicle { Id = 10, Name = "Falcon Heavy", Manufacturer = "SpaceX" },
                new LaunchVehicle { Id = 11, Name = "Electron", Manufacturer = "Rocket Lab" },
                new LaunchVehicle { Id = 12, Name = "Pegasus", Manufacturer = "Northrop Grumman" },
                new LaunchVehicle { Id = 13, Name = "Minotaur", Manufacturer = "Northrop Grumman" },
                new LaunchVehicle { Id = 14, Name = "Proton", Manufacturer = "Khrunichev" },
                new LaunchVehicle { Id = 15, Name = "Long March 2D", Manufacturer = "CASC" },
                new LaunchVehicle { Id = 16, Name = "Long March 3B", Manufacturer = "CASC" },
                new LaunchVehicle { Id = 17, Name = "Long March 5", Manufacturer = "CASC" },
                new LaunchVehicle { Id = 18, Name = "Long March 7", Manufacturer = "CASC" },
                new LaunchVehicle { Id = 19, Name = "New Shepard", Manufacturer = "Blue Origin" },
                new LaunchVehicle { Id = 20, Name = "Starship", Manufacturer = "SpaceX" }
            );

            modelBuilder.Entity<Payload>().HasData(
                new Payload { Id = 1, Name = "Payload A", Weight = 1000, Type = "Satellite" },
                new Payload { Id = 2, Name = "Payload B", Weight = 2000, Type = "Spacecraft" },
                new Payload { Id = 3, Name = "Communication Satellite 1", Type = "Satellite", Weight = 2000 },
                new Payload { Id = 4, Name = "Communication Satellite 2", Type = "Satellite", Weight = 1800 },
                new Payload { Id = 5, Name = "Earth Observation Satellite 1", Type = "Satellite", Weight = 1200 },
                new Payload { Id = 6, Name = "Earth Observation Satellite 2", Type = "Satellite", Weight = 1500 },
                new Payload { Id = 7, Name = "Navigation Satellite 1", Type = "Satellite", Weight = 1400 },
                new Payload { Id = 8, Name = "Navigation Satellite 2", Type = "Satellite", Weight = 1600 },
                new Payload { Id = 9, Name = "Scientific Satellite 1", Type = "Satellite", Weight = 1300 },
                new Payload { Id = 10, Name = "Scientific Satellite 2", Type = "Satellite", Weight = 1100 },
                new Payload { Id = 11, Name = "Lunar Probe 1", Type = "Probe", Weight = 800 },
                new Payload { Id = 12, Name = "Lunar Probe 2", Type = "Probe", Weight = 850 },
                new Payload { Id = 13, Name = "Mars Rover 1", Type = "Rover", Weight = 900 },
                new Payload { Id = 14, Name = "Mars Rover 2", Type = "Rover", Weight = 950 },
                new Payload { Id = 15, Name = "Space Telescope 1", Type = "Telescope", Weight = 2000 },
                new Payload { Id = 16, Name = "Space Telescope 2", Type = "Telescope", Weight = 2100 },
                new Payload { Id = 17, Name = "Space Station Module 1", Type = "Module", Weight = 4200 },
                new Payload { Id = 18, Name = "Space Station Module 2", Type = "Module", Weight = 4300 },
                new Payload { Id = 19, Name = "Interplanetary Probe 1", Type = "Probe", Weight = 3000 },
                new Payload { Id = 20, Name = "Interplanetary Probe 2", Type = "Probe", Weight = 3200 }
);


            modelBuilder.Entity<RocketLaunch>().HasData(
    new RocketLaunch
    {
        Id = 1,
        LaunchDate = DateTime.Parse("2023-01-01"),
        LaunchVehicleId = 1,
        LaunchSiteId = 1,
        PayloadId = 1,
        UserId = 1,
        MissionOutcome = "Success"
    },
    new RocketLaunch
    {
        Id = 2,
        LaunchDate = DateTime.Parse("2023-02-01"),
        LaunchVehicleId = 2,
        LaunchSiteId = 2,
        PayloadId = 2,
        UserId = 2,
        MissionOutcome = "Failure"
    },
     new RocketLaunch
     {
         Id = 3,
         LaunchDate = DateTime.Parse("2023-03-01"),
         LaunchVehicleId = 3,
         LaunchSiteId = 3,
         PayloadId = 3,
         UserId = 3,
         MissionOutcome = "Success"
     },
    new RocketLaunch
    {
        Id = 4,
        LaunchDate = DateTime.Parse("2023-04-01"),
        LaunchVehicleId = 4,
        LaunchSiteId = 4,
        PayloadId = 4,
        UserId = 4,
        MissionOutcome = "Failure"
    },
    new RocketLaunch
    {
        Id = 5,
        LaunchDate = DateTime.Parse("2023-03-15"),
        LaunchVehicleId = 5,
        LaunchSiteId = 5,
        PayloadId = 5,
        UserId = 5,
        MissionOutcome = "Success"
    },
    new RocketLaunch
    {
    Id = 6,
    LaunchDate = DateTime.Parse("2023-03-20"),
    LaunchVehicleId = 6,
    LaunchSiteId = 6,
    PayloadId = 6,
    UserId = 6,
    MissionOutcome = "Failure"
    },
    new RocketLaunch
    {
    Id = 7,
    LaunchDate = DateTime.Parse("2023-04-05"),
    LaunchVehicleId = 7,
    LaunchSiteId = 7,
    PayloadId = 7,
    UserId = 7,
    MissionOutcome = "Success"
    },
    new RocketLaunch
    {
    Id = 8,
    LaunchDate = DateTime.Parse("2023-04-10"),
    LaunchVehicleId = 8,
    LaunchSiteId = 8,
    PayloadId = 8,
    UserId = 8,
    MissionOutcome = "Failure"
    },
    new RocketLaunch
    {
    Id = 10,
    LaunchDate = DateTime.Parse("2023-04-15"),
    LaunchVehicleId = 9,
    LaunchSiteId = 9,
    PayloadId = 9,
    UserId = 9,
    MissionOutcome = "Success"
    },
    new RocketLaunch
    {
    Id = 9,
    LaunchDate = DateTime.Parse("2023-04-20"),
    LaunchVehicleId = 10,
    LaunchSiteId = 10,
    PayloadId = 10,
    UserId = 10,
    MissionOutcome = "Failure"
    },
    new RocketLaunch
    {
    Id = 11,
    LaunchDate = DateTime.Parse("2023-04-25"),
    LaunchVehicleId = 11,
    LaunchSiteId = 11,
    PayloadId = 11,
    UserId = 11,
    MissionOutcome = "Success"
    },
    new RocketLaunch
    {
    Id = 12,
    LaunchDate = DateTime.Parse("2023-04-30"),
    LaunchVehicleId = 12,
    LaunchSiteId = 12,
    PayloadId = 12,
    UserId = 12,
    MissionOutcome = "Failure"
    },
    new RocketLaunch
    {
    Id = 13,
    LaunchDate = DateTime.Parse("2023-05-05"),
    LaunchVehicleId = 13,
    LaunchSiteId = 13,
    PayloadId = 13,
    UserId = 13,
    MissionOutcome = "Success"
    },
    new RocketLaunch
    {
    Id = 14,
    LaunchDate = DateTime.Parse("2023-05-10"),
    LaunchVehicleId = 14,
    LaunchSiteId = 14,
    PayloadId = 14,
    UserId = 14,
    MissionOutcome = "Failure"
    },
    new RocketLaunch
    {
    Id = 15,
    LaunchDate = DateTime.Parse("2023-05-15"),
    LaunchVehicleId = 15,
    LaunchSiteId = 15,
    PayloadId = 15,
    UserId = 15,
    MissionOutcome = "Success"
    },
    new RocketLaunch
    {
    Id = 16,
    LaunchDate = DateTime.Parse("2023-05-20"),
    LaunchVehicleId = 16,
    LaunchSiteId = 16,
    PayloadId = 16,
    UserId = 16,
    MissionOutcome = "Failure"
    },
    new RocketLaunch
    {
    Id = 17,
    LaunchDate = DateTime.Parse("2023-05-25"),
    LaunchVehicleId = 17,
    LaunchSiteId = 17,
    PayloadId = 17,
    UserId = 17,
    MissionOutcome = "Success"
    },
    new RocketLaunch
    {
    Id = 18,
    LaunchDate = DateTime.Parse("2023-05-30"),
    LaunchVehicleId = 18,
    LaunchSiteId = 18,
    PayloadId = 18,
    UserId = 18,
    MissionOutcome = "Failure"
    },
    new RocketLaunch
    {
    Id = 19,
    LaunchDate = DateTime.Parse("2023-06-05"),
    LaunchVehicleId = 19,
    LaunchSiteId = 19,
    PayloadId = 19,
    UserId = 19,
    MissionOutcome = "Success"
    },
    new RocketLaunch
    {
    Id = 20,
    LaunchDate = DateTime.Parse("2023-06-10"),
    LaunchVehicleId = 20,
    LaunchSiteId = 20,
    PayloadId = 20,
    UserId = 20,
    MissionOutcome = "Failure"
    }


    );
        }
    }
}
