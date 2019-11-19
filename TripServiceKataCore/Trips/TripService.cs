using System.Collections.Generic;
using TripServiceKataCore.Exception;
using TripServiceKataCore.Users;

namespace TripServiceKataCore.Trips
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User user)
        {
            List<Trip> tripList = new List<Trip>();
            User loggedUser = GetLoggedUser();
            if (loggedUser != null)
            {
                if (user.IsFriendOf(loggedUser))
                {
                    tripList = FindTrips(user);
                }
                return tripList;
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
