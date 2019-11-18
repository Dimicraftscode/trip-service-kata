namespace TripServiceKataCore.Tests.Builders
{
    public class UserBuilder
    {
        private readonly User.User _user;

        public UserBuilder()
        {
            _user = new User.User();
        }

        public UserBuilder WithFriend(User.User user)
        {
            _user.AddFriend(user);
            return this;
        }

        public UserBuilder WithTrip(Trip.Trip trip)
        {
            _user.AddTrip(trip);
            return this;
        }

        public User.User Build()
        {
            return _user;
        }

        public static implicit operator User.User(UserBuilder userBuilder) => userBuilder.Build();
    }
}
