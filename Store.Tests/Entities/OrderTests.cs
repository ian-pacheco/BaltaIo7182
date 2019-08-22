using Store.Domain.Entities;
using Store.Domain.Enums;
using System;
using Xunit;

namespace Store.Tests.Entities
{
    public class OrderTests
    {
        private readonly Customer CUSTOMER = new Customer("Ian Pacheco", "ianpacheco@me.com");
        private readonly Product PRODUCT = new Product("Cerveja", 10, true);
        private readonly Discount DISCOUNT = new Discount(10, DateTime.Now.AddDays(5));
        private readonly Discount EXPIRE_DISCOUNT = new Discount(10, DateTime.Now.AddDays(-5));

        [Fact]
        public void ShouldBeGenerateNewValidOrder8CharNumber()
        {
            var ORDER = new Order(CUSTOMER, 0, null);
            Assert.Equal(8, ORDER.Number.Length);
        }

        [Fact]
        public void ShouldBeStatusWaitingPaymentWhenGivenNewOrder()
        {
            var ORDER = new Order(CUSTOMER, 0, null);
            Assert.Equal(EOrderStatus.WaitingPayment, ORDER.Status);
        }

        [Fact]
        public void ShouldBeStatusWaitingDeliveryWhenOrderPaid()
        {
            var ORDER = new Order(CUSTOMER, 0, null);
            ORDER.AddItem(PRODUCT, 1);
            ORDER.Pay(10);
            Assert.Equal(EOrderStatus.WaitingDelivery, ORDER.Status);
        }

        [Fact]
        public void ShouldBeStatusCanceledWhenStatusCanceled()
        {
            var ORDER = new Order(CUSTOMER, 0, null);
            ORDER.Cancel();
            Assert.Equal(EOrderStatus.Canceled, ORDER.Status);
        }

        [Fact]
        public void ShouldNotBeAddNewItemWithoutProductAdded()
        {
            var ORDER = new Order(CUSTOMER, 0, null);
            ORDER.AddItem(null, 10);
            Assert.Equal(0, ORDER.Itens.Count);
        }

        [Fact]
        public void ShouldNotAddItemWithoutQuantityLikeZeroOrBelow()
        {
            var ORDER = new Order(CUSTOMER, 0, null);
            ORDER.AddItem(PRODUCT, 0);
            Assert.Equal(0, ORDER.Itens.Count);
        }

        [Fact]
        public void ShouldBeTotalLike50WhenNewValidOrder()
        {
            var ORDER = new Order(CUSTOMER, 10, DISCOUNT);
            ORDER.AddItem(PRODUCT, 5);
            Assert.Equal(50, ORDER.Total());
        }

        [Fact]
        public void ShouldBeTotaLike60WhenGivenExpiredDiscount()
        {
            var ORDER_EXD = new Order(CUSTOMER, 10, EXPIRE_DISCOUNT);
            ORDER_EXD.AddItem(PRODUCT, 5);
            Assert.Equal(60, ORDER_EXD.Total());
        }

        [Fact]
        public void ShouldBeTotalLike60WhenGivenAnInvalidDiscount()
        {
            var ORDER = new Order(CUSTOMER, 10, null);
            ORDER.AddItem(PRODUCT, 5);
            Assert.Equal(60, ORDER.Total());
        }

        [Fact]
        public void ShouldBeTotalLike50WhenDiscountLike10()
        {
            var ORDER = new Order(CUSTOMER, 10, DISCOUNT);
            ORDER.AddItem(PRODUCT, 5);
            Assert.Equal(50, ORDER.Total());
        }

        [Fact]
        public void ShouldBeTotalLike60WhenDeliveryFeeBeLike10()
        {
            var ORDER = new Order(CUSTOMER, 10, DISCOUNT);
            ORDER.AddItem(PRODUCT, 6);
            Assert.Equal(60, ORDER.Total());
        }

        [Fact]
        public void ShouldBeInvalidWhenOrderWithoutCustomer()
        {
            var ORDER = new Order(null, 10, DISCOUNT);
            ORDER.AddItem(PRODUCT, 5);
            Assert.False(ORDER.Valid);
        }
    }
}
