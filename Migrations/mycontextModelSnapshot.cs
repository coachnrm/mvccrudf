﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mvccrudf.Models;

#nullable disable

namespace mvccrudf.Migrations
{
    [DbContext(typeof(mycontext))]
    partial class mycontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("mvccrudf.Models.skill", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("skillname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("skill");

                    b.HasData(
                        new
                        {
                            id = 1,
                            skillname = "php"
                        },
                        new
                        {
                            id = 2,
                            skillname = "python"
                        });
                });

            modelBuilder.Entity("mvccrudf.Models.student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("skillid")
                        .HasColumnType("int");

                    b.Property<string>("studentname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentphone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("skillid");

                    b.ToTable("student");
                });

            modelBuilder.Entity("mvccrudf.Models.student", b =>
                {
                    b.HasOne("mvccrudf.Models.skill", "Skill")
                        .WithMany()
                        .HasForeignKey("skillid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");
                });
#pragma warning restore 612, 618
        }
    }
}
