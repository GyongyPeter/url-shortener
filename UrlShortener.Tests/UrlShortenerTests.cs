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
        public void GetShortUrlByNormal_ShouldReturnShortUrl()
        {
            // Arrange
            var normalUrl = "https://abacusmedicinegroup.com/";
            var generatedShortUrl = _urlShortener.SaveUrlMappingToCache(normalUrl);

            // Act
            var receivedShortUrl = _urlShortener.GetShortUrlByNormal(normalUrl);

            // Assert
            Assert.Equal(generatedShortUrl, receivedShortUrl);
        }

        [Fact]
        public void GetNormalUrlByShort_ShouldReturnOriginalUrl()
        {
            // Arrange
            var normalUrl = "https://abacusmedicinegroup.com/";
            var generatedShortUrl = _urlShortener.SaveUrlMappingToCache(normalUrl);

            // Act
            var receivedNormalUrl = _urlShortener.GetNormalUrlByShort(generatedShortUrl);

            // Assert
            Assert.Equal(normalUrl, receivedNormalUrl);
        }
    }
}