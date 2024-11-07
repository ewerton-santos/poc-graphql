using GraphQLDemo.Data;
using GraphQLDemo.Models;
using System.Linq;

namespace GraphQLDemo.Queries
{
    public class Query
    {
        private readonly AppDbContext _context;
        public Query(AppDbContext context) => _context = context;             
        public IQueryable<Book> GetBooks() => _context.Books.AsQueryable();                
        public Book GetBookById(int id) => _context.Books.FirstOrDefault(b => b.Id == id);                
        public int GetTotalBooks() => _context.Books.Count();
    }
}