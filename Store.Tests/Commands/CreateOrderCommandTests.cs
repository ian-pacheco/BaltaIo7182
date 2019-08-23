using Store.Domain.Commands;
using System;
using Xunit;

namespace Store.Tests.Commands
{
    public class CreateOrderCommandTests
    {
        [Fact]
        public void ShouldNotBeCreatedOrderWithInvalidCommand()
        {
            var command = new CreateOrderCommand();
            command.Customer = "";
            command.ZipCode = "12345678";
            command.PromoCode = "123456789";
            command.Itens.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Itens.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.False(command.Valid);
        }
    }
}
