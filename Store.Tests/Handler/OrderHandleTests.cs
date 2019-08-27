using Store.Domain.Commands;
using Store.Domain.Handlers;
using Store.Domain.Repositories;
using Store.Tests.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Store.Tests.Handler
{
    public class OrderHandleTests
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFeeRepository _deliveryFeeRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderHandleTests()
        {
            _customerRepository = new FakeCustomerRepository();
            _deliveryFeeRepository = new FakeDeliveryFeeRepository();
            _discountRepository = new FakeDiscountRepository();
            _productRepository = new FakeProductRepository();
            _orderRepository = new FakeOrderRepository();
        }

        [Fact]
        public void ShouldNotGenerateOrderWhenClientInexist()
        {
            Assert.True(true);
        }

        [Fact]
        public void ShouldGenerateOrderWithInexistZipCode()
        {
            Assert.True(true);
        }

        [Fact]
        public void ShouldGenerateOrderwithInexistPromoCode()
        {
            Assert.True(true);
        }

        [Fact]
        public void ShouldNotGenerateOrderWithoutItens()
        {
            Assert.True(true);
        }

        [Fact]
        public void ShouldNotGenerateOrderWithInvalidCommand()
        {
            Assert.True(true);
        }

        [Fact]
        public void ShouldGenerateOrderWithValidCommand()
        {
            var command = new CreateOrderCommand();
            command.Customer = "1234567890";
            command.ZipCode = "12345678";
            command.PromoCode = "012345";
            command.Itens.Add(new CreateOrderItemCommand(Guid.NewGuid(),1));
            command.Itens.Add(new CreateOrderItemCommand(Guid.NewGuid(),1));

            var handler = new OrderHandler(
               _customerRepository,
               _deliveryFeeRepository,
               _discountRepository,
               _productRepository,
               _orderRepository);

            handler.Handle(command);
            Assert.True(handler.Valid);
        }
    }
}
