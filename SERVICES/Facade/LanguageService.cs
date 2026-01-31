using SERVICES.Services;

namespace SERVICES.Facade
{
    public static class LanguageService
    {
        public static string Translate(string key) => LanguageManager.Translate(key);
    }
}
