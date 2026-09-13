using Monat.Guard;

namespace Monat.Guard.Tests;

public class GuardTests
{
    [Fact]
    public void NotNull_WhenValueIsNotNull_ShouldNotThrow()
    {
        var value = new object();

        var exception = Record.Exception(() =>
            Guard.NotNull(value));

        Assert.Null(exception);
    }

    [Fact]
    public void NotNull_WhenValueIsNull_ShouldThrowArgumentNullException()
    {
        object? value = null;

        var exception = Assert.Throws<ArgumentNullException>(() =>
            Guard.NotNull(value));

        Assert.Equal("value", exception.ParamName);
    }

    [Theory]
    [InlineData("Mehmet")]
    [InlineData("123")]
    [InlineData(" hello ")]
    public void NotNullOrWhiteSpace_WhenValueIsValid_ShouldNotThrow(
        string value)
    {
        var exception = Record.Exception(() =>
            Guard.NotNullOrWhiteSpace(value));

        Assert.Null(exception);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("   ")]
    public void NotNullOrWhiteSpace_WhenValueIsInvalid_ShouldThrow(
        string? value)
    {
        var exception = Assert.Throws<ArgumentException>(() =>
            Guard.NotNullOrWhiteSpace(value));

        Assert.Equal("value", exception.ParamName);
    }

    [Fact]
    public void NotEmpty_WhenGuidIsValid_ShouldNotThrow()
    {
        var value = Guid.NewGuid();

        var exception = Record.Exception(() =>
            Guard.NotEmpty(value));

        Assert.Null(exception);
    }

    [Fact]
    public void NotEmpty_WhenGuidIsEmpty_ShouldThrowArgumentException()
    {
        var userId = Guid.Empty;
        var exception = Assert.Throws<ArgumentException>(() =>
            Guard.NotEmpty(userId));

        Assert.Equal("userId", exception.ParamName);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    public void Positive_WhenValueIsPositive_ShouldNotThrow(int value)
    {
        var exception = Record.Exception(() =>
            Guard.Positive(value));

        Assert.Null(exception);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void Positive_WhenValueIsZeroOrNegative_ShouldThrow(
        int value)
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
            Guard.Positive(value));

        Assert.Equal("value", exception.ParamName);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(99.99)]
    public void NotNegative_WhenValueIsZeroOrPositive_ShouldNotThrow(
        decimal value)
    {
        var exception = Record.Exception(() =>
            Guard.NotNegative(value));

        Assert.Null(exception);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-10)]
    [InlineData(-99.99)]
    public void NotNegative_WhenValueIsNegative_ShouldThrow(
        decimal value)
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
            Guard.NotNegative(value));

        Assert.Equal("value", exception.ParamName);
    }

    [Fact]
    public void NotDefault_WhenValueIsDefault_ShouldThrowArgumentException()
    {
        var value = Guid.Empty;

        var exception = Assert.Throws<ArgumentException>(() =>
            Guard.NotDefault(value));

        Assert.Equal("value", exception.ParamName);
    }

    [Fact]
    public void NotDefault_WhenValueIsValid_ShouldNotThrow()
    {
        var value = Guid.NewGuid();

        var exception = Record.Exception(() =>
            Guard.NotDefault(value));

        Assert.Null(exception);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void InRange_WhenValueIsInRange_ShouldNotThrow(int value)
    {
        var exception = Record.Exception(() =>
            Guard.InRange(value, 1, 10));

        Assert.Null(exception);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(11)]
    [InlineData(-5)]
    public void InRange_WhenValueIsOutOfRange_ShouldThrow(
        int value)
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
            Guard.InRange(value, 1, 10));

        Assert.Equal("value", exception.ParamName);
    }

    [Fact]
    public void NotNullOrEmpty_WhenCollectionHasItems_ShouldNotThrow()
    {
        var items = new[] { 1, 2, 3 };

        var exception = Record.Exception(() =>
            Guard.NotNullOrEmpty(items));

        Assert.Null(exception);
    }

    [Fact]
    public void NotNullOrEmpty_WhenCollectionIsEmpty_ShouldThrow()
    {
        var items = Array.Empty<int>();

        var exception = Assert.Throws<ArgumentException>(() =>
            Guard.NotNullOrEmpty(items));

        Assert.Equal("items", exception.ParamName);
    }

    [Fact]
    public void NotNullOrEmpty_WhenCollectionIsNull_ShouldThrow()
    {
        int[]? items = null;

        var exception = Assert.Throws<ArgumentException>(() =>
            Guard.NotNullOrEmpty(items));

        Assert.Equal("items", exception.ParamName);
    }
}