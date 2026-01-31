using SERVICES.DAL.Implementations;
using SERVICES.Domain.Exceptions;

namespace SERVICES.Services
{
    public static class LanguageManager
    {
        public static string Translate(string key)
        {
            try
            {
                return LanguageRepository.Translate(key);
            }
            catch (WordNotFoundException)
            {
                return key;
            }
            catch
            {
                return key;
            }
        }
    }
}
