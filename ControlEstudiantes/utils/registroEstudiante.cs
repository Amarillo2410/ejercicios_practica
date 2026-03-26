using System;

using control_estudiantes.utils;
namespace control_estudiantes.utils;

// Gestiona el registro de estudiantes usando HashSet.
// HashSet garantiza unicidad automáticamente gracias a Equals() y GetHashCode()
public class registroEstudiante
{
    // HashSet de objetos personalizados — detecta duplicados por Codigo
    private readonly HashSet<Estudiante> _estudiantes = new HashSet<Estudiante>();

    // Intenta registrar un estudiante nuevo.
    // retorna True si fue agregado, False si el código ya existía
    public bool Registrar(Estudiante estudiante)
    {
        // Add() llama internamente a Equals() y GetHashCode() del objeto
        // Si ya existe un estudiante con el mismo Codigo, retorna false
        return _estudiantes.Add(estudiante);
    }

    // Busca un estudiante por su código.
    // HashSet.TryGetValue permite obtener el objeto original almacenado.
    // retorna el estudiante encontrado, o null si no existe
    public Estudiante? BuscarPorCodigo(string codigo)
    {
        // Creamos un objeto "clave" solo para buscar (Equals compara por Codigo)
        var clave = new Estudiante { Codigo = codigo };

        // TryGetValue retorna el objeto real almacenado en el HashSet
        _estudiantes.TryGetValue(clave, out Estudiante? encontrado);
        return encontrado;
    }

    // Retorna todos los estudiantes ordenados por código.
    public IEnumerable<Estudiante> ObtenerTodos()
    {
        return _estudiantes.OrderBy(e => e.Codigo);
    }

    // Cantidad de estudiantes registrados.
    public int Total => _estudiantes.Count;
}