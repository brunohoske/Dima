using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category> //Mapeando a criação da tabela Categories.
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category"); //Diz o nome da tabela
            builder.HasKey(x => x.Id); //Indica que terá uma chave primaria no ID da category

            builder.Property(x => x.Title) //Cria a coluna para title
                .IsRequired() //Indica que ele é obrigatorio
                .HasColumnType("NVARCHAR") //Indica o tipo da coluna
                .HasMaxLength(80); //Indica o maximo de caracteres da coluna

            builder.Property(x => x.Description)
               .IsRequired(false) // Indica que não é obrigatorio o preenchimento
               .HasColumnType("NVARCHAR")
               .HasMaxLength(255);

            builder.Property(x => x.UserId)
               .IsRequired(true)
               .HasColumnType("NVARCHAR")
               .HasMaxLength(160);

        }
    }
}
