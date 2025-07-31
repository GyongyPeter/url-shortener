namespace UrlShortener
{
    public class InMemoryUrlMapDb : IUrlMapDb
    {
        private readonly Dictionary<string, string> _shortToLong = new();

        public string GetLongUrl(string shortUrl)
        {
            _shortToLong.TryGetValue(shortUrl, out var longUrl);
            return longUrl;
        }

        public void SaveUrlMapping(string shortUrl, string longUrl)
        {
            _shortToLong[shortUrl] = longUrl;
        }
    }
}
