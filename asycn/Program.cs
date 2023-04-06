// See https://aka.ms/new-console-template for more information

internal class Program
{
    static async Task Main()
    {
        string filename = @"D:\course\1.txt";
           
        // sync
        File.WriteAllText(filename, @"never give up");
        string s = File.ReadAllText(filename);

        // async 
        await File.WriteAllTextAsync(filename, @"life's little bit messy.we all make mistakes");
        string s = await File.ReadAllTextAsync(filename);
        Console.WriteLine(s);
    }

}