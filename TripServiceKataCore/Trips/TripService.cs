using System.Collections.Generic;
using TripServiceKataCore.Exception;
using TripServiceKataCore.Users;

namespace TripServiceKataCore.Trips
{
    public class TripService
    {
        private readonly TripDAO _tripDAO;

        public TripService()
        {
        }

        public TripService(TripDAO tripDAO)
        {
            _tripDAO = tripDAO;
        }

        public List<Trip> GetTripsByUser(User user, User loggedUser)
        {
            if (loggedUser == null)
            {
                throw new UserNotLoggedInException();
            }

            return user.IsFriendOf(loggedUser) ? _tripDAO.FindTripsByUser(user) : new List<Trip>();
        }
    }
}
