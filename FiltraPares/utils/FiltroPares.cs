using System;

namespace filtrar_pares.utils;

// Clase que filtra una lista de enteros y retorna solo los números pares.
public class FiltroPares
{

    // Recorre la lista original y genera una nueva lista que contiene únicamente los números pares.
    // La lista original no se modifica.
    public static List<int> FiltrarPares(List<int> numeros)
    {
        // Nueva lista donde se guardarán solo los números pares
        List<int> pares = new List<int>();

        // Recorremos cada número de la lista original
        foreach (int numero in numeros)
        {
            // Si el número es par, lo agregamos
            if (numero % 2 == 0)
                pares.Add(numero);
        }

        return pares;
    }

    // Muestra una lista de enteros con su título en consola.
    public static void MostrarLista(string titulo, List<int> lista)
    {
        Console.Write($"{titulo}: [");
        Console.Write(string.Join(", ", lista));
        Console.WriteLine("]");
        Console.WriteLine($"  Total: {lista.Count} elemento(s).");
    }
}