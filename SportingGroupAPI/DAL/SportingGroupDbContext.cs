using Microsoft.EntityFrameworkCore;
using SportingGroupAPI.DAL.Models;
using SportingGroupAPI.Models;

namespace SportingGroupAPI.DAL
{
    public class SportingGroupDbContext : DbContext
    {
        private DbContextOptions<SportingGroupDbContext> options;
        public SportingGroupDbContext(DbContextOptions<SportingGroupDbContext> options) : base(options) { }

        public DbSet<Bet> Bet { get; set; }
        public DbSet<BetFixture> BetFixture { get; set; }
        public DbSet<Fixture> Fixture { get; set; }
        public DbSet<Result> Result { get; set; }
        public DbSet<Team> Team { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bet>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<BetFixture>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Fixture>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Result>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Team>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Fixture>()
                .HasOne(e => e.HostTeam)
                .WithMany(e => e.FixtureHosts)
                .HasForeignKey(e => e.HostTeamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Fixture>()
                .HasOne(e => e.GuestTeam)
                .WithMany(e => e.FixtureGuests)
                .HasForeignKey(e => e.GuestTeamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Fixture>()
                .HasOne(e => e.Result)
                .WithMany(e => e.Fixtures)
                .HasForeignKey(e => e.ResultId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BetFixture>()
                .HasOne(e => e.Bet)
                .WithMany(e => e.BetFixtures)
                .HasForeignKey(e => e.BetId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BetFixture>()
                .HasOne(e => e.Fixture)
                .WithMany(e => e.BetFixtures)
                .HasForeignKey(e => e.FixtureId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BetFixture>()
                .HasOne(e => e.BetResult)
                .WithMany(e => e.BetFixtures)
                .HasForeignKey(e => e.BetResultId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Result>()
                .HasData(
                    new Result { Id = 1, Name = Constants.Result_ToBePlayed },
                    new Result { Id = 2, Name = Constants.Result_Draw },
                    new Result { Id = 3, Name = Constants.Result_HostWin },
                    new Result { Id = 4, Name = Constants.Result_GuestWin }
                    );
            modelBuilder.Entity<Team>()
                .HasData(
                    new Team { Id = 1, Name = "Reptile Warriors" },
                    new Team { Id = 2, Name = "Swamp Donkeys" },
                    new Team { Id = 3, Name = "Awesome Miners" },
                    new Team { Id = 4, Name = "Junk Yard Divas" },
                    new Team { Id = 5, Name = "Sneaky Pirates" }
                    );
            modelBuilder.Entity<Fixture>()
                .HasData(
                    new Fixture { Id = 1, HostTeamId = 1, GuestTeamId = 2, ResultId = 1 },
                    new Fixture { Id = 3, HostTeamId = 5, GuestTeamId = 1, ResultId = 1 },
                    new Fixture { Id = 4, HostTeamId = 2, GuestTeamId = 4, ResultId = 1 },
                    new Fixture { Id = 5, HostTeamId = 3, GuestTeamId = 5, ResultId = 1 },
                    new Fixture { Id = 2, HostTeamId = 3, GuestTeamId = 4, ResultId = 1 },
                    new Fixture { Id = 6, HostTeamId = 1, GuestTeamId = 3, ResultId = 1 }
                    );
        }
    }
}
