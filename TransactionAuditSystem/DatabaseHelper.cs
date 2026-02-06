using System;
using System.Runtime.CompilerServices;
using Microsoft.Data.Sqlite;

namespace TransactionAuditSystem;

public static class DatabaseHelper
{
private const string ConnectionString = "Data Source=transactions.db";

    public static void InitializeDatabase()
    {
        try 
        {
            Console.WriteLine("DEBUG: Opening SQLite Connection...");
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            
            Console.WriteLine("DEBUG: Connection Open. Creating Table...");
            var command = connection.CreateCommand();
            command.CommandText = "CREATE TABLE IF NOT EXISTS Transactions (Id TEXT PRIMARY KEY, Amount DECIMAL, AccountFrom TEXT, AccountTo TEXT, Timestamp TEXT);";
            command.ExecuteNonQuery();

            Console.WriteLine("DEBUG: Database Initialization Complete.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"FATAL DATABASE ERROR: {ex.Message}");
        }
    }
    public static void SaveTransaction(Transaction t)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Transactions VALUES ($id, $amount, $from, $to, $time)";
        command.Parameters.AddWithValue("$id", t.Id);
        command.Parameters.AddWithValue("$amount", t.Amount);
        command.Parameters.AddWithValue("$from", t.AccountFrom);
        command.Parameters.AddWithValue("$to", t.AccountTo);
        command.Parameters.AddWithValue("$time", t.Timestamp);
        command.ExecuteNonQuery();
    }
    public static HashSet<string> GetExsitingIds()
    {
        var ids = new HashSet<string>();
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "SELECT Id FROM Transactions";
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            ids.Add(reader.GetString(0));
        }
        return ids;
    }
}
