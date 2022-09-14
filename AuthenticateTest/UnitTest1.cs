using NUnit.Framework;
using Authenticaticate_Microservice.Controllers;
using Authenticaticate_Microservice.Model;
using Microsoft.Extensions.Configuration;
using Moq;

namespace AuthenticateTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsTokenNotNull_When_ValidserCredentialsAreUsed()
        {
            Mock<IConfiguration> config = new Mock<IConfiguration>();
            AuthController TokenObj = new AuthController();
            var Result = TokenObj.CreatedAtAction("auth", new User() { UserId = 1, Password = "1234" });
            Assert.IsNotNull(Result);
        }


        [Test]
        public void IsTokenNull_When_InvalidUserCredentialsAreUsed()
        {
            Mock<IConfiguration> config = new Mock<IConfiguration>();
            var TokenObj = new AuthController();
            var Result = TokenObj.CreatedAtAction("auth", new User() { UserId = 0, Password = "wronginput"});
            Assert.IsEmpty(Result.ContentTypes);
        }
    }
}