using System;
using System.Collections.Generic;
using System.IO;

namespace WrapUpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PersonModel> people = new List<PersonModel>
            {
                new PersonModel{FirstName = "Chris", LastName = "C", Email = "chris.c@mail.com"},
                new PersonModel{FirstName = "John", LastName = "D", Email = "john.d@mail.com"},
                new PersonModel{FirstName = "John", LastName = "crap", Email = "zjohn.d@mail.com"},
                new PersonModel{FirstName = "John", LastName = "a", Email = "xjcrap.d@mail.com"},
                new PersonModel{FirstName = "Sue", LastName = "S", Email = "sue.s@mail.com"}
            };

            List<CarModel> cars = new List<CarModel>
            {
                new CarModel{Manufacturer = "Dodge", Model = "m1"},
                new CarModel{Manufacturer = "Dodge", Model = "m2"},
                new CarModel{Manufacturer = "Ford", Model = "m1"}
            };

            string filePath = @"C:\Temp\SavedFiles\people.csv";

            people.SaveToCSV(filePath);
            cars.SaveToCSV(@"C:\Temp\SavedFiles\cars.csv");

            Console.ReadLine();
        }
    }

    public static class DataAccess
    {
        public static void SaveToCSV<T>(this List<T> items, string filePath) where T: new()
        {
            List<string> rows = new List<string>();
            string row = "";

            T entry = new T();
            var cols = entry.GetType().GetProperties();

            foreach (var col in cols)
            {
                row += $",{col.Name}";
            }
            row = row.Substring(1);
            rows.Add(row);

            foreach (var item in items)
            {
                row = "";
                bool badWordDetected = false;

                foreach (var col in cols)
                {
                    string val = col.GetValue(item, null).ToString();

                    badWordDetected = BadWordDetector(val);

                    if (badWordDetected == true)
                    {
                        break;
                    }
                    row += $",{val}";
                }

                if (badWordDetected == false)
                {
                    row = row.Substring(1);
                    rows.Add(row);
                }
            }

            File.WriteAllLines(filePath, rows);
        }

        private static bool BadWordDetector(string bw)
        {
            bool output = false;
            string b = bw.ToLower();

            if (b.Contains("crap") || b.Contains("darn"))
            {
                output = true;
            }

            return output;
        }
    }
}
