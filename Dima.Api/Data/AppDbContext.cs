using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Dima.Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; } = null!; 
        public DbSet<Transaction> Transactions { get; set; } = null!; // Indica que não vai ser nulo. Meio que diz ao programa que você cuidará para que não seja nulo.
        protected override void OnModelCreating(ModelBuilder modelBuilder) // Roda no momento da criação das tabelas
        {
            //APLICANDO OS MAPEAMENTOS (PASTA: DATA/MAPPINGS)
            // 1 OPÇÃO: (Nesse caso você especifica o que quer mapear)

            //modelBuilder.ApplyConfiguration(new TransactionMapping());
            //modelBuilder.ApplyConfiguration(new CategoryMapping());

            //2 OPÇÃO:
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //Nesse caso ele busca todos os itens dentro do assembly que herdem da Interface IEntityTypeConfiguration (interface do mapeamento)
        }
    }
}
