using FormulaOne.Domain.Entities;
using FormulaOne.Presistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;

namespace FormulaOne.Presistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options)
        {
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users");
            builder.Entity<Person>().ToTable("Persons");
            builder.Entity<Team>().ToTable("Teams");
            builder.Entity<Driver>().ToTable("Drivers");

            //builder.Entity<Driver>().

            builder.Entity<User>().HasData(
                new User 
                {
                    UserName    = "User",
                    Password    = "1234567890",
                    Role        = Roles.User,
                    Created     = DateTime.UtcNow,
                    CreatedBy   = "SYSTEM"
                },
                new User
                {
                    UserName    = "Admin",
                    Password    = "1234567890",
                    Role        = Roles.Admin,
                    Created     = DateTime.UtcNow,
                    CreatedBy   = "SYSTEM"
                }
            );

            builder.Entity<Team>().HasData(
                new Team
                {
                    Id = Guid.NewGuid(),
                    FullTeamName = "Alfa Romeo F1 Team Stake",
                    Base = "Hinwil, Switzerland",
                    TeamChief = "Alessandro Alunni Bravi",
                    TechnicalChief = "James Key",
                    Chassis = "C43",
                    PowerUnit = "Ferrari",
                    FirstTeamEntry = 1993,
                    WorldChampionships = 0,
                    HighestRaceFinish = "1 (x1)",
                    PolePositions = 1,
                    FastestLaps = 7,
                    Created = DateTime.UtcNow,
                    CreatedBy = "SYSTEM"
                },
                new Team
                {
                    Id = Guid.NewGuid(),
                    FullTeamName = "Scuderia AlphaTauri",
                    Base = "Faenza, Italy",
                    TeamChief = "Franz Tost",
                    TechnicalChief = "Jody Egginton",
                    Chassis = "AT04",
                    PowerUnit = "Honda RBPT",
                    FirstTeamEntry = 1985,
                    WorldChampionships = 0,
                    HighestRaceFinish = "1 (x2)",
                    PolePositions = 1,
                    FastestLaps = 2,
                    Created = DateTime.UtcNow,
                    CreatedBy = "SYSTEM"
                },
                new Team
                {
                    Id = Guid.NewGuid(),
                    FullTeamName = "BWT Alpine F1 Team",
                    Base = "Enstone, United Kingdom",
                    TeamChief = "Bruno Famin",
                    TechnicalChief = "Matt Harman",
                    Chassis = "A523",
                    PowerUnit = "Renault",
                    FirstTeamEntry = 1986,
                    WorldChampionships = 2,
                    HighestRaceFinish = "1 (x21)",
                    PolePositions = 20,
                    FastestLaps = 15,
                    Created = DateTime.UtcNow,
                    CreatedBy = "SYSTEM"
                },
                new Team
                {
                    Id = Guid.NewGuid(),
                    FullTeamName = "MoneyGram Haas F1 Team",
                    Base = "Kannapolis, United States",
                    TeamChief = "Guenther Steiner",
                    TechnicalChief = "Simone Resta",
                    Chassis = "VF-23",
                    PowerUnit = "Ferrari",
                    FirstTeamEntry = 2016,
                    WorldChampionships = 0,
                    HighestRaceFinish = "4 (x1)",
                    PolePositions = 1,
                    FastestLaps = 2,
                    Created = DateTime.UtcNow,
                    CreatedBy = "SYSTEM"
                },
                new Team
                {
                    Id = Guid.NewGuid(),
                    FullTeamName = "Aston Martin Aramco Cognizant F1 Team",
                    Base = "Silverstone, United Kingdom",
                    TeamChief = "Mike Krack",
                    TechnicalChief = "Dan Fallows",
                    Chassis = "AMR23",
                    PowerUnit = "Mercedes",
                    FirstTeamEntry = 2018,
                    WorldChampionships = 0,
                    HighestRaceFinish = "1 (x1)",
                    PolePositions = 1,
                    FastestLaps = 1,
                    Created = DateTime.UtcNow,
                    CreatedBy = "SYSTEM"
                },
                new Team
                {
                    Id = Guid.NewGuid(),
                    FullTeamName = "McLaren Formula 1 Team",
                    Base = "Woking, United Kingdom",
                    TeamChief = "Andrea Stella",
                    TechnicalChief = "Peter Prodromou / Neil Houldey",
                    Chassis = "MCL60",
                    PowerUnit = "Mercedes",
                    FirstTeamEntry = 1966,
                    WorldChampionships = 8,
                    HighestRaceFinish = "1 (x183)",
                    PolePositions = 156,
                    FastestLaps = 163,
                    Created = DateTime.UtcNow,
                    CreatedBy = "SYSTEM"
                },
                new Team
                {
                    Id = Guid.NewGuid(),
                    FullTeamName = "Mercedes-AMG PETRONAS F1 Team",
                    Base = "Brackley, United Kingdom",
                    TeamChief = "Toto Wolff",
                    TechnicalChief = "James Allison",
                    Chassis = "W14",
                    PowerUnit = "Mercedes",
                    FirstTeamEntry = 1970,
                    WorldChampionships = 8,
                    HighestRaceFinish = "1 (x116)",
                    PolePositions = 129,
                    FastestLaps = 95,
                    Created = DateTime.UtcNow,
                    CreatedBy = "SYSTEM"
                },
                new Team
                {
                    Id = Guid.NewGuid(),
                    FullTeamName = "Williams Racing",
                    Base = "Grove, United Kingdom",
                    TeamChief = "James Vowles",
                    TechnicalChief = "TBC",
                    Chassis = "FW45",
                    PowerUnit = "Mercedes",
                    FirstTeamEntry = 1978,
                    WorldChampionships = 9,
                    HighestRaceFinish = "1 (x114)",
                    PolePositions = 128,
                    FastestLaps = 133,
                    Created = DateTime.UtcNow,
                    CreatedBy = "SYSTEM"
                }
            );

            builder.Entity<Person>().HasData(
                new Person
                {
                    Id = Guid.NewGuid(),
                    Name = "Alexander",
                    LastName = "Albon",
                    CountryCode = "TH",
                    DateOfBirth = new DateTime(1996, 03, 23),
                    PlaceOfBirth = "London, England",
                    Created = DateTime.UtcNow,
                    CreatedBy = "SYSTEM"
                },
                new Person
                {
                    Id = Guid.NewGuid(),
                    Name = "Fernando",
                    LastName = "Alonso",
                    CountryCode = "ES",
                    DateOfBirth = new DateTime(1981, 07, 29),
                    PlaceOfBirth = "Oviedo, Spain",
                    Created = DateTime.UtcNow,
                    CreatedBy = "SYSTEM"
                },
                new Person
                {
                    Id = Guid.NewGuid(),
                    Name = "Valtteri",
                    LastName = "Bottas",
                    CountryCode = "FI",
                    DateOfBirth = new DateTime(1989, 08, 28),
                    PlaceOfBirth = "Nastola, Finland",
                    Created = DateTime.UtcNow,
                    CreatedBy = "SYSTEM"
                }
            );

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
