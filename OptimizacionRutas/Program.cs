using optimizacion_rutas.utils;

Console.WriteLine("╔══════════════════════════════════════════╗");
Console.WriteLine("║   Sistema de Optimización de Rutas       ║");
Console.WriteLine("║   Algoritmo de Dijkstra                  ║");
Console.WriteLine("╚══════════════════════════════════════════╝\n");

// Construimos la red logística con todos los puntos y conexiones
var grafo = Conexiones.Construir();

// Mostramos el mapa de conexiones disponibles para orientar al usuario
Console.WriteLine("Red logística disponible:");
grafo.MostrarConexiones();

bool continuar = true;

while (continuar)
{
    Console.WriteLine("\n──────────────────────────────────────────");

    // Solicitamos el punto de recogida
    Console.Write("Punto de recogida: ");
    string origen = Console.ReadLine()?.Trim().ToUpper() ?? "";

    // Validamos que el punto de recogida exista en el grafo
    if (!grafo.ExisteNodo(origen))
    {
        Console.WriteLine($"   El punto \"{origen}\" no existe en la red.");
        continue;
    }

    // Solicitamos el punto de entrega
    Console.Write("Punto de entrega:  ");
    string destino = Console.ReadLine()?.Trim().ToUpper() ?? "";

    // Validamos que el punto de entrega exista en el grafo
    if (!grafo.ExisteNodo(destino))
    {
        Console.WriteLine($"   El punto \"{destino}\" no existe en la red.");
        continue;
    }

    // Validamos que origen y destino no sean el mismo punto
    if (origen == destino)
    {
        Console.WriteLine("   El punto de recogida y entrega no pueden ser iguales.");
        continue;
    }

    // Ejecutamos el algoritmo de Dijkstra
    var resultado = Dijkstra.CalcularRuta(grafo, origen, destino);

    Console.WriteLine();

    // Mostramos el resultado según si se encontró ruta o no
    if (!resultado.Encontrada)
    {
        Console.WriteLine($"   No existe ruta entre \"{origen}\" y \"{destino}\".");
    }
    else
    {
        // Formateamos la ruta como "A -> C -> B -> D -> E -> F"
        string rutaFormateada = string.Join(" -> ", resultado.Ruta);

        Console.WriteLine($"  Ruta de menor consumo: {rutaFormateada}");
        Console.WriteLine($"  Consumo total estimado: {resultado.CostoTotal}");
    }

    // Preguntamos si desea calcular otra ruta
    Console.Write("\n¿Calcular otra ruta? (s/n): ");
    string resp = Console.ReadLine()?.Trim().ToLower() ?? "n";
    continuar = resp == "s";
}

Console.WriteLine("\n¡Hasta luego!");