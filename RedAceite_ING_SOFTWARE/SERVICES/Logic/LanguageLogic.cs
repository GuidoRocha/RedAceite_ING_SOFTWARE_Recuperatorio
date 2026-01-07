using SERVICES.DAL;
using SERVICES.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERVICES.Logic
{
    internal static class LanguageLogic
    {
        /// <summary>
        /// Traduce una clave de texto a su valor en el idioma actual.
        /// </summary>
        /// <param name="key">Clave de texto a traducir.</param>
        /// <returns>Texto traducido si la clave existe, o la clave original en caso de error.</returns>
        public static string Translate(string key)
        {
            try
            {
                // Simplemente llamar a la DAO para traducir la clave
                return LanguageRepository.Translate(key);
            }
            catch (Exception ex)
            {
                // Registrar cualquier excepción, si es necesario
                Console.WriteLine(ex.Message);
                LoggerService.WriteException(ex);
            }

            return key; // Si ocurre un error, se retorna la clave original
        }
        /// <summary>
        /// Traduce todos los controles de un formulario utilizando las claves de traducción en las etiquetas (tags) de los controles.
        /// </summary>
        /// <param name="control">Control principal del formulario a traducir.</param>
        public static void TranslateForm(Control control)
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl.Tag != null && !string.IsNullOrEmpty(ctrl.Tag.ToString()))
                {
                    ctrl.Text = Translate(ctrl.Tag.ToString());
                }

                // Traducir recursivamente subcontroles
                if (ctrl.HasChildren)
                {
                    TranslateForm(ctrl);
                }

                // Verificar si es un MenuStrip
                if (ctrl is MenuStrip menuStrip)
                {
                    foreach (ToolStripMenuItem item in menuStrip.Items)
                    {
                        TranslateMenuItem(item);
                    }
                }
            }

            // Si el control en sí es un MenuStrip
            if (control is MenuStrip menuStripDirect)
            {
                foreach (ToolStripMenuItem item in menuStripDirect.Items)
                {
                    TranslateMenuItem(item);
                }
            }
        }
        /// <summary>
        /// Traduce un elemento de menú y todos sus subelementos.
        /// </summary>
        /// <param name="menuItem">Elemento de menú a traducir.</param>
        private static void TranslateMenuItem(ToolStripMenuItem menuItem)
        {
            if (menuItem.Tag != null && !string.IsNullOrEmpty(menuItem.Tag.ToString()))
            {
                menuItem.Text = Translate(menuItem.Tag.ToString());
            }

            // Traducir recursivamente subitems
            foreach (ToolStripItem subItem in menuItem.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                {
                    TranslateMenuItem(subMenuItem);
                }
            }
        }

        /// <summary>
        /// Guarda el idioma seleccionado para el usuario actual.
        /// </summary>
        /// <param name="languageCode">Código del idioma a guardar.</param>
        public static void SaveUserLanguage(string languageCode)
        {
            LanguageRepository.SaveUserLanguage(languageCode);
        }

        /// <summary>
        /// Carga el idioma seleccionado previamente para el usuario actual.
        /// </summary>
        /// <returns>El código del idioma seleccionado.</returns>
        public static string LoadUserLanguage()
        {
            return LanguageRepository.LoadUserLanguage();
        }



    }
}
