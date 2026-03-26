using System;

namespace optimizacion_rutas.utils;

// Clase que construye las conexiones definidas en el enunciado del ejercicio.
public static class Conexiones
{
    // Construye y retorna el grafo con las conexiones del enunciado:
    // A→B=4, A→C=2, B→D=5, C→B=1, C→D=8, C→E=10, D→E=2, E→F=3, D→F=6
    public static Grafo Construir()
    {
        var grafo = new Grafo();

        // Definimos cada conexión con su consumo de combustible
        grafo.AgregarConexion("A", "B", 4);
        grafo.AgregarConexion("A", "C", 2);
        grafo.AgregarConexion("B", "D", 5);
        grafo.AgregarConexion("C", "B", 1);
        grafo.AgregarConexion("C", "D", 8);
        grafo.AgregarConexion("C", "E", 10);
        grafo.AgregarConexion("D", "E", 2);
        grafo.AgregarConexion("E", "F", 3);
        grafo.AgregarConexion("D", "F", 6);

        return grafo;
    }
}