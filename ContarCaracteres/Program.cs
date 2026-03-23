using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;

class Program
{
    // Clase para guardar resultados
    class Frecuencia
    {
        public char Car { get; set; }
        public int Veces { get; set; }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Ingresa un texto:");
        string texto = Console.ReadLine() ?? String.Empty;

        // 🔹 Evita error si el usuario no escribe nada
        if (string.IsNullOrEmpty(texto))
        {
            Console.WriteLine("Texto vacío");
            return;
        }

        // 🔹 Minúsculas
        string normalizado = texto.ToLower();

        // 🔹 Quitar tildes
        string textoNormalizado = normalizado.Normalize(NormalizationForm.FormD);
        string sinTildes = "";

        foreach (char c in textoNormalizado)
        {
            if (Char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            {
                sinTildes += c;
            }
        }

        // 🔹 Diccionario para contar
        Dictionary<char, int> contador = new Dictionary<char, int>();

        foreach (char c in sinTildes)
        {
            if (char.IsLetterOrDigit(c))
            {
                if (contador.ContainsKey(c))
                    contador[c]++;
                else
                    contador[c] = 1;
            }
        }

        // 🔹 Convertir y ordenar
        var resultado = contador
            .Select(x => new Frecuencia { Car = x.Key, Veces = x.Value })
            .OrderBy(x => x.Car)
            .ToList();

        // 🔹 Mostrar
        Console.WriteLine("\nFrecuencia:");

        foreach (var item in resultado)
        {
            Console.WriteLine($"Car: {item.Car} - Veces: {item.Veces}");
        }
    }
}