using inventario_arraylist.utils;

Console.WriteLine("=== Inventario de Productos (ArrayList) ===\n");

// Instancia del inventario que usa ArrayList internamente
var inventario = new Inventario();

string opcion;

// Menú con do-while para que se muestre al menos una vez
do
{
    Console.WriteLine("\n──────────────────────────");
    Console.WriteLine("  1. Agregar producto");
    Console.WriteLine("  2. Mostrar inventario");
    Console.WriteLine("  3. Eliminar producto");
    Console.WriteLine("  4. Salir");
    Console.WriteLine("──────────────────────────");
    Console.Write("Elige una opción: ");

    opcion = Console.ReadLine() ?? "";
    Console.WriteLine();

    switch (opcion)
    {
        // ─── Agregar producto ─────────────────────────────────────────────
        case "1":
            Console.Write("Nombre del producto: ");
            string nombre = Console.ReadLine() ?? "";

            // Validamos que no esté vacío
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre no puede estar vacío.");
                break;
            }

            // Verificamos si ya existe antes de agregar
            if (inventario.Existe(nombre))
            {
                Console.WriteLine($"   \"{nombre}\" ya está en el inventario.");
                break;
            }

            // Agregamos al ArrayList
            inventario.Agregar(nombre);
            Console.WriteLine($"   \"{nombre}\" agregado. Total: {inventario.Total} producto(s).");
            break;

        // ─── Mostrar inventario ───────────────────────────────────────────
        case "2":
            Console.WriteLine($"Inventario ({inventario.Total} producto(s)):");
            inventario.MostrarTodos();
            break;

        // ─── Eliminar producto ────────────────────────────────────────────
        case "3":
            Console.Write("Nombre del producto a eliminar: ");
            string aEliminar = Console.ReadLine() ?? "";

            bool eliminado = inventario.Eliminar(aEliminar);

            if (eliminado)
                Console.WriteLine($"   \"{aEliminar}\" eliminado. Total: {inventario.Total} producto(s).");
            else
                Console.WriteLine($"   \"{aEliminar}\" no se encontró en el inventario.");
            break;

        // ─── Salir ────────────────────────────────────────────────────────
        case "4":
            Console.WriteLine("¡Hasta luego!");
            break;

        default:
            Console.WriteLine("Opción inválida. Elige entre 1 y 4.");
            break;
    }

} while (opcion != "4");