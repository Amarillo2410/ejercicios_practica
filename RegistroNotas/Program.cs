using registro_notas.utils;

Console.WriteLine("=== Registro de Notas ===");
Console.WriteLine("Ingresa notas decimales entre 0.0 y 5.0.");
Console.WriteLine("Escribe -1 para terminar.\n");

// Lista donde se guardarán las notas ingresadas
List<double> notas = new List<double>();

// Ciclo while: sigue pidiendo notas hasta que el usuario escriba -1
while (true)
{
    Console.Write($"Nota {notas.Count + 1}: ");
    string input = Console.ReadLine() ?? "";

    // Validamos que la entrada sea un número decimal válido
    // double.TryParse convierte el texto a double de forma segura
    if (!double.TryParse(input, out double nota))
    {
        Console.WriteLine("  Entrada inválida. Ingresa un número como 3.5 o 4.0\n");
        continue;
    }

    // Condición de salida: el usuario escribió -1
    if (nota == -1)
    {
        Console.WriteLine("  Fin del registro.\n");
        break;
    }

    // Validamos que la nota esté en el rango válido (0.0 a 5.0)
    if (nota < 0.0 || nota > 5.0)
    {
        Console.WriteLine("  La nota debe estar entre 0.0 y 5.0.\n");
        continue;
    }

    // Agregamos la nota válida a la lista
    notas.Add(nota);
    Console.WriteLine($"  Nota registrada: {nota:F1}\n");
}

// Verificamos que se hayan ingresado al menos una nota antes de reportar
if (notas.Count == 0)
{
    Console.WriteLine("No se ingresó ninguna nota.");
}
else
{
    // Mostramos el reporte completo con promedio y aprobadas
    RegistroNotas.MostrarReporte(notas);
}