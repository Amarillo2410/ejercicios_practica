using control_acceso.utils;

Console.WriteLine("=== Sistema de Control de Acceso ===\n");
Console.WriteLine("Registra 10 códigos de estudiantes.");
Console.WriteLine("Los códigos duplicados serán rechazados.\n");

// Instancia del sistema de control de acceso
var sistema = new ControlAcceso();

// Intentos realizados (puede superar 10 si hay duplicados o inválidos)
int registrosExitosos = 0;

// Ciclo while: seguimos pidiendo hasta tener 10 códigos únicos registrados
while (registrosExitosos < 10)
{
    Console.Write($"Código [{registrosExitosos + 1,2}/10]: ");
    string input = Console.ReadLine() ?? "";

    // Validación 1: formato básico (no vacío, sin espacios)
    if (!ControlAcceso.FormatoValido(input))
    {
        Console.WriteLine("   Formato inválido. El código no puede estar vacío ni tener espacios.\n");
        continue;
    }

    // Intentamos registrar el código en el HashSet
    bool aceptado = sistema.Registrar(input);

    // Informamos el resultado y actualizamos el contador de exitosos
    if (aceptado)
    {
        registrosExitosos++;
        Console.WriteLine($"   Código \"{input.Trim().ToUpper()}\" registrado.\n");
    }
    else
    {
        Console.WriteLine($"   El código \"{input.Trim().ToUpper()}\" ya fue registrado.\n");
    }
}

// Mostramos el resumen del registro
Console.WriteLine("──────────────────────────────────");
Console.WriteLine("       Resumen de registro");
Console.WriteLine("──────────────────────────────────");
Console.WriteLine($" Intentos totales: {sistema.IntentosTotal}");
Console.WriteLine($" Registrados: {sistema.Total}");
Console.WriteLine($" Duplicados: {sistema.Rechazados}");

// Listamos todos los códigos registrados
Console.WriteLine("\nCódigos con acceso:");
foreach (string codigo in sistema.ObtenerTodos())
    Console.WriteLine($"  - {codigo}");

// Simulamos una verificación de acceso
Console.WriteLine("\n──────────────────────────────────");
Console.WriteLine("       Verificar acceso");
Console.WriteLine("──────────────────────────────────");
Console.Write("Ingresa un código para verificar: ");
string verificar = Console.ReadLine() ?? "";

bool tieneAcceso = sistema.TieneAcceso(verificar);

if (tieneAcceso)
    Console.WriteLine($"\n   Acceso PERMITIDO para \"{verificar.Trim().ToUpper()}\".");
else
    Console.WriteLine($"\n   Acceso DENEGADO para \"{verificar.Trim().ToUpper()}\".");