using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Models
{
    public class EventDbContext : DbContext
    {
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Organiser> Organiser { get; set; }
        public DbSet<Artist_Event> Artist_Event { get; set; }
        public DbSet<Event_Organiser> Event_Organiser { get; set; }

        public EventDbContext()
        { }

        public EventDbContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s19151;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artist>(builder =>
            {
                builder.HasKey(m => m.IdArtist);
                builder.Property(m => m.IdArtist).ValueGeneratedOnAdd();

                builder.Property(m => m.Nickname).HasMaxLength(30);
                builder.Property(m => m.Nickname).IsRequired();

                builder.HasMany(m => m.Artists_Events)
                    .WithOne(m => m.Artist)
                    .HasForeignKey(m => m.IdArtist)
                    .IsRequired();
            });

            modelBuilder.Entity<Event>(builder =>
            {
                builder.HasKey(m => m.IdEvent);
                builder.Property(m => m.IdEvent).ValueGeneratedOnAdd();

                builder.Property(m => m.Name).HasMaxLength(100);
                builder.Property(m => m.Name).IsRequired();
                builder.Property(m => m.StartDate).IsRequired();
                builder.Property(m => m.EndDate).IsRequired();

                builder.HasMany(m => m.Artists_Events)
                    .WithOne(m => m.Event)
                    .HasForeignKey(m => m.IdEvent)
                    .IsRequired();

                builder.HasMany(m => m.Events_Organisers)
                    .WithOne(m => m.Event)
                    .HasForeignKey(m => m.IdEvent)
                    .IsRequired();
            });

            modelBuilder.Entity<Organiser>(builder =>
            {
                builder.HasKey(m => m.IdOrganiser);
                builder.Property(m => m.IdOrganiser).ValueGeneratedOnAdd();

                builder.Property(m => m.Name).HasMaxLength(100);
                builder.Property(m => m.Name).IsRequired();

                builder.HasMany(m => m.Events_Organisers)
                    .WithOne(m => m.Organiser)
                    .HasForeignKey(m => m.IdOrganiser)
                    .IsRequired();
            });

            modelBuilder.Entity<Artist_Event>(builder =>
            {
                builder.HasKey(m => new { m.IdEvent, m.IdArtist});
                builder.Property(m => m.IdEvent).IsRequired();
                builder.Property(m => m.IdArtist).IsRequired();

                builder.Property(m => m.PerfomanceDate).IsRequired();
            });

            modelBuilder.Entity<Event_Organiser>(builder =>
            {
                builder.HasKey(m => new { m.IdEvent, m.IdOrganiser });
                builder.Property(m => m.IdEvent).IsRequired();
                builder.Property(m => m.IdOrganiser).IsRequired();
            });

            modelBuilder.Seed();
        }
    }
}
