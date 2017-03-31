using WEB_ASP_TP3.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WEB_ASP_TP3.Repository
{

    public interface ILivroRepository  {


        IEnumerable<Livro> GetAllLivros();
        void CreateLivro(Livro livro);
        void DeleteLivro(int Id);
        void EditLivro(Livro livro);
        Livro GetOneLivro(int Id);

    }


    public class LivroRepository : ILivroRepository
    {
        public string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Banco2.mdf;Integrated Security=True";



        public IEnumerable<Livro> GetAllLivros()
        {

            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "SELECT * FROM Livro";
                var selectCommand = new SqlCommand(commandText, connection);

                Livro livro = null;
                var livros = new List<Livro>();

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            livro = new Livro();
                            livro.Id = (int)reader["Id"];
                            livro.Titulo = reader["Titulo"].ToString();
                            livro.Autor = reader["Autor"].ToString();
                            livro.Editora = reader["Editora"].ToString();
                            livro.Ano = (int)reader["Ano"];

                            livros.Add(livro);
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }

                return livros;

            }
        }

        public void CreateLivro(Livro livro)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "INSERT INTO Livro (Titulo, Autor, Editora, Ano, Anotacao) VALUES (@Titulo, @Autor, @Editora, @Ano, @Anotacao)";
                var insertCommand = new SqlCommand(commandText, connection);
                insertCommand.Parameters.AddWithValue("@Titulo", livro.Titulo);
                insertCommand.Parameters.AddWithValue("@Autor", livro.Autor);
                insertCommand.Parameters.AddWithValue("@Editora", livro.Editora);
                insertCommand.Parameters.AddWithValue("@Ano", livro.Ano);
                insertCommand.Parameters.AddWithValue("@Anotacao", livro.Anotacao);

                try
                {
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void DeleteLivro(int Id)
        {


            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = string.Format(/*"DELETE FROM Livro WHERE Id = @Id "
                 */
                " DELETE FROM Livro WHERE Id = {0} ", Id);
                var insertCommand = new SqlCommand(commandText, connection);
                try
                {
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void EditLivro(Livro livro)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string commandText = "UPDATE Livro SET Titulo=@Titulo, Autor=@Autor, Editora=@Editora, Ano=@Ano, Anotacao=@Anotacao Where Id=@Id";
                var selectCommand = new SqlCommand(commandText, connection);
                selectCommand.Parameters.AddWithValue("@Id", livro.Id);
                selectCommand.Parameters.AddWithValue("@Titulo", livro.Titulo);
                selectCommand.Parameters.AddWithValue("@Autor", livro.Autor);
                selectCommand.Parameters.AddWithValue("@Editora", livro.Editora);
                selectCommand.Parameters.AddWithValue("@Ano", livro.Ano);
                selectCommand.Parameters.AddWithValue("@Anotacao", livro.Anotacao);
                try
                {
                    connection.Open();
                    selectCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public Livro GetOneLivro(int Id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string commandText = "Select Id, Titulo, Autor, Editora, Ano, Anotacao FROM Livro WHERE Id=@Id";
                var selectCommand = new SqlCommand(commandText, connection);
                selectCommand.Parameters.AddWithValue("@Id", Id);
                Livro livro = null;
                try
                {
                    connection.Open();
                    using (var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                livro = new Livro();
                                livro.Id = (int)reader["Id"];
                                livro.Titulo = reader["Titulo"].ToString();
                                livro.Autor = reader["Autor"].ToString();
                                livro.Editora = reader["Editora"].ToString();
                                livro.Ano = (int)reader["Ano"];
                                livro.Anotacao = reader["Anotacao"].ToString(); 
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return livro;
            }
        }
    }
}
