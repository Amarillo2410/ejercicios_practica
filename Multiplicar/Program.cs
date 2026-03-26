using tabla_multiplicar.utils;

Console.WriteLine("=== Tabla de Multiplicar ===\n");

// Variable para controlar si el usuario quiere otra tabla
string continuar = "s";

while (continuar == "s")
{
    // Solicitamos el número al usuario
    Console.Write("Ingrese un número entero: ");
    string input = Console.ReadLine() ?? "";

    // Intentamos convertir la entrada a entero
    // int.TryParse retorna true si la conversión fue exitosa, false si no
    if (!int.TryParse(input, out int numero))
    {
        Console.WriteLine("Por favor ingrese un número entero válido.\n");
        continue;
    }

    // Llamamos la función que genera y muestra la tabla
    tablaMultiplicar.Mostrar(numero);

    // Preguntamos si quiere generar otra tabla
    Console.Write("\n¿Ver otra tabla? (s/n): ");
    continuar = Console.ReadLine()?.Trim().ToLower() ?? "n";
    Console.WriteLine();
}

Console.WriteLine("¡Hasta luego!");