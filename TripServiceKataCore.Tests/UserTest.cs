using TripServiceKataCore.Tests.Builders;
using TripServiceKataCore.Users;
using Xunit;

namespace TripServiceKataCore.Tests
{
    public class UserTest
    {
        private static readonly User _loggedInUser = new UserBuilder();

        [Fact]
        public void Should_Be_Friends()
        {
            User friend = new UserBuilder();
            friend.AddFriend(_loggedInUser);

            Assert.True(friend.IsFriendOf(_loggedInUser));
        }

        [Fact]
        public void Should_Not_Be_Friends()
        {
            User noFriend = new UserBuilder();

            Assert.False(noFriend.IsFriendOf(_loggedInUser));
        }
    }
}
