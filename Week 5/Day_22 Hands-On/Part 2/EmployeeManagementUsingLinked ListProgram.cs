using System;
namespace DSA_Problem_2
{
    class Node
    {
        public int empId;
        public string name;
        public Node next;

        public Node(int id, string name)
        {
            this.empId = id;
            this.name = name;
            this.next = null;
        }
    }

    class LinkedList
    {
        Node head = null;
        public void InsertAtBeginning(int id, string name)
        {
            Node newNode = new Node(id, name);
            newNode.next = head;
            head = newNode;
        }
        public void InsertAtEnd(int id, string name)
        {
            Node newNode = new Node(id, name);

            if (head == null)
            {
                head = newNode;
                return;
            }

            Node temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }

            temp.next = newNode;
        }

        public void Delete(int id)
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            if (head.empId == id)
            {
                head = head.next;
                return;
            }

            Node temp = head;
            Node prev = null;

            while (temp != null && temp.empId != id)
            {
                prev = temp;
                temp = temp.next;
            }

            if (temp == null)
            {
                Console.WriteLine("Employee not found");
                return;
            }

            prev.next = temp.next;
        }

        public void Display()
        {
            Node temp = head;

            if (temp == null)
            {
                Console.WriteLine("Employee List is Empty");
                return;
            }

            while (temp != null)
            {
                Console.WriteLine(temp.empId + " - " + temp.name);
                temp = temp.next;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== EMPLOYEE LINKED LIST ===");

            LinkedList list = new LinkedList();

            list.InsertAtEnd(101, "John");
            list.InsertAtEnd(102, "Sara");
            list.InsertAtEnd(103, "Mike");

            Console.WriteLine("\nBefore Deletion:");
            list.Display();

            list.Delete(102);

            Console.WriteLine("\nAfter Deletion:");
            list.Display();
        }
    }
}
