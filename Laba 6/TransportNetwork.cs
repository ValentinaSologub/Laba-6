using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6
{
    public class TransportNetwork
    {
        public void CalculateOptimalRoute(Vehicle vehicle, Route route)
        {
            Console.WriteLine($"Calculating optimal route for {vehicle.GetType().Name} from {route.StartPoint} to {route.EndPoint}.");
        }
    }
}
