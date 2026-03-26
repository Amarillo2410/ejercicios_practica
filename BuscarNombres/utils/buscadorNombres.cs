using System;

namespace buscar_nombres.utils;

// Clase que gestiona una lista de nombres y permite buscar dentro de ella.

public class BuscadorNombres
{
    // Busca un nombre dentro de la lista ignorando mayúsculas y minúsculas.
    // retorna True si el nombre existe, False si no
    public static bool Buscar(List<string> nombres, string busqueda)
    {
        // Contains verifica si el elemento existe en la lista
        // StringComparer.OrdinalIgnoreCase hace que "laura" encuentre "Laura"
        return nombres.Contains(busqueda.Trim(), StringComparer.OrdinalIgnoreCase);
    }

    // Muestra todos los nombres de la lista numerados.
    public static void MostrarLista(List<string> nombres)
    {
        Console.WriteLine("\nNombres en la lista:");

        // Ciclo for con índice para mostrar el número de cada nombre
        for (int i = 0; i < nombres.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {nombres[i]}");
        }
    }
}
