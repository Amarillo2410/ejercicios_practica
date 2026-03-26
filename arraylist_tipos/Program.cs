using System.Collections; // para ArrayList
using arraylist_tipos.utils;

Console.WriteLine("=== ArrayList con Mezcla de Tipos ===\n");

// ─── Parte 1: ejemplo con datos fijos 

Console.WriteLine("[ Ejemplo con datos de una persona ]");

// Creamos el ArrayList con datos mixtos de ejemplo
ColeccionMixta coleccionEjemplo = ColeccionMixta.CrearEjemplo();
coleccionEjemplo.MostrarConTipos();

// ─── Parte 2: el usuario agrega sus propios datos 

Console.WriteLine("\n[ Ingresa tus propios datos ]\n");

// Creamos un ArrayList directamente aquí para mostrar el uso directo
ArrayList datosUsuario = new ArrayList();

// Pedimos cada dato de tipo distinto al usuario
Console.Write("Ingresa tu nombre:    ");
string nombre = Console.ReadLine() ?? "Sin nombre";
datosUsuario.Add(nombre.Trim()); // string

Console.Write("Ingresa tu edad:      ");
if (int.TryParse(Console.ReadLine(), out int edad))
    datosUsuario.Add(edad); // int
else
    datosUsuario.Add(0); // int por defecto

Console.Write("Ingresa tu estatura (ej: 1.70): ");
if (double.TryParse(Console.ReadLine(), out double estatura))
    datosUsuario.Add(estatura); // double
else
    datosUsuario.Add(0.0); // double por defecto

Console.Write("¿Estás activo? (true/false):    ");
if (bool.TryParse(Console.ReadLine(), out bool activo))
    datosUsuario.Add(activo); // bool
else
    datosUsuario.Add(false); // bool por defecto

// Recorremos el ArrayList del usuario con foreach y mostramos cada elemento con su tipo usando GetType()
Console.WriteLine($"\n  {"Valor",-20} {"Tipo",-15}");
Console.WriteLine("  " + new string('─', 35));

foreach (object elemento in datosUsuario)
{
    // GetType().Name devuelve el nombre del tipo real en tiempo de ejecución
    string tipo  = elemento.GetType().Name;
    string valor = elemento.ToString() ?? "null";

    Console.WriteLine($"  {valor,-20} {tipo,-15}");
}

Console.WriteLine("  " + new string('─', 35));
Console.WriteLine($"  Elementos almacenados: {datosUsuario.Count}");