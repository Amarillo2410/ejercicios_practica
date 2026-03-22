using System;
using System.Collections.Generic;

class EjercicioDos
{
    static void Main()
    {
        List<int> Numeros = new List<int>();
        int opciones = 0;
        while (opciones != 5)
        {
            Console.WriteLine("--MENU--");
            Console.WriteLine("1. Agregar numero a la lista");
            Console.WriteLine("2. Mostrar numeros en la lista");
            Console.WriteLine("3. eliiminar numeros de la lista");
            Console.WriteLine("4. Numeros en la lista repetidos");
            Console.WriteLine("5. Salir");


            Console.WriteLine("ingrese valosres a la lista");
            if(!int.TryParse(Console.ReadLine(), out int enteros) )
            {
                Console.WriteLine("Opcion no valida");
                continue;
            }
            switch(enteros){
                case 1:
                    Console.WriteLine("Ingrese un numero para agregar a la lista");
                    if(int.TryParse(Console.ReadLine(), out int numeroAgregar))
                    {
                        Numeros.Add(numeroAgregar);
                        Console.WriteLine("Se ha agregado " + numeroAgregar + " a la lista");
                    }
                    else
                    {
                        Console.WriteLine("Numero no valido");
                    }
                    break;
                case 2:
                    Console.WriteLine("Lista: ");
                    foreach (int numero in Numeros)
                    {
                        Console.WriteLine(numero);
                    }
                    break;
                case 3:
                    Console.WriteLine("Ingrese un numero para eliminar de la lista");
                    if(int.TryParse(Console.ReadLine(), out int numeroEliminar))
                    {
                        if(Numeros.Remove(numeroEliminar))
                        {
                            Console.WriteLine("Numero eliminado de la lista");
                        }
                        else
                        {
                            Console.WriteLine("Numero no encontrado en la lista");
                        }
                    }
                    break;
                case 4:
                    Console.WriteLine("Numeros repetidos en la lista: ");
                    HashSet<int> numerosUnicos = new HashSet<int>();
                    HashSet<int> numerosRepetidos = new HashSet<int>();
                    foreach (int numero in Numeros)
                    {
                        if (!numerosUnicos.Add(numero))
                        {
                            numerosRepetidos.Add(numero);
                        }
                    }
                    foreach (int numero in numerosRepetidos)
                    {
                        Console.WriteLine(numero);
                    }
                    break;
                case 5:
                    Console.WriteLine("Saliendo del programa...");
                    return;
            default:
                Console.WriteLine("Opcion no valida");
                break;
            }

        }
    }
}
