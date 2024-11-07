using GraphQLDemo.Data;
using GraphQLDemo.Models;
using HotChocolate;

namespace GraphQLDemo.Mutations
{
    public class Mutation
    {
        public readonly AppDbContext _context;
        public Mutation(AppDbContext context) => _context = context;
        public Book AddBook(BookInput bookInput)
        {
            var book = new Book { Title = bookInput.Title, Author = bookInput.Author };
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public Book UpdateBook(int id, BookInput bookInput)
        {
            var book = _context.Books.Find(id);
            if (book == null) throw new GraphQLException("Book not found");
            book.Title = bookInput.Title;
            book.Author = bookInput.Author;
            _context.SaveChanges();
            return book;
        }
    }
}
