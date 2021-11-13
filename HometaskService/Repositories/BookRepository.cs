using HometaskService.DBModels;
using HometaskService.ModelsDTO;
using HometaskService.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace HometaskService.Repositories
{
    public class BookRepository : IBookRepository
    {
        private const string connectionString = "Server=ASYAGRAFPC\\SQLEXPRESS;Database=DBBook;Trusted_Connection=True";
        public async Task Create(BookDTO book)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"INSERT INTO Books VALUES ('{book.Name}', '{book.Author}')";
                SqlCommand command = new SqlCommand(query, connection);
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"DELETE FROM Books WHERE Id = {id}";
                SqlCommand command = new SqlCommand(query, connection);
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        public async Task<DBBook> Get(int id)
        {
            DBBook book = null;

            try
            {
                await using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"SELECT * FROM Books WHERE Id = {id}";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                reader.Read();
                book = new DBBook()
                {
                    Id = int.Parse(reader[0].ToString()),
                    Name = reader[1].ToString(),
                    Author = reader[2].ToString()
                };
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            return book;
        }

        public async Task<List<DBBook>> GetAll()
        {
            List<DBBook> books = new List<DBBook>();

            try
            {
                await using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"SELECT * FROM Books";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    books.Add(new DBBook()
                    {
                        Id = int.Parse(reader[0].ToString()),
                        Name = reader[1].ToString(),
                        Author = reader[2].ToString()
                    });
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            return books;
        }

        public async Task Update(DBBook book)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"UPDATE Books SET Name = '{book.Name}', Author = '{book.Author}' WHERE Id = {book.Id}";
                SqlCommand command = new SqlCommand(query, connection);
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
