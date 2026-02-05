using System;
using System.Collections.Generic;
using System.Linq;

namespace TransactionAuditSystem;

public class AuditService
{
    private readonly HashSet<string> _processedIds = new ();
    private readonly List<Transaction> _log = new ();
    public string ProcessTransaction(Transaction t)
    {
        string result;
        if (_processedIds.Contains(t.Id))
        {
            result = $"[REJECTED] Transaction {t.Id} is a duplicate.";
        }
        else if (t.Amount <= 0)
        {
            result = $"[REJECTED] Invalid Amount, Please enter a correct amount: {t.Amount}.";
        }
        else
        {
            _processedIds.Add(t.Id);
            _log.Add(t);
            result = $"[SUCCESS] {t.Amount:C} transferred from {t.AccountFrom} to {t.AccountTo}.";
                       
        }
        bool wasSaved = FileHelper.WriteToLog(result);
        if (!wasSaved)
        {
            return "[SYSTEM ALERT] Transaction processed but failed to save to log file.";
        }
        return result;
    }
    public void DisplayAuditLog()
    {
        Console.WriteLine("\n--- OFFICIAL AUDIT LOG ---");
        foreach (var t in _log)
        {
            Console.WriteLine($"{t.Timestamp: yyyy-MM-dd HH:mm:ss} | ID: {t.Id} | Amount: {t.Amount:C} | From: {t.AccountFrom} | To: {t.AccountTo}");
        }
        Console.WriteLine("--- END OF AUDIT LOG ---\n");
    }
}