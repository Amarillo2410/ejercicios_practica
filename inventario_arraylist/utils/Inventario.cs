using System;
using System.Collections;
namespace inventario_arraylist.utils;

// Clase que gestiona un inventario de productos usando ArrayList.
// Se usa aquí para demostrar colecciones no genéricas del namespace System.Collections.
public class Inventario
{
    // ArrayList puede guardar cualquier tipo de objeto (object) A diferencia de List<string>, no está limitado a un tipo específico
    private readonly ArrayList _productos = new ArrayList();

    // Agrega un producto al inventario.
    public void Agregar(string nombre)
    {
        // Add() acepta object, por eso funciona con cualquier tipo
        _productos.Add(nombre.Trim());
    }

    /// Verifica si un producto ya existe en el inventario.
    public bool Existe(string nombre)
    {
        // Contains de ArrayList compara por valor usando Equals()
        return _productos.Contains(nombre.Trim());
    }

    // Elimina un producto del inventario por nombre.
    public bool Eliminar(string nombre)
    {
        // Verificamos primero si existe para informar el resultado
        if (!Existe(nombre)) return false;

        // Remove() elimina la primera ocurrencia del valor
        _productos.Remove(nombre.Trim());
        return true;
    }

    // Muestra todos los productos del inventario numerados.
    // Demuestra el recorrido de ArrayList con foreach y casting a string.
    public void MostrarTodos()
    {
        if (_productos.Count == 0)
        {
            Console.WriteLine("  (inventario vacío)");
            return;
        }

        // Recorremos el ArrayList — cada elemento es object, hacemos cast a string
        for (int i = 0; i < _productos.Count; i++)
        {
            // Cast explícito de object a string para poder usarlo como texto
            string producto = (string)_productos[i]!;
            Console.WriteLine($"  {i + 1,2}. {producto}");
        }
    }

    public int Total => _productos.Count;
}