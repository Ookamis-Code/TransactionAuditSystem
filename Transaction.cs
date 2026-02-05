using System;

namespace TransactionAuditSystem;

public class Transaction
{
    public string Id { get; }
    public decimal Amount { get; }
    public string AccountFrom { get; }
    public string AccountTo { get; }
    public DateTime Timestamp { get; }
    public Transaction(string id, decimal amount, string from, string to)
    {
        Id = id;
        Amount = amount;
        AccountFrom = from;
        AccountTo = to;
        Timestamp = DateTime.Now;
    }
    public override bool Equals(object? obj) =>
        obj is Transaction other && Id == other.Id;
    public override int GetHashCode() => Id.GetHashCode();
}