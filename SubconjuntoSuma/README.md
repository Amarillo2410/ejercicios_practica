# 5. Verificar si existe un subconjunto con suma dada

En este reto debes crear un programa en **C# para consola** que determine si, a partir de una lista de números enteros positivos, existe algún subconjunto cuyos elementos sumen un valor objetivo.

Debes implementar una función recursiva, por ejemplo `ExisteSuma()`, que reciba:

- una lista o arreglo de enteros positivos,
- un número entero que represente la suma objetivo.

La función deberá devolver:

- `true` si existe al menos un subconjunto cuyos elementos sumen exactamente el valor indicado,
- `false` en caso contrario.

------

## Ejemplos

```
ExisteSuma([3, 4, 2, 8, 7], 6)   -> true
ExisteSuma([3, 4, 2, 8, 7], 26)  -> false
ExisteSuma([4], 4)               -> true
```

### Explicación de los ejemplos

- En `[3, 4, 2, 8, 7]`, sí existe un subconjunto que suma `6`, por ejemplo `4 + 2`.
- En esa misma lista no existe ningún subconjunto que sume `26`.
- En `[4]`, el único elemento coincide con la suma buscada.