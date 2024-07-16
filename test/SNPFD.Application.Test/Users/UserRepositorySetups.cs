using Moq;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using SNPFD.Application.Users.Contracts;
using SNPFD.Application.Users.Dtos;
using SNPFD.Domain.Users;

namespace SNPFD.Application.Test.Users;

internal static class UserRepositorySetups
{
    public static User SetupAddAsync(this Mock<IUserRepository> userRepositoryFake)
    {
        var someUser = new User(new RandomizerFullName(new FieldOptionsFullName()
        {
            Female = true,
            Male = true,
        }).Generate()!);

        userRepositoryFake
            .Setup(repository => repository.AddAsync(someUser, true, CancellationToken.None))
            .ReturnsAsync(someUser);

        userRepositoryFake
            .Setup(repository => repository.GetByIdAsync(someUser.Id, CancellationToken.None))
            .ReturnsAsync(someUser);
        
        return someUser;
    }
}