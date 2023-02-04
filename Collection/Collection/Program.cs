using Collections;

namespace Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var collection = new Collection<int>();
            Console.WriteLine("Current collection: " + collection.ToString());

            Console.WriteLine("Collection count: " + collection.Count);
            Console.WriteLine("Collection capacity: " + collection.Capacity);

        }
    }
}