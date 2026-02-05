using System;
using System.IO;

namespace TransactionAuditSystem;

public static class FileHelper
{
    private const string FileName = "audit_log.txt";
    public static bool WriteToLog(string message)
    {
        try
        {
            File.AppendAllText(FileName, message + Environment.NewLine);
            return true;
        }
        catch (IOException ex)
        {
            Console.WriteLine($"[CRITICAL ERROR] Failed to write to log file: {ex.Message}");
            return false;
        }
        catch (Exception ex) 
        {
            Console.WriteLine($"[CRITICAL ERROR] An unexpected error occurred while writing to log file: {ex.Message}");
            return false;
        }
    }
}