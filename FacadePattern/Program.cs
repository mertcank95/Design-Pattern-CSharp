using System.Text;
string password = "password123";
Console.WriteLine(password);
var verification = new PasswordVertification() { vertification=true};
var encrypt = new Encryptor() { Password=password};
var createPassword = new PasswordCreator(verification, encrypt);
var encryptPassword = createPassword.GetPassword();
if(encryptPassword.Vertification.vertification)
Console.WriteLine(encryptPassword.PasswordEncryptor.Encrypt());
public class Password
{
    public Password(PasswordVertification vertification, Encryptor encryptor)
    {
        Console.WriteLine(vertification);
        Console.WriteLine(encryptor.Encrypt());
    }
}
public class PasswordVertification
{
    public bool vertification { get; set; }
}

public class Encryptor
{
    public string Password { get; set; }
    public string Encrypt()
    {
        Console.WriteLine("Encrypting the text...");
        byte[] bytes = Encoding.ASCII.GetBytes(Password);
        string encryptedText = Convert.ToBase64String(bytes);
        Console.WriteLine("Text encrypted");
        return encryptedText;
    }
}
public class PasswordCreator
{
    public PasswordVertification Vertification { get; set; }
    public Encryptor PasswordEncryptor { get; set; }
    public PasswordCreator(PasswordVertification vertification, Encryptor passwordEncryptor)
    {
        Vertification = vertification;
        PasswordEncryptor = passwordEncryptor;
    }
    public PasswordCreator GetPassword()
    {
        return new PasswordCreator(Vertification, PasswordEncryptor);
    }

}