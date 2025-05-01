using System;
using System.Collections.Generic;
using System.Linq;

namespace TowerOfHanoi
{
    public class Program
    {
        // Holds the initial number of disks to help with formatting
        public static int maxHeight;

        public static void Main(string[] args)
        {

            List<Employee> employees = new List<Employee>
            {
                new Employee(1, "John Doe", "IT", "Developer", 60000),
                new Employee(2, "Jane Smith", "HR", "Manager", 70000),
                new Employee(3, "Sam Brown", "Finance", "Analyst", 80000)
            };

            Console.Write("Enter the number of disks: ");
            if (!int.TryParse(Console.ReadLine(), out int numDisks) || numDisks <= 0)
            {
                Console.WriteLine("Please enter a positive integer.");
                return;
            }

            maxHeight = numDisks;

            // Initialize the three towers with fixed keys: A, B, C.
            var towers = new Dictionary<char, Stack<int>>
            {
                { 'A', new Stack<int>() },
                { 'B', new Stack<int>() },
                { 'C', new Stack<int>() }
            };

            // Populate Tower A so that the smallest disk is on top.
            for (int disk = numDisks; disk >= 1; disk--)
            {
                towers['A'].Push(disk);
            }

            // Display the initial state of the towers.
            Console.WriteLine("\nInitial State:");
            DisplayTowers(towers);

            // Solve Tower of Hanoi: move all disks from A to C with B as auxiliary.
            SolveHanoi(numDisks, 'A', 'B', 'C', towers);
        }

        // Recursive method that implements the Tower of Hanoi algorithm.
        public static void SolveHanoi(int n, char from, char aux, char to, Dictionary<char, Stack<int>> towers)
        {
            if (n == 1)
            {
                MakeMove(from, to, towers);
                return;
            }

            SolveHanoi(n - 1, from, to, aux, towers);
            MakeMove(from, to, towers);
            SolveHanoi(n - 1, aux, from, to, towers);
        }

        // Helper method to perform a move and display the towers.
        public static void MakeMove(char from, char to, Dictionary<char, Stack<int>> towers)
        {
            int disk = towers[from].Peek();
            towers[from].Pop();
            towers[to].Push(disk);
            Console.WriteLine($"\nMove disk {disk} from {from} to {to}");
            DisplayTowers(towers);
        }

        // Displays the towers vertically in fixed alphabetical order: A, B, then C.
        public static void DisplayTowers(Dictionary<char, Stack<int>> towers)
        {
            // Get the maximum height of the towers.
            int height = maxHeight;
            var displays = new Dictionary<char, string[]>();

            // Build the display lines for each tower.
            foreach (char towerName in new char[] { 'A', 'B', 'C' })
            {
                // Get disks in the original order (top-to-bottom).
                List<int> towerList = towers[towerName].ToList();
                string[] rows = new string[height];
                int blankRows = height - towerList.Count;

                // Top rows are blank if the tower does not have a disk in that row.
                for (int i = 0; i < blankRows; i++)
                {
                    rows[i] = "";
                }
                // Then fill in the disk numbers.
                for (int i = blankRows; i < height; i++)
                {
                    rows[i] = towerList[i - blankRows].ToString();
                }
                displays[towerName] = rows;
            }

            // Print each row from top to bottom.
            for (int row = 0; row < height; row++)
            {
                Console.WriteLine($"{displays['A'][row],7} {displays['B'][row],7} {displays['C'][row],7}");
            }

            // Print the separator and labels.
            Console.WriteLine($"{"  ---",7} {"  ---",7} {"  ---",7}");
            Console.WriteLine($"{"A",7} {"B",7} {"C",7}");
        }
    }
}