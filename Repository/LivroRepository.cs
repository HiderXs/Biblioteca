using ConsoleApp1.DataConnection;
using ConsoleApp1.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Repository
{
    internal class LivroRepository
    {
        DatabaseConnection databaseConnection = new DatabaseConnection();

        public void AdicionarLivro(Livro livro)
        {
            try
            {
                using var connection = databaseConnection.GetConnection();

                connection.Open();

                string sql = """
                INSERT INTO livros (titulo, autor, ano_publi, genero, quantidade)
                VALUES (@titulo, @autor, @ano_publi, @genero, @quantidade)
                """;

                using var command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@titulo", livro.Titulo);
                command.Parameters.AddWithValue("@autor", livro.Autor);
                command.Parameters.AddWithValue("@ano_publi", livro.AnoPublicacao);
                command.Parameters.AddWithValue("@genero", livro.Genero);
                command.Parameters.AddWithValue("@quantidade", livro.QuantidadeDisponivel);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar livro: {ex.Message}");
            }
        }
        public List<Livro> GetAllLivros()
        {
            List<Livro> livros = new List<Livro>();
            try
            {
                using var connection = databaseConnection.GetConnection();
                connection.Open();
                string sql = "SELECT * FROM livros";
                using var command = new MySqlCommand(sql, connection);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32("id_livro");
                    string titulo = reader.GetString("titulo");
                    string autor = reader.GetString("autor");
                    DateTime anoPublicacao = reader.GetDateTime("ano_publi");
                    string genero = reader.GetString("genero");
                    int quantidadeDisponivel = reader.GetInt32("quantidade");
                    Livro livro = new Livro(id, titulo, autor, genero, anoPublicacao, quantidadeDisponivel);
                    livros.Add(livro);
                }
                string sqlStatus = "SELECT\r\n    id_livro,\r\n    titulo,\r\n    CASE\r\n        WHEN EXISTS (\r\n            SELECT 1\r\n            FROM emprestimos\r\n            WHERE emprestimos.livro_id = livros.id_livro\r\n        )\r\n        THEN TRUE\r\n        ELSE FALSE\r\n    END AS emprestado\r\nFROM livros;";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter livros: {ex.Message}");
            }
            return livros;
        }
    }
}
