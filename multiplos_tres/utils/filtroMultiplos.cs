using System;

namespace multiplos_tres.utils;

// Clase que filtra los múltiplos de 3 de una lista de enteros.
public class FiltroMultiplos
{
    // Recorre la lista original y genera una nueva lista con solo los múltiplos de 3. La lista original no se modifica.
    public static List<int> FiltrarMultiplosDeTres(List<int> numeros)
    {
        // Lista nueva donde se guardarán los múltiplos encontrados
        List<int> multiplos = new List<int>();

        // Recorremos cada número de la lista original
        foreach (int numero in numeros)
        {
            // Un número es múltiplo de 3 si el residuo de dividirlo entre 3 es 0
            // Usamos Math.Abs para que funcione también con números negativos
            if (numero % 3 == 0)
                multiplos.Add(numero);
        }

        return multiplos;
    }

    /// Muestra una lista con su título y estadísticas básicas.
    public static void MostrarLista(string titulo, List<int> lista)
    {
        Console.WriteLine($"\n  {titulo}:");

        if (lista.Count == 0)
        {
            Console.WriteLine("  (ninguno)");
            return;
        }

        // Mostramos los elementos en una sola línea entre corchetes
        Console.WriteLine($"  [{string.Join(", ", lista)}]");
        Console.WriteLine($"  Total: {lista.Count} elemento(s).");
    }
}