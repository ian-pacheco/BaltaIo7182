using Store.Domain.Commands;
using System;
using System.Collections.Generic;

namespace Store.Domain.Utils
{
    public static class ExtractGuids
    {
        public static IEnumerable<Guid> Extract(IList<CreateOrderItemCommand> itens)
        {
            var guids = new List<Guid>();
            foreach (var item in itens)
                guids.Add(item.Product);

            return guids;
        }
    }
}
