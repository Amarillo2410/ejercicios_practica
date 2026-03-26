using System;

namespace gestion_edades.utils;

// Clase que analiza una lista de edades y genera estadísticas.
public class GestorEdades
{
    // Edad mínima para ser considerado mayor de edad
    private const int MAYORIA_EDAD = 18;

    // Calcula el promedio de una lista de edades.
    public static double Promedio(List<int> edades)
    {
        // Acumulamos la suma de todas las edades
        int suma = 0;
        foreach (int edad in edades)
            suma += edad;

        // Dividimos entre la cantidad total de edades registradas
        return (double)suma / edades.Count;
    }

    // Cuenta cuántas personas son mayores de edad (>= 18).
    public static int ContarMayores(List<int> edades)
    {
        int contador = 0;
        foreach (int edad in edades)
        {
            if (edad >= MAYORIA_EDAD)
                contador++;
        }
        return contador;
    }

    // Cuenta cuántas personas son menores de edad (menos de 18).
    public static int ContarMenores(List<int> edades)
    {
        int contador = 0;
        foreach (int edad in edades)
        {
            if (edad < MAYORIA_EDAD)
                contador++;
        }
        return contador;
    }

    // Muestra el reporte completo con todas las estadísticas.
    public static void MostrarReporte(List<int> edades)
    {
        int    mayores  = ContarMayores(edades);
        int    menores  = ContarMenores(edades);
        double promedio = Promedio(edades);

        Console.WriteLine("\n──────────────────────────────");
        Console.WriteLine("         Reporte final");
        Console.WriteLine("──────────────────────────────");
        Console.WriteLine($" Edades registradas: {edades.Count}");
        Console.WriteLine($" Promedio de edad: {promedio:F1} años");
        Console.WriteLine($" Mayores de edad: {mayores} (>= {MAYORIA_EDAD} años)");
        Console.WriteLine($" Menores de edad: {menores} (<  {MAYORIA_EDAD} años)");
        Console.WriteLine("──────────────────────────────");
    }
}