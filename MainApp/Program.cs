using Sorter;

namespace MainApp
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to Sorting Time calculator!!!");

            Console.WriteLine("Enter the number of elements in the array: ");
            int n = Convert.ToInt32(Console.ReadLine());
            
            // Bubble Sort
            BubbleSort bubbleSort = new(n);
            bubbleSort.TemplateMethod();

            // Merge Sort
            MergeSort mergeSort = new(n);
            mergeSort.TemplateMethod();

            
            Console.WriteLine("Thank you and Goodbye!!");
        }
    }
}
