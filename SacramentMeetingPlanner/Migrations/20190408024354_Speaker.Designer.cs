﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Migrations
{
    [DbContext(typeof(SacramentMeetingPlannerContext))]
    [Migration("20190408024354_Speaker")]
    partial class Speaker
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Meeting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Benediction")
                        .HasMaxLength(60);

                    b.Property<int>("ClosingHymn");

                    b.Property<string>("Conducting")
                        .HasMaxLength(60);

                    b.Property<string>("Invocation")
                        .HasMaxLength(60);

                    b.Property<DateTime>("MeetingDate");

                    b.Property<int>("OpeningHymn");

                    b.Property<string>("Presiding")
                        .HasMaxLength(60);

                    b.Property<int>("SacramentHymn");

                    b.Property<string>("Topic");

                    b.HasKey("Id");

                    b.ToTable("Meeting");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.SpeakerAssignment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssignedTopic");

                    b.Property<int>("MeetingID");

                    b.Property<string>("SpeakerName")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("MeetingID");

                    b.ToTable("SpeakerAssignment");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.SpeakerAssignment", b =>
                {
                    b.HasOne("SacramentMeetingPlanner.Models.Meeting", "Meeting")
                        .WithMany("Speakers")
                        .HasForeignKey("MeetingID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
