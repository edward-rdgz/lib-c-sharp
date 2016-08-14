using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Tools
{
    /// <summary>
    /// Configuraciones generales de la aplicación.
    /// </summary>
    public class GeneralConfig
    {
        /// <summary>
        /// Construye la ruta del servidor web. (Sirve para referenciar los archivos img, css y js desde la ruta raiz)
        /// </summary>
        /// <param name="strFolderAndFile">Representa el nombre de la carpeta y el archivo separados por una diagonal entre los dos.</param>
        /// <returns>Devuelve la ruta completa del servidor junto con la carpeta y el archivo.</returns>
        public static String ServerPath(String strFolderAndFile)
        {
            // Ruta del servidor web.
            String baseUrl = HttpContext.Current.Request.Url.Scheme + "://" +  HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";
            // Devuelve la ruta web para la carpeta y el archivo.
            return baseUrl + strFolderAndFile;
        }
        /// <summary>
        /// Remueve todos los archivos seleccionados del directorio especificado.
        /// </summary>
        /// <param name="listFiles">Representa la lista de archivos anexados para su depuración.</param>
        public static void CleanFileDirectory(List<String> listFiles)
        {
            // Recorre cada archivo de la lista.
            foreach (var itemFile in listFiles)
            {
                // Remueve el archivo de la carpeta.
                System.IO.File.Delete(itemFile);
            }
        }
        /// <summary>
        /// Método encargado de separar los valores de una cadena dependiendo del caracter especial indicado.
        /// </summary>
        /// <param name="strDataSource">Representa la fuente de datos a formatear.</param>
        /// <param name="strSpecialChar">Representa el caracter especial a remover de la cadena.</param>
        /// <returns>Devuelve una lista de datos en forma de cadena.</returns>
        public static List<String> ParseString(String strDataSource, String strSpecialChar)
        {
            // Inicializa la cadena.
            String str = "";
            // Instancia de una lista númerica.
            List<String> listData = new List<String>();
            // Recorre toda la fuente de datos.
            for (int i = 0; i < strDataSource.Length; i++)
            {
                // Filtra los valores que no tengan comas.
                if (strDataSource.Substring(i, 1) != strSpecialChar)
                {
                    // Concatena cada valor númerico.
                    str += strDataSource.Substring(i, 1);
                }
                else
                {
                    // Añade los valores númericos a la lista.
                    listData.Add(str);
                    // Formatea la variable.
                    str = "";
                }
            }
            // Devuelve la lista númerica conseguida.
            return listData;
        }
        /// <summary>
        /// Método encargado de formatear la cadena de conexión en cada valor.
        /// </summary>
        /// <param name="strConnectionString">Representa la cadena de conexión a dividir.</param>
        /// <returns>Devuelve los valores en un arreglo en formato de cadena.</returns>
        public static List<String> ParseConnectionString(String strConnectionString)
        {
            // Parsea la cadena de conexión en valores separados por cada punto y coma.
            return ParseString(strConnectionString.Replace("=", ";"), ";");
        }
    }
}