﻿// <auto-generated />
using Archie.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Archie.Migrations
{
    [DbContext(typeof(SyrakuzaContext))]
    [Migration("20181105221543_tickers")]
    partial class tickers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Archie.Models.ExchangeRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("EUR");

                    b.Property<decimal>("GBP");

                    b.Property<decimal>("PLN");

                    b.Property<DateTime>("dateInput");

                    b.HasKey("Id");

                    b.ToTable("ExchangeRates");
                });

            modelBuilder.Entity("Archie.Models.Spots", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("dateInput");

                    b.Property<decimal>("goldVal");

                    b.Property<decimal>("platiniumVal");

                    b.Property<decimal>("silverVal");

                    b.HasKey("Id");

                    b.ToTable("Spots");
                });

            modelBuilder.Entity("Archie.Models.Ticker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ask");

                    b.Property<decimal>("bid");

                    b.Property<decimal>("high");

                    b.Property<decimal>("last");

                    b.Property<decimal>("low");

                    b.Property<decimal>("volume");

                    b.Property<decimal>("vwap");

                    b.HasKey("Id");

                    b.ToTable("Tickers");
                });

            modelBuilder.Entity("Archie.Models.Trade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("amount");

                    b.Property<decimal>("closeRate");

                    b.Property<decimal>("rate");

                    b.Property<DateTime>("transactionTime");

                    b.HasKey("Id");

                    b.ToTable("Trades");
                });
#pragma warning restore 612, 618
        }
    }
}
