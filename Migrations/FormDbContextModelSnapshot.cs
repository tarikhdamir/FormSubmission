﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FormSubmission.Migrations
{
    [DbContext(typeof(FormDbContext))]
    partial class FormDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("FormSubmission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FormDataJson")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("FormData");

                    b.Property<DateTime>("SubmittedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Submissions");
                });
#pragma warning restore 612, 618
        }
    }
}
