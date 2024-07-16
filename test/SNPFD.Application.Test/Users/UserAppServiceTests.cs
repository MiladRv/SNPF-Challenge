using Moq;
using SNPFD.Application.Users;
using SNPFD.Application.Users.Contracts;

namespace SNPFD.Application.Test.Users;

public class UserAppServiceTests
{
    private readonly IUserAppService _sut;

    public UserAppServiceTests()
    {
        var userRepositoryFake = new Mock<IUserRepository>();
        
        _sut = new UserAppService(userRepositoryFake.Object);
    }
    
}