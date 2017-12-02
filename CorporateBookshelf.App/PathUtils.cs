using System.IO;

namespace CorporateBookshelf.App
{
    internal static class PathUtils
    {
        internal static string GetCurrentPath(string entity) => Path.Combine(Directory.GetCurrentDirectory(), $"{entity}.db.json");
    }
}