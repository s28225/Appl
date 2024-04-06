using LegacyApp;

namespace ApplTest;

public class UnitTest1
{
    [Fact]
    public void AddNormalUser()
    {
        var userService = new UserService();
        var result = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        Assert.True(result);
    }

    [Fact]
    public void FirstNameNull()
    {
        var userService = new UserService();
        var result = userService.AddUser(null, "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        Assert.False(result, "First name cannot be null");
    }
    [Fact]
    public void FirstNameEmpty()
    {
        var userService = new UserService();
        var result = userService.AddUser("", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        Assert.False(result, "First name cannot be empty");
    }
    [Fact]
    public void LastNameNull()
    {
        var userService = new UserService();
        var result = userService.AddUser("John", null, "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        Assert.False(result, "Last name cannot be null");
    }
    [Fact]
    public void LastNameEmpty()
    {
        var userService = new UserService();
        var result = userService.AddUser("John", "", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        Assert.False(result, "Last name cannot be empty");
    }

    [Fact]
    public void WrongEmail()
    {
        var userService = new UserService();
        var result = userService.AddUser("John", "Doe", "johndoegmailcom", DateTime.Parse("1982-03-21"), 1);
        Assert.False(result, "Email must contain @ or .");
    }
    
    [Fact]
    public void CheckAge()
    {
        var userService = new UserService();
        var result = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("2005-03-21"), 1);
        Assert.False(result, "Client must be older than 21");
    }
}