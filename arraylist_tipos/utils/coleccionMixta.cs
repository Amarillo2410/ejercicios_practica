using System;
using System.Collections; // necesario para ArrayList
namespace arraylist_tipos.utils;

public class ColeccionMixta
{
    // ArrayList sin tipo específico — acepta cualquier object
    private readonly ArrayList _datos = new ArrayList();

    // Agrega un elemento de cualquier tipo al ArrayList.
    public void Agregar(object elemento)
    {
        // object es la clase base de todos los tipos en C#
        // Por eso ArrayList acepta string, int, double, bool, etc.
        _datos.Add(elemento);
    }

    // Recorre el ArrayList con foreach e imprime cada elemento
    // junto con su tipo de dato usando GetType().
    public void MostrarConTipos()
    {
        Console.WriteLine($"\n  {"Índice",-6} {"Valor",-15} {"Tipo de dato",-20}");
        Console.WriteLine("  " + new string('─', 45));

        // foreach recorre cada elemento como object
        // usamos un índice manual porque foreach no lo provee
        int indice = 0;

        foreach (object elemento in _datos)
        {
            // GetType() retorna el tipo real del objeto en tiempo de ejecución
            // Name da solo el nombre corto: "String", "Int32", "Double", "Boolean"
            string tipo = elemento.GetType().Name;

            // ToString() convierte el valor a texto para mostrarlo
            string valor = elemento.ToString() ?? "null";

            Console.WriteLine($"  [{indice}]    {valor,-15} {tipo,-20}");
            indice++;
        }

        Console.WriteLine("  " + new string('─', 45));
        Console.WriteLine($"  Total de elementos: {_datos.Count}");
    }

    // Demuestra que ArrayList puede mezclar tipos en una sola colección
    // cargando datos de ejemplo con tipos variados.
    public static ColeccionMixta CrearEjemplo()
    {
        var coleccion = new ColeccionMixta();

        // Agregamos distintos tipos de datos
        coleccion.Agregar("Carlos Medina");   // string  nombre
        coleccion.Agregar(28);                // int edad
        coleccion.Agregar(1.75);              // double estatura en metros
        coleccion.Agregar(true);              // bool está activo
        coleccion.Agregar("Bogotá");          // string ciudad
        coleccion.Agregar(95000.50);          // double salario
        coleccion.Agregar(false);             // bool es VIP

        return coleccion;
    }
}