using System.Collections.Generic;
using TripServiceKataCore.Exception;
using TripServiceKataCore.Users;

namespace TripServiceKataCore.Trips
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User user)
        {
            User loggedUser = GetLoggedUser();
            if (loggedUser != null)
            {
                return user.IsFriendOf(loggedUser) ? FindTrips(user) : new List<Trip>();
            }
            else
            {
                throw new UserNotLoggedInException();
            }
        }

        protected virtual User GetLoggedUser()
        {
            return UserSession.GetInstance().GetLoggedUser();
        }

        protected virtual List<Trip> FindTrips(User user)
        {
            return TripDAO.FindTripsByUser(user);
        }
    }
}
