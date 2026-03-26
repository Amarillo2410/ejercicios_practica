using verificar_signos.utils;

Console.WriteLine("=== Verificador de Signos de Agrupamiento ===\n");

// Casos de prueba del enunciado
var casos = new string[]
{
    "[1+x+3*(y-5)]",   // Correcto -1
    "[1+x)",           // Error en posición 4
    "}1+x",            // Error en posición 0
    "((()))",          // Correcto -1
    "({[]})",          // Correcto -1
    "({[}])",          // Error anidamiento incorrecto
    "",                // Cadena vacía -1
};

// Recorremos cada caso y mostramos el resultado
foreach (string expresion in casos)
{
    int resultado = agrupamientoSignos.SimbEquilibrados(expresion);

    // Construimos el mensaje según el resultado
    string mensaje = resultado == -1
        ? "✓ Correcta"
        : $"✗ Error en posición {resultado} → '{expresion[resultado]}'";

    // Mostramos en el formato del enunciado
    string expr = expresion == "" ? "(vacía)" : $"\"{expresion}\"";
    Console.WriteLine($"SimbEquilibrados({expr}) -> {resultado,2}   {mensaje}");
}