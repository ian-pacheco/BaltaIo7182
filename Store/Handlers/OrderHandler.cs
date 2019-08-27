using Flunt.Notifications;
using Store.Domain.Commands;
using Store.Domain.Commands.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Handlers.Interfaces;
using Store.Domain.Repositories;
using Store.Domain.Utils;
using System.Linq;

namespace Store.Domain.Handlers
{
    public class OrderHandler : Notifiable, IHandler<CreateOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFeeRepository _deliveryFeeRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderHandler(
            ICustomerRepository customerRepository,
            IDeliveryFeeRepository deliveryFeeRepository,
            IDiscountRepository discountRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _deliveryFeeRepository = deliveryFeeRepository;
            _discountRepository = discountRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public ICommandResult Handle(CreateOrderCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Pedido inválido", command.Notifications);

            // Recupera o client
            var customer = _customerRepository.Get(command.Customer);

            //Calcula a taxa de entrega
            var deliveryFee = _deliveryFeeRepository.Get(command.ZipCode);

            // Obtem o cupom de desconto
            var discount = _discountRepository.Get(command.PromoCode);

            //Gera o pedido
            var products = _productRepository.Get(ExtractGuids.Extract(command.Itens)).ToList();
            var order = new Order(customer, deliveryFee, discount);

            foreach (var item in command.Itens)
            {
                var product = products.Where(x => x.Id == item.Product).FirstOrDefault();
                order.AddItem(product, item.Quantity);
            }

            // Agrupa notificações
            AddNotifications(customer.Notifications);
            AddNotifications(order.Notifications);

            // Verifica se deu certo
            if (Invalid)
                return new GenericCommandResult(false, "Falha ao ferar o pedido", Notifications);

            // Retorna resultado
            _orderRepository.Save(order);
            return new GenericCommandResult(true, $"Pedido {order.Number} gerado com sucesso", order);
        }
    }
}
