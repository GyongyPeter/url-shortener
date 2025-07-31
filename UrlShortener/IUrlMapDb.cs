namespace UrlShortener
{
    public interface IUrlMapDb
    {
        string GetLongUrl(string shortUrl);
        string GetShortUrl(string longUrl);
        void SaveUrlMapping(string shortUrl, string longUrl);
    }
}
