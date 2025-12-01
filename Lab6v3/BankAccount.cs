public class BankAccount
{
    public string Number { get; set; }
    public double Balance { get; set; }

    public BankAccount(string number, double balance)
    {
        Number = number;
        Balance = balance;
    }
}
