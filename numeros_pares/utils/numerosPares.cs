using System;

namespace numeros_pares.utils;

// Clase que contiene la lógica para encontrar y mostrar números pares.
public class NumerosPares
{
    // Recorre los números del 1 al 100, muestra los pares y retorna la cantidad total de pares encontrados.
    public static int MostrarPares()
    {
        // Contador de números pares encontrados
        int cantidad = 0;

        // Ciclo for del 1 al 100
        for (int i = 1; i <= 100; i++)
        {
            // Un número es par si su residuo al dividir entre 2 es 0
            if (i % 2 == 0)
            {
                Console.Write($"{i,4}"); // Alineamos a la derecha en 4 espacios
                cantidad++;

                // Salto de línea cada 10 números para mejor lectura
                if (cantidad % 10 == 0)
                    Console.WriteLine();
            }
        }

        return cantidad;
    }
}