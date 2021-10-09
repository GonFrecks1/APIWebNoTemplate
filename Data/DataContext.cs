using Microsoft.EntityFrameworkCore;
using WebApiCRUD.Models;

namespace WebApiCRUD.Data.Interfaces
{
    public class DataContext : DbContext
    {
        // Constructor con Inyeccion de Dependencia
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        // Agregamos los DbSets
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}