namespace assignment4 
{
    class Program {
        public static void Main(string[] args)
        {
            // LinkedList Part
            LinkedList<int> lst = new LinkedList<int>();
            lst.Add(1);
            lst.Add(2);
            lst.Add(3);
            lst.Add(4);
            // 遍历
            LinkedList<int>.Foreach(lst, x => Console.WriteLine($"目前元素为: {x}"));
            // 求和
            var sum = 0;
            LinkedList<int>.Foreach(lst, x => sum += x);
            Console.WriteLine($"列表总和为: {sum}");
            // 求最大值
            var max = int.MinValue;
            LinkedList<int>.Foreach(lst, x => {
                if (x > max) {
                    max = x;
                }
            });
            Console.WriteLine($"列表最大值为: {max}");
            // 求最小值
            var min = int.MaxValue;
            LinkedList<int>.Foreach(lst, x => {
                if (x < min)
                {
                    min = x;
                }
            });
            Console.WriteLine($"列表最小值为: {min}");


            // Clock Part
            Clock c = new Clock(5);
            Subscriber.subcribe(c);
            c.start();
        }
    }
}