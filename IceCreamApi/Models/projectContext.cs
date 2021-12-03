using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace IceCreamApi.Models
{
    public partial class projectContext : DbContext
    {
        public projectContext()
        {
        }

        public projectContext(DbContextOptions<projectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookIceCream> BookIceCreams { get; set; }
        public virtual DbSet<BookPayment> BookPayments { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MemberOption> MemberOptions { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=project;User=sa;Password=1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BookIceCream>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__BookIceC__3DE0C2276C50643D");

                entity.ToTable("BookIceCream");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.Author)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateAt).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Image)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BookPayment>(entity =>
            {
                entity.ToTable("BookPayment");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdMember).HasColumnName("Id_Member");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasOne(d => d.IdMemberNavigation)
                    .WithMany(p => p.BookPayments)
                    .HasForeignKey(d => d.IdMember)
                    .HasConstraintName("FK_BookPayment_Member");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("Member");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdMemberOption).HasColumnName("Id_MemberOption");

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RegisterDay).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMemberOptionNavigation)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.IdMemberOption)
                    .HasConstraintName("FK_Member_MemberOption");
            });

            modelBuilder.Entity<MemberOption>(entity =>
            {
                entity.ToTable("MemberOption");

                entity.Property(e => e.Day)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.MemberOption1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MemberOption");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.ToTable("Page");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("Recipe");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ingredents).HasColumnType("text");

                entity.Property(e => e.Preparation).HasColumnType("text");

                entity.Property(e => e.Thumbnail)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
