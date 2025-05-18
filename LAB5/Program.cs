using LAB5.Models;
using LAB5.Services;
using System.Collections.Concurrent;

var handler = new FileHandler();
var progress = new Progress<int>(i => Console.Write("#"));

while (true)
{
    Console.WriteLine("\n1 - Сгенерировать и сохранить напитки");
    Console.WriteLine("2 - Прочитать файлы параллельно");
    Console.WriteLine("3 - Выйти");

    var choice = Console.ReadLine();

    if (choice == "1")
    {
        var drinks = handler.GenerateDrinks(50);
        await handler.SaveToMultipleFilesAsync(drinks);
        Console.WriteLine("Файлы успешно записаны.");
    }
    else if (choice == "2")
    {
        string[] files = Enumerable.Range(1, 5).Select(i => $"file{i}.json").ToArray();
        var result = await handler.LoadFromFilesAsync(files, progress);

        Console.WriteLine("\n\nРезультат чтения:");
        foreach (var pair in result)
        {
            Console.WriteLine($"\nФайл: {pair.Key}");
            foreach (var drink in pair.Value)
            {
                Console.WriteLine(drink);
            }
        }

        handler.SortDictionary(result);
        Console.WriteLine("\nСловарь отсортирован по ID.");
    }
    else if (choice == "3")
    {
        break;
    }
    else
    {
        Console.WriteLine("Неверный выбор.");
    }
}
