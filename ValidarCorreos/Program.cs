using validar_correos.utils;

Console.WriteLine("=== Registro de Correos Electrónicos ===");
Console.WriteLine("Escribe 'salir' para terminar.\n");

// Creamos el registro de correos que usa HashSet internamente
var registro = new EmailRegistry();

// Ciclo principal: seguimos pidiendo correos hasta que el usuario escriba "salir"
while (true)
{
    Console.Write("Ingrese un correo: ");
    string input = Console.ReadLine() ?? "";

    // Condición de salida del ciclo
    if (input.Trim().ToLower() == "salir")
        break;

    // Validación básica: no permitimos correos vacíos
    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Por favor ingrese un correo válido.\n");
        continue;
    }

    // Intentamos registrar el correo
    // Registrar() retorna true si era nuevo, false si ya existía
    bool agregado = registro.Registrar(input);

    // Mostramos el mensaje correspondiente según el resultado
    if (agregado)
        Console.WriteLine("Correo agregado correctamente.\n");
    else
        Console.WriteLine("El correo ya estaba registrado.\n");
}

// Mostramos el reporte final con todos los correos guardados
Console.WriteLine("\nCorreos registrados:");

if (registro.Total == 0)
{
    Console.WriteLine("  (no se registró ningún correo)");
}
else
{
    // Recorremos la colección ordenada y mostramos cada correo
    foreach (string correo in registro.ObtenerTodos())
    {
        Console.WriteLine($"  - {correo}");
    }

    Console.WriteLine($"\nTotal: {registro.Total} correo(s) registrado(s).");
}