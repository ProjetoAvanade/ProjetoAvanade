using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Senai_ProjetoAvanade_webAPI.Domains;

#nullable disable

namespace Senai_ProjetoAvanade_webAPI.Context
{
    public partial class AvanadeContext : DbContext
    {
        public AvanadeContext()
        {
        }

        public AvanadeContext(DbContextOptions<AvanadeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bicicletario> Bicicletarios { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Vaga> Vagas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=Default;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Bicicletario>(entity =>
            {
                entity.HasKey(e => e.IdBicicletario)
                    .HasName("PK__biciclet__F77125520BE8CE82");

                entity.ToTable("bicicletarios");

                entity.Property(e => e.IdBicicletario).HasColumnName("idBicicletario");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("bairro");

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cep");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("cidade");

                entity.Property(e => e.HorarioAberto).HasColumnName("horarioAberto");

                entity.Property(e => e.HorarioFechado).HasColumnName("horarioFechado");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("longitude");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rua");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.IdReserva)
                    .HasName("PK__reservas__94D104C813F73648");

                entity.ToTable("reservas");

                entity.Property(e => e.IdReserva).HasColumnName("idReserva");

                entity.Property(e => e.AbreTrava)
                    .HasColumnType("datetime")
                    .HasColumnName("abreTrava");

                entity.Property(e => e.FechaTrava)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaTrava");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.IdVaga).HasColumnName("idVaga");

                entity.Property(e => e.Preco)
                    .HasColumnType("smallmoney")
                    .HasColumnName("preco")
                    .HasDefaultValueSql("('0,00')");

                entity.Property(e => e.StatusPagamento)
                    .HasColumnName("statusPagamento")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__reservas__idUsua__33D4B598");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdVaga)
                    .HasConstraintName("FK__reservas__idVaga__34C8D9D1");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFF3E73C841");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.TipoUsuario1, "UQ__tipoUsua__A9585C053531AF58")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.TipoUsuario1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuarios__645723A6EA2CD452");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.Email, "UQ__usuarios__AB6E6164665CA579")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__usuarios__D836E71F32E069B0")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cpf")
                    .IsFixedLength(true);

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("dataNascimento");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Imagem)
                    .HasMaxLength(235)
                    .IsUnicode(false)
                    .HasColumnName("imagem");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.Pontos)
                    .HasColumnName("pontos")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Saldo)
                    .HasColumnType("smallmoney")
                    .HasColumnName("saldo")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuarios__idTipo__29572725");
            });

            modelBuilder.Entity<Vaga>(entity =>
            {
                entity.HasKey(e => e.IdVaga)
                    .HasName("PK__vagas__02E6F4AABB12C6C2");

                entity.ToTable("vagas");

                entity.Property(e => e.IdVaga).HasColumnName("idVaga");

                entity.Property(e => e.IdBicicletario).HasColumnName("idBicicletario");

                entity.Property(e => e.StatusVaga)
                    .HasColumnName("statusVaga")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdBicicletarioNavigation)
                    .WithMany(p => p.Vagas)
                    .HasForeignKey(d => d.IdBicicletario)
                    .HasConstraintName("FK__vagas__idBicicle__300424B4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
