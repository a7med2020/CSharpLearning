﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpLearning.Keywords.Modifiers.NewAndOverrid
{
    // The override modifier extends the base class virtual method, and the new modifier hides an accessible base class method. 
    // Override methods are not considered as declared on a class, they are new implementations of a method declared on a base class.
    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords
    /// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/virtual
    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/new-modifier
    // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords
    // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/versioning-with-the-override-and-new-keywords
    /// </summary>
    public static class NewAndOverrid_Example2
    {
        public static void Execute()
        {
            // Declare objects of the derived classes and test which version  
            // of ShowDetails is run, base or derived.  
            TestCars1();

            // Declare objects of the base class, instantiated with the  
            // derived classes, and repeat the tests.  
            TestCars2();

            // Declare objects of the derived classes and call ShowDetails  
            // directly.  
            TestCars3();

            // Declare objects of the base class, instantiated with the  
            // derived classes, and repeat the tests.  
            //TestCars4();
        }

        public static void TestCars1()
        {
            Console.WriteLine("\nTestCars1");
            Console.WriteLine("----------");

            Car car1 = new Car();
            car1.DescribeCar();
            Console.WriteLine("----------");

            // Notice the output from this test case. The new modifier is  
            // used in the definition of ShowDetails in the ConvertibleCar  
            // class.
            ConvertibleCar car2 = new ConvertibleCar();
            car2.DescribeCar();
            Console.WriteLine("----------");

            Minivan car3 = new Minivan();
            car3.DescribeCar();
            Console.WriteLine("----------");
        }
        // Output:  
        // TestCars1  
        // ----------  
        // Four wheels and an engine.  
        // Standard transportation.  
        // ----------  
        // Four wheels and an engine.  
        // Standard transportation.  
        // ----------  
        // Four wheels and an engine.  
        // Carries seven people.  
        // ----------  

        public static void TestCars2()
        {
            Console.WriteLine("\nTestCars2");
            Console.WriteLine("----------");

            var cars = new List<Car> { new Car(), new ConvertibleCar(),
                new Minivan() };

            foreach (var car in cars)
            {
                car.DescribeCar();
                Console.WriteLine("----------");
            }
        }
        // Output:  
        // TestCars2  
        // ----------  
        // Four wheels and an engine.  
        // Standard transportation.  
        // ----------  
        // Four wheels and an engine.  
        // Standard transportation.  
        // ----------  
        // Four wheels and an engine.  
        // Carries seven people.  
        // ----------  

        public static void TestCars3()
        {
            Console.WriteLine("\nTestCars3");
            Console.WriteLine("----------");
            ConvertibleCar car2 = new ConvertibleCar();
            Minivan car3 = new Minivan();
            car2.ShowDetails();
            car3.ShowDetails();
        }
        // Output:  
        // TestCars3  
        // ----------  
        // A roof that opens up.  
        // Carries seven people.  

        public static void TestCars4()
        {
            Console.WriteLine("\nTestCars4");
            Console.WriteLine("----------");
            Car car2 = new ConvertibleCar();
            Car car3 = new Minivan();
            car2.ShowDetails();
            car3.ShowDetails();
        }
        // Output:  
        // TestCars4  
        // ----------  
        // Standard transportation.  
        // Carries seven people.  
    }

    // Define the base class, Car. The class defines two virtual methods,  
    // DescribeCar and ShowDetails. DescribeCar calls ShowDetails, and each derived  
    // class also defines a ShowDetails method. The example tests which version of  
    // ShowDetails is used, the base class method or the derived class method.  
    class Car
    {
        public virtual void DescribeCar()
        {
            Console.WriteLine("Four wheels and an engine.");
            ShowDetails();
        }

        public virtual void ShowDetails()
        {
            Console.WriteLine("Standard transportation.");
        }
    }

    // Define the derived classes.  

    // Class ConvertibleCar uses the new modifier to acknowledge that ShowDetails  
    // hides the base class method.  
    class ConvertibleCar : Car
    {
        public new void ShowDetails()
        {
            Console.WriteLine("A roof that opens up.");
        }
    }

    // Class Minivan uses the override modifier to specify that ShowDetails  
    // extends the base class method.  
    class Minivan : Car
    {
        public override void ShowDetails()
        {
            Console.WriteLine("Carries seven people.");
        }
    }

}
