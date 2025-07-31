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
    }
}