using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpLearning.Delegates.DifferentFlavorsofDelegate
{
    class DifferentFlavorsofDelegate
    {
        protected delegate int tempFunctionPointer(string strParameter, int intParamater);

        public static void Execute()
        {
            DelegateSample tempObj = new DelegateSample();
            tempFunctionPointer funcPointer = tempObj.FirstTestFunction;
            funcPointer("hello", 1);
            Console.ReadKey();
            funcPointer = tempObj.SecondTestFunction;
            funcPointer("hello", 1);
            Console.ReadKey();

            //-------------- Func<TParameter, TOutput>
            Func<string, int, int> tempFuncPointer = tempObj.FirstTestFunction;
            int value = tempFuncPointer("hello", 3);
            Console.ReadKey();

            //--------------Action<TParameter>
            Action<string, int> tempActionPointer = tempObj.ThirdTestFunction;
            tempActionPointer("hello", 4);
            Console.ReadKey();


            //--------------------Predicate<in T>
            Predicate<Employee> tempPredicatePointer = tempObj.FourthTestFunction;
            Employee[] lstEmployee = (new Employee[]
            {
               new Employee(){ Name = "Ashwin", Age = 31},
               new Employee(){ Name = "Akil", Age = 25},
               new Employee(){ Name = "Amit", Age = 28},
               new Employee(){ Name = "Ajay", Age = 29},
            });

            
            Employee tempEmployee = Array.Find(lstEmployee, tempPredicatePointer);
            // Employee tempEmployee = Array.Find(lstEmployee, x=> x.Age < 27);

            Console.WriteLine("Person below 27 age :" + tempEmployee.Name);
            Console.ReadKey();


            //--------------------------------------------Entity FrameWork understanding-----------------------------------------------------------
            Func<Employee, bool> entityFunc = tempObj.EntityFunction;
            Predicate<Employee> entityPredicate = tempObj.EntityFunction; // XX does not work

            var lst = lstEmployee.Where(entityFunc).ToList();

        }


        public bool FourthTestFunction(Employee employee)
        {
            return employee.Age < 27;
        }

        
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class XEmployee
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public bool IsExEmployee
        {
            get { return true; }
        }
    }

    public class DelegateSample
    {
        public int FirstTestFunction(string strParameter, int intParamater)
        {
            Console.WriteLine("First Test Function Execution");
            Console.WriteLine(strParameter);
            return intParamater;
        }

        public int SecondTestFunction(string strParameter, int intParamater)
        {
            Console.WriteLine("Second Test Function Execution");
            Console.WriteLine(strParameter);
            return intParamater;
        }

        public void ThirdTestFunction(string strParameter, int intParamater)
        {
            Console.WriteLine("Third Test Function Execution");
            Console.WriteLine(strParameter);
        }

        public bool FourthTestFunction(Employee employee)
        {
            return employee.Age < 27;
        }

        public XEmployee FifthTestFunction(Employee employee)
        {
            return new XEmployee() { Name = employee.Name, Age = employee.Age };
        }

        public int SixTestFunction(Employee strParameter1, Employee strParamater2)
        {
            return strParameter1.Name.CompareTo(strParamater2.Name);
        }

        public bool EntityFunction(Employee employee)
        {
            return employee.Age < 27;
        }
    }
}
