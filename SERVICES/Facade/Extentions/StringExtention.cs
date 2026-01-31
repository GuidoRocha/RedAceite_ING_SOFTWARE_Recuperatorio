namespace SERVICES.Facade.Extentions
{
    public static class StringExtention
    {
        public static string Translate(this string key)
        {
            return LanguageService.Translate(key);
        }
    }
}
