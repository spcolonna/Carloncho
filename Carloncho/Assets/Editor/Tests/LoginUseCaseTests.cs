using System.Collections.Generic;
using NUnit.Framework;


public class LoginUseCaseTests
{
    [Test]
    public void ReturnTrueWhenUserExist()
    {
        var user = new UserLogin("seba", "1234");
        var repository = new LoginRepositoryDouble(new List<UserLogin>() { user});
        var useCase = new LoginUseCase(repository);

        var result = useCase.Login(user);

        Assert.IsTrue(result);
    }

    [Test]
    public void ReturnFalseWhenUserNotExist()
    {
        var user = new UserLogin("seba", "1234");
        var repository = new LoginRepositoryDouble();
        var useCase = new LoginUseCase(repository);

        var result = useCase.Login(user);

        Assert.IsFalse(result);
    }
}

