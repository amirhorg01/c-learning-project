namespace tamrin_temp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter your number");
            if (!long.TryParse(Console.ReadLine(), out long num))
            {
                Console.WriteLine("invalid number");
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    num = num * num;
                }
             Console.WriteLine(num);
            }
        }
    }
}
