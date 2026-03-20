using System;
using System.Collections.Generic;
namespace CollectionProblem
{ 
    class TodoApp
    {
        static void Main()
        {
            List<string> tasks = new List<string>();
            int choice;

            do
            {
                Console.WriteLine("\nTo-Do List Manager");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Remove Task");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                // Input validation for menu
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddTask(tasks);
                        break;

                    case 2:
                        ViewTasks(tasks);
                        break;

                    case 3:
                        RemoveTask(tasks);
                        break;

                    case 4:
                        Console.WriteLine("Exiting application...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }

            } while (choice != 4);
        }

        // Add Task
        static void AddTask(List<string> tasks)
        {
            Console.Write("Enter task: ");
            string task = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(task))
            {
                Console.WriteLine("Task cannot be empty!");
                return;
            }

            tasks.Add(task);
            Console.WriteLine("Task added!");
        }

        // View Tasks
        static void ViewTasks(List<string> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            Console.WriteLine("Tasks:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        // Remove Task
        static void RemoveTask(List<string> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks to remove.");
                return;
            }

            Console.Write("Enter task number to remove: ");

            if (!int.TryParse(Console.ReadLine(), out int index))
            {
                Console.WriteLine("Invalid input! Enter a number.");
                return;
            }

            if (index < 1 || index > tasks.Count)
            {
                Console.WriteLine("Invalid task number.");
                return;
            }

            string removedTask = tasks[index - 1];
            tasks.RemoveAt(index - 1);

            Console.WriteLine($"Removed: {removedTask}");
        }
    }
}
