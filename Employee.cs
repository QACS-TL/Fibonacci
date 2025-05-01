using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }

        public Employee(int id, string name, string department, string position, int salary)
        {
            Id = id;
            Name = name;
            Department = department;
            Position = position;
            Salary = salary;
        }
        public override string ToString()
        {
            return $"{Id}, {Name}, {Department}, {Position}, {Salary}";
        }
    }
}
