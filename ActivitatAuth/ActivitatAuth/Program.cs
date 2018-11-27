using System;

namespace ActivitatAuth
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            Utils.IniFile();
            bool exit = false;
            ConsoleKeyInfo option;
            Console.Clear();
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("************** AUTENTICACIO ********************");
                Console.WriteLine();
                Console.WriteLine("1............. VALIDAR-SE");
                Console.WriteLine("2............. REGISTRAR-SE");
                Console.WriteLine("0............. EXIT");
                Console.WriteLine("**************************************************");
                do
                {
                    // El ReadKey(true) és perquè no s'escrigui per tornarpantalla
                    option = Console.ReadKey(true);
                } while (option.KeyChar < '0' || option.KeyChar > '2');
                Console.Clear();
                string user;
                string password;
                switch (option.KeyChar)
                {
                    // Validar usuari
                    // Es demana usuari i password i es comprova
                    // si el vàlid es mostra el missatge de benvinguda
                    // cas contrari es mostra un avís
                    case '1':
                        Console.Write("Has escollit autenticarte.\nIntrodueix el nom d'usuari: ");
                        user = Utils.EntraUsuari();
                        Console.Write("\nIntrodueix el password: ");
                        password = Criptografia.EntraPassword();

                        bool registeredUser = Criptografia.ComprovaUsuari(user, password);

                        user = null;
                        password = null;
                        Console.ReadKey();
                        break;





                    // Donar d'alta usuari
                    // Es demana nom d'usuari (es comprova validesa)
                    // Es demana el password es comprova si té criteris mínims
                    // Si passa criteri es demana per tornarsegon cop per tornarassegurar
                    // Finalment s'afegeix l'usuari/password al fitxer


                    case '2': // Falta comprobar si el usuario yas existe || Podria dar la opcion de volver a introducir valores 
                             // || controlar el error si no introduces nada || catch con los errores posibles

                        Console.Write("Has escollit registarte.\nIntrodueix el nou nom d'usuari: ");
                        bool validUser = false;

                        user = Utils.EntraUsuari();
                        if (Utils.LlegirUsuari(user)==null)
                        {
                            if (validUser = Utils.ValidaUsuariRegex(user))
                            {
                                Console.Write("\nUsuari correcte\n\n");
                                Console.Write("\nIntrodueix el password: ");
                                password = Criptografia.EntraPassword();
                                Console.Write("\nTorna a introduir el password: ");
                                string repeatPassword = Criptografia.EntraPassword();

                                if (password.Equals(repeatPassword))
                                {
                                    Console.Write("\nPassword correcte. Usuari creat correctament");
                                    bool onCreateUserSucced = Criptografia.AltaUsuari(user, password); 
                                }
                                else
                                {
                                    Console.Write("\nEls passwords no concideixen");
                                }
                            }
                            else
                            {
                                Console.Write("\nUsuari incorrecte.\n Mida de 4 a 24 caràcters \n Caracters acceptats: numeros, lletres, '.','-','_' " +
                                                "\n L'usuari ha de començar per una lletra. \n No pot acabar en '.','-','._' o '-_'");
                            }
                        }
                        else
                        {
                        Console.Write("\nAquest usuari ja existeix");
                        }

                        user = null;
                        password = null;
                        Console.ReadKey();

                        break;  


                    // Sortim del programa   
                    case '0':
                        exit = true;
                        break;
                }

            }
        }
    }
}
