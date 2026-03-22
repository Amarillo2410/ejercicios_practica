# Filtrar datos en consola

Tienes una colección de datos que representa varias filas de una tabla y debes crear un programa en **C# para consola** capaz de filtrarlas según el texto ingresado por el usuario.

Debes implementar una función llamada `FilterTable()` que reciba una lista de filas y un texto de búsqueda, y muestre únicamente las filas que contengan ese texto.

El filtrado debe hacerse **sin distinguir entre mayúsculas y minúsculas**.

En un programa de consola, el comportamiento “en vivo” se puede simular pidiendo al usuario que escriba un texto y actualizando el resultado cada vez que ingrese una nueva búsqueda.

### Ejemplo de comportamiento

Si el usuario escribe:

- `J` → se muestran las filas 1 y 3
- `Ju` → solo se muestra la fila 1

Esto significa que el programa debe buscar coincidencias parciales dentro de cada fila.