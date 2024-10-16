using System;

public struct HiringDate
{
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }

    public HiringDate(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Day:D2}/{Month:D2}/{Year}";
    }

    public int CompareTo(HiringDate other)
    {
        if (this.Year != other.Year) return this.Year.CompareTo(other.Year);
        if (this.Month != other.Month) return this.Month.CompareTo(other.Month);
        return this.Day.CompareTo(other.Day);
    }
}

public class Employee
{
   
    public int ID { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
    public HiringDate HireDate { get; set; }
    public string Gender { get; set; }

   
    public Employee(int id, string name, double salary, HiringDate hireDate, string gender)
    {
        ID = id;
        Name = name;
        Salary = salary;
        HireDate = hireDate;
        Gender = gender;
    }

    public Employee() : this(0, "Unknown", 0.0, new HiringDate(1, 1, 2000), "Not Specified") { }

    
    public override string ToString()
    {
        return $"ID: {ID}, Name: {Name}, Salary: {Salary:C}, Hire Date: {HireDate}, Gender: {Gender}";
    }

    
    public object this[string propertyName]
    {
        get
        {
            return propertyName.ToLower() switch
            {
                "id" => ID,
                "name" => Name,
                "salary" => Salary,
                "hiredate" => HireDate,
                "gender" => Gender,
                _ => null
            };
        }
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of employees: ");
        int employeeCount = int.Parse(Console.ReadLine());

       
        Employee[] employees = new Employee[employeeCount];

       
        for (int i = 0; i < employeeCount; i++)
        {
            Console.WriteLine($"\nEnter details for Employee {i + 1}:");

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Salary: ");
            double salary = double.Parse(Console.ReadLine());

            Console.Write("Hire Date (DD MM YYYY): ");
            string[] dateParts = Console.ReadLine().Split(' ');
            int day = int.Parse(dateParts[0]);
            int month = int.Parse(dateParts[1]);
            int year = int.Parse(dateParts[2]);

            HiringDate hireDate = new HiringDate(day, month, year);

            Console.Write("Gender: ");
            string gender = Console.ReadLine();

            
            employees[i] = new Employee(id, name, salary, hireDate, gender);
        }

       
        Array.Sort(employees, (emp1, emp2) => emp1.HireDate.CompareTo(emp2.HireDate));

        
        Console.WriteLine("\nEmployees sorted by Hire Date:");
        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }
    }
}
