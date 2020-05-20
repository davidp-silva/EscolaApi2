using Ds.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Data.Mappings
{
    public class PessoaMappings : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NomeCompleto)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(p => p.Documento).HasColumnType("varchar(50)");

            builder.Property(p => p.DataNascimento).IsRequired();

            builder.Property(p => p.Telefone).HasColumnType("varchar(50)");
            // 1 : 1 => Fornecedor : Endereco
            builder.HasOne(f => f.Endereco)
                .WithOne(e => e.Pessoa);


            builder.ToTable("Pessoal");
        }
    }
}
