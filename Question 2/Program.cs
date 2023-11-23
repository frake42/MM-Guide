using MMGuide;


string[] words = { "the", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
LinkedList<string> wordlist = new(words);

var reverselist = ReverseLinkedList<string>.ReverseWithLoop(wordlist);

Console.WriteLine("Reverse List with Loop:");
foreach (string s in reverselist)
{
    Console.Write(s + " ");
}

reverselist = ReverseLinkedList<string>.ReverseWithRecursion(wordlist);
Console.WriteLine("");
Console.WriteLine("Reverse List with Recursion:");
foreach (string s in reverselist)
{
    Console.Write(s + " ");
}


namespace MMGuide
{

    public class ReverseLinkedList<T>
    {
        public static LinkedList<T> ReverseWithLoop(LinkedList<T> list)
        {
            LinkedList<T> reversedList = new();
            foreach (T item in list)
            {
                reversedList.AddFirst(item);
            }
            return reversedList;
        }

        public static LinkedList<T> ReverseWithRecursion(LinkedList<T> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }

            var first = list.First;
            list.RemoveFirst();
            var reversed = ReverseLinkedList<T>.ReverseWithRecursion(list);

            if (first != null)  // first is not null but this prevents compiler warning
            {
                reversed.AddLast(first);
            }
            return reversed;
        }

    }

}








