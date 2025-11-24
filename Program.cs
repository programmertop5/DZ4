using System;
using System.Collections.Generic;

namespace dz4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s = null;

            while (true)
            {
                Console.WriteLine("\n--- Student Menu ---");
                Console.WriteLine("1. Create student");
                Console.WriteLine("2. View student data");
                Console.WriteLine("3. Add marks");
                Console.WriteLine("4. Show average marks");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        try
                        {
                            Console.Write("Enter name: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter surname: ");
                            string surname = Console.ReadLine();

                            Console.Write("Enter parent name: ");
                            string parentname = Console.ReadLine();

                            Console.Write("Enter group: ");
                            string group = Console.ReadLine();

                            Console.Write("Enter age: ");
                            int age = Convert.ToInt32(Console.ReadLine());

                            s = new Student(name, surname, parentname, group, age);
                            Console.WriteLine("Student created!");
                        }
                        catch (MyStudentException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input for age!");
                        }
                        break;

                    case "2":
                        if (s != null)
                            s.Print();
                        else
                            Console.WriteLine("No student created yet!");
                        break;

                    case "3":
                        if (s == null)
                        {
                            Console.WriteLine("No student created yet!");
                            break;
                        }

                   
                        Console.WriteLine("Enter the marks of programming through space: ");
                        string progr = Console.ReadLine();
                        string[] parts = progr.Split(' ');
                        int[] programming = new int[parts.Length];
                        for (int i = 0; i < parts.Length; i++)
                        {
                            programming[i] = Convert.ToInt32(parts[i]);
                        }
                        s.SetMarks(0, programming);

                       
                        Console.WriteLine("Enter the marks of administration through space: ");
                        string adm = Console.ReadLine();
                        string[] partsAdm = adm.Split(' ');
                        int[] administration = new int[partsAdm.Length];
                        for (int i = 0; i < partsAdm.Length; i++)
                        {
                            administration[i] = Convert.ToInt32(partsAdm[i]);
                        }
                        s.SetMarks(1, administration);

                        
                        Console.WriteLine("Enter the marks of design through space: ");
                        string desig = Console.ReadLine();
                        string[] partsDesign = desig.Split(' ');
                        int[] design = new int[partsDesign.Length];
                        for (int i = 0; i < partsDesign.Length; i++)
                        {
                            design[i] = Convert.ToInt32(partsDesign[i]);
                        }
                        s.SetMarks(2, design);

                        Console.WriteLine("Marks added!");
                        break;

                    case "4":
                        if (s == null)
                        {
                            Console.WriteLine("No student created yet!");
                            break;
                        }
                        Console.WriteLine("Average marks for Programming: " + s.GetAverage(0));
                        Console.WriteLine("Average marks for Administration: " + s.GetAverage(1));
                        Console.WriteLine("Average marks for Design: " + s.GetAverage(2));
                        break;

                    case "5":
                        Console.WriteLine("Exit..");
                        return; 

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}
