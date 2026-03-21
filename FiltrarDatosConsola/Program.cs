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

            // 🔥 VALIDACIÓN SEGURA
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Debe ingresar un número válido");
                continue; // vuelve al inicio del menú
            }

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ingrese el elemento que desea añadir:");
                    lista.Add(Console.ReadLine() ?? string.Empty);
                    break;

                case 2:
                    Console.WriteLine("Ingrese el texto a buscar:");
                    string busqueda = Console.ReadLine() ?? string.Empty;

                    bool encuentra = false;

                    foreach (string item in lista)
                    {
                        if (item.ToLower().Contains(busqueda.ToLower()))
                        {
                            Console.WriteLine(item);
                            encuentra = true;
                        }
                    }

                    if (!encuentra)
                    {
                        Console.WriteLine("El elemento no se encuentra en la lista");
                    }
                    break;

                case 3:
                    Console.WriteLine("Ingrese el elemento a eliminar:");
                    string eliminar = Console.ReadLine() ?? string.Empty;

                    string encontrado = null;

                    foreach (string item in lista)
                    {
                        if (item == eliminar)
                        {
                            encontrado = item;
                            break;
                        }
                    }

                    if (encontrado != null)
                    {
                        lista.Remove(encontrado);
                        Console.WriteLine("Elemento eliminado");
                    }
                    else
                    {
                        Console.WriteLine("El elemento no se encuentra en la lista");
                    }
                    break;

                case 4:
                    Console.WriteLine("Lista actual:");
                    foreach (string item in lista)
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case 5:
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
    }
}