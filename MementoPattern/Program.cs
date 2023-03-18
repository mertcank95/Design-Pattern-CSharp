var bankAccount = new BankAccount();
bankAccount.Amount = 1000.00f;
bankAccount.DateTime= DateTime.Now;
Console.WriteLine(bankAccount.ToString());

var bankAccountTakker = new BankAccountTaker();
bankAccountTakker.BankMemento=bankAccount.Insert();

Thread.Sleep(2000);
bankAccount.Amount=1200.00f;
bankAccount.DateTime= DateTime.Now;

Console.WriteLine(bankAccount.ToString());

bankAccount.PreviousData(bankAccountTakker.BankMemento);
Console.WriteLine(bankAccount.ToString());
public class BankAccount
{
    public float Amount { get; set; }
	public DateTime DateTime { get; set; }

    public override string ToString()
    {
        return $"{DateTime}  --> {Amount}";
    }

    public BankAccountMemento Insert ()
    {
        return new BankAccountMemento()
        {
            Amount = this.Amount,
            DateTime = this.DateTime
        };
    }

    public void PreviousData(BankAccountMemento memento)
    {
        this.Amount= memento.Amount;
        this.DateTime = memento.DateTime;
    
    }
}

public class BankAccountMemento
{
    public float Amount { get; set; }
    public DateTime DateTime { get; set; }
}

public class BankAccountTaker
{
    public BankAccountMemento BankMemento { get; set; }
}
