using Manero_Backend.Models.Auth;
using Manero_Backend.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Manero_Backend.Contexts
{
	public class ManeroDbContext : IdentityDbContext<AppUser>
	{
		public ManeroDbContext(DbContextOptions<ManeroDbContext> options) : base(options)
		{
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<AppUser>(appUser =>
			{
				appUser.HasMany(au => au.Addresses)
				.WithOne(a => a.AppUser)
				.HasForeignKey(a => a.AppUserId)
				.OnDelete(DeleteBehavior.NoAction);

				appUser.HasMany(au => au.UserPromoCodes)
				.WithOne(upc => upc.AppUser)
				.HasForeignKey(upc => upc.AppUserId)
				.OnDelete(DeleteBehavior.NoAction);

				appUser.HasMany(au => au.PaymentDetails)
				.WithOne(pd => pd.AppUser)
				.HasForeignKey(pd => pd.AppUserId)
				.OnDelete(DeleteBehavior.NoAction);

				appUser.HasMany(au => au.Orders)
				.WithOne(o => o.AppUser)
				.HasForeignKey(o => o.AppUserId)
				.OnDelete(DeleteBehavior.NoAction);


				appUser.HasMany(au => au.Reviews)
				.WithOne(r => r.AppUser)
				.HasForeignKey(r => r.AppUserId)
				.OnDelete(DeleteBehavior.NoAction);

				appUser.HasMany(au => au.WishList)
				.WithOne(wl => wl.AppUser)
				.HasForeignKey(wl => wl.AppUserId)
				.OnDelete(DeleteBehavior.NoAction);
			});

			modelBuilder.Entity<PromoCodeEntity>(promoCode =>
			{
				promoCode.HasMany(pc => pc.UserPromoCodes)
				.WithOne(upc => upc.PromoCode)
				.HasForeignKey(upc => upc.PromoCodeId)
				.OnDelete(DeleteBehavior.NoAction);

				promoCode.HasMany(pc => pc.Orders)
				.WithOne(o => o.PromoCode)
				.HasForeignKey(o => o.PromoCodeId)
				.OnDelete(DeleteBehavior.NoAction);

				

				promoCode.Property(pc => pc.Discount)
					.HasColumnType("decimal(3,2)");
				promoCode.HasIndex(x => x.Code)
						.IsUnique();
			});

			modelBuilder.Entity<CompanyEntity>(company =>
			{
				company.HasMany(c => c.PromoCodes)
				.WithOne(pc => pc.Company)
				.HasForeignKey(pc => pc.CompanyId)
				.OnDelete(DeleteBehavior.NoAction);

				company.HasMany(c => c.Products)
				.WithOne(p => p.Company)
				.HasForeignKey(p => p.CompanyId)
				.OnDelete(DeleteBehavior.NoAction);



				company.HasIndex(x => x.Name)
					.IsUnique();
			});

			modelBuilder.Entity<AddressEntity>(address =>
			{
				address.HasMany(a => a.Orders)
				.WithOne(o => o.Address)
				.HasForeignKey(o => o.AddressId)
				.OnDelete(DeleteBehavior.NoAction);
			});

			modelBuilder.Entity<TagEntity>(tag =>
			{
				tag.HasMany(t => t.TagProducts)
				.WithOne(tp => tp.Tag)
				.HasForeignKey(tp => tp.TagId)
				.OnDelete(DeleteBehavior.NoAction);

				tag.HasIndex(x => x.Name)
				.IsUnique();
			});

			modelBuilder.Entity<ProductEntity>(product =>
			{
				product.HasMany(p => p.TagProducts)
				.WithOne(tp => tp.Product)
				.HasForeignKey(tp => tp.ProductId)
				.OnDelete(DeleteBehavior.NoAction);


                product.HasMany(p => p.WishList)
                .WithOne(wl => wl.Product)
                .HasForeignKey(wl => wl.ProductId)
                .OnDelete(DeleteBehavior.NoAction);


                product.HasMany(p => p.OrderProducts)
                .WithOne(op => op.Product)
                .HasForeignKey(op => op.ProductId)
                .OnDelete(DeleteBehavior.NoAction);


                product.HasMany(p => p.Reviews)
                .WithOne(r => r.Product)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

				product.HasMany(p => p.ProductColors)
				.WithOne(pc => pc.Product)
				.HasForeignKey(pc => pc.ProductId)
				.OnDelete(DeleteBehavior.NoAction);

                product.HasMany(p => p.ProductSizes)
                .WithOne(ps => ps.Product)
                .HasForeignKey(ps => ps.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
            });

			modelBuilder.Entity<CategoryEntity>(category =>
			{
				category.HasMany(c => c.Products)
				.WithOne(p => p.Category)
				.HasForeignKey(p => p.CategoryId)
				.OnDelete(DeleteBehavior.NoAction);

				category.HasIndex(x => x.Name)
					.IsUnique();
			});

			modelBuilder.Entity<SizeEntity>(size => 
			{
				size.HasMany(s => s.OrderProducts)
				.WithOne(op => op.Size)
				.HasForeignKey(op => op.SizeId)
				.OnDelete(DeleteBehavior.NoAction);

				size.HasMany(s => s.ProductSizes)
				.WithOne(ps => ps.Size)
				.HasForeignKey(ps => ps.SizeId)
				.OnDelete(DeleteBehavior.NoAction);

				size.HasIndex(x => x.Name)
					.IsUnique();
				
			});

			modelBuilder.Entity<ColorEntity>(color => 
			{
				color.HasMany(c => c.OrderProducts)
				.WithOne(op => op.Color)
				.HasForeignKey(op => op.ColorId)
				.OnDelete(DeleteBehavior.NoAction);

				color.HasMany(c => c.ProductColors)
				.WithOne(pc => pc.Color)
				.HasForeignKey(pc => pc.ColorId)
				.OnDelete(DeleteBehavior.NoAction);

				
				color.HasIndex(x => x.Name)
					.IsUnique();
			});

			modelBuilder.Entity<OrderEntity>(order =>
			{
				order.HasMany(o => o.OrderProducts)
				.WithOne(op => op.Order)
				.HasForeignKey(op => op.OrderId)
				.OnDelete(DeleteBehavior.NoAction);

				order.HasMany(o => o.OrderStatuses)
				.WithOne(os => os.Order)
				.HasForeignKey(os => os.OrderId)
				.OnDelete(DeleteBehavior.NoAction);

				order.Property(o => o.TotalPrice)
				.HasColumnType("decimal(18,2)");

			});

			modelBuilder.Entity<OrderStatusTypeEntity>(orderStatusType =>
			{
				orderStatusType.HasMany(ost => ost.OrderStatuses)
				.WithOne(os => os.OrderStatusType)
				.HasForeignKey(os => os.OrderStatusTypeId)
				.OnDelete(DeleteBehavior.NoAction);

				orderStatusType.HasIndex(x => x.Name)
				.IsUnique();
			});

			modelBuilder.Entity<PaymentDetailEntity>(paymentDetail =>
			{
				paymentDetail.HasMany(pd => pd.Orders)
				.WithOne(o => o.PaymentDetail)
				.HasForeignKey(o => o.PaymentDetailId)
				.OnDelete(DeleteBehavior.NoAction);
			});

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AddressEntity> Addresses { get; set; }
		public DbSet<CategoryEntity> Categories { get; set; }
		public DbSet<ColorEntity> Colors { get; set; }
		public DbSet<CompanyEntity> Companies { get; set; }
		public DbSet<OrderEntity> Orders { get; set; }
		public DbSet<OrderProductEntity> OrderProducts { get; set; }
		public DbSet<OrderStatusEntity> OrderStatuses { get; set; }
		public DbSet<OrderStatusTypeEntity> OrderStatusTypes { get; set; }
		public DbSet<PaymentDetailEntity> PaymentDetails { get; set; }
		public DbSet<ProductEntity> Products { get; set; }
		public DbSet<PromoCodeEntity> PromoCodes { get; set; }
		public DbSet<ReviewEntity> Reviews { get; set; }
		public DbSet<SizeEntity> Sizes { get; set; }
		public DbSet<TagEntity> Tags { get; set; }
		public DbSet<TagProductEntity> TagProducts { get; set; }
		public DbSet<UserPromoCodeEntity> UserPromoCodes { get; set; }
		public DbSet<WishEntity> WishList { get; set; }

		public DbSet<ProductColorEntity> ProductColors { get; set; }
		public DbSet<ProductSizeEntity> ProductSizes { get; set; }
	}
}
