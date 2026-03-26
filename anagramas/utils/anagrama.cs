using System;

namespace anagramas.utils;

public class Anagrama
{
    public static bool EsAnagrama(string palabra1, string palabra2)
    {
        // Normalizamos ambas palabras:
        // - Quitamos espacios en blanco
        // - Convertimos a minúsculas para no distinguir mayúsculas
        string p1 = palabra1.Replace(" ", "").ToLower();
        string p2 = palabra2.Replace(" ", "").ToLower();

        // Si las palabras son exactamente iguales (tras normalizar),
        // NO se consideran anagramas según las reglas del ejercicio
        if (p1 == p2)
            return false;

        // Si tienen diferente longitud, no pueden ser anagramas
        // porque no pueden tener las mismas letras en la misma cantidad
        if (p1.Length != p2.Length)
            return false;

        // Ordenamos los caracteres de cada palabra alfabéticamente
        // Si son anagramas, al ordenar deben quedar exactamente iguales
        // Ejemplo: "amor" → "amor", "roma" → "amor" - iguales 
        char[] chars1 = p1.ToCharArray();
        char[] chars2 = p2.ToCharArray();

        Array.Sort(chars1);
        Array.Sort(chars2);

        // Comparamos los arreglos ordenados carácter por carácter
        // SequenceEqual retorna true si todos los elementos son iguales en orden
        return chars1.SequenceEqual(chars2);
    }
}