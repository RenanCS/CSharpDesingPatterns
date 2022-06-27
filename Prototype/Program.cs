using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new Manager("Cindy");
            var managerClone = (Manager)manager.Clone();
            Console.WriteLine($"Manager was clone {manager.Name}");

            var employee = new Employee("Kevin", manager);
            var employeeClone = (Employee)employee.Clone();
            Console.WriteLine($"Employee was clone {employee.Name}, with manager {employee.Manager.Name}");

            Console.ReadKey();
        }
    }
}
