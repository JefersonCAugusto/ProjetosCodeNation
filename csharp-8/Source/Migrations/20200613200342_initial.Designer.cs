﻿// <auto-generated />
using System;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Source.Migrations
{
    [DbContext(typeof(CodenationContext))]
    [Migration("20200613200342_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Codenation.Challenge.Models.Acceleration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChallengeId")
                        .HasColumnName("challenge_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnName("slug")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ChallengeId");

                    b.ToTable("acceleration");
                });

            modelBuilder.Entity("Codenation.Challenge.Models.Candidate", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.Property<int>("AccelerationId")
                        .HasColumnName("acceleration_id");

                    b.Property<int>("CompanyId")
                        .HasColumnName("company_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.HasKey("UserId", "AccelerationId", "CompanyId");

                    b.HasIndex("AccelerationId");

                    b.HasIndex("CompanyId");

                    b.ToTable("candidate");
                });

            modelBuilder.Entity("Codenation.Challenge.Models.Challenge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnName("slug")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("challenge");
                });

            modelBuilder.Entity("Codenation.Challenge.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnName("slug")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("company");
                });

            modelBuilder.Entity("Codenation.Challenge.Models.Submission", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.Property<int>("ChallengeId")
                        .HasColumnName("challenge_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<decimal>("Score")
                        .HasColumnName("score")
                        .HasColumnType("decimal(9,2)");

                    b.HasKey("UserId", "ChallengeId");

                    b.HasIndex("ChallengeId");

                    b.ToTable("submission");
                });

            modelBuilder.Entity("Codenation.Challenge.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(100);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnName("full_name")
                        .HasMaxLength(100);

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnName("nickname")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Codenation.Challenge.Models.Acceleration", b =>
                {
                    b.HasOne("Codenation.Challenge.Models.Challenge", "Challenge")
                        .WithMany("Accelerations")
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Codenation.Challenge.Models.Candidate", b =>
                {
                    b.HasOne("Codenation.Challenge.Models.Acceleration", "Acceleration")
                        .WithMany("Candidates")
                        .HasForeignKey("AccelerationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Codenation.Challenge.Models.Company", "Company")
                        .WithMany("Candidates")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Codenation.Challenge.Models.User", "User")
                        .WithMany("Candidates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Codenation.Challenge.Models.Submission", b =>
                {
                    b.HasOne("Codenation.Challenge.Models.Challenge", "Challenge")
                        .WithMany("Submissions")
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Codenation.Challenge.Models.User", "User")
                        .WithMany("Submissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
