using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
//using Portfolio.EntityModels.PostgreSQL.Models;

namespace Portfolio.EntityModels;

public partial class PostgresWebPortfolioContext : DbContext
{
    //private readonly string _connectionString;
    public PostgresWebPortfolioContext()
    {
        //_connectionString = connectionString;
    }

    public PostgresWebPortfolioContext(DbContextOptions<PostgresWebPortfolioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<WpClient> WpClients { get; set; }

    public virtual DbSet<WpProject> WpProjects { get; set; }

    public virtual DbSet<WpProjectScreenshot> WpProjectScreenshots { get; set; }

    public virtual DbSet<WpProjectTechnologiesAssociative> WpProjectTechnologiesAssociatives { get; set; }

    public virtual DbSet<WpSkillCategory> WpSkillCategories { get; set; }

    public virtual DbSet<WpSkillset> WpSkillsets { get; set; }

    public virtual DbSet<WpTechnology> WpTechnologies { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseNpgsql(_connectionString);

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<WpClient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wp_clients_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Createddate).HasDefaultValueSql("CURRENT_DATE");
            entity.Property(e => e.Isactive).HasDefaultValue(false);
            entity.Property(e => e.Logo).HasDefaultValueSql("'logo-placeholder.png'::character varying");
        });

        modelBuilder.Entity<WpProject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wp_projects_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Coverimage).HasDefaultValueSql("'placeholder_2000x1000.png'::character varying");
            entity.Property(e => e.Createddate).HasDefaultValueSql("CURRENT_DATE");
            entity.Property(e => e.Isactive).HasDefaultValue(false);
            entity.Property(e => e.Isfeature).HasDefaultValue(false);
            entity.Property(e => e.Projecttype).HasDefaultValueSql("'Work'::character varying");
            entity.Property(e => e.Thumbnail).HasDefaultValueSql("'placeholder_2000x1000.png'::character varying");
        });

        modelBuilder.Entity<WpProjectScreenshot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wp_project_screenshots_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Createddate).HasDefaultValueSql("CURRENT_DATE");
            entity.Property(e => e.Isactive).HasDefaultValue(false);

            entity.HasOne(d => d.Project).WithMany(p => p.WpProjectScreenshots).HasConstraintName("fk_wp_project_screenshots_project");
        });

        modelBuilder.Entity<WpProjectTechnologiesAssociative>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wp_project_technologies_associative_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Project).WithMany(p => p.WpProjectTechnologiesAssociatives).HasConstraintName("fk_wp_project_technologies_associative_projects");

            entity.HasOne(d => d.ProjectNavigation).WithMany(p => p.WpProjectTechnologiesAssociatives).HasConstraintName("fk_wp_project_technologies_associative_technologies");
        });

        modelBuilder.Entity<WpSkillCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wp_skill_categories_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Skillset).WithMany(p => p.WpSkillCategories).HasConstraintName("fk_wp_skillsets_categories");
        });

        modelBuilder.Entity<WpSkillset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wp_skillsets_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Isfeature).HasDefaultValue(false);
        });

        modelBuilder.Entity<WpTechnology>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wp_technologies_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Category).WithMany(p => p.WpTechnologies).HasConstraintName("fk_wp_categories_technologies");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}


//public partial class WpClient { }

