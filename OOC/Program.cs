using System;

namespace tuto
{
    class Program
    {
        public class heroes
        {
            public string Name;
            public string Ability;
            public string Origin;

            public heroes(string name,string ability,string origin)
            {
                Name = name;
                Ability = ability;
                Origin = origin;
            }

        }

        static void Main(string[] args)
        {
            heroes Superman = new heroes("Superman","Super Strenght","Alien");
            heroes Spiderman = new heroes("Spiderman","Super senses","Human");
            heroes Wolverine = new heroes("Wolverine","Regenerative Power","Mutant");
            heroes Flash = new heroes("Flash","Super Speed","Human");
            heroes Thor  = new heroes("Thor","God of Thunder","Alien");
            Console.WriteLine(Superman.Name + " has " + Superman.Ability + ", he is an " + Superman.Origin);
            Console.WriteLine(Spiderman.Name + " has " + Spiderman.Ability + ", he is " + Spiderman.Origin);
            Console.WriteLine(Wolverine.Name + " has " + Wolverine.Ability + ", he is " + Wolverine.Origin);
            Console.WriteLine(Flash.Name + " has " + Flash.Ability + ", he is " + Flash.Origin);
            Console.WriteLine(Thor.Name + " is the " + Thor.Ability + ", he is an " + Thor.Origin);
        }
    }
}
