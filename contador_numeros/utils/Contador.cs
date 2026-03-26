using System;

namespace contador_numeros.utils;

// Clase que clasifica números en positivos, negativos y ceros, llevando el conteo de cada categoría.
public class Contador
{
    // Contadores de cada categoría — se incrementan con cada número clasificado
    public int Positivos { get; private set; } = 0;
    public int Negativos { get; private set; } = 0;
    public int Ceros { get; private set; } = 0;

    // Clasifica un número y suma 1 al contador correspondiente.
    public void Clasificar(int numero)
    {
        // if-else encadenado para determinar en qué categoría cae el número
        if (numero > 0)
            Positivos++;
        else if (numero < 0)
            Negativos++;
        else
            Ceros++;
    }
}