using System;
namespace DSA_Problem_1
{ 
    class StackUndo
    {
        static int MAX = 10;
        static string[] stack = new string[MAX];
        static int top = -1;

        public static void Push(string action)
        {
            if (top == MAX - 1)
            {
                Console.WriteLine("Stack Overflow");
                return;
            }
            stack[++top] = action;
            Display();
        }

        public static void Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack Underflow - Nothing to Undo");
                return;
            }
            Console.WriteLine("Undo: " + stack[top--]);
            Display();
        }

        public static void Display()
        {
            if (top == -1)
            {
                Console.WriteLine("Current State: Empty");
                return;
            }

            Console.Write("Current State: ");
            for (int i = 0; i <= top; i++)
            {
                Console.Write(stack[i] + " ");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== STACK UNDO SYSTEM ===");

            StackUndo.Push("Type A");
            StackUndo.Push("Type B");
            StackUndo.Push("Type C");
            StackUndo.Pop();
            StackUndo.Pop();
        }
    }
}
