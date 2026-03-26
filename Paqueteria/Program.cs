internal class Program
{
    private static void Main(string[] args)
    {
        // string collection
        List<string> strinSkills = new List<string>() {
            "C# Tutorials",
            "SpringBoot",
            "Java",
            "Android and Java" ,
            "C# and .NET Tutorials",
        };

        // LINQ Query Syntax
        var result = from s in strinSkills
                     where s.Contains("Java")
                     select s;
        foreach (var str in result)
		{
			Console.WriteLine(str);
		}
   }
}