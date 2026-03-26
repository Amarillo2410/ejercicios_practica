using System;

namespace optimizacion_rutas.utils;

// Representa el grafo ponderado de la red de puntos de la ciudad.
public class Grafo
{
    // Lista de adyacencia: Key = nodo origen, Value = lista de (vecino, costo)
    private readonly Dictionary<string, List<(string vecino, int costo)>> _adyacencia = new();

    // Agrega una conexión bidireccional entre dos puntos con su costo de combustible. Si los nodos no existen, los crea automáticamente.
    public void AgregarConexion(string origen, string destino, int costo)
    {
        // Si el nodo de origen no existe, lo creamos con una lista vacía
        if (!_adyacencia.ContainsKey(origen))
            _adyacencia[origen] = new List<(string, int)>();

        // Si el nodo de destino no existe, lo creamos también
        if (!_adyacencia.ContainsKey(destino))
            _adyacencia[destino] = new List<(string, int)>();

        // Agregamos la conexión en ambas direcciones (grafo no dirigido)
        _adyacencia[origen].Add((destino, costo));
        _adyacencia[destino].Add((origen, costo));
    }

    // Retorna los vecinos directos de un nodo con sus costos.
    public List<(string vecino, int costo)> ObtenerVecinos(string nodo)
    {
        // Si el nodo no existe, retornamos lista vacía para evitar errores
        return _adyacencia.ContainsKey(nodo)
            ? _adyacencia[nodo]
            : new List<(string, int)>();
    }

    // Retorna todos los nodos del grafo.
    public IEnumerable<string> ObtenerNodos() => _adyacencia.Keys;

    // Verifica si un nodo existe en el grafo.
    public bool ExisteNodo(string nodo) => _adyacencia.ContainsKey(nodo);

    // Muestra todas las conexiones del grafo para referencia del usuario.
    public void MostrarConexiones()
    {
        Console.WriteLine("  Nodo   Conexiones (destino = combustible)");
        Console.WriteLine("  " + new string('─', 45));

        foreach (var nodo in _adyacencia.Keys.OrderBy(n => n))
        {
            // Formateamos cada conexión como el costo
            string conexiones = string.Join(", ",
                _adyacencia[nodo].Select(c => $"{c.vecino}({c.costo})"));
            Console.WriteLine($"  {nodo,-6} → {conexiones}");
        }
    }
}