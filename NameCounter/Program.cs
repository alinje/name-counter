using System.Diagnostics;


if (args?.Length != 1)
{
    Console.WriteLine("Program need single argument filename.");
    Environment.Exit(1);
}
var path = args[0];

try {
    var res = WordSearch.FileWordSearch(path);
    
    Console.WriteLine($"Found {res} instances of file title in input file.");
    Environment.Exit(0);
} catch (ArgumentException e)
{
    Console.WriteLine($"Illegal input \"{path}\".\n{e.Message}");
    Environment.Exit(1);
} catch (Exception e)
{
    Console.WriteLine("Unexpected error.");
    Trace.TraceError(e.Message);
    Environment.Exit(2);
}
