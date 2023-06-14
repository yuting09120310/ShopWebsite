using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AlexBlogMVC.Areas.BackEnd.Models;

public partial class BlogMvcContext : DbContext
{
    public BlogMvcContext()
    {
    }

    public BlogMvcContext(DbContextOptions<BlogMvcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AdminGroup> AdminGroups { get; set; }

    public virtual DbSet<AdminRole> AdminRoles { get; set; }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<MenuGroup> MenuGroups { get; set; }

    public virtual DbSet<MenuSub> MenuSubs { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<NewsClass> NewsClasses { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductClass> ProductClasses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=bph0f9e031dbspxvzlln-mysql.services.clever-cloud.com;database=bph0f9e031dbspxvzlln;user id=uu0og8gexiz2qadf;password=kpmmSeU7FxEiwHQ2P0L7", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminNum).HasName("PRIMARY");

            entity.ToTable("Admin");

            entity.Property(e => e.AdminAcc)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.AdminName)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.AdminPublish).HasColumnType("bit(1)");
            entity.Property(e => e.AdminPwd)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
        });

        modelBuilder.Entity<AdminGroup>(entity =>
        {
            entity.HasKey(e => e.GroupNum).HasName("PRIMARY");

            entity.ToTable("AdminGroup");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.GroupInfo).HasColumnType("text");
            entity.Property(e => e.GroupName)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.GroupPublish).HasColumnType("bit(1)");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<AdminRole>(entity =>
        {
            entity.HasKey(e => e.RoleNum).HasName("PRIMARY");

            entity.ToTable("AdminRole");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<Banner>(entity =>
        {
            entity.HasKey(e => e.BannerNum).HasName("PRIMARY");

            entity.ToTable("Banner");

            entity.Property(e => e.BannerContxt).HasColumnType("text");
            entity.Property(e => e.BannerDescription).HasColumnType("text");
            entity.Property(e => e.BannerImg1).HasColumnType("text");
            entity.Property(e => e.BannerImgAlt).HasColumnType("text");
            entity.Property(e => e.BannerImgUrl).HasColumnType("text");
            entity.Property(e => e.BannerOffTime).HasColumnType("datetime");
            entity.Property(e => e.BannerPublish).HasColumnType("bit(1)");
            entity.Property(e => e.BannerPutTime).HasColumnType("datetime");
            entity.Property(e => e.BannerTitle).HasColumnType("text");
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Lang)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PRIMARY");

            entity.ToTable("Comment");

            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Message).HasColumnType("text");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactNum).HasName("PRIMARY");

            entity.ToTable("Contact");

            entity.Property(e => e.ContactMail).HasColumnType("text");
            entity.Property(e => e.ContactName).HasColumnType("text");
            entity.Property(e => e.ContactPhone).HasColumnType("text");
            entity.Property(e => e.ContactReTxt).HasColumnType("text");
            entity.Property(e => e.ContactTxt).HasColumnType("text");
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<MenuGroup>(entity =>
        {
            entity.HasKey(e => e.MenuGroupNum).HasName("PRIMARY");

            entity.ToTable("MenuGroup");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MenuGroupIcon)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MenuGroupId)
                .HasMaxLength(100)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MenuGroupInfo)
                .HasMaxLength(100)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MenuGroupName)
                .HasMaxLength(100)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MenuGroupPublish).HasColumnType("bit(1)");
            entity.Property(e => e.MenuGroupUrl)
                .HasMaxLength(100)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<MenuSub>(entity =>
        {
            entity.HasKey(e => e.MenuSubNum).HasName("PRIMARY");

            entity.ToTable("MenuSub");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MenuGroupId)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MenuSubIcon)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MenuSubId)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MenuSubInfo)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MenuSubName)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MenuSubPublish).HasColumnType("bit(1)");
            entity.Property(e => e.MenuSubRole)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MenuSubUrl)
                .HasMaxLength(100)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.NewsNum).HasName("PRIMARY");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Lang)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.NewsContxt).HasColumnType("text");
            entity.Property(e => e.NewsDescription).HasColumnType("text");
            entity.Property(e => e.NewsImg1).HasColumnType("text");
            entity.Property(e => e.NewsImgAlt).HasColumnType("text");
            entity.Property(e => e.NewsImgUrl).HasColumnType("text");
            entity.Property(e => e.NewsOffTime).HasColumnType("datetime");
            entity.Property(e => e.NewsPublish).HasColumnType("bit(1)");
            entity.Property(e => e.NewsPutTime).HasColumnType("datetime");
            entity.Property(e => e.NewsTitle).HasColumnType("text");
            entity.Property(e => e.Tag).HasColumnType("text");
        });

        modelBuilder.Entity<NewsClass>(entity =>
        {
            entity.HasKey(e => e.NewsClassNum).HasName("PRIMARY");

            entity.ToTable("NewsClass");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.NewsClassId)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.NewsClassName)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.NewsClassPublish).HasColumnType("bit(1)");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerName).HasMaxLength(50);
            entity.Property(e => e.Email).HasColumnType("text");
            entity.Property(e => e.OrderStatus).HasMaxLength(50);
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.ShippingAddress).HasColumnType("text");
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(e => e.OrderProductId).HasName("PRIMARY");

            entity.ToTable("OrderProduct");

            entity.Property(e => e.OrderProductId).HasColumnName("OrderProductID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductNum).HasName("PRIMARY");

            entity.ToTable("Product");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip)
                .HasColumnType("text")
                .HasColumnName("IP");
            entity.Property(e => e.Lang).HasMaxLength(50);
            entity.Property(e => e.ProductContxt).HasColumnType("text");
            entity.Property(e => e.ProductDepartment).HasColumnType("text");
            entity.Property(e => e.ProductDescription).HasColumnType("text");
            entity.Property(e => e.ProductId).HasColumnType("text");
            entity.Property(e => e.ProductImg1).HasColumnType("text");
            entity.Property(e => e.ProductImgAlt).HasColumnType("text");
            entity.Property(e => e.ProductImgList).HasColumnType("text");
            entity.Property(e => e.ProductImgListAlt).HasColumnType("text");
            entity.Property(e => e.ProductImgUrl).HasColumnType("text");
            entity.Property(e => e.ProductOffTime).HasColumnType("datetime");
            entity.Property(e => e.ProductPublish).HasColumnType("bit(1)");
            entity.Property(e => e.ProductPutTime).HasColumnType("datetime");
            entity.Property(e => e.ProductTitle).HasColumnType("text");
            entity.Property(e => e.ProductVideo1).HasColumnType("text");
            entity.Property(e => e.Tag).HasColumnType("text");
        });

        modelBuilder.Entity<ProductClass>(entity =>
        {
            entity.HasKey(e => e.ProductClassNum).HasName("PRIMARY");

            entity.ToTable("ProductClass");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP");
            entity.Property(e => e.ProductClassId).HasMaxLength(50);
            entity.Property(e => e.ProductClassName).HasMaxLength(50);
            entity.Property(e => e.ProductClassPublish).HasColumnType("bit(1)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
