using System.Collections.Generic;
using TripServiceKataCore.Exception;
using TripServiceKataCore.Trip;
using Xunit;

namespace TripServiceKataCore.Tests
{
    public class TripServiceTest
    {
        private static readonly User.User _guest = null;
        private static readonly User.User _unknownUser = new User.User();
        private static readonly User.User _loggedInUser = new User.User();
        private static readonly User.User _friend = new User.User();

        private static User.User _loggedUser = new User.User();

        private readonly TripService _tripService;

        public TripServiceTest()
        {
            _tripService = new TestableTripService();
        }

        [Fact]
        public void Should_Throw_Exception_If_User_Is_Not_Logged_In()
        {
            _loggedUser = _guest;

            Assert.Throws<UserNotLoggedInException>(() => _tripService.GetTripsByUser(_unknownUser));
        }

        [Fact]
        public void Should_Not_Return_Trips_When_User_Is_Not_A_Friend()
        {
            _loggedUser = _loggedInUser;

            var trips = _tripService.GetTripsByUser(_unknownUser);
            Assert.Empty(trips);
        }

        [Fact]
        public void Should_Return_Trips_When_User_Is_A_Friend()
        {
            _loggedUser = _loggedInUser;

            _friend.AddFriend(_loggedInUser);
            _friend.AddTrip(new Trip.Trip());

            var trips = _tripService.GetTripsByUser(_friend);

            Assert.Single(trips);
        }

        private class TestableTripService : TripService
        {
            protected override List<Trip.Trip> FindTrips(User.User user)
            {
                return user.Trips();
            }

            protected override User.User GetLoggedUser()
            {
                return _loggedUser;
            }
        }
    }
}
