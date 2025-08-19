// In SecureApp.Tests/UserServiceTests.cs
using SecureAppl;
using System;
using Xunit;

public class UserServiceTests
{
    [Fact]
    public void Register_ShouldCreateUser_WithHashedPassword()
    {
        // Arrange
        var service = new UserService();
        var password = "password123";

        // Act
        var user = service.Register("testuser", password);
        var hashedPassword = service.HashPassword(password);

        // Assert
        Assert.NotNull(user);
        Assert.Equal("testuser", user.Username);
        Assert.Equal(hashedPassword, user.HashedPassword);
        Assert.NotEqual(password, user.HashedPassword);
    }

    [Fact]
    public void Authenticate_ShouldReturnTrue_ForValidCredentials()
    {
        // Arrange
        var service = new UserService();
        service.Register("testuser", "password123");

        // Act
        var result = service.Authenticate("testuser", "password123");

        // Assert
        Assert.True(result);
    }

    // Add to SecureApp.Tests/UserServiceTests.cs
    [Fact]
    public void Register_ShouldThrowException_WhenUserExists()
    {
        // Arrange
        var service = new UserService();
        service.Register("testuser", "password123");

        // Act & Assert
        // Correct
        Assert.Throws<ArgumentException>(() => service.Register("testuser", "newpassword"));
    }
}