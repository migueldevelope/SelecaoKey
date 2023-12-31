﻿using Microsoft.EntityFrameworkCore;
using SelecaoKey.Core.Business;

namespace SelecaoKey.Data
{
    public class DataContext : DbContext
    {
        private readonly string _connectionString;
        public DataContext(string connectionString)
        {
            _connectionString = connectionString;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Users>(entity => entity.ToTable("Users").HasKey(p => p.Id));
            builder.Entity<Streaming>(entity => entity.ToTable("Streaming").HasKey(p => p.Id));
            builder.Entity<MovieStreaming>(entity => entity.ToTable("MovieStreaming").HasKey(p => p.Id));
            builder.Entity<Movie>(entity =>
                entity.ToTable("Movie")
                    .HasKey(p => p.Id)
            );

            builder.Entity<Rating>(entity =>
                entity
                .ToTable("Rating")
                .HasKey(p => p.Id)
            );


            builder.Entity<Movie>().HasMany(p => p.Ratings).WithOne(p => p.Movie).HasForeignKey("idMovie")
                .HasConstraintName("Rating_Movie_FK").Metadata.SetConstraintName("Rating_Movie_FK");
           
            builder.Entity<Rating>().HasOne(c => c.Movie).WithMany(c => c.Ratings).HasForeignKey("idMovie")
                .HasConstraintName("Rating_Movie_FK").Metadata.SetConstraintName("Rating_Movie_FK");

            base.OnModelCreating(builder);
        }
    }
}