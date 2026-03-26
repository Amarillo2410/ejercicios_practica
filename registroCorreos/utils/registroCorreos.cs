using System;

namespace registro_correos.utils;

// Clase que gestiona el registro de correos únicos usando HashSet.
public class RegistroCorreos
{
    // HashSet que almacena los correos normalizados (minúsculas, sin espacios)
    // La normalización garantiza que "Ana@Gmail.com" y "ana@gmail.com" sean el mismo
    private readonly HashSet<string> _correos = new HashSet<string>();

    // Verifica que el correo tenga un formato básico válido:
    public static bool TieneFormatoValido(string correo)
    {
        // Buscamos la posición del símbolo '@' en el correo
        int posArroba = correo.IndexOf('@');

        // El '@' debe existir y no estar al inicio ni al final
        if (posArroba <= 0 || posArroba == correo.Length - 1)
            return false;

        // Después del '@' debe haber al menos un punto
        string dominio = correo.Substring(posArroba + 1);
        return dominio.Contains('.');
    }

    // Intenta registrar un correo en el HashSet.
    // Normaliza el correo antes de guardarlo.
    // True si fue agregado, False si ya existía
    public bool Registrar(string correo)
    {
        // Normalizamos: quitamos espacios y convertimos a minúsculas
        string normalizado = correo.Trim().ToLower();

        // Add() retorna false automáticamente si el correo ya existe
        return _correos.Add(normalizado);
    }

    // Retorna todos los correos registrados en orden alfabético.
    public IEnumerable<string> ObtenerTodos()
    {
        return _correos.OrderBy(c => c);
    }

    // Cantidad de correos únicos registrados.
    public int Total => _correos.Count;
}