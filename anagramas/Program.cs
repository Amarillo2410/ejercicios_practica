using anagramas.utils;

Console.WriteLine("=== Detector de Anagramas ===\n");

// Casos de prueba: los del enunciado y algunos extras
var casos = new (string p1, string p2)[]
{
    ("amor",   "roma"),   // true mismas letras, distinto orden
    ("rota",   "otra"),   // true mismas letras, distinto orden
    ("otra",   "otra"),   // false son exactamente iguales
    ("hola",   "adios"),  // false diferente longitud
};

// Recorremos cada caso y mostramos el resultado
foreach (var (p1, p2) in casos)
{
    // Llamamos la función principal del ejercicio
    bool resultado = Anagrama.EsAnagrama(p1, p2);

    // Mostramos en el formato del enunciado
    string icono = resultado ? "✓" : "✗";
    Console.WriteLine($"EsAnagrama(\"{p1}\", \"{p2}\") -> {resultado.ToString().ToLower()}  {icono}");
}