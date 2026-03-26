using System;

namespace control_acceso.utils;

// Clase que simula un sistema de control de acceso usando HashSet para garantizar códigos únicos.
public class ControlAcceso
{
    // HashSet que almacena los códigos registrados sin duplicados
    private readonly HashSet<string> _codigos = new HashSet<string>();

    // Contador de intentos de registro (incluye los rechazados)
    public int IntentosTotal   { get; private set; } = 0;

    // Cantidad de códigos duplicados rechazados
    public int Rechazados      { get; private set; } = 0;

    // Valida que el código tenga un formato básico aceptable.
    public static bool FormatoValido(string codigo)
    {
        // El código no puede estar vacío ni contener espacios en el medio
        return !string.IsNullOrWhiteSpace(codigo) && !codigo.Contains(' ');
    }

    // Intenta registrar un código en el sistema.
    public bool Registrar(string codigo)
    {
        IntentosTotal++;

        // Normalizamos a mayúsculas para que "a101" y "A101" sean el mismo código
        string normalizado = codigo.Trim().ToUpper();

        // Add() retorna false si el código ya existe en el HashSet
        bool agregado = _codigos.Add(normalizado);

        // Contamos el rechazo si era duplicado
        if (!agregado) Rechazados++;

        return agregado;
    }

    // Verifica si un código tiene acceso al sistema.
    public bool TieneAcceso(string codigo)
    {
        // Contains es O(1) en HashSet — búsqueda instantánea sin importar el tamaño
        return _codigos.Contains(codigo.Trim().ToUpper());
    }

    // Retorna todos los códigos registrados en orden alfabético.
    public IEnumerable<string> ObtenerTodos()
    {
        return _codigos.OrderBy(c => c);
    }

    // Cantidad de códigos únicos registrados.
    public int Total => _codigos.Count;
}