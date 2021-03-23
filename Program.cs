using System;
using System.Collections.Generic;
using System.Linq;

namespace FP1.Lesson_5
{
    class Program
    {
        /*
         * Напишите заголовок метода группировки элементов коллекции по какому-то признаку — GroupBy. 
         * Как задать критерий группировки? Что может быть результатом работы этого метода?
         */

        class Car
        {
            public string Name { get; set; }
            public string Model { get; set; }

        }
        static void Main(string[] args)
        {
            var cars = new[]
            {
            new Car{Name="Model S",Model="Tesla"},
            new Car{Name="Fortuner",Model="Toyota"},
            new Car{Name="X3",Model="BMW"},
            new Car{Name="CX-9",Model="Mazda"},
            new Car{Name="Cybertruck",Model="Tesla"},
            new Car{Name="CX-5",Model="Mazda"},
            new Car{Name="Hatchback",Model="Mazda"}

            };
            var carGroups = cars.GroupBy(p => p.Model)
                                .Select(g => new { Name = g.Key, Count = g.Count() });
            var carGroups2 = from car in cars
                             group car by car.Model into g
                             select new
                             {
                                 Name = g.Key,
                                 Count = g.Count(),
                                 Cars = from p in g select p
                             };
            foreach (var group in carGroups2)
            {
                Console.WriteLine($"{group.Name} : {group.Count}");
                foreach (Car car in group.Cars)
                    Console.WriteLine(car.Name);
                Console.WriteLine();
            }

        }


    }


}
