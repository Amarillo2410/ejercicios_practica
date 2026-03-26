using System;

namespace tabla_multiplicar.utils;

// Clase que genera e imprime la tabla de multiplicar de un número.
public class tablaMultiplicar
{
    // Muestra la tabla de multiplicar del 1 al 10 para el número recibido.
    public static void Mostrar(int numero)
    {
        Console.WriteLine($"\n  Tabla de multiplicar del {numero}\n");
        Console.WriteLine("  " + new string('─', 22));

        // Ciclo for del 1 al 10 para generar cada línea de la tabla
        for (int i = 1; i <= 10; i++)
        {
            // Calculamos el resultado de la multiplicación
            int resultado = numero * i;

            // Concatenamos los valores formateados para alinear columnas
            // {numero,3} alinea el número a la derecha en 3 espacios
            // {i,2} alinea el multiplicador en 2 espacios
            // {resultado,4} alinea el resultado en 4 espacios
            string linea = "  " + numero + " x " + i.ToString().PadLeft(2) + " = " + resultado.ToString().PadLeft(4);
            Console.WriteLine(linea);
        }

        Console.WriteLine("  " + new string('─', 22));
    }
}