using MultiDb.One;
using MultiDb.Two;
using System;

namespace MultiDb.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db1 = new DbOneContext())
            {
                using (var db2 = new DbTwoContext())
                {
                    DbInitializer.Initialize(db1, db2);

                    var lectures = db1.GetLectures(db2);

                    foreach (var l in lectures)
                    {
                        Console.WriteLine(l.name);
                        Console.WriteLine($"Proctor: {l.proctor.name}");
                        Console.WriteLine("Attendees:");

                        foreach (var a in l.attendees)
                        {
                            Console.WriteLine(a.name);
                        }
                        Console.WriteLine();
                    }

                    Console.ReadLine();
                }
            }
        }
    }
}
