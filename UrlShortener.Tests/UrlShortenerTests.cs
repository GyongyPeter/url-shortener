namespace UrlShortener.Tests
{
    public class UrlShortenerTests
    {
        private readonly UrlShortener _urlShortener;
        private readonly InMemoryUrlMapDb _urlMapDb;

        public UrlShortenerTests()
        {
            _urlMapDb = new InMemoryUrlMapDb();
            _urlShortener = new UrlShortener(_urlMapDb);
        }

        [Fact]
        public void GetShortUrlByLong_ShouldReturnShortUrl()
        {
            // Arrange
            var longUrl = "https://abacusmedicinegroup.com/";
            var generatedShortUrl = _urlShortener.SaveUrlMappingToCache(longUrl);

            // Act
            var receivedShortUrl = _urlShortener.GetShortUrlByLong(longUrl);

            // Assert
            Assert.Equal(generatedShortUrl, receivedShortUrl);
        }

        [Fact]
        public void GetLongUrlByShort_ShouldReturnLongUrl()
        {
            // Arrange
            var longUrl = "https://abacusmedicinegroup.com/";
            var generatedShortUrl = _urlShortener.SaveUrlMappingToCache(longUrl);

            // Act
            var receivedLongUrl = _urlShortener.GetLongUrlByShort(generatedShortUrl);

            // Assert
            Assert.Equal(longUrl, receivedLongUrl);
        }

        [Fact]
        public void SaveUrlMappingToCache_ShouldNotAddNewShortUrlIfLongExists()
        {
            // Arrange
            var longUrl = "https://abacusmedicinegroup.com/";
            var generatedShortUrl1 = _urlShortener.SaveUrlMappingToCache(longUrl);

            // Act
            var generatedShortUrl2 = _urlShortener.SaveUrlMappingToCache(longUrl);

            // Assert
            Assert.Equal(generatedShortUrl1, generatedShortUrl2);
        }

        [Fact]
        public void GetShortUrlByLong_WithUnknownUrl_ShouldThrow()
        {
            // Arrange
            var unknownUrl = "https://nonexistent.com/";

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() =>
                _urlShortener.GetShortUrlByLong(unknownUrl));
        }

        [Fact]
        public void GetLongUrlByShort_WithUnknownShortUrl_ShouldThrow()
        {
            // Arrange
            var unknownShortUrl = "sho.rt/12345678";

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() =>
                _urlShortener.GetLongUrlByShort(unknownShortUrl));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void GetShortUrlByLong_WithInvalidInput_ShouldThrow(string input)
        {
            Assert.Throws<ArgumentException>(() =>
                _urlShortener.GetShortUrlByLong(input));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void GetLongUrlByShort_WithInvalidInput_ShouldThrow(string input)
        {
            Assert.Throws<ArgumentException>(() =>
                _urlShortener.GetLongUrlByShort(input));
        }
    }
}