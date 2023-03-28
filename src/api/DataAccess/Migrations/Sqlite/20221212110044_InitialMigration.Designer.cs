﻿// <auto-generated />

#nullable disable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Todo.Api.DataAccess.Migrations.Sqlite
{
    [DbContext(typeof(SqliteTodoContext))]
    [Migration("20221212110044_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("backend.api.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Todos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Todo 1 Description",
                            IsCompleted = false,
                            Title = "Todo 1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Todo 2 Description",
                            IsCompleted = true,
                            Title = "Todo 2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Todo 3 Description",
                            IsCompleted = false,
                            Title = "Todo 3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
