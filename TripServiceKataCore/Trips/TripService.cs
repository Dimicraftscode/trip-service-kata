using System.Collections.Generic;
using TripServiceKataCore.Exception;
using TripServiceKataCore.Users;

namespace TripServiceKataCore.Trips
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User user, User loggedUser)
        {
            if (loggedUser == null)
            {
                throw new UserNotLoggedInException();
            }

            return user.IsFriendOf(loggedUser) ? FindTrips(user) : new List<Trip>();
        }

        protected virtual List<Trip> FindTrips(User user)
        {
            return TripDAO.FindTripsByUser(user);
        }
    }
}
