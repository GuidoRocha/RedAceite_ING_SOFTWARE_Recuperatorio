using System;

namespace SERVICES.Domain.Exceptions
{
    /// <summary>
    /// Se lanza cuando no se encuentra una key de traducción en el archivo de idioma.
    /// </summary>
    public sealed class WordNotFoundException : Exception
    {
        public string Key { get; }

        public WordNotFoundException(string key)
            : base($"Word not found for key: {key}")
        {
            Key = key;
        }

        public WordNotFoundException(string key, Exception innerException)
            : base($"Word not found for key: {key}", innerException)
        {
            Key = key;
        }
    }
}
