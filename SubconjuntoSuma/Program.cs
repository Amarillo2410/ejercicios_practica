using System;

class Program
{
    static void Main(string[] args)
    {
        int[] numeros = { 3, 4, 2, 8, 7 };

        Console.WriteLine(ExisteSuma(numeros, 6));   // true
        Console.WriteLine(ExisteSuma(numeros, 26));  // false
        Console.WriteLine(ExisteSuma(new int[] { 4 }, 4)); // true
    }

    // Función recursiva
    static bool ExisteSuma(int[] nums, int objetivo, int index = 0)
    {
        // 🔹 Caso base: si llegamos exactamente al objetivo
        if (objetivo == 0)
            return true;

        // 🔹 Caso base: si nos pasamos o terminamos la lista
        if (objetivo < 0 || index >= nums.Length)
            return false;

        return 
            ExisteSuma(nums, objetivo - nums[index], index + 1) // incluir
            || 
            ExisteSuma(nums, objetivo, index + 1); // no incluir
    }
}