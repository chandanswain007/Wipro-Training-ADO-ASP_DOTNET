// In SecureApp.Tests/EncryptionHelperTests.cs
using SecureAppl;
using Xunit;

public class EncryptionHelperTests
{
    [Fact]
    public void EncryptDecrypt_ShouldReturnOriginalText()
    {
        // Arrange
        var originalText = "This is sensitive data.";

        // Act
        var encryptedText = EncryptionHelper.Encrypt(originalText);
        var decryptedText = EncryptionHelper.Decrypt(encryptedText);

        // Assert
        Assert.NotEqual(originalText, encryptedText);
        Assert.Equal(originalText, decryptedText);
    }
}