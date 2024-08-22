using System;
using System.Collections.Generic;

namespace CSharpLearning.Delegates
{
    class FunctionPointer
    {
        public static void Execute()
        {

            List<Employee> emplist = new List<Employee>();

            emplist.Add(new Employee() { Id = 1, Name = "sivakumar", Experience = 8 });
            emplist.Add(new Employee() { Id = 2, Name = "Aravind", Experience = 6 });
            emplist.Add(new Employee() { Id = 3, Name = "jagadeesh", Experience = 10 });
            emplist.Add(new Employee() { Id = 4, Name = "subbalakshmi", Experience = 9 });

            IsPromotable isPromotable = new IsPromotable(EligibleEmp);

          
            Employee.PromoteEmployee(emplist, isPromotable);

        }

        public static bool EligibleEmp(Employee ee)
        {
            if (ee.Experience >= 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    delegate bool IsPromotable(Employee emp1);
    class Employee
    {

        public int Id { set; get; }
        public string Name { set; get; }
        public int Experience { set; get; }

        public static void PromoteEmployee(List<Employee> emp, IsPromotable IsEligibleToPromote)
        {
            foreach (Employee employee in emp)
            {
                if (IsEligibleToPromote(employee))
                {
                    Console.WriteLine("Employee" + " " + employee.Name + " " + "Promoted");
                }
            }
        }

    }
}


 

