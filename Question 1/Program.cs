using MMGuide;
using Microsoft.VisualBasic;


GenericList<Animal> listOfAnimals2 = new();
GenericList<double> listOfNumbers2 = new();
listOfNumbers2.DoSomething(2.5);
listOfAnimals2.DoSomething(new Animal());


namespace MMGuide
{
    public class Animal
    {
        public string Name { get; set; } = String.Empty;
        public List<string> Habitats { get; set; } = new List<string>();
    }

    public class GenericList<T>
    {

        public void DoSomething(T parm)
        {
            var name = Information.IsNumeric(parm) ? "Number" : parm?.GetType().Name;
            Console.WriteLine($"Foo {name}");
        }

    }


}








