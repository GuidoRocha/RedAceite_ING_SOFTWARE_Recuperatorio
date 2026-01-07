using SERVICES.DAL.Contratos;
using SERVICES.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERVICES.Facade
{
    /// <summary>
    /// Servicio encargado de gestionar el idioma de la aplicación.
    /// Permite traducir claves, formularios y notificar cambios a observadores.
    /// </summary>
    public static class LanguageService
    {
        private static List<ILanguageObserver> observers = new List<ILanguageObserver>();

        /// <summary>
        /// Suscribe un observador al sistema de idioma para recibir notificaciones de cambio.
        /// </summary>
        /// <param name="observer">Instancia que implementa <see cref="ILanguageObserver"/>.</param>
        public static void Subscribe(ILanguageObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        /// <summary>
        /// Elimina un observador previamente suscripto.
        /// </summary>
        /// <param name="observer">Instancia que implementa <see cref="ILanguageObserver"/>.</param>
        public static void Unsubscribe(ILanguageObserver observer)
        {
            observers.Remove(observer);
        }

        /// <summary>
        /// Notifica a todos los formularios y componentes suscritos que el idioma ha cambiado.
        /// Llama a <c>UpdateLanguage()</c> en cada observador.
        /// </summary>
        private static void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.UpdateLanguage();
            }
        }

        /// <summary>
        /// Traduce una clave textual según el idioma actual del sistema.
        /// </summary>
        /// <param name="key">Clave a traducir (ej. "Guardar", "Cliente").</param>
        /// <returns>Texto traducido correspondiente al idioma activo.</returns>
        public static string Translate(string key)
        {
            return LanguageLogic.Translate(key);
        }

        /// <summary>
        /// Guarda el idioma seleccionado por el usuario y notifica a los observadores.
        /// </summary>
        /// <param name="languageCode">Código del idioma (por ejemplo: "es", "en").</param>
        public static void SaveUserLanguage(string languageCode)
        {
            LanguageLogic.SaveUserLanguage(languageCode);
            NotifyObservers();
        }

        /// <summary>
        /// Carga el idioma previamente guardado del usuario.
        /// </summary>
        /// <returns>Código del idioma actual (por ejemplo: "es", "en").</returns>
        public static string LoadUserLanguage()
        {
            return LanguageLogic.LoadUserLanguage();
        }

        /// <summary>
        /// Aplica traducción automática a todos los controles de un formulario dado.
        /// </summary>
        /// <param name="control">Control raíz (por lo general el formulario completo).</param>
        public static void TranslateForm(Control control)
        {
            LanguageLogic.TranslateForm(control);
        }
    }
}
