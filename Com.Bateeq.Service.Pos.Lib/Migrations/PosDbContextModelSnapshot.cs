﻿// <auto-generated />
using System;
using Com.Danliris.Service.Inventory.Lib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Com.Bateeq.Service.Pos.Lib.Migrations
{
    [DbContext(typeof(PosDbContext))]
    partial class PosDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Com.Bateeq.Service.Pos.Lib.Models.Discount.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Code")
                        .HasMaxLength(255);

                    b.Property<int>("DiscountOne");

                    b.Property<int>("DiscountTwo");

                    b.Property<DateTimeOffset>("EndDate");

                    b.Property<string>("Information")
                        .HasMaxLength(255);

                    b.Property<DateTimeOffset>("StartDate");

                    b.Property<string>("StoreCategory")
                        .HasMaxLength(255);

                    b.Property<string>("StoreName")
                        .HasMaxLength(255);

                    b.Property<string>("UId")
                        .HasMaxLength(255);

                    b.Property<string>("_CreatedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_CreatedUtc");

                    b.Property<string>("_DeletedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_DeletedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_DeletedUtc");

                    b.Property<bool>("_IsDeleted");

                    b.Property<string>("_LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_LastModifiedUtc");

                    b.HasKey("Id");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("Com.Bateeq.Service.Pos.Lib.Models.Discount.DiscountDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("ArticleRealizationOrder")
                        .HasMaxLength(255);

                    b.Property<string>("Code")
                        .HasMaxLength(255);

                    b.Property<int>("DiscountItemId");

                    b.Property<float>("DomesticCOGS");

                    b.Property<float>("DomesticRetail");

                    b.Property<float>("DomesticSale");

                    b.Property<float>("DomesticWholesale");

                    b.Property<float>("InternationalCOGS");

                    b.Property<float>("InternationalRetail");

                    b.Property<float>("InternationalSale");

                    b.Property<float>("InternationalWholesale");

                    b.Property<int>("ItemId");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<string>("Size")
                        .HasMaxLength(255);

                    b.Property<string>("Uid")
                        .HasMaxLength(255);

                    b.Property<string>("Uom")
                        .HasMaxLength(255);

                    b.Property<string>("_CreatedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_CreatedUtc");

                    b.Property<string>("_DeletedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_DeletedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_DeletedUtc");

                    b.Property<bool>("_IsDeleted");

                    b.Property<string>("_LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_LastModifiedUtc");

                    b.HasKey("Id");

                    b.HasIndex("DiscountItemId");

                    b.ToTable("DiscountDetails");
                });

            modelBuilder.Entity("Com.Bateeq.Service.Pos.Lib.Models.Discount.DiscountItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int>("DiscountId");

                    b.Property<string>("RealizationOrder")
                        .HasMaxLength(255);

                    b.Property<string>("UId")
                        .HasMaxLength(255);

                    b.Property<string>("_CreatedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_CreatedUtc");

                    b.Property<string>("_DeletedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_DeletedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_DeletedUtc");

                    b.Property<bool>("_IsDeleted");

                    b.Property<string>("_LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_LastModifiedUtc");

                    b.HasKey("Id");

                    b.HasIndex("DiscountId");

                    b.ToTable("DiscountItems");
                });

            modelBuilder.Entity("Com.Bateeq.Service.Pos.Lib.Models.Discount.DiscountStore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Address")
                        .HasMaxLength(255);

                    b.Property<string>("City")
                        .HasMaxLength(255);

                    b.Property<string>("Code")
                        .HasMaxLength(255);

                    b.Property<string>("DiscountCode")
                        .HasMaxLength(255);

                    b.Property<int>("DiscountId");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<string>("OnlineOffline")
                        .HasMaxLength(255);

                    b.Property<string>("SalesCategory")
                        .HasMaxLength(255);

                    b.Property<string>("StorageCode")
                        .HasMaxLength(255);

                    b.Property<string>("StorageId")
                        .HasMaxLength(255);

                    b.Property<string>("StorageIsCentral")
                        .HasMaxLength(255);

                    b.Property<string>("StorageName")
                        .HasMaxLength(255);

                    b.Property<string>("StoreArea")
                        .HasMaxLength(255);

                    b.Property<string>("StoreCategory")
                        .HasMaxLength(255);

                    b.Property<int>("StoreId");

                    b.Property<string>("StoreWide")
                        .HasMaxLength(255);

                    b.Property<string>("UId")
                        .HasMaxLength(255);

                    b.Property<string>("_CreatedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_CreatedUtc");

                    b.Property<string>("_DeletedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_DeletedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_DeletedUtc");

                    b.Property<bool>("_IsDeleted");

                    b.Property<string>("_LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_LastModifiedUtc");

                    b.HasKey("Id");

                    b.ToTable("DiscountStores");
                });

            modelBuilder.Entity("Com.Bateeq.Service.Pos.Lib.Models.SalesDoc.SalesDoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("BankCardCode")
                        .HasMaxLength(255);

                    b.Property<int>("BankCardId");

                    b.Property<string>("BankCardName")
                        .HasMaxLength(255);

                    b.Property<string>("BankCode")
                        .HasMaxLength(255);

                    b.Property<int>("BankId");

                    b.Property<string>("BankName")
                        .HasMaxLength(255);

                    b.Property<string>("Card")
                        .HasMaxLength(255);

                    b.Property<double>("CardAmount");

                    b.Property<string>("CardName")
                        .HasMaxLength(255);

                    b.Property<string>("CardNumber")
                        .HasMaxLength(255);

                    b.Property<string>("CardTypeCode")
                        .HasMaxLength(255);

                    b.Property<int>("CardTypeId");

                    b.Property<string>("CardTypeName")
                        .HasMaxLength(255);

                    b.Property<double>("CashAmount");

                    b.Property<string>("Code")
                        .HasMaxLength(255);

                    b.Property<DateTimeOffset>("Date");

                    b.Property<double>("Discount");

                    b.Property<double>("GrandTotal");

                    b.Property<string>("PaymentType")
                        .HasMaxLength(255);

                    b.Property<string>("Reference")
                        .HasMaxLength(255);

                    b.Property<string>("Remark")
                        .HasMaxLength(255);

                    b.Property<int>("Shift");

                    b.Property<string>("StoreCategory")
                        .HasMaxLength(255);

                    b.Property<string>("StoreCode")
                        .HasMaxLength(255);

                    b.Property<int>("StoreId");

                    b.Property<string>("StoreName")
                        .HasMaxLength(255);

                    b.Property<string>("StoreStorageCode")
                        .HasMaxLength(255);

                    b.Property<int>("StoreStorageId");

                    b.Property<string>("StoreStorageName")
                        .HasMaxLength(255);

                    b.Property<double>("SubTotal");

                    b.Property<double>("TotalProduct");

                    b.Property<string>("UId")
                        .HasMaxLength(255);

                    b.Property<double>("VoucherValue");

                    b.Property<string>("_CreatedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_CreatedUtc");

                    b.Property<string>("_DeletedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_DeletedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_DeletedUtc");

                    b.Property<bool>("_IsDeleted");

                    b.Property<string>("_LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_LastModifiedUtc");

                    b.Property<bool>("isReturn");

                    b.Property<bool>("isVoid");

                    b.HasKey("Id");

                    b.ToTable("SalesDocs");
                });

            modelBuilder.Entity("Com.Bateeq.Service.Pos.Lib.Models.SalesDoc.SalesDocDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<double>("Discount1");

                    b.Property<double>("Discount2");

                    b.Property<double>("DiscountNominal");

                    b.Property<string>("ItemArticleRealizationOrder")
                        .HasMaxLength(255);

                    b.Property<string>("ItemCode")
                        .HasMaxLength(255);

                    b.Property<double>("ItemDomesticCOGS");

                    b.Property<double>("ItemDomesticRetail");

                    b.Property<double>("ItemDomesticSale");

                    b.Property<double>("ItemDomesticWholeSale");

                    b.Property<long>("ItemId");

                    b.Property<string>("ItemName")
                        .HasMaxLength(255);

                    b.Property<string>("ItemSize")
                        .HasMaxLength(255);

                    b.Property<string>("ItemUom")
                        .HasMaxLength(255);

                    b.Property<double>("Margin");

                    b.Property<double>("Price");

                    b.Property<string>("PromoCode")
                        .HasMaxLength(255);

                    b.Property<int>("PromoId");

                    b.Property<string>("PromoName")
                        .HasMaxLength(255);

                    b.Property<double>("Quantity");

                    b.Property<int>("SalesDocId");

                    b.Property<string>("Size")
                        .HasMaxLength(255);

                    b.Property<double>("SpesialDiscount");

                    b.Property<double>("Total");

                    b.Property<string>("UId")
                        .HasMaxLength(255);

                    b.Property<string>("_CreatedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_CreatedUtc");

                    b.Property<string>("_DeletedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_DeletedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_DeletedUtc");

                    b.Property<bool>("_IsDeleted");

                    b.Property<string>("_LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_LastModifiedUtc");

                    b.Property<bool>("isReturn");

                    b.HasKey("Id");

                    b.HasIndex("SalesDocId");

                    b.ToTable("SalesDocDetails");
                });

            modelBuilder.Entity("Com.Bateeq.Service.Pos.Lib.Models.SalesDoc.SalesDocDetailReturnItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<double>("Discount1");

                    b.Property<double>("Discount2");

                    b.Property<double>("DiscountNominal");

                    b.Property<string>("ItemArticleRealizationOrder")
                        .HasMaxLength(255);

                    b.Property<string>("ItemCode")
                        .HasMaxLength(255);

                    b.Property<double>("ItemDomesticCOGS");

                    b.Property<double>("ItemDomesticRetail");

                    b.Property<double>("ItemDomesticSale");

                    b.Property<double>("ItemDomesticWholeSale");

                    b.Property<long>("ItemId");

                    b.Property<string>("ItemName")
                        .HasMaxLength(255);

                    b.Property<string>("ItemSize")
                        .HasMaxLength(255);

                    b.Property<string>("ItemUom")
                        .HasMaxLength(255);

                    b.Property<double>("Margin");

                    b.Property<double>("Price");

                    b.Property<string>("PromoCode")
                        .HasMaxLength(255);

                    b.Property<int>("PromoId");

                    b.Property<string>("PromoName")
                        .HasMaxLength(255);

                    b.Property<double>("Quantity");

                    b.Property<int>("SalesDocDetailId");

                    b.Property<string>("Size")
                        .HasMaxLength(255);

                    b.Property<double>("SpesialDiscount");

                    b.Property<double>("Total");

                    b.Property<string>("UId")
                        .HasMaxLength(255);

                    b.Property<string>("_CreatedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_CreatedUtc");

                    b.Property<string>("_DeletedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_DeletedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_DeletedUtc");

                    b.Property<bool>("_IsDeleted");

                    b.Property<string>("_LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_LastModifiedUtc");

                    b.Property<bool>("isReturn");

                    b.HasKey("Id");

                    b.ToTable("SalesDocDetailReturnItems");
                });

            modelBuilder.Entity("Com.Bateeq.Service.Pos.Lib.Models.SalesReport.SalesReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Brand")
                        .HasMaxLength(50);

                    b.Property<string>("Category")
                        .HasMaxLength(255);

                    b.Property<string>("Collection")
                        .HasMaxLength(255);

                    b.Property<string>("Color")
                        .HasMaxLength(255);

                    b.Property<string>("Date")
                        .HasMaxLength(255);

                    b.Property<double>("Discount1");

                    b.Property<double>("Discount2");

                    b.Property<double>("DiscountNominal");

                    b.Property<double>("Gross");

                    b.Property<string>("Group")
                        .HasMaxLength(255);

                    b.Property<string>("ItemArticleRealizationOrder")
                        .HasMaxLength(255);

                    b.Property<string>("ItemCode")
                        .HasMaxLength(255);

                    b.Property<string>("ItemName")
                        .HasMaxLength(255);

                    b.Property<string>("Location")
                        .HasMaxLength(255);

                    b.Property<double>("Margin");

                    b.Property<double>("Nett");

                    b.Property<double>("OriginalCost");

                    b.Property<double>("Quantity");

                    b.Property<string>("SeasonCode")
                        .HasMaxLength(255);

                    b.Property<string>("SeasonYear")
                        .HasMaxLength(255);

                    b.Property<string>("Size")
                        .HasMaxLength(255);

                    b.Property<double>("SpecialDiscount");

                    b.Property<string>("Style")
                        .HasMaxLength(255);

                    b.Property<double>("TotalGross");

                    b.Property<double>("TotalNett");

                    b.Property<double>("TotalOriCost");

                    b.Property<string>("TransactionNo")
                        .HasMaxLength(255);

                    b.Property<string>("_CreatedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_CreatedUtc");

                    b.Property<string>("_DeletedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_DeletedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_DeletedUtc");

                    b.Property<bool>("_IsDeleted");

                    b.Property<string>("_LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_LastModifiedUtc");

                    b.HasKey("Id");

                    b.ToTable("SalesReports");
                });

            modelBuilder.Entity("Com.Bateeq.Service.Pos.Lib.Models.SalesReturn.SalesDocReturn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Code")
                        .HasMaxLength(255);

                    b.Property<DateTimeOffset>("Date");

                    b.Property<bool>("IsVoid");

                    b.Property<string>("SalesDocCode")
                        .HasMaxLength(255);

                    b.Property<int>("SalesDocId");

                    b.Property<bool>("SalesDocIsReturn");

                    b.Property<string>("SalesDocReturnCode")
                        .HasMaxLength(255);

                    b.Property<int>("SalesDocReturnId");

                    b.Property<bool>("SalesDocReturnIsReturn");

                    b.Property<string>("StoreCode")
                        .HasMaxLength(255);

                    b.Property<int>("StoreId");

                    b.Property<string>("StoreName")
                        .HasMaxLength(255);

                    b.Property<string>("StoreStorageCode")
                        .HasMaxLength(255);

                    b.Property<int>("StoreStorageId");

                    b.Property<string>("StoreStorageName")
                        .HasMaxLength(255);

                    b.Property<string>("UId")
                        .HasMaxLength(255);

                    b.Property<string>("_CreatedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_CreatedUtc");

                    b.Property<string>("_DeletedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_DeletedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_DeletedUtc");

                    b.Property<bool>("_IsDeleted");

                    b.Property<string>("_LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_LastModifiedUtc");

                    b.HasKey("Id");

                    b.ToTable("SalesDocReturns");
                });

            modelBuilder.Entity("Com.Bateeq.Service.Pos.Lib.Models.SalesReturn.SalesDocReturnDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<double>("Discount1");

                    b.Property<double>("Discount2");

                    b.Property<double>("DiscountNominal");

                    b.Property<string>("ItemArticleRealizationOrder")
                        .HasMaxLength(255);

                    b.Property<string>("ItemCode")
                        .HasMaxLength(255);

                    b.Property<double>("ItemDomesticCOGS");

                    b.Property<double>("ItemDomesticRetail");

                    b.Property<double>("ItemDomesticSale");

                    b.Property<double>("ItemDomesticWholeSale");

                    b.Property<long>("ItemId");

                    b.Property<string>("ItemName")
                        .HasMaxLength(255);

                    b.Property<string>("ItemSize")
                        .HasMaxLength(255);

                    b.Property<string>("ItemUom")
                        .HasMaxLength(255);

                    b.Property<double>("Margin");

                    b.Property<double>("Price");

                    b.Property<string>("PromoCode")
                        .HasMaxLength(255);

                    b.Property<int>("PromoId");

                    b.Property<string>("PromoName")
                        .HasMaxLength(255);

                    b.Property<double>("Quantity");

                    b.Property<int>("SalesReturnId");

                    b.Property<string>("Size")
                        .HasMaxLength(255);

                    b.Property<double>("SpesialDiscount");

                    b.Property<double>("Total");

                    b.Property<string>("UId")
                        .HasMaxLength(255);

                    b.Property<string>("_CreatedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_CreatedUtc");

                    b.Property<string>("_DeletedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_DeletedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_DeletedUtc");

                    b.Property<bool>("_IsDeleted");

                    b.Property<string>("_LastModifiedAgent")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("_LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("_LastModifiedUtc");

                    b.Property<bool>("isReturn");

                    b.HasKey("Id");

                    b.HasIndex("SalesReturnId");

                    b.ToTable("SalesDocReturnDetails");
                });

            modelBuilder.Entity("Com.Bateeq.Service.Pos.Lib.Models.Discount.DiscountDetail", b =>
                {
                    b.HasOne("Com.Bateeq.Service.Pos.Lib.Models.Discount.DiscountItem", "DiscountItem")
                        .WithMany("Details")
                        .HasForeignKey("DiscountItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Com.Bateeq.Service.Pos.Lib.Models.Discount.DiscountItem", b =>
                {
                    b.HasOne("Com.Bateeq.Service.Pos.Lib.Models.Discount.Discount", "Discount")
                        .WithMany("Items")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Com.Bateeq.Service.Pos.Lib.Models.SalesDoc.SalesDocDetail", b =>
                {
                    b.HasOne("Com.Bateeq.Service.Pos.Lib.Models.SalesDoc.SalesDoc", "SalesDoc")
                        .WithMany("Details")
                        .HasForeignKey("SalesDocId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Com.Bateeq.Service.Pos.Lib.Models.SalesReturn.SalesDocReturnDetail", b =>
                {
                    b.HasOne("Com.Bateeq.Service.Pos.Lib.Models.SalesReturn.SalesDocReturn", "SalesReturn")
                        .WithMany("Details")
                        .HasForeignKey("SalesReturnId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
