using ConsoleApp1.DataConnection;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1.Repository
{
    internal class EmprestimoRepository
    {
        DatabaseConnection databaseConnection = new DatabaseConnection();
        public bool AdicionarEmprestimo(int idLivro)
        {
            try
            {
                using var connection = databaseConnection.GetConnection();

                connection.Open();

                string sql = @"""
                    SELECT NOT EXISTS (
                    SELECT 1
                    FROM emprestimos
                    WHERE id_livro = @idLivro
                      AND data_devolucao IS NULL
                ) AS disponivel;
                """;
                using var command = new MySqlConnector.MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idLivro", idLivro);
                command.ExecuteNonQuery();
                return Convert.ToBoolean(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
        }

        public void RegistrarEmprestimo(int idLivro, int idUsuario)
        {
            try
            {
                using var connection = databaseConnection.GetConnection();
                connection.Open();
                string sql = @"""
                    INSERT INTO emprestimos (id_livro, id_usuario, data_emprestimo)
                    VALUES (@idLivro, @idUsuario, NOW());
                """;
                using var command = new MySqlConnector.MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idLivro", idLivro);
                command.Parameters.AddWithValue("@idUsuario", idUsuario);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao registrar empréstimo: {ex.Message}");
            }
        }
    }
}
