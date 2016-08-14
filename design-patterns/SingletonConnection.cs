using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.DesignPatterns
{
    /// <summary>
    /// Se crea una conexión de datos con el patrón de diseño: Singleton
    /// </summary>
    /// Se heredan los componentes de la conexión de datos principal.
    public class SingletonConnection : dbConnectionSource
    {
        // Se declara e inicializa un objeto privado, estático y del tipo de la clase en nulo como referencia a una instancia futura.
        private static SingletonConnection Instance = null;
        // Se invoca al constructor de la clase de manera privada para así evitar la creación de nuevas instancias de esta clase desde otros contextos.
        private SingletonConnection() {  }
        // Se crea una propiedad pública, estática y del tipo de la clase para obtener el nuevo valor del objeto.
        public static SingletonConnection SingletonConnection
        {
            get
            {
                // Se valida si el objeto es nulo.
                if (Instance == null)
                {
                    // Se reasigna el valor del objeto como una instancia de esta clase.
                    Instance = new SingletonConnection();
                }
                // Se devuelve el objeto de la instancia con los nuevos valores y componentes.
                return Instance;
            }
        }
    }
}