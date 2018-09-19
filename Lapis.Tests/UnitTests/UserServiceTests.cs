using Lapis.Api.Helpers;
using Lapis.Api.Services;
using Lapis.DAL.Interfaces;
using Lapis.DAL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Linq.Expressions;

namespace Lapis.UnitTests.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private string _exisitngUserName;
        private string _matchingPassword;

        private string _nonExistingUserName;
        private string _wrongPassword;

        private User _exampleUser;

        private UserService _userService;
        private IUserRepository _userRepositoryMock;

        [TestInitialize]
        public void Setup()
        {
            _exisitngUserName = "existing_user";
            _nonExistingUserName = "nonexisting_user";

            _matchingPassword = "good_pass";
            _wrongPassword = "bad_pass";

            CryptoHelper.CreatePasswordHash(_matchingPassword, out byte[] passwordHash, out byte[] passwordSalt);

            _exampleUser = new User
            {
                Id = 1,
                FirstName = "User_1",
                LastName = "User_1",
                Username = "User_1",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _userRepositoryMock = Substitute.For<IUserRepository>();
            var username = _exisitngUserName;
            Expression<Func<User, bool>> exp = u => u.Username == username;
            _userRepositoryMock.GetFirst(Arg.Any<Expression<Func<User, bool>>>()).Returns(_exampleUser);
            _userRepositoryMock.GetFirst(user => user.Username == _nonExistingUserName).Returns(r => null);

            _userService = new UserService(_userRepositoryMock);
        }

        [TestMethod]
        public void AuthenticateWithValidPasswordAndValidUserName_UserFound()
        {
            var user = _userService.Authenticate(_exisitngUserName, _matchingPassword);
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void AuthenticateWithValidPasswordAndNonValidUserName_UserNotFound()
        {
            var user = _userService.Authenticate(_nonExistingUserName, _matchingPassword);
            Assert.IsNull(user);
        }

        [TestMethod]
        public void AuthenticateWithNonValidPasswordAndValidUserName_UserNotFound()
        {
            var user = _userService.Authenticate(_exisitngUserName, _matchingPassword);
            Assert.IsNull(user);
        }

        [TestMethod]
        public void AuthenticateWithNonValidPasswordAndNonValidUserName_UserNotFound()
        {
            var user = _userService.Authenticate(_nonExistingUserName, _wrongPassword);
            Assert.IsNull(user);
        }
    }
}
