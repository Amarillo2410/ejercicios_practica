using System;

namespace control_estudiantes.utils;

// Representa un estudiante registrado en el curso.
// Implementa IEquatable para que HashSet detecte duplicados por Codigo.
public class Estudiante : IEquatable<Estudiante>
{
    public string Codigo { get; set; } = "";
    public string Nombre { get; set; } = "";

    // ---- Igualdad por Codigo ----

    // Dos estudiantes son iguales si tienen el mismo Codigo.

    public bool Equals(Estudiante? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        // Comparamos solo por Codigo, ignorando mayúsculas/minúsculas
        return string.Equals(Codigo, other.Codigo, StringComparison.OrdinalIgnoreCase);
    }

    // si dos objetos son iguales, deben tener el mismo hash.
    public override int GetHashCode() => Codigo.ToLower().GetHashCode();

    public override bool Equals(object? obj) => Equals(obj as Estudiante);

    public override string ToString() => $"Código: {Codigo} | Nombre: {Nombre}";
}