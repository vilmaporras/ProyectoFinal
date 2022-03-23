using Microsoft.EntityFrameworkCore;
using WEB_Core_Conv2.Models;

namespace WEB_Core_Conv2.Data
{
    //Heredando de la clase DbContext
    public class MyDbContext : DbContext 
    {
        //punto de inicializaciòn de la clase
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
           
        }
        public DbSet<Producto> Producto
        {
            get;
            set;
        }
        public DbSet<Categoria> Categoria
        {
            get;
            set;
        }
        public DbSet<Modulo> Modulo
        {
            get;
            set;
        }
    }
}
