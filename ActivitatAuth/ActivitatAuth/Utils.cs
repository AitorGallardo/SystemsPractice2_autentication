using System;
using System.IO;
using System.Text.RegularExpressions;
namespace ActivitatAuth

{
    public static class Utils
    {

        private static string FitxerUsuaris => "users.txt";


        public static void IniFile()
        {
            if (!File.Exists(FitxerUsuaris))

                using (File.Create(FitxerUsuaris))
                {
                    //Creem el fitxer si aquest no existeix
                }



        }

        /// <summary>
        /// Afegim a l'arxiu una línia amb el nom d'usuari i el hash
        /// </summary>
        /// <param name="nomUsuari"></param>
        /// <param name="hashUsuari"></param>
        /// <returns>true si s'ha fet, false en cas contrari</returns>
        public static bool EscriuFitxer(string nomUsuari, string hashUsuari)
        {

            try
            {
                string linia = nomUsuari + "," + hashUsuari;
                using (StreamWriter w = File.AppendText(FitxerUsuaris))
                {
                    w.WriteLine(linia);
                }
                System.Diagnostics.Process.Start(FitxerUsuaris); // Open file to check inserted values
                return true;
            }
            catch
            {

                return false;

            }

        }

        /// <summary>
        /// Determina si el nom usuari compleix les condicions.
        /// Condicions:
        /// Mida de 4 a 24 caràcters
        /// Començar per una lletra a-zA-Z
        /// Contenir lletres, nombres o '.','-' o '_'
        /// No pot acabar en '.','-','._' o '-_' 
        /// </summary> 
        /// <param name="nomUsuari"></param>
        /// <returns>True si és vàlid i false cas contrari</returns>
        public static bool ValidaUsuariRegex(string nomUsuari)
        {

            Regex expression = new Regex(@"^[a-zA-Z][a-zA-Z0-9\._\-]{3,23}[a-zA-Z0-9]$");
            bool resultat = expression.IsMatch(nomUsuari);

            return resultat;
        }

        public static string EntraUsuari()
        {

            string nomUsuari = null;
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    nomUsuari += key.KeyChar;
                    Console.Write(key.Key);
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    Console.Write("\b \b");

                }
            }
            while (key.Key != ConsoleKey.Enter);
            return nomUsuari;

        }



        /// <summary>
        /// Recorre l'arxiu d'usuaris buscant l'usuari 
        /// </summary>
        /// <param name="nomUsuari"></param>
        /// <returns>Retorna null si no troba l'usuari i el string de hash si el troba</returns>
        public static string LlegirUsuari(string nomUsuari)
        {
            string text = "";

            return text;
           

        }




    }
}
