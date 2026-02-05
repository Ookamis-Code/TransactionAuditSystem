using System;
using TransactionAuditSystem;

var auditor = new AuditService();

var t1 = new Transaction("TXN001", 150.00m, "Checking", "Savings");
var t2 = new Transaction("TXN002", 50.00m, "Savings", "Utilities");
var t3 = new Transaction("TXN001", 150.00m, "Checking", "Savings");

Console.WriteLine(auditor.ProcessTransaction(t1));
Console.WriteLine(auditor.ProcessTransaction(t2));
Console.WriteLine(auditor.ProcessTransaction(t3));

auditor.DisplayAuditLog();