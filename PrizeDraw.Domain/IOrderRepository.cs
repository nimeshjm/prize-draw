using System.Collections.Generic;

namespace PrizeDraw.Domain
{
    public interface IOrderRepository
    {
        IEnumerable<IEnumerable<int>> GetOrderValues();
    }
}