using FluentAssertions;
using Moq;
using SNPFD.Application.Orders;
using SNPFD.Application.Orders.Contracts;
using SNPFD.Application.Orders.Dtos;
using SNPFD.Application.Products.Contracts;
using SNPFD.Application.Test.Products;
using SNPFD.Application.Test.Users;
using SNPFD.Application.Users.Contracts;

namespace SNPFD.Application.Test;

public sealed class OrderAppServiceTests
{
    private readonly IOrderAppService _sut;
    readonly Mock<IUserRepository> _userRepositoryFake;
    readonly Mock<IProductRepository> _productRepositoryFake;
    readonly Mock<IOrderRepository> _orderRepositoryFake;

    public OrderAppServiceTests()
    {
        _userRepositoryFake = new Mock<IUserRepository>();
        _productRepositoryFake = new Mock<IProductRepository>();
        _orderRepositoryFake = new Mock<IOrderRepository>();
        var unitOfWorkFake = new Mock<IUnitOfWork>();

        _sut = new OrderAppService(_productRepositoryFake.Object,
            _userRepositoryFake.Object,
            _orderRepositoryFake.Object,
            unitOfWorkFake.Object);
    }

    [Fact]
    public async Task CreateAsync_CreateAnOrder()
    {
        // arrange
        var someUser = _userRepositoryFake.SetupAddAsync();
        var someProduct = _productRepositoryFake.SetupAddAsync();

        var expected = new OrderDto(Guid.Empty,
            someUser.Id,
            someProduct.Id,
            DateTime.UtcNow);
            
        // act
       var orderDto= await _sut.CreateAsync(someUser.Id,
            someProduct.Id);
       
       // assert

       orderDto
           .Should()
           .BeEquivalentTo(expected, options => options
               .Excluding(dto => dto.Id)
               .Excluding(dto => dto.CreationDate));
    }
}