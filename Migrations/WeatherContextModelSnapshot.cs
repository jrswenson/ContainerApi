using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ContainerApi;

namespace ContainerApi.Migrations
{
    [DbContext(typeof(WeatherContext))]
    partial class WeatherContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("ContainerApi.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ReactionId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("ReactionId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ContainerApi.Reaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Quote");

                    b.Property<int>("WeatherEventId");

                    b.HasKey("Id");

                    b.HasIndex("WeatherEventId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("ContainerApi.WeatherEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("MostCommonWord");

                    b.Property<TimeSpan>("Time");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("WeatherEvents");
                });

            modelBuilder.Entity("ContainerApi.Comment", b =>
                {
                    b.HasOne("ContainerApi.Reaction")
                        .WithMany("Comments")
                        .HasForeignKey("ReactionId");
                });

            modelBuilder.Entity("ContainerApi.Reaction", b =>
                {
                    b.HasOne("ContainerApi.WeatherEvent")
                        .WithMany("Reactions")
                        .HasForeignKey("WeatherEventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
