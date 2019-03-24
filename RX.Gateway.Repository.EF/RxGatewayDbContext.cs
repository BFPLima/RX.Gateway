using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RX.Gateway.Model.Core;
using RX.Gateway.Model.Enums;
using RX.Gateway.Model.Transaction;

namespace RX.Gateway.Repository.EF
{
    public partial class RxGatewayDbContext : DbContext
    {
        public RxGatewayDbContext()
        {
        }

        public RxGatewayDbContext(DbContextOptions<RxGatewayDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=root123456;Database=RxGateway");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<StoreAcquirier>()
    .HasKey(bc => new { bc.StoreObjectID, bc.AcquirierObjectID });

            modelBuilder.Entity<StoreAcquirier>()
                .HasOne(bc => bc.Store)
                .WithMany(b => b.Acquiriers)
                .HasForeignKey(bc => bc.StoreObjectID);


            modelBuilder.Entity<StoreAntiFraud>()
.HasKey(bc => new { bc.StoreObjectID, bc.AntiFraudObjectID });

            modelBuilder.Entity<StoreAntiFraud>()
            .HasOne(bc => bc.Store)
            .WithMany(b => b.AntiFrauds)
            .HasForeignKey(bc => bc.StoreObjectID);




            modelBuilder.Entity<ShopkeeperAcquirierCredcardBrand>()
       .HasKey(bc => new { bc.ShopkeeperID, bc.AcquirierID, bc.CreditCardBrand });

            modelBuilder.Entity<ShopkeeperAcquirierCredcardBrand>()
                .HasOne(bc => bc.Shopkeeper)
                .WithMany(b => b.AcquirierByBrand)
                .HasForeignKey(bc => bc.ShopkeeperID);

        }


        public DbSet<Acquirier> Acquiriers { get; set; }

        public DbSet<AntiFraud> AntiFrauds { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Shopkeeper> Shopkeepers { get; set; }

        public DbSet<CreditCardTransactionRegistry> TransactionRegistries { get; set; }

        public void InsertInitialData()
        {
            //using (RxGatewayDbContext this = new RxGatewayDbContext())
            //{


                var stone = new Acquirier()
                {
                    ObjectID = System.Guid.NewGuid(),
                    Name = "Stone"
                };

                var cielo = new Acquirier()
                {
                    ObjectID = System.Guid.NewGuid(),
                    Name = "Cielo"
                };


                this.Acquiriers.Add(stone);
                this.Acquiriers.Add(cielo);

                var clearSale = new AntiFraud()
                {
                    ObjectID = System.Guid.NewGuid(),
                    Name = "Clear Sale"
                };


                this.AntiFrauds.Add(clearSale);



                var zara = new Store()
                {
                    ObjectID = System.Guid.NewGuid(),
                    Name = "Zara"
                };

                zara.Acquiriers.Add(new StoreAcquirier
                {
                    Acquirier = stone,
                    AcquirierObjectID = stone.ObjectID,
                    Store = zara,
                    StoreObjectID = zara.ObjectID
                });

                zara.Acquiriers.Add(new StoreAcquirier
                {
                    Acquirier = cielo,
                    AcquirierObjectID = cielo.ObjectID,
                    Store = zara,
                    StoreObjectID = zara.ObjectID
                });

                this.Stores.Add(zara);

                //zara.AntiFrauds.Add(clearSale);


                var zaraFilial1 = new Shopkeeper()
                {
                    ObjectID = System.Guid.NewGuid(),
                    Name = "Zara filial 1"
                };

                zaraFilial1.AcquirierByBrand.Add(new ShopkeeperAcquirierCredcardBrand()
                {
                    Acquirier = cielo,
                    AcquirierID = cielo.ObjectID,
                    Shopkeeper = zaraFilial1,
                    ShopkeeperID = zaraFilial1.ObjectID,
                    CreditCardBrand = ECreditCardBrand.Master
                });


                zara.Shopkeepers.Add(zaraFilial1);

                this.Shopkeepers.Add(zaraFilial1);


                // context.SaveChanges();

           // }
        }

    }
}
