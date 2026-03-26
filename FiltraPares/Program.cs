using filtrar_pares.utils;

Console.WriteLine("=== Filtrar Números Pares ===\n");

// Lista original donde se guardan los 10 números
List<int> numeros = new List<int>();

// Pedimos exactamente 10 números al usuario
for (int i = 1; i <= 10; i++)
{
    Console.Write($"Ingrese el número {i,2} de 10: ");
    string input = Console.ReadLine() ?? "";

    // Validamos que sea un entero válido
    if (!int.TryParse(input, out int numero))
    {
        Console.WriteLine("  Entrada inválida, se usará 0.");
        numero = 0;
    }

    // Agregamos a la lista original
    numeros.Add(numero);
}

// Mostramos la lista original completa
Console.WriteLine();
FiltroPares.MostrarLista("Lista original ", numeros);

// Generamos una nueva lista con solo los pares
List<int> solopares = FiltroPares.FiltrarPares(numeros);

// Mostramos la nueva lista filtrada
Console.WriteLine();
FiltroPares.MostrarLista("Solo los pares ", solopares);

// Confirmamos que la lista original no fue modificada
Console.WriteLine($"\nLista original sin cambios: {numeros.Count} elementos.");