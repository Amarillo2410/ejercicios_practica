using contar_frecuencia.utils;

Console.WriteLine("Contador de Frecuencia de Caracteres\n");

// Texto de entrada de ejemplo (el original nunca se modifica)
string texto = "Hoy ya es día 10";

// Mostramos el texto original
Console.WriteLine($"Texto original: \"{texto}\"\n");

// Llamamos la función que calcula la frecuencia de cada carácter
List<CharResult> frecuencias = CharFrequency.Count(texto);

// Mostramos los resultados en el formato requerido por el ejercicio
Console.WriteLine("Resultado:");
foreach (CharResult item in frecuencias)
{
    Console.WriteLine($"{{ Car = '{item.Car}', Veces = {item.Veces} }}");
}

// Confirmamos que el texto original no fue modificado
Console.WriteLine($"\nTexto después del proceso: \"{texto}\"");
Console.WriteLine("(El texto original no fue modificado)");