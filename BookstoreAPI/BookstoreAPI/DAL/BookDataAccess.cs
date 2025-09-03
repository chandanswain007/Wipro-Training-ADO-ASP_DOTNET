using BookstoreAPI.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace BookstoreAPI.DAL
{
    public class BookDataAccess
    {
        private readonly string _connectionString;

        public BookDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        // User Story 1 & 5: Get all books using SqlDataReader (Connected Architecture)
        public IEnumerable<Book> GetAllBooks()
        {
            var books = new List<Book>();
             using (SqlConnection con = new SqlConnection(_connectionString)) // Establishes connection [cite: 16]
            {
                // Using a stored procedure for retrieving data
                SqlCommand cmd = new SqlCommand("sp_GetAllBooks", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader()) // Uses SqlDataReader [cite: 18, 44]
                {
                    while (rdr.Read())
                    {
                        books.Add(new Book
                        {
                            Id = Convert.ToInt32(rdr["Id"]),
                            Title = rdr["Title"].ToString()!,
                            Author = rdr["Author"].ToString()!,
                            Price = Convert.ToDecimal(rdr["Price"])
                        });
                    }
                }
            }
            return books;
        }

        // User Story 1, 2 & 3: Add a new book using Stored Procedure
        public void AddBook(Book book)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                // Call stored procedure [cite: 27, 32]
                SqlCommand cmd = new SqlCommand("sp_AddBook", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Use parameterized queries to prevent SQL injection [cite: 23, 52]
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Price", book.Price);

                con.Open();
                cmd.ExecuteNonQuery(); // Implements Create operation [cite: 17]
            }
        }

        // User Story 1, 2 & 3: Update an existing book using Stored Procedure
        public void UpdateBook(Book book)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateBook", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Parameters protect against SQL injection [cite: 25]
                cmd.Parameters.AddWithValue("@Id", book.Id);
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Price", book.Price);

                con.Open();
                cmd.ExecuteNonQuery(); // Implements Update operation [cite: 17]
            }
        }

        // User Story 1, 2 & 3: Delete a book using Stored Procedure
        public void DeleteBook(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteBook", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery(); // Implements Delete operation [cite: 17]
            }
        }

        // User Story 4 & 5: Get all books using SqlDataAdapter (Disconnected Architecture)
        public DataSet GetAllBooksDisconnected()
        {
            DataSet ds = new DataSet(); // Use DataSet [cite: 36]
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                // Use SqlDataAdapter to fill the DataSet [cite: 38, 45]
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Books", con);
                da.Fill(ds, "Books");
            }
            return ds;
        }

        // User Story 4: Update database from a DataSet
        public void UpdateBooksFromDataSet(DataSet ds)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Books", con);

                // This command builder automatically generates Insert, Update, Delete commands
                // based on the select command. This is a powerful feature for disconnected data.
                SqlCommandBuilder builder = new SqlCommandBuilder(da);

                // Update the database with changes from the DataSet [cite: 40]
                da.Update(ds, "Books");
            }
        }
    }
}
