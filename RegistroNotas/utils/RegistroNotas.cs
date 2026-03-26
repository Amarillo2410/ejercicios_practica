using System;

namespace registro_notas.utils;

// Clase que analiza una lista de notas decimales y genera estadísticas.

public class RegistroNotas
{
    // Nota mínima aprobatoria definida como constante
    private const double NOTA_APROBATORIA = 3.0;

    // Calcula el promedio de una lista de notas.

    public static double Promedio(List<double> notas)
    {
        // Acumulamos la suma de todas las notas
        double suma = 0;

        foreach (double nota in notas)
            suma += nota;

        // Dividimos la suma entre la cantidad de notas para obtener el promedio
        return suma / notas.Count;
    }

    // Cuenta cuántas notas son superiores o iguales a 3.0.
    public static int ContarAprobadas(List<double> notas)
    {
        int contador = 0;

        // Recorremos cada nota y verificamos si supera la nota aprobatoria
        foreach (double nota in notas)
        {
            if (nota >= NOTA_APROBATORIA)
                contador++;
        }

        return contador;
    }

    // Muestra el reporte completo: notas, promedio y aprobadas.
    public static void MostrarReporte(List<double> notas)
    {
        Console.WriteLine("\n─────────────────────────────");
        Console.WriteLine("          Notas");
        Console.WriteLine("─────────────────────────────");

        // Mostramos cada nota con su número y si aprobó o no
        for (int i = 0; i < notas.Count; i++)
        {
            // Indicamos si la nota es aprobatoria o no con un ícono
            string estado = notas[i] >= NOTA_APROBATORIA ? "✓" : "✗";
            Console.WriteLine($"  Nota {i + 1,2}: {notas[i]:F1}  {estado}");
        }

        // Calculamos y mostramos el promedio
        double promedio = Promedio(notas);
        int aprobadas   = ContarAprobadas(notas);
        int reprobadas  = notas.Count - aprobadas;

        Console.WriteLine("─────────────────────────────");
        Console.WriteLine($"  Total notas:  {notas.Count}");
        Console.WriteLine($"  Promedio:     {promedio:F2}");
        Console.WriteLine($"  Aprobadas:    {aprobadas}  (>= {NOTA_APROBATORIA})");
        Console.WriteLine($"  Reprobadas:   {reprobadas}  (< {NOTA_APROBATORIA})");
        Console.WriteLine("─────────────────────────────");
    }
}