using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<string> tasks = new List<string>();
    static string filePath = "tasks.txt";

    static void Main()
    {
        LoadTasks();

        while (true)

        {
            Console.Clear();
            Console.WriteLine("To-Do List\n");

            ViewTasks(); 

            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Mark Task Done");
            Console.WriteLine("4. Save & Exit");
            Console.Write("Choose an option: ");


            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    MarkTaskDone();
                    break;
                case "4":
                    SaveTasks();
                    return; 
                default:
                    Console.WriteLine("Invalid option! Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Enter task description: ");
        string task = Console.ReadLine();
        tasks.Add(task);
    }

    static void ViewTasks()
    {
        Console.WriteLine("Tasks");
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks yet.");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($" {i + 1}. {tasks[i]}");
            }
        }
        Console.WriteLine();
    }

    static void MarkTaskDone()
    {
        Console.Write("Enter task number to mark done: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks.RemoveAt(taskNumber - 1);
            Console.WriteLine("Task removed!");
        }
        else
        {
            Console.WriteLine("Invalid task number!");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void SaveTasks()
    {
        File.WriteAllLines(filePath, tasks);
    }

    static void LoadTasks()
    {
        if (File.Exists(filePath))
        {
            tasks = new List<string>(File.ReadAllLines(filePath)); 
        }
    }
}