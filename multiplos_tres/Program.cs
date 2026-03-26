using multiplos_tres.utils;

Console.WriteLine("=== Filtrar Múltiplos de 3 ===\n");

// Lista original donde se guardan los 15 números ingresados
List<int> numeros = new List<int>();

// Ciclo para pedir exactamente 15 números al usuario
for (int i = 1; i <= 15; i++)
{
    Console.Write($"Número {i,2} de 15: ");
    string input = Console.ReadLine() ?? "";

    // Validamos que sea un entero válido
    if (!int.TryParse(input, out int numero))
    {
        Console.WriteLine("  Entrada inválida, se usará 0.");
        numero = 0;
    }

    // Agregamos a la lista original (puede tener cualquier número)
    numeros.Add(numero);
}

// Filtramos los múltiplos de 3 en una nueva lista
List<int> multiplos = FiltroMultiplos.FiltrarMultiplosDeTres(numeros);

// Mostramos ambas listas
Console.WriteLine("\n──────────────────────────────────");
FiltroMultiplos.MostrarLista("Lista original (15 números)", numeros);
FiltroMultiplos.MostrarLista("Solo múltiplos de 3",         multiplos);
Console.WriteLine("──────────────────────────────────");

// Resumen final
Console.WriteLine($"\n  De 15 números, {multiplos.Count} son múltiplos de 3.");