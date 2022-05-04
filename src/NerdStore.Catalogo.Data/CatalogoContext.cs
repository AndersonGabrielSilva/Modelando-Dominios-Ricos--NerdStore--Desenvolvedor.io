using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.Data;
using NerdStore.Core.Messages;

namespace NerdStore.Catalogo.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options)
            : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // É uma boa pratica realizar está configuração
            // Pega todas as entidades mapeadas, verificar quais são do tipo string e mapear automaticamente todas para varchar(100)
            // Caso o tamanho não seja 100 basta apenas configurar para cada propriedade expecifica
            // desta forma evita ficar criando tipos nvarchar(MAX)
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.Relational().ColumnType = "varchar(100)";

            modelBuilder.Ignore<Event>();

            //Forma de registrar os Mappings de categoria e produto
            //Busca dentro do assembly todas as classes que possui a Interface IEntityTypeConfiguration<T>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            /*Sempre quando for realizar um commit, o EF irá buscar todas as entidades que possui DataCadastro.
             Caso esteja como EntityState.Add
                - Vai jogar o DateTime.Now
            Caso esteja com o EntityState.Modified
                - não irá permir alterar está data */
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            
            //Salva os Trackers
            return await base.SaveChangesAsync() > 0;
        }
    }
}