using gestion_edades.utils;

Console.WriteLine("=== Gestión de Edades ===");
Console.WriteLine("Ingresa edades de personas. Escribe -1 para terminar.\n");

// List<int> que guarda todas las edades ingresadas
List<int> edades = new List<int>();

// Ciclo while: se repite hasta que el usuario ingrese -1
while (true)
{
    Console.Write($"Edad {edades.Count + 1}: ");
    string input = Console.ReadLine() ?? "";

    // Validamos que sea un entero válido
    if (!int.TryParse(input, out int edad))
    {
        Console.WriteLine("  Entrada inválida. Ingresa un número entero.\n");
        continue;
    }

    // Condición de salida: el usuario escribió -1
    if (edad == -1)
    {
        Console.WriteLine("  Fin del registro.\n");
        break;
    }

    // Validamos que la edad sea un valor realista (0 a 120)
    if (edad < 0 || edad > 120)
    {
        Console.WriteLine("  Edad inválida. Debe estar entre 0 y 120.\n");
        continue;
    }

    // Agregamos la edad válida a la lista
    edades.Add(edad);

    // Indicamos si es mayor o menor de edad al registrar
    string clasificacion = edad >= 18 ? "mayor de edad" : "menor de edad";
    Console.WriteLine($"  ✓ {edad} años — {clasificacion}\n");
}

// Verificamos que se haya ingresado al menos una edad
if (edades.Count == 0)
{
    Console.WriteLine("No se registró ninguna edad.");
}
else
{
    // Mostramos el reporte completo
    GestorEdades.MostrarReporte(edades);
}