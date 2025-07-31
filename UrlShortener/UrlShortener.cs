namespace UrlShortener
{
    public class UrlShortener
    {
        private readonly IUrlMapDb _urlMapDb;

        public UrlShortener(IUrlMapDb urlMapDb)
        {
            _urlMapDb = urlMapDb;
        }

        public string GetShortUrlByLong(string longUrl)
        {
            if (string.IsNullOrWhiteSpace(longUrl))
            {
                throw new ArgumentException("Url cannot be empty");
            }

            var shortUrl = _urlMapDb.GetShortUrl(longUrl);
            if (shortUrl == null)
            {
                throw new KeyNotFoundException("Long url not found");
            }

            return shortUrl;
        }

        public string GetLongUrlByShort(string shortUrl)
        {
            if (string.IsNullOrWhiteSpace(shortUrl))
            {
                throw new ArgumentException("Url cannot be empty");
            }

            var longUrl = _urlMapDb.GetLongUrl(shortUrl);
            if (longUrl == null)
            {
                throw new KeyNotFoundException("Short url not found");
            }

            return longUrl;
        }

        public string SaveUrlMappingToCache(string longUrl)
        {
            if (_urlMapDb.GetShortUrl(longUrl) is { } existingShortUrl)
            {
                return existingShortUrl;
            }

            var shortUrl = GenerateShortUrl();
            _urlMapDb.SaveUrlMapping(shortUrl, longUrl);

            return shortUrl;
        }

        private string GenerateShortUrl()
        {
            var hash = Guid.NewGuid().ToString()[..8];
            return $"sho.rt/{hash}";
        }
    }
}
