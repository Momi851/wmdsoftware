using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace wmdsoftware.Models;

public partial class WmdsoftwareContext : DbContext
{
    public WmdsoftwareContext()
    {
    }

    public WmdsoftwareContext(DbContextOptions<WmdsoftwareContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Visitorregistration> Visitorregistrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {


        }
    }
  


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Visitorregistration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__visitorr__3213E83F3B23637C");

            entity.ToTable("visitorregistration");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Company).HasMaxLength(100);
            entity.Property(e => e.ContactNumber).HasMaxLength(20);
            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
