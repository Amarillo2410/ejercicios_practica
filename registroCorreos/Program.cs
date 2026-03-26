using registro_correos.utils;

Console.WriteLine("=== Registro de Correos Electrónicos ===");
Console.WriteLine("Escribe 'salir' para terminar.\n");

// Registro que usa HashSet internamente para evitar duplicados
var registro = new RegistroCorreos();

// Ciclo while: se repite hasta que el usuario escriba "salir"
while (true)
{
    Console.Write("Ingrese un correo: ");
    string input = Console.ReadLine() ?? "";

    // Condición de salida del ciclo
    if (input.Trim().ToLower() == "salir")
        break;

    // Validación 1: no permitimos entradas vacías
    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("  El correo no puede estar vacío.\n");
        continue;
    }

    // Validación 2: verificamos el formato básico del correo
    if (!RegistroCorreos.TieneFormatoValido(input.Trim()))
    {
        Console.WriteLine("  Formato inválido. Debe contener '@' y un dominio.\n");
        continue;
    }

    // Intentamos registrar el correo en el HashSet
    bool agregado = registro.Registrar(input);

    // Informamos el resultado al usuario
    if (agregado)
        Console.WriteLine("   Correo agregado correctamente.\n");
    else
        Console.WriteLine("   El correo ya estaba registrado.\n");
}

// Mostramos el reporte final con todos los correos únicos
Console.WriteLine("\n──────────────────────────────");
Console.WriteLine("      Correos registrados");
Console.WriteLine("──────────────────────────────");

if (registro.Total == 0)
{
    Console.WriteLine("  (no se registró ningún correo)");
}
else
{
    foreach (string correo in registro.ObtenerTodos())
        Console.WriteLine($"  - {correo}");

    Console.WriteLine($"\n  Total: {registro.Total} correo(s).");
}