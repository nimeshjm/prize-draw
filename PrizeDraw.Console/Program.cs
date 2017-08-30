using PrizeDraw.Domain;
using PrizeDraw.Persistence;

namespace PrizeDraw.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var prizeMoneyCalculator = new PrizeMoneyCalculator(new OrderStdInOutRepository());

            System.Console.Out.WriteLine(prizeMoneyCalculator.CalculateTotalPrizeMoney());
        }
    }
}
