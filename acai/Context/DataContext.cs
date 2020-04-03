using acai.Models;
using Microsoft.EntityFrameworkCore;

namespace acai.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DataContext()
            
        {

        }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoItem> PedidoItem { get; set; }
        public DbSet<PedidoItemAdicional> PedidoItemAdicional { get; set; }
        public DbSet<Tamanho> Tamanho { get; set; }
        public DbSet<Sabor> Sabor { get; set; }
        public DbSet<Adicional> Adicional { get; set; }

    }
}
