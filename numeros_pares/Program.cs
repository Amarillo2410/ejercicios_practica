using numeros_pares.utils;

Console.WriteLine("=== Números pares del 1 al 100 ===\n");

// Llamamos la función que muestra los pares y retorna cuántos hubo
int total = NumerosPares.MostrarPares();

// Mostramos el resumen final
Console.WriteLine($"\nTotal de números pares: {total}");