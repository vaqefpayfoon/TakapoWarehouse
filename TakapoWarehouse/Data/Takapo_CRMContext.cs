using System;
using Microsoft.EntityFrameworkCore;
using TakapoWarehouse.Models;

namespace TakapoWarehouse.Data
{
    public partial class Takapo_CRMContext : DbContext
    {
        public Takapo_CRMContext()
        {
        }

        public Takapo_CRMContext(DbContextOptions<Takapo_CRMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BasCity> BasCities { get; set; }
        public virtual DbSet<BasCountry> BasCountries { get; set; }
        public virtual DbSet<BasSupcust> BasSupcusts { get; set; }
        public virtual DbSet<BasSupcustGood> BasSupcustGoods { get; set; }
        public virtual DbSet<BasSupcustType> BasSupcustTypes { get; set; }
        public virtual DbSet<IngredientsWarehouse> IngredientsWarehouses { get; set; }
        public virtual DbSet<IngredientDoc> IngredientDocs { get; set; }
        public virtual DbSet<InvBrand> InvBrands { get; set; }
        public virtual DbSet<InvGood> InvGoods { get; set; }
        public virtual DbSet<HplPersonal> HplPersonals{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=CRM;Initial Catalog=Takapo_CRM;User ID=sa;Password=V@qef2512740");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Persian_100_BIN");
            modelBuilder.Entity<BasCity>(entity =>
            {
                entity.HasKey(e => e.Srl);

                entity.ToTable("bas_city");

                entity.Property(e => e.Srl).HasColumnName("srl");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("city_name");
            });
            modelBuilder.Entity<HplPersonal>(entity =>
            {
                entity.HasKey(e => e.Srl);

                entity.ToTable("hpl_personal");

                entity.Property(e => e.Srl).HasColumnName("srl");
                entity.Property(e => e.UDateTime).HasColumnName("u_date_time");
                entity.Property(e => e.NameHpl).HasColumnName("name_hpl");
                entity.Property(e => e.NoHpl).HasColumnName("no_hpl");
                entity.Property(e => e.MobileNo).HasColumnName("mobile_no");
                entity.Property(e => e.TelNo).HasColumnName("tel_no");
                entity.Property(e => e.AddressHpl).HasColumnName("address_hpl");
                entity.Property(e => e.FatherName).HasColumnName("father_name");
                entity.Property(e => e.UserName).HasColumnName("user_name");
                entity.Property(e => e.PassCode).HasColumnName("pass_code");
                entity.Property(e => e.MeliCode).HasColumnName("meli_code");
                entity.Property(e => e.IdNo).HasColumnName("id_no");
                entity.Property(e => e.MailAddress).HasColumnName("mail_address");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.BusinessKind).HasColumnName("business_kind");
                entity.Property(e => e.UserPermission).HasColumnName("user_permission");
                entity.Property(e => e.Section).HasColumnName("section");

            });
            modelBuilder.Entity<BasCountry>(entity =>
            {
                entity.HasKey(e => e.Srl);

                entity.ToTable("bas_country");

                entity.Property(e => e.Srl).HasColumnName("srl");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("country_name");
            });
            modelBuilder.Entity<BasSupcust>(entity =>
            {
                entity.HasKey(e => e.Srl);

                entity.ToTable("bas_supcust");

                entity.Property(e => e.Srl).HasColumnName("srl");

                entity.Property(e => e.Address1)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("address1");

                entity.Property(e => e.Describe)
                    .IsUnicode(false)
                    .HasColumnName("describe");

                entity.Property(e => e.EMail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("e_mail");

                entity.Property(e => e.EconomicNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("economic_no");

                entity.Property(e => e.Fax1)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("fax1");

                entity.Property(e => e.IdNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_no");

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("mobile_no")
                    .IsFixedLength(true);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("pass");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("post_code");

                entity.Property(e => e.RegisterNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("register_no");

                entity.Property(e => e.RelatedPerson)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("related_person");

                entity.Property(e => e.SrlCity).HasColumnName("srl_city");

                entity.Property(e => e.SrlCountry).HasColumnName("srl_country");

                entity.Property(e => e.SupcustCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("supcust_code");

                entity.Property(e => e.SupcustName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("supcust_name")
                    .IsFixedLength(true);

                entity.Property(e => e.Tel1)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("tel1");

                entity.Property(e => e.Tel2)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("tel2");

                entity.Property(e => e.TypeSrl).HasColumnName("type_srl");

                entity.Property(e => e.UDateTime)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("u_date_time")
                    .IsFixedLength(true);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.Property(e => e.WebAdr)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("web_adr");

                entity.HasOne(d => d.SrlCityNavigation)
                    .WithMany(p => p.BasSupcusts)
                    .HasForeignKey(d => d.SrlCity)
                    .HasConstraintName("FK_supcust_srl_city");

                entity.HasOne(d => d.SrlCountryNavigation)
                    .WithMany(p => p.BasSupcusts)
                    .HasForeignKey(d => d.SrlCountry)
                    .HasConstraintName("FK_supcust_srl_country");

                entity.HasOne(d => d.TypeSrlNavigation)
                    .WithMany(p => p.BasSupcusts)
                    .HasForeignKey(d => d.TypeSrl)
                    .HasConstraintName("FK__type_srl_supcust");
            });
            modelBuilder.Entity<BasSupcustGood>(entity =>
            {
                entity.HasKey(e => e.Srl)
                    .HasName("PK_supcust_goods");

                entity.ToTable("bas_supcust_goods");

                entity.HasIndex(e => e.BasscSrl, "supcust_srl_bas_supcust_goods");

                entity.Property(e => e.Srl)
                    .ValueGeneratedNever()
                    .HasColumnName("srl");

                entity.Property(e => e.BasscSrl).HasColumnName("bassc_srl");

                entity.Property(e => e.CellPhone)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cell_phone")
                    .IsFixedLength(true);

                entity.Property(e => e.Describe)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("describe");

                entity.Property(e => e.DeviceLocate)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("device_locate");

                entity.Property(e => e.FileNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("file_no");

                entity.Property(e => e.IgdSrl).HasColumnName("igd_srl");

                entity.Property(e => e.InstallDate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("install_date")
                    .IsFixedLength(true);

                entity.Property(e => e.Model)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("model");

                entity.Property(e => e.MoveDeviceDate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("move_device_date")
                    .IsFixedLength(true);

                entity.Property(e => e.Occupation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("occupation");

                entity.Property(e => e.RelatedPerson)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("related_person");

                entity.Property(e => e.Serial)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("serial");

                entity.Property(e => e.Tel)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("tel")
                    .IsFixedLength(true);

                entity.HasOne(d => d.BasscSrlNavigation)
                    .WithMany(p => p.BasSupcustGoods)
                    .HasForeignKey(d => d.BasscSrl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bassc_srl_supcust_goods");

                entity.HasOne(d => d.IgdSrlNavigation)
                    .WithMany(p => p.BasSupcustGoods)
                    .HasForeignKey(d => d.IgdSrl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__igd_srl_supcust_goods");
            });
            modelBuilder.Entity<BasSupcustType>(entity =>
            {
                entity.HasKey(e => e.Srl);

                entity.ToTable("bas_supcust_type");

                entity.Property(e => e.Srl).HasColumnName("srl");

                entity.Property(e => e.SupcustType)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("supcust_type");
            });
            modelBuilder.Entity<IngredientsWarehouse>(entity =>
            {
                entity.HasKey(e => e.Srl);

                entity.ToTable("IngredientsWarehouse");

                entity.Property(e => e.Srl)
                    .ValueGeneratedNever()
                    .HasColumnName("srl");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IngredientsName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GoodsModel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PartNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StockIngredients)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Barcode)
                    .HasMaxLength(int.MaxValue)
                    .IsUnicode(false);

                entity.Property(e => e.SerialNo)
                    .HasMaxLength(int.MaxValue)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<IngredientDoc>(entity =>
            {
                entity.HasKey(e => e.Srl);

                entity.ToTable("IngredientDoc");

                entity.Property(e => e.Srl).HasColumnName("srl");

                entity.Property(e => e.DocDate)
                    .IsUnicode(false)
                    .HasColumnName("doc_date");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DocType)
                    .IsUnicode(false)
                    .HasColumnName("doc_type");

                entity.Property(e => e.HplSrl).HasColumnName("hpl_srl");
                entity.Property(e => e.IngredientSrl).HasColumnName("ingredient_srl");

                entity.HasOne(d => d.SrlPersonalNavigation)
                    .WithMany(p => p.IngredientDocs)
                    .HasForeignKey(d => d.HplSrl)
                    .HasConstraintName("FK_Personel_srl");

                entity.HasOne(d => d.SrlIngredientsWarehouseNavigation)
                    .WithMany(p => p.IngredientDocs)
                    .HasForeignKey(d => d.IngredientSrl)
                    .HasConstraintName("FK_IngredientsWarehouse_srl");
            });
            modelBuilder.Entity<InvBrand>(entity =>
            {
                entity.HasKey(e => e.Srl);

                entity.ToTable("inv_brand");

                entity.Property(e => e.Srl).HasColumnName("srl");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("brand_name");
            });
            modelBuilder.Entity<InvGood>(entity =>
            {
                entity.HasKey(e => e.Srl);

                entity.ToTable("inv_goods");

                entity.Property(e => e.Srl).HasColumnName("srl");

                entity.Property(e => e.CodeIgd)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("code_igd");

                entity.Property(e => e.GoodsType).HasColumnName("goods_type");

                entity.Property(e => e.HplSrl).HasColumnName("hpl_srl");

                entity.Property(e => e.IbtSrl).HasColumnName("ibt_srl");

                entity.Property(e => e.SrlCountry).HasColumnName("srl_country");

                entity.Property(e => e.TitleIgd)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("title_igd");

                entity.Property(e => e.UDateTime)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("u_date_time")
                    .IsFixedLength(true);

                entity.Property(e => e.UseType).HasColumnName("use_type");

                entity.HasOne(d => d.IbtSrlNavigation)
                    .WithMany(p => p.InvGoods)
                    .HasForeignKey(d => d.IbtSrl)
                    .HasConstraintName("FK__ibt_srl_goods");

                entity.HasOne(d => d.SrlCountryNavigation)
                    .WithMany(p => p.InvGoods)
                    .HasForeignKey(d => d.SrlCountry)
                    .HasConstraintName("FK__srl_country");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
