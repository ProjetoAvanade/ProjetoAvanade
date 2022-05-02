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
<<<<<<< HEAD
                optionsBuilder.UseSqlServer("Data Source=NOTE0113F1\\SQLEXPRESS; initial catalog=db-gp11; user Id=sa; pwd=Senai@132;", x => x.UseNetTopologySuite());
=======
                optionsBuilder.UseSqlServer("Data Source=DAREDE-000850\\SQLEXPRESS; initial catalog=db-gp11; user Id=sa; pwd=D@06341610;", x => x.UseNetTopologySuite());
>>>>>>> 57063acbb5bd09bf6d29af4ac888c77212e9d84e
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Bicicletario>(entity =>
            {
                entity.HasKey(e => e.IdBicicletario)
<<<<<<< HEAD
                    .HasName("PK__biciclet__F7712552E2A2EAFF");
=======
                    .HasName("PK__biciclet__F7712552727CFC12");
>>>>>>> 57063acbb5bd09bf6d29af4ac888c77212e9d84e

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

<<<<<<< HEAD
                entity.Property(e => e.Latlong)
                    .HasColumnType("geometry")
                    .HasColumnName("latlong");
=======
                entity.Property(e => e.Latlong).HasColumnName("latlong");
>>>>>>> 57063acbb5bd09bf6d29af4ac888c77212e9d84e

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
<<<<<<< HEAD
                    .HasName("PK__reservas__94D104C8D89572ED");
=======
                    .HasName("PK__reservas__94D104C8D0334095");
>>>>>>> 57063acbb5bd09bf6d29af4ac888c77212e9d84e

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
<<<<<<< HEAD
                    .HasName("PK__tipoUsua__03006BFF0B011E91");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.TipoUsuario1, "UQ__tipoUsua__A9585C0581252269")
=======
                    .HasName("PK__tipoUsua__03006BFF1C92B767");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.TipoUsuario1, "UQ__tipoUsua__A9585C0559F1A72A")
>>>>>>> 57063acbb5bd09bf6d29af4ac888c77212e9d84e
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
<<<<<<< HEAD
                    .HasName("PK__usuarios__645723A698D121C2");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.Email, "UQ__usuarios__AB6E6164D8DEF54E")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__usuarios__D836E71F960CC456")
=======
                    .HasName("PK__usuarios__645723A636F86F7E");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.Email, "UQ__usuarios__AB6E6164267EA037")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__usuarios__D836E71FE751131A")
>>>>>>> 57063acbb5bd09bf6d29af4ac888c77212e9d84e
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
<<<<<<< HEAD
                    .HasName("PK__vagas__02E6F4AA8D07A5BC");
=======
                    .HasName("PK__vagas__02E6F4AA135B0E25");
>>>>>>> 57063acbb5bd09bf6d29af4ac888c77212e9d84e

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
