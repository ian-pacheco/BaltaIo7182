using Store.Domain.Entities;
using System.Collections.Generic;
using Xunit;

namespace Store.Tests.Entities
{
    public class OrderTests
    {
        private Customer CUSTOMER = new Customer("Ian Pacheco", "ianpacheco@me.com");
        private Order ORDER => new Order(CUSTOMER, 0, null);

        [Fact]
        public void ShouldBeGenerateNewValidOrder8CharNumber()
        {
            Assert.Equal(8, ORDER.Number.Length);
        }

        [Fact]
        public void ShouldBeStatusWaitingPaymentWhenGivenNewOrder()
        {
            Assert.True(false, "message");
        }

        [Fact]
        public void ShouldBeStatusWaitingDeliveryWhenOrderPaid()
        {
            Assert.True(false, "message");
        }

        [Fact]        
        public void ShouldBeStatusCanceledWhenStatusCanceled()
        {
            Assert.True(false, "message");
        }

        [Fact]        
        public void ShouldNotBeAddNewItemWithoutProductAdded()
        {
            Assert.True(false, "message");
        }

        [Fact]        
        public void ShouldNotAddItemWithoutQuantityLikeZeroOrBelow()
        {
            Assert.True(false, "message");
        }

        [Fact]        
        public void ShouldBeTotalLike50WhenNewValidOrder()
        {
            Assert.True(false, "message");
        }

        [Fact]        
        public void ShouldBeTotaLike60WhenGivenExpiredDiscount()
        {
            Assert.True(false, "message");
        }

        [Fact]        
        public void ShouldBeTotalLike60WhenGivenAnInvalidDiscount()
        {
            Assert.True(false, "message");
        }

        [Fact]        
        public void ShouldBeTotalLike50WhenDiscountLike10()
        {
            Assert.True(false, "message");
        }

        [Fact]        
        public void ShouldBeTotalLike60WhenDeliveryFeeBeLike10()
        {
            Assert.True(false, "message");
        }

        [Fact]        
        public void ShouldBeInvalidWhenOrderWithoutCustomer()
        {
            Assert.True(false, "message");
        }
    }
}
