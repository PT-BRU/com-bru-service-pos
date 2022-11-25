using Com.Bateeq.Service.Pos.Lib.Models.SalesDoc;
using Com.Bateeq.Service.Pos.Lib.Models.SalesReturn;
using Com.Bateeq.Service.Pos.Lib.Models.Discount;

using Com.Moonlay.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Com.Bateeqshop.Lib
{
    public class BateeqshopDbContext : BaseDbContext
    {
        public BateeqshopDbContext(DbContextOptions<BateeqshopDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new MaterialsRequestNoteConfig());
            //modelBuilder.ApplyConfiguration(new MaterialsRequestNote_ItemConfig());
            //modelBuilder.ApplyConfiguration(new FpRegradingResultDocsDetailsConfig());
            //modelBuilder.ApplyConfiguration(new FpRegradingResultDocsConfig());
            //modelBuilder.ApplyConfiguration(new MaterialDistributionNoteConfig());
            //modelBuilder.ApplyConfiguration(new MaterialDistributionNoteItemConfig());
            //modelBuilder.ApplyConfiguration(new MaterialDistributionNoteDetailConfig());
            //modelBuilder.ApplyConfiguration(new StockTransferNoteConfig());
            //modelBuilder.ApplyConfiguration(new StockTransferNoteItemConfig());
            //modelBuilder.ApplyConfiguration(new FPReturnInvToPurchasingConfig());
            //modelBuilder.ApplyConfiguration(new FPReturnInvToPurchasingDetailConfig());
            //modelBuilder.ApplyConfiguration(new InventoryDocumentConfig());
            //modelBuilder.ApplyConfiguration(new InventoryDocumentItemConfig());
            //modelBuilder.ApplyConfiguration(new InventoryMovementConfig());
            //modelBuilder.ApplyConfiguration(new InventorySummaryConfig());
        }
    }
}