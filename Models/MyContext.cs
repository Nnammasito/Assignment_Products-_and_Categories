#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace Assignment_Products__and_Categories.Models;

// la clase MyContext representa una sesión con nuestra base de datos MySQL, lo que nos permite consultar o guardar datos
// DbContext es una clase que proviene de EntityFramework, queremos heredar sus características
public class MyContext : DbContext
{
    // Esta línea siempre estará aquí. Es lo que construye nuestro contexto tras la inicialización.
    public MyContext(DbContextOptions options) : base(options) { }
    // Necesitamos crear un nuevo DbSet<Model> para cada modelo de nuestro proyecto que esté creando una tabla
    // El nombre de nuestra tabla en nuestra base de datos se basará en el nombre que proporcionemos aquí
    // Aquí es donde proporcionamos una versión plural de nuestro modelo para ajustarse a los estándares de nomenclatura de tablas
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Association> Associations { get; set; }

}