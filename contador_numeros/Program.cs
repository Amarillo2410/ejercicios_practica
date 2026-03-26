using contador_numeros.utils;

Console.WriteLine("=== Contador de Positivos, Negativos y Ceros ===\n");

// Total de números que se van a pedir
const int TOTAL = 10;

// Creamos el contador que lleva el registro de cada categoría
var contador = new Contador();

// Ciclo for: pedimos exactamente 10 números al usuario
for (int i = 1; i <= TOTAL; i++)
{
    // Pedimos el número indicando cuál va ejemplo: Número 3 de 10
    Console.Write($"Número {i} de {TOTAL}: ");
    string input = Console.ReadLine() ?? "";

    // Validamos que la entrada sea un número entero
    if (!int.TryParse(input, out int numero))
    {
        Console.WriteLine("  Entrada inválida, se cuenta como 0.\n");
        numero = 0;
    }

    // Clasificamos el número (positivo, negativo o cero)
    contador.Clasificar(numero);
}

// Mostramos el resumen final con los conteos de cada categoría
Console.WriteLine(" Resultados finales");
Console.WriteLine($" Positivos: {contador.Positivos}");
Console.WriteLine($" Negativos: {contador.Negativos}");
Console.WriteLine($" Ceros: {contador.Ceros}");
Console.WriteLine("─────────────────────────────");
Console.WriteLine($"  Total: {contador.Positivos + contador.Negativos + contador.Ceros}");