using buscar_nombres.utils;

Console.WriteLine("=== Lista de Nombres y Búsqueda ===\n");

// Lista donde se guardarán los 5 nombres
List<string> nombres = new List<string>();

// Total de nombres a ingresar
const int TOTAL = 5;

// Ciclo para pedir los 5 nombres al usuario
for (int i = 1; i <= TOTAL; i++)
{
    Console.Write($"Ingrese el nombre {i} de {TOTAL}: ");
    string nombre = Console.ReadLine() ?? "";

    // Validamos que no esté vacío
    if (string.IsNullOrWhiteSpace(nombre))
    {
        Console.WriteLine("  Nombre vacío, se usará \"Sin nombre\".");
        nombre = "Sin nombre";
    }

    // Agregamos el nombre a la lista
    nombres.Add(nombre.Trim());
}

// Mostramos la lista completa de nombres ingresados
BuscadorNombres.MostrarLista(nombres);

// Pedimos el nombre a buscar
Console.Write("\nIngrese el nombre a buscar: ");
string busqueda = Console.ReadLine() ?? "";

// Usamos Contains a través del método Buscar para verificar si existe
bool encontrado = BuscadorNombres.Buscar(nombres, busqueda);

// Mostramos el resultado de la búsqueda
if (encontrado)
    Console.WriteLine($"\n✓ \"{busqueda}\" SÍ está en la lista.");
else
    Console.WriteLine($"\n✗ \"{busqueda}\" NO está en la lista.");