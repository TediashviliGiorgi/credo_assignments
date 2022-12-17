namespace Assignments.MultithreadingBugFix;

public class TransactionService
{
    private static object _lockObject = new object();
    public void Transfer(BankAccount fromAccount, BankAccount toAccount, decimal amount)
    {
        lock (_lockObject)
        {
            if (amount > fromAccount.Balance)
            {
                Console.WriteLine($"{fromAccount.Iban} has Insufficient funds");
                return;
            }
            fromAccount.Balance -= amount;
            toAccount.Balance += amount;
        }
    }
}