using System;

public class Program
{
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.

        Console.WriteLine("Hello Sandbox World!");

        Console.WriteLine("I am not sure how to work here, but I will figure it out!");
        var numbers = new List<int>();

        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(3);


        foreach (var variableanyname in numbers)
        { Console.WriteLine(variableanyname); }

        for (var index = 0; index < numbers.Count; ++index)
        {
            Console.WriteLine(numbers[index]);
        }

    }
}


