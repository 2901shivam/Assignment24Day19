using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment24Day19
{
    public class Source
    {
     public int Id { get; set; }
     public string Name { get; set; }
     public string Description { get; set; }

    }
    public class Destination
    {
        public int Id { get; set; }
        public int ProId { get; set; }

        public string Name { get; set; }

        public string Proname { get; set; }

        public string Newname { get; set; }

    }
    internal class Program
    {

         public static void MappedProperty(Source source,Destination destination)
        {
            PropertyInfo[] sourceProperties = typeof(Source).GetProperties();

            PropertyInfo[] destinationProperties = typeof(Destination).GetProperties();
            foreach(var sourceProperty in sourceProperties)
            {
                foreach(var destinationProperty in destinationProperties)
                {
                    if(sourceProperty.Name==destinationProperty.Name && sourceProperty.PropertyType == destinationProperty.PropertyType)
                    {
                        destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            var source = new Source { Id = 1, Name = "SourceName", Description = "SourceDescription" };
            var destination = new Destination();

           

            MappedProperty(source, destination);

            Console.WriteLine("Mapped Properties:");
            Console.WriteLine($"Id: {destination.Id}");
            Console.WriteLine($"ProId: {destination.ProId}");
            Console.WriteLine($"Name: {destination.Name}");
            Console.WriteLine($"Proname: {destination.Proname}");
            Console.WriteLine($"Newname: {destination.Newname}");

            Console.ReadKey();
        }
    }
}
