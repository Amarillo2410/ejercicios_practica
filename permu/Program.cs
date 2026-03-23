using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingresa una cadena:");
        string texto = Console.ReadLine() ?? String.Empty;

        Console.WriteLine("\nPermutaciones:");
        Permutar(texto, ""); // Llamada inicial
    }

    // Función recursiva
    static void Permutar(string restante, string actual)
    {
        // Caso base: no quedan caracteres
        if (restante.Length == 0)
        {
            Console.WriteLine(actual); // Mostrar una permutación
            return;
        }

        //  Recorremos cada carácter
        for (int i = 0; i < restante.Length; i++)
        {
            // Elegimos un carácter
            char elegido = restante[i];

            // Quitamos ese carácter del string
            string nuevoRestante = restante.Substring(0, i) + restante.Substring(i + 1);

            // Lo agregamos a la construcción actual
            Permutar(nuevoRestante, actual + elegido);
        }
    }
}
