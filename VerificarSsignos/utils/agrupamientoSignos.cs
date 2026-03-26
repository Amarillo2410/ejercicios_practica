using System;

namespace verificar_signos.utils;

public class agrupamientoSignos
{
    // Diccionario que mapea cada símbolo de cierre con su correspondiente de apertura
    // Se usa para verificar que el cierre coincida con el último símbolo abierto
    private static readonly Dictionary<char, char> Pares = new()
    {
        { ')', '(' },
        { ']', '[' },
        { '}', '{' },
    };

    // Conjunto de símbolos de apertura para identificarlos rápidamente
    private static readonly HashSet<char> Aperturas = new() { '(', '[', '{' };
    
    public static int SimbEquilibrados(string expresion)
    {
        // Pila (Stack) para llevar el registro de los símbolos de apertura
        // encontrados. La pila permite saber cuál fue el ÚLTIMO símbolo abierto.
        // Funciona como LIFO: el último en entrar es el primero en salir.
        var pila = new Stack<char>();

        // Recorremos cada carácter de la expresión con su índice (posición)
        for (int i = 0; i < expresion.Length; i++)
        {
            char c = expresion[i];

            // Si es un símbolo de apertura, lo empujamos a la pila
            if (Aperturas.Contains(c))
            {
                pila.Push(c);
            }
            // Si es un símbolo de cierre, verificamos que coincida con el último abierto
            else if (Pares.ContainsKey(c))
            {
                // Si la pila está vacía, hay un cierre sin apertura previa → error
                if (pila.Count == 0)
                    return i;

                // Sacamos el último símbolo de apertura de la pila
                char ultimoAbierto = pila.Pop();

                // Verificamos que el símbolo de cierre corresponda al último de apertura
                // Ejemplo: si el último abierto fue '[' y encontramos ')', hay error
                if (Pares[c] != ultimoAbierto)
                    return i;
            }
            // Si el carácter no es un símbolo de agrupamiento, lo ignoramos
        }

        // Si al final la pila no está vacía, hay aperturas sin cerrar
        // Retornamos -1 igualmente porque el enunciado solo pide detectar
        // errores de cierre o anidamiento (no de apertura sin cierre)
        return -1;
    }
}