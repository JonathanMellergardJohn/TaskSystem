﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManager.Data;

#nullable disable

namespace TaskSystem.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230316190612_ChangedOnDeleteToRestrict")]
    partial class ChangedOnDeleteToRestrict
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskManager.Data.Entities.CommentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TaskItemId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TaskItemId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("TaskManager.Data.Entities.StaffEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("TaskManager.Data.Entities.TaskItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReporteeId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupervisorId")
                        .HasColumnType("int");

                    b.Property<int?>("TaskItemStatusEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReporteeId");

                    b.HasIndex("StatusId");

                    b.HasIndex("SupervisorId");

                    b.HasIndex("TaskItemStatusEntityId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskManager.Data.Entities.TaskItemStatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("TaskManager.Data.Entities.CommentEntity", b =>
                {
                    b.HasOne("TaskManager.Data.Entities.TaskItemEntity", "TaskItem")
                        .WithMany("Comments")
                        .HasForeignKey("TaskItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskItem");
                });

            modelBuilder.Entity("TaskManager.Data.Entities.TaskItemEntity", b =>
                {
                    b.HasOne("TaskManager.Data.Entities.StaffEntity", "Reportee")
                        .WithMany("ReportedTasks")
                        .HasForeignKey("ReporteeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TaskManager.Data.Entities.TaskItemStatusEntity", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaskManager.Data.Entities.StaffEntity", "Supervisor")
                        .WithMany("SupervisedTasks")
                        .HasForeignKey("SupervisorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TaskManager.Data.Entities.TaskItemStatusEntity", null)
                        .WithMany("TaskItems")
                        .HasForeignKey("TaskItemStatusEntityId");

                    b.Navigation("Reportee");

                    b.Navigation("Status");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("TaskManager.Data.Entities.StaffEntity", b =>
                {
                    b.Navigation("ReportedTasks");

                    b.Navigation("SupervisedTasks");
                });

            modelBuilder.Entity("TaskManager.Data.Entities.TaskItemEntity", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("TaskManager.Data.Entities.TaskItemStatusEntity", b =>
                {
                    b.Navigation("TaskItems");
                });
#pragma warning restore 612, 618
        }
    }
}
