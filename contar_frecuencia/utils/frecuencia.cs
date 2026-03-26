using System;

namespace contar_frecuencia.utils;

// Clase que representa un resultado de frecuencia para un carácter
public class CharResult
{
    public char Car   { get; set; }  // El carácter encontrado
    public int  Veces { get; set; }  // Cantidad de veces que aparece
}

public class CharFrequency
{
    // Diccionario de vocales con tilde y su equivalente sin tilde
    // Se usa para normalizar caracteres antes de contarlos
    private static readonly Dictionary<char, char> Tildes = new()
    {
        { 'á', 'a' }, { 'é', 'e' }, { 'í', 'i' }, { 'ó', 'o' }, { 'ú', 'u' },
        { 'à', 'a' }, { 'è', 'e' }, { 'ì', 'i' }, { 'ò', 'o' }, { 'ù', 'u' },
        { 'ä', 'a' }, { 'ë', 'e' }, { 'ï', 'i' }, { 'ö', 'o' }, { 'ü', 'u' },
    };
    public static List<CharResult> Count(string text)
    {
        // Diccionario para acumular el conteo de cada carácter
        // Key: carácter normalizado, Value: cantidad de apariciones
        var frequency = new Dictionary<char, int>();

        // Recorremos cada carácter del texto original sin modificarlo
        foreach (char c in text)
        {
            // Convertimos a minúscula para no distinguir mayúsculas de minúsculas
            char normalized = char.ToLower(c);

            // Si el carácter tiene tilde, lo reemplazamos por su versión sin tilde
            if (Tildes.ContainsKey(normalized))
                normalized = Tildes[normalized];

            // Solo contamos letras y números, ignoramos espacios y símbolos
            if (!char.IsLetterOrDigit(normalized))
                continue;

            // Si el carácter ya existe en el diccionario, sumamos 1
            // Si no existe, lo agregamos con valor inicial 1
            if (frequency.ContainsKey(normalized))
                frequency[normalized]++;
            else
                frequency[normalized] = 1;
        }

        // Convertimos el diccionario a una lista de objetos CharResult
        // y la ordenamos alfabéticamente por el carácter (Key)
        List<CharResult> result = frequency
            .OrderBy(pair => pair.Key)
            .Select(pair => new CharResult { Car = pair.Key, Veces = pair.Value })
            .ToList();

        return result;
    }
}