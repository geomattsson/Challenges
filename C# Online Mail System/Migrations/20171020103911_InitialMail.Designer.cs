﻿// <auto-generated />
using DistNet.Data.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DistNet.Migrations
{
    [DbContext(typeof(MailDBContext))]
    [Migration("20171020103911_InitialMail")]
    partial class InitialMail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DistNet.Models.GroupModel.Group", b =>
                {
                    b.Property<Guid>("GroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GroupName")
                        .IsRequired();

                    b.HasKey("GroupId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("DistNet.Models.GroupToUserMapping", b =>
                {
                    b.Property<Guid>("MapId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("GroupId");

                    b.Property<string>("UserEmail");

                    b.HasKey("MapId");

                    b.HasIndex("GroupId");

                    b.ToTable("Mapping");
                });

            modelBuilder.Entity("DistNet.Models.Mail", b =>
                {
                    b.Property<Guid>("MailId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("GroupId");

                    b.Property<string>("MailBody")
                        .IsRequired();

                    b.Property<string>("MailTitle")
                        .IsRequired();

                    b.Property<string>("Sender");

                    b.Property<DateTime>("Time");

                    b.HasKey("MailId");

                    b.HasIndex("GroupId");

                    b.ToTable("Mails");
                });

            modelBuilder.Entity("DistNet.Models.MailUserSpecification", b =>
                {
                    b.Property<Guid>("MailUserSpecificationId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<Guid?>("MailId");

                    b.Property<bool>("Unread");

                    b.Property<string>("UserEmail");

                    b.HasKey("MailUserSpecificationId");

                    b.HasIndex("MailId");

                    b.ToTable("MailUserSpecification");
                });

            modelBuilder.Entity("DistNet.Models.GroupToUserMapping", b =>
                {
                    b.HasOne("DistNet.Models.GroupModel.Group", "Group")
                        .WithMany("ListOfUserMapping")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DistNet.Models.Mail", b =>
                {
                    b.HasOne("DistNet.Models.GroupModel.Group")
                        .WithMany("Mail")
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("DistNet.Models.MailUserSpecification", b =>
                {
                    b.HasOne("DistNet.Models.Mail", "Mail")
                        .WithMany("Specifications")
                        .HasForeignKey("MailId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}