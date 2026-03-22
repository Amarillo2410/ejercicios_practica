using System;
using System.Collections.Generic;

class EjercicioUno
{
    static void Main()
    {
        List<string> lista = new List<string>();
        int opcion = 0;

        while (opcion != 5)
        {
            Console.WriteLine("\n--- MENÚ ---");
            Console.WriteLine("1. Añadir elemento a la lista");
            Console.WriteLine("2. Buscar elemento de la lista");
            Console.WriteLine("3. Eliminar elemento de la lista");
            Console.WriteLine("4. Mostrar la lista");
            Console.WriteLine("5. Salir");
            Console.Write("Ingrese una opción: ");

            // VALIDACIÓN SEGURA
            if (!int.TryParse(Console.ReadLine(), out opcion)) // Trypase devuelve true o false despues de convefrtir en entero el string del usuario, si no se puede convertir devuelve false y se le pide al usuario que ingrese un número válido
            {
                Console.WriteLine("Debe ingresar un número válido"); // Si no ingresa una opción válida muentra el error 
                continue; // vuelve al inicio del menú
            }

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ingrese el elemento que desea añadir:");// Se le avisa al usuario que va a añadir algo a la lista
                    lista.Add(Console.ReadLine() ?? string.Empty); // añade el elemnento a la lista "Lista", el string.Empty es para evitar que se añada un valor nulo a la lista
                    break;

                case 2:
                    Console.WriteLine("Ingrese el texto a buscar:"); // se le avisa al usuario que va a buscar algo en la lista
                    string busqueda = Console.ReadLine() ?? string.Empty;

                    bool encuentra = false; // Se le coloca un valor inicial false a la variable "encuentra" porque no se ha encontrado ningun obejto

                    foreach (string item in lista) // foreach para recorrer cada elemento de la lista 
                    {
                        if (item.ToLower().Contains(busqueda.ToLower())) // Se verifica si lo que el usuario coloca conincide con algun elemento de la Lista
                        {
                            Console.WriteLine(item); // se escriie el elemento encontrado
                            encuentra = true;
                        }
                    }

                    if (!encuentra) // si el objeto no se encuentra en la lista 
                    {
                        Console.WriteLine("El elemento no se encuentra en la lista");
                    }
                    break;

                case 3:
                    Console.WriteLine("Ingrese el elemento a eliminar:");
                    string eliminar = Console.ReadLine() ?? string.Empty; // se declara la variable eliminar que pide al usuario el elemento que desea eliminar

                    string encontrado = null;

                    foreach (string item in lista)// recorre la lista 
                    {
                        if (item == eliminar) // se verifica que lo que el usuario quiera eliminar este en la lista
                        {
                            encontrado = item;// se declara la variable encontrado sea igual al item de la lista
                            break;
                        }
                    }

                    if (encontrado != null) // si se encuentra el elemento en la lista
                    {
                        lista.Remove(encontrado); // se elimina el objeto que el usuario pidio que se borrara
                        Console.WriteLine("Elemento eliminado");
                    }
                    else
                    {
                        Console.WriteLine("El elemento no se encuentra en la lista");
                    }
                    break;

                case 4:
                    Console.WriteLine("Lista actual:");

                    foreach (string item in lista) //recorre todos los elementos de la lista
                    {
                        Console.WriteLine(item); // muestra los elementos de la lista
                    }
                    break;

                case 5:
                    Console.WriteLine("Saliendo del sistema..."); // salimos del ciclo
                    break;

                default:
                    Console.WriteLine("Opción no válida"); // se le avisa al usuario que la opcion que dio no es valida
                    break;
            }
        }
    }
}