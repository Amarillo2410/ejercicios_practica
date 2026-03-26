using System;

namespace validar_correos.utils;

// Clase que gestiona el registro de correos electrónicos únicos.

public class EmailRegistry
{
    // HashSet que almacena los correos registrados
    // Al ser string, la comparación de igualdad ya está definida por defecto
    private readonly HashSet<string> _correos = new HashSet<string>();

    // Intenta registrar un correo electrónico.
    // Normaliza el correo antes de guardarlo (minúsculas y sin espacios).
    public bool Registrar(string correo)
    {
        // Normalizamos el correo: quitamos espacios y convertimos a minúsculas
        // Esto evita que "Ana@Gmail.com" y "ana@gmail.com" se traten como distintos
        string correoNormalizado = correo.Trim().ToLower();

        // Add() retorna true si el elemento fue agregado (era nuevo)
        // retorna false si el elemento ya existía en el HashSet
        return _correos.Add(correoNormalizado);
    }

    // Retorna todos los correos registrados ordenados alfabéticamente.
    public IEnumerable<string> ObtenerTodos()
    {
        // OrderBy para mostrarlos en orden alfabético en el reporte final
        return _correos.OrderBy(c => c);
    }

    /// <summary>
    /// Retorna la cantidad de correos registrados actualmente.
    /// </summary>
    public int Total => _correos.Count;
}