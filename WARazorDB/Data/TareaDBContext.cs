using Microsoft.EntityFrameworkCore;
using WARazorDB.Models;

namespace WARazorDB.Data
{
    public class TareaDbContext : DbContext
    {
        public TareaDbContext(DbContextOptions<TareaDbContext> options) : base(options) //Tarea investigar
        {
        }

        public DbSet<Tarea> Tareas { get; set; }  //Investigar
    }
}
