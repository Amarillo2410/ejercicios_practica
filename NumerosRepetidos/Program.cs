using System;
using System.Collections.Generic;

class EjercicioDos
{
    static void Main()
    {
        List<int> Numeros = new List<int>(); // se crea una lista donde se guardaran los numeros
        int opciones = 0; // variable para guardar la opcion del menu
        while (opciones != 5) // mientras sea diferente a 5 (salir) se ejecutara ek programa
        {
            //menu de opciones para el usuario
            Console.WriteLine("--MENU--");
            Console.WriteLine("1. Agregar numero a la lista");
            Console.WriteLine("2. Mostrar numeros en la lista");
            Console.WriteLine("3. eliiminar numeros de la lista");
            Console.WriteLine("4. Numeros en la lista repetidos");
            Console.WriteLine("5. Salir");


            Console.WriteLine("ingrese valosres a la lista");
            if(!int.TryParse(Console.ReadLine(), out int enteros) )//controlamos que lo ingresado sea un numero valido
            {
                Console.WriteLine("Opcion no valida");
                continue;
            }
            switch(enteros){
                case 1:
                    Console.WriteLine("Ingrese un numero para agregar a la lista");
                    if(int.TryParse(Console.ReadLine(), out int numeroAgregar)) // si el numero es valido se agrega a la lista, sino se muestra un mensaje de error
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
                    foreach (int numero in Numeros) // se muestra cada numero en la lista
                    {
                        Console.WriteLine(numero);
                    }
                    break;
                case 3:
                    Console.WriteLine("Ingrese un numero para eliminar de la lista");
                    if(int.TryParse(Console.ReadLine(), out int numeroEliminar)) // se valida el numero 
                    {
                        if(Numeros.Remove(numeroEliminar)) // si el numero esta en la lista se elimina
                        {
                            Console.WriteLine("Numero eliminado de la lista");
                        }
                        else
                        {
                            Console.WriteLine("Numero no encontrado en la lista"); // si el numero no esta en la lista se muestra un mensaje de error
                        }
                    }
                    break;
                case 4:
                    Console.WriteLine("Numeros repetidos en la lista: ");
                    // se crea una "lista" que guarda numeros unicos y otra que guarde numero repetidos
                    HashSet<int> numerosUnicos = new HashSet<int>();
                    HashSet<int> numerosRepetidos = new HashSet<int>();
                    foreach (int numero in Numeros)// se recorre los valores de la lista
                    {
                        if (!numerosUnicos.Add(numero))//si el no se repite se repite 
                        {
                            numerosRepetidos.Add(numero);// se guardan numeros repetidos
                        }
                    }
                    foreach (int numero in numerosRepetidos)
                    {
                        Array.Sort(Numeros.ToArray()); // se organiza la lista de numeros 
                        Console.WriteLine(numero);// se imprime los numeros repetidos en la lista
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
