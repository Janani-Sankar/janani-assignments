using EventAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI.Data
{
    public class EventContext:DbContext
    {
        public EventContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventPrice> EventPrices { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventCategory>(ConfigureEventCategory);
            modelBuilder.Entity<EventPrice>(ConfigureEventPrice);
            modelBuilder.Entity<EventType>(ConfigureEventType);
            modelBuilder.Entity<Event>(ConfigureEvent);
        }

        private void ConfigureEvent(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("event");
            builder.Property(a => a.Id)
               .IsRequired()
               .ForSqlServerUseSequenceHiLo("events_hilo");

            builder.Property(a =>a.Name)
                 .IsRequired()
                .HasMaxLength(100);

            builder.Property(a =>a.Location)
                 .IsRequired()
                .HasMaxLength(100);

            builder.Property( a =>a.Description)
                 .IsRequired()
                .HasMaxLength(100);

            builder.Property(a =>a.DateTime)
                 .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(a => a.EventCategory)
                .WithMany()
                .HasForeignKey(a => a.EventCategoryID);


            
            builder.HasOne(a => a.EventType)
              .WithMany()
              .HasForeignKey(a => a.EventTypeID);

        }

        private void ConfigureEventType(EntityTypeBuilder<EventType> builder)

        {
            builder.ToTable("Type");

            builder.Property(b => b.Id)
               .IsRequired()
               .ForSqlServerUseSequenceHiLo("eventtype_hilo");

            builder.Property(b => b.Typename)
            .IsRequired()
            .HasMaxLength(1000);
        
        }

        private void ConfigureEventPrice(EntityTypeBuilder<EventPrice> builder)
        {
            builder.ToTable("Price");

            builder.Property(d => d.Id)
               .IsRequired()
               .ForSqlServerUseSequenceHiLo("price_hilo");

            builder.Property(d => d.Price)
            .IsRequired();
        }

        private void ConfigureEventCategory(EntityTypeBuilder<EventCategory> builder)

        {
            builder.ToTable("Category");

            builder.Property(c => c.Id)
               .IsRequired()
               .ForSqlServerUseSequenceHiLo("category_hilo");

            builder.Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(1000);
   
        }
    }
}
