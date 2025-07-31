namespace UrlShortener
{
    public class InMemoryUrlMapDb : IUrlMapDb
    {
        private readonly Dictionary<string, string> _shortToLong = new();
        private readonly Dictionary<string, string> _longToShort = new();

        public string GetLongUrl(string shortUrl)
        {
            _shortToLong.TryGetValue(shortUrl, out var longUrl);
            return longUrl;
        }

        public string GetShortUrl(string longUrl)
        {
            _longToShort.TryGetValue(longUrl, out var shortUrl);
            return shortUrl;
        }

        public void SaveUrlMapping(string shortUrl, string longUrl)
        {
            _shortToLong[shortUrl] = longUrl;
            _longToShort[longUrl] = shortUrl;
        }
    }
}
