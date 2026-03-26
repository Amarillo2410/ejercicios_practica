using System;

namespace optimizacion_rutas.utils;

// Contiene la ruta encontrada y el costo total.
public class ResultadoRuta
{
    public List<string> Ruta { get; set; } = new();
    public int CostoTotal { get; set; } = 0;
    public bool Encontrada { get; set; } = false;
}

// Implementación del algoritmo de Dijkstra para encontrar la ruta de menor costo entre dos nodos de un grafo ponderado.
public class Dijkstra
{
    // Valor que representa "infinito" — costo inicial para todos los nodos
    private const int INFINITO = int.MaxValue / 2;

    // Calcula la ruta de menor costo desde el origen hasta el destino.
    public static ResultadoRuta CalcularRuta(Grafo grafo, string origen, string destino)
    {
        // ─── Inicialización 

        // Diccionario de costos: costo mínimo conocido para llegar a cada nodo
        var costos = new Dictionary<string, int>();

        // Diccionario de anteriores: guarda desde qué nodo llegamos a cada uno
        // Se usa al final para reconstruir la ruta completa
        var anteriores = new Dictionary<string, string?>();

        // HashSet de nodos ya visitados
        var visitados = new HashSet<string>();

        // Inicializamos todos los nodos con costo INFINITO
        foreach (string nodo in grafo.ObtenerNodos())
        {
            costos[nodo]     = INFINITO;
            anteriores[nodo] = null;
        }

        // El origen tiene costo 0
        costos[origen] = 0;

        // ─── Algoritmo principal 

        // Seguimos mientras haya nodos no visitados
        while (true)
        {
            // Elegimos el nodo no visitado con el menor costo acumulado
            string? nodoActual = null;
            int menorCosto = INFINITO;

            foreach (string nodo in grafo.ObtenerNodos())
            {
                // Solo consideramos nodos no visitados con costo menor al actual mínimo
                if (!visitados.Contains(nodo) && costos[nodo] < menorCosto)
                {
                    menorCosto = costos[nodo];
                    nodoActual = nodo;
                }
            }

            // Si no encontramos ningún nodo alcanzable, terminamos
            if (nodoActual is null)
                break;

            // Si llegamos al destino, ya encontramos el camino óptimo
            if (nodoActual == destino)
                break;

            // Marcamos el nodo actual como visitado
            visitados.Add(nodoActual);

            // ─── Relajación de aristas 
            // Revisamos todos los vecinos del nodo actual
            foreach (var (vecino, costo) in grafo.ObtenerVecinos(nodoActual))
            {
                // Si el vecino ya fue visitado, lo ignoramos
                if (visitados.Contains(vecino))
                    continue;

                // Calculamos el costo total si vamos por el nodo actual
                int nuevoCosto = costos[nodoActual] + costo;

                // Si este camino es más barato que el conocido, actualizamos
                if (nuevoCosto < costos[vecino])
                {
                    costos[vecino]     = nuevoCosto;    // actualizamos el costo mínimo
                    anteriores[vecino] = nodoActual;    // recordamos por dónde llegamos
                }
            }
        }

        // ─── Verificar si existe ruta 
        if (costos[destino] == INFINITO)
        {
            // El destino quedó en INFINITO, no hay camino posible
            return new ResultadoRuta { Encontrada = false };
        }

        // ─── Reconstruir la ruta 
        // Seguimos los "anteriores" desde el destino hasta el origen
        // y luego invertimos la lista
        var ruta = new List<string>();
        string? paso = destino;

        while (paso is not null)
        {
            ruta.Add(paso);
            anteriores.TryGetValue(paso, out paso);
        }

        // Invertimos para tener el orden origen → destino
        ruta.Reverse();

        return new ResultadoRuta
        {
            Ruta       = ruta,
            CostoTotal = costos[destino],
            Encontrada = true
        };
    }
}