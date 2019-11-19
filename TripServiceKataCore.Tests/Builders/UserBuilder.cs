using TripServiceKataCore.Trips;
using TripServiceKataCore.Users;

namespace TripServiceKataCore.Tests.Builders
{
    public class UserBuilder
    {
        private readonly User _user;

        public UserBuilder()
        {
            _user = new User();
        }

        public UserBuilder WithFriend(User user)
        {
            _user.AddFriend(user);
            return this;
        }

        public UserBuilder WithTrip(Trip trip)
        {
            _user.AddTrip(trip);
            return this;
        }

        public User Build()
        {
            return _user;
        }

        public static implicit operator User(UserBuilder userBuilder) => userBuilder.Build();
    }
}
