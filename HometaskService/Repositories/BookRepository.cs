using HometaskService.DBModels;
using HometaskService.ModelsDTO;
using HometaskService.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HometaskService.Repositories
{
    public class BookRepository : IBookRepository
    {
        private const string connectionString = "Server=ASYAGRAFPC\\SQLEXPRESS;Database=DBBook;Trusted_Connection=True";
        public void Create(BookDTO book)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"INSERT INTO Books VALUES ('{book.Name}', '{book.Author}')";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"DELETE FROM Books WHERE Id = {id}";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        public DBBook Get(int id)
        {
            DBBook book = null;

            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"SELECT * FROM Books WHERE Id = {id}";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
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

        public List<DBBook> GetAll()
        {
            List<DBBook> books = new List<DBBook>();

            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"SELECT * FROM Books";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
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

        public void Update(DBBook book)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"UPDATE Books SET Name = '{book.Name}', Author = '{book.Author}' WHERE Id = {book.Id}";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
