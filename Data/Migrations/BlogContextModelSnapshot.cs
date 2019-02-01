﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(BlogContext))]
    partial class BlogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Models.Blog", b =>
                {
                    b.Property<int>("iD")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datetime");

                    b.Property<string>("Subject");

                    b.Property<string>("Tiltle");

                    b.Property<string>("body");

                    b.Property<string>("rate");

                    b.Property<string>("user");

                    b.HasKey("iD");

                    b.ToTable("blogs");
                });

            modelBuilder.Entity("Data.Models.Register", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Email");

                    b.Property<string>("Fname")
                        .IsRequired();

                    b.Property<string>("Lname");

                    b.Property<string>("Password");

                    b.Property<string>("Photo");

                    b.HasKey("id");

                    b.ToTable("register");
                });
#pragma warning restore 612, 618
        }
    }
}
