using System.Collections.Generic;
using TripServiceKataCore.Trips;

namespace TripServiceKataCore.Users
{
    public class User
    {
        private readonly List<Trip> _trips = new List<Trip>();
        private readonly List<User> _friends = new List<User>();

        public List<User> GetFriends()
        {
            return _friends;
        }

        public void AddFriend(User user)
        {
            _friends.Add(user);
        }

        public void AddTrip(Trip trip)
        {
            _trips.Add(trip);
        }

        public bool IsFriendOf(User loggedUser)
        {
            return _friends.Contains(loggedUser);
        }

        public List<Trip> Trips()
        {
            return _trips;
        }
    }
}
