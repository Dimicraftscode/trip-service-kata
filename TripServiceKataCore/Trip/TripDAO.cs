using System.Collections.Generic;
using TripServiceKataCore.Exception;

namespace TripServiceKataCore.Trip
{
    public class TripDAO
    {
        public static List<Trip> FindTripsByUser(User.User user)
        {
            throw new DependendClassCallDuringUnitTestException(
                        "TripDAO should not be invoked on an unit test.");
        }
    }
}
