using System;                  // Permite usar Console, Random, etc.
using System.Linq;            // Permite usar OrderBy para mezclar
using System.Text;            // Permite usar StringBuilder

class Contrasena               // Definición de la clase
{
    public static void Main(string[] args) // Método principal
    {
        Random random = new Random(); // Generador de números aleatorios

        // Cadenas con los tipos de caracteres permitidos
        string mayus = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; 
        string minus = "abcdefghijklmnopqrstuvwxyz";
        string numeros = "0123456789";
        string especiales = "!@#$%&*?+=-/";

        string todos = mayus + minus + numeros + especiales; // Todos los caracteres juntos

        int longitud = random.Next(15, 88);// Genera una longitud aleatoria entre 15 y 87

        StringBuilder contraseña = new StringBuilder();// Se usa para construir la contraseña

        contraseña.Append(mayus[random.Next(mayus.Length)]);// Agrega al menos una mayúscula

        contraseña.Append(minus[random.Next(minus.Length)]);// Agrega al menos una minúscula

        contraseña.Append(numeros[random.Next(numeros.Length)]);// Agrega al menos un número

        contraseña.Append(especiales[random.Next(especiales.Length)]);// Agrega al menos un carácter especial

        for (int i = contraseña.Length; i < longitud; i++)// Completa el resto de la contraseña hasta la longitud deseada
        {
            contraseña.Append(todos[random.Next(todos.Length)]);// Agrega un carácter aleatorio de todos los disponibles
        }

        // Mezcla los caracteres para que no queden en orden fijo
        string resultado = new string(contraseña.ToString()
            .OrderBy(x => random.Next()) // Orden aleatorio
            .ToArray());                 // Convierte a arreglo

        // Muestra la contraseña generada
        Console.WriteLine("Contraseña generada:");
        Console.WriteLine(resultado);
    }
}