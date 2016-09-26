using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogStruct
{
    public struct Dog
    {
        public string Name;
        public string Breed;

        public Dog(string name, string breed)
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
