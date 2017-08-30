using System;
using System.Collections.Generic;
using System.Linq;
using PrizeDraw.Domain;

namespace PrizeDraw.Persistence
{
    public class OrderStdInOutRepository : IOrderRepository
    {
        public IEnumerable<IEnumerable<int>> GetOrderValues()
        {
            var days = Convert.ToInt32(Console.In.ReadLine());

            for (var i = 0; i < days; i++)
            {
                yield return Console.In.ReadLine().Split(' ').ToList().ConvertAll(Convert.ToInt32).Skip(1);
            }
        }
    }
}
