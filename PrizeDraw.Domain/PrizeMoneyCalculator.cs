using System;
using System.Collections.Generic;
using System.Linq;

namespace PrizeDraw.Domain
{
    public class PrizeMoneyCalculator
    {
        private readonly IOrderRepository _orderRepository;

        public PrizeMoneyCalculator(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public int CalculateTotalPrizeMoney()
        {
            var allOrders = new List<int>();
            var prizeTotal = 0;

            foreach (var orders in this._orderRepository.GetOrderValues())
            {
                allOrders.AddRange(orders);
                allOrders.Sort();

                prizeTotal += allOrders.Last() - allOrders.First();
                allOrders = allOrders.GetRange(1, Math.Max(0, allOrders.Count - 2));
            }

            return prizeTotal;
        }
    }
}
