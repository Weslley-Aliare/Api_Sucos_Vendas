using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication1
{
    public partial class SUCOS_VENDASContext : DbContext
    {
        public SUCOS_VENDASContext()
        {
        }

        public SUCOS_VENDASContext(DbContextOptions<SUCOS_VENDASContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ItensNotasFiscai> ItensNotasFiscais { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<NotasFiscai> NotasFiscais { get; set; }
        public virtual DbSet<TabelaDeCliente> TabelaDeClientes { get; set; }
        public virtual DbSet<TabelaDeProduto> TabelaDeProdutos { get; set; }
        public virtual DbSet<TabelaDeVendedore> TabelaDeVendedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Password=@Nicolas2018;Persist Security Info=True;User ID=sa;Initial Catalog=SUCOS_VENDAS;Data Source=NTB-6NHXQK3");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItensNotasFiscai>(entity =>
            {
                entity.HasKey(e => new { e.Numero, e.CodigoDoProduto });

                entity.ToTable("ITENS NOTAS FISCAIS");

                entity.Property(e => e.Numero).HasColumnName("NUMERO");

                entity.Property(e => e.CodigoDoProduto)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CODIGO DO PRODUTO");

                entity.Property(e => e.Preço).HasColumnName("PREÇO");

                entity.Property(e => e.Quantidade).HasColumnName("QUANTIDADE");

                entity.HasOne(d => d.CodigoDoProdutoNavigation)
                    .WithMany(p => p.ItensNotasFiscais)
                    .HasForeignKey(d => d.CodigoDoProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ITENS NOTAS FISCAIS_TABELA DE PRODUTOS");

                entity.HasOne(d => d.NumeroNavigation)
                    .WithMany(p => p.ItensNotasFiscais)
                    .HasForeignKey(d => d.Numero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ITENS NOTAS FISCAIS_NOTAS FISCAIS");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("Login");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Login1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Login")
                    .IsFixedLength(true);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<NotasFiscai>(entity =>
            {
                entity.HasKey(e => e.Numero);

                entity.ToTable("NOTAS FISCAIS");

                entity.Property(e => e.Numero)
                    .ValueGeneratedNever()
                    .HasColumnName("NUMERO");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.Data)
                    .HasColumnType("date")
                    .HasColumnName("DATA");

                entity.Property(e => e.Imposto).HasColumnName("IMPOSTO");

                entity.Property(e => e.Matricula)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MATRICULA");

                entity.HasOne(d => d.CpfNavigation)
                    .WithMany(p => p.NotasFiscais)
                    .HasForeignKey(d => d.Cpf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOTAS FISCAIS_TABELA DE CLIENTES");

                entity.HasOne(d => d.MatriculaNavigation)
                    .WithMany(p => p.NotasFiscais)
                    .HasForeignKey(d => d.Matricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOTAS FISCAIS_TABELA DE VENDEDORES");
            });

            modelBuilder.Entity<TabelaDeCliente>(entity =>
            {
                entity.HasKey(e => e.Cpf)
                    .HasName("PK_CLIENTES");

                entity.ToTable("TABELA DE CLIENTES");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BAIRRO");

                entity.Property(e => e.Cep)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CEP");

                entity.Property(e => e.Cidade)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CIDADE");

                entity.Property(e => e.DataDeNascimento)
                    .HasColumnType("date")
                    .HasColumnName("DATA DE NASCIMENTO");

                entity.Property(e => e.Endereco1)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("ENDERECO 1");

                entity.Property(e => e.Endereco2)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("ENDERECO 2");

                entity.Property(e => e.Estado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ESTADO");

                entity.Property(e => e.Idade).HasColumnName("IDADE");

                entity.Property(e => e.LimiteDeCredito)
                    .HasColumnType("money")
                    .HasColumnName("LIMITE DE CREDITO");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOME");

                entity.Property(e => e.PrimeiraCompra).HasColumnName("PRIMEIRA COMPRA");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SEXO");

                entity.Property(e => e.VolumeDeCompra).HasColumnName("VOLUME DE COMPRA");
            });

            modelBuilder.Entity<TabelaDeProduto>(entity =>
            {
                entity.HasKey(e => e.CodigoDoProduto);

                entity.ToTable("TABELA DE PRODUTOS");

                entity.Property(e => e.CodigoDoProduto)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CODIGO DO PRODUTO");

                entity.Property(e => e.Embalagem)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EMBALAGEM");

                entity.Property(e => e.NomeDoProduto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME DO PRODUTO");

                entity.Property(e => e.PreçoDeLista)
                    .HasColumnType("smallmoney")
                    .HasColumnName("PREÇO DE LISTA");

                entity.Property(e => e.Sabor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SABOR");

                entity.Property(e => e.Tamanho)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TAMANHO");
            });

            modelBuilder.Entity<TabelaDeVendedore>(entity =>
            {
                entity.HasKey(e => e.Matricula)
                    .HasName("PK_VENDEDORES");

                entity.ToTable("TABELA DE VENDEDORES");

                entity.Property(e => e.Matricula)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MATRICULA");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BAIRRO");

                entity.Property(e => e.DataAdmissão)
                    .HasColumnType("date")
                    .HasColumnName("DATA ADMISSÃO");

                entity.Property(e => e.DeFerias).HasColumnName("DE FERIAS");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOME");

                entity.Property(e => e.PercentualComissão).HasColumnName("PERCENTUAL COMISSÃO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
