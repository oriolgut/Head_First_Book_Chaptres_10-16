using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogStruct
{
    public class Canine
    {
        public string Name;
        public string Breed;

        public Canine(string name, string breed)
        {
            Name = name;
            Breed = breed;
        }

        public void Speak()
        {
            Console.WriteLine($"My Name is {Name} an I'm a {Breed}.");
        }
    }
}
