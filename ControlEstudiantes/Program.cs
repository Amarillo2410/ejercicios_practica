using control_estudiantes.utils;

Console.WriteLine("=== Control de Estudiantes ===\n");

// Registro principal que usa HashSet<Estudiante> internamente
var registro = new registroEstudiante();

// Variable para controlar el menú
bool salir = false;

while (!salir)
{
    // ------- Menú de opciones -------
    Console.WriteLine("------ Menú ------");
    Console.WriteLine("1. Registrar estudiante");
    Console.WriteLine("2. Mostrar estudiantes");
    Console.WriteLine("3. Buscar por código");
    Console.WriteLine("4. Salir");
    Console.Write("\nElige una opción: ");

    string opcion = Console.ReadLine() ?? "";
    Console.WriteLine();

    switch (opcion)
    {
        // ------- Opción 1: Registrar --------
        case "1":
            Console.Write("Ingrese código: ");
            string codigo = Console.ReadLine() ?? "";

            Console.Write("Ingrese nombre: ");
            string nombre = Console.ReadLine() ?? "";

            // Validamos que no estén vacíos
            if (string.IsNullOrWhiteSpace(codigo) || string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("Código y nombre son obligatorios.\n");
                break;
            }

            // Creamos el objeto estudiante y lo intentamos registrar
            var estudiante = new Estudiante { Codigo = codigo.Trim(), Nombre = nombre.Trim() };
            bool agregado = registro.Registrar(estudiante);

            // Mostramos el resultado según si fue nuevo o duplicado
            if (agregado)
                Console.WriteLine("Estudiante agregado correctamente.\n");
            else
                Console.WriteLine("El estudiante ya está registrado.\n");
            break;

        // --- Opción 2: Mostrar todos -----------------------
        case "2":
            Console.WriteLine("Estudiantes registrados:");

            if (registro.Total == 0)
            {
                Console.WriteLine("  (no hay estudiantes registrados aún)\n");
                break;
            }

            // Recorremos e imprimimos cada estudiante en orden por código
            foreach (var est in registro.ObtenerTodos())
                Console.WriteLine($"  - {est}");

            Console.WriteLine($"\n  Total: {registro.Total} estudiante(s).\n");
            break;

        // --- Opción 3: Buscar por código -----------------------
        case "3":
            Console.Write("Ingrese el código a buscar: ");
            string busqueda = Console.ReadLine() ?? "";

            // BuscarPorCodigo usa TryGetValue del HashSet
            Estudiante? encontrado = registro.BuscarPorCodigo(busqueda.Trim());

            if (encontrado is not null)
                Console.WriteLine($"   Encontrado → {encontrado}\n");
            else
                Console.WriteLine($"   No se encontró ningún estudiante con código \"{busqueda}\".\n");
            break;

        // --- Opción 4: Salir -------------------------
        case "4":
            salir = true;
            Console.WriteLine("¡Hasta luego!");
            break;

        default:
            Console.WriteLine("Opción inválida. Elige entre 1 y 4.\n");
            break;
    }
}