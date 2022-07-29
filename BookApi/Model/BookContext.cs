using Microsoft.EntityFrameworkCore;

namespace BookApi.Model
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
            //Se existir nenhuma ação sera iniciada, caso contrario será criado todp esquema do banco de dados
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }
    }
}
