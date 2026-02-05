using Xunit;
using TransactionAuditService;
using System.Transactions;
using System.Reflection;

namespace TransactionAuditService.Tests;

public class AuditServiceTests
{
    [Fact]
    public void ProcessTransaction_ShouldRejectDuplicateId()
    {
        var auditor = new AuditService();
        var t1  = new Transaction {"TXN_TEST", 100m, "A", "B"};
        var t2  = new Transaction {"TXN_TEST", 200m, "C", "D"};
        auditor.ProcessTransaction(t1);
        string result = auditor.ProcessTransaction(t2);
        Assert.Contains("REJECTED", result);
        Assert.Contains("Duplicate", result);
    }
}