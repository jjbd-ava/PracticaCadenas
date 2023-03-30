using System;

namespace Cadenas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();
            bool seguir = true;
            string texto = "";
            while (seguir)
            {
                Console.WriteLine("Introduzca una cadena de al menos 40 caracteres.");
                texto = Console.ReadLine();
                if (texto.Length >= 40) seguir = false;
                else Console.WriteLine($"La cadena introducida contiene {texto.Length} caracteres.");
            }
            seguir = true;
            while (seguir)
            {
                Console.WriteLine("####################################\n#                                  #\n# ¿Qué operación quieres realizar? #\n#                                  #\n####################################\n#                                  #\n# 1.- Sustituir palabra            #\n#                                  #\n# 2.- Buscar texto en cadena       #\n#                                  #\n# 3.- Buscar texto en inicio       #\n#                                  #\n# 4.- Formateador de dígitos       #\n#                                  #\n# 5.- Recortar los espacios        #\n#                                  #\n# 0.- Salir                        #\n#                                  #\n####################################");
                switch (Console.ReadLine()[0])
                {
                    case '0':
                        seguir = false;
                        break;
                    case '1':
                        ReemplazarPalabra(texto);
                        break;
                    case '2':
                        BuscarTexto(texto);
                        break;
                    case '3':
                        ComienzaPor(texto);
                        break;
                    case '4':
                        FormateadorDigitos();
                        break;
                    case '5':
                        RecortarTexto(texto);
                        break;
                    default:
                        Console.WriteLine("Programa no válido.");
                        break;
                }
            }
            
        }

        private static void RecortarTexto(string texto)
        {
            Console.WriteLine($"Así quedaría recortada la cadena:\n{texto.Trim()}");
        }

        private static void FormateadorDigitos()
        {
            Console.WriteLine("Introduce el dígito a rellenar con 0 hasta 12 caracteres.");
            string cadenaNum = Console.ReadLine();
            int digito;
            while(!int.TryParse(cadenaNum,out digito))
            {
                Console.WriteLine("Eso no es un número, introduce otro.");
                cadenaNum = Console.ReadLine();
            }
            cadenaNum = cadenaNum.PadLeft(12, '0');
            Console.WriteLine($"Resultado: {cadenaNum}");
        }

        private static void ComienzaPor(string texto)
        {
            Console.WriteLine("Introduzca el texto a buscar en el inicio");
            string textoBusqueda = Console.ReadLine();
            //TODO Usar el método StartsWith mejor.
            if (texto.IndexOf(textoBusqueda) == 0)
            {
                Console.WriteLine("La cadena comienza con el texto especificado.");
            }
            else Console.WriteLine("El comienzo de la cadena no se corresponde con el texto especificado.");
        }

        private static void BuscarTexto(string texto)
        {
            Console.WriteLine("Introduzca el texto a buscar");
            string textoBusqueda = Console.ReadLine();
            int posicionInicial = 0;
            int posicionFinal = texto.IndexOf(textoBusqueda);
            int ocurrencias = texto.Split(textoBusqueda).Length - 1;
            Console.WriteLine(ocurrencias);
            if (ocurrencias>0)
            {
                for(int i = 1; i <= ocurrencias; i++)
                {
                    Console.Write(texto.Substring(posicionInicial,posicionFinal));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(textoBusqueda);
                    Console.ResetColor();
                    posicionInicial += posicionFinal + textoBusqueda.Length;
                    posicionFinal = texto.Substring(posicionInicial).IndexOf(textoBusqueda);
                }
                Console.WriteLine(texto.Substring(posicionInicial));
            }
            else Console.WriteLine("No se ha encontrado el texto.");
        }

        private static void ReemplazarPalabra(string texto)
        {
            Console.WriteLine("Introduzca la palabra a sustituir, un espacio y la sustituta");
            string cadenappal = Console.ReadLine();
            //TODO Utilizar la función Split
            if (cadenappal.IndexOf(' ') != -1)
            {
                string sustituir = cadenappal.Substring(0, cadenappal.IndexOf(' '));
                string sustituta = cadenappal.Substring(cadenappal.IndexOf(' ') + 1);
                if (cadenappal.IndexOf(sustituir) != -1)
                {
                    Console.WriteLine($"Resultado:\n{texto.Replace(sustituir, sustituta)}");
                }
                else Console.WriteLine("No hay nada que sustituir.");
            }
            else Console.WriteLine("Te ha faltado el espacio.");
        }
    }
}
