using System.Collections;
using System.Collections.ObjectModel;

namespace Assignment02Adv
{
    class Program
    {
        #region Q1

        static int GreatThanCounter(int[] arr, int X)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > X)
                {
                    count++;
                }
            }

            return count;
        }

        #endregion

        #region Q2

        static bool IsPalindrome(int[] arr)
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                if (arr[i] != arr[arr.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Q3

        public static void ReverseQueue<T>(Queue<T> queue)
        {
            Stack<T> stack = new Stack<T>();
            while (queue.Count > 0)
            {
                stack.Push(queue.Dequeue());
            }

            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }
        }

        #endregion

        #region Q4

        public static bool BalancedParantheses(String str)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(' || str[i] == '{' || str[i] == '[')
                {
                    stack.Push(str[i]);
                }
                else if (str[i] == ')' || str[i] == '}' || str[i] == ']')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    char top = stack.Pop();
                    if ((top == '(' && str[i] != ')') || (top == '{' && str[i] != '}') || (top == '[' && str[i] != ']'))
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        #endregion

        #region Q5

        public static T[] RemoveDuplicates<T>(T[] arr)
        {
            return new HashSet<T>(arr).ToArray();
        }

        #endregion

        #region Q6

        public static void RemoveOddNumbers(ArrayList list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if ((int)list[i] % 2 != 0)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }

        #endregion


        #region Q8

        public static void FindTarget(Stack<int> stack, int target)
        {
            Stack<int> tempStack = new Stack<int>();
            int count = 0;

            while (stack.Count > 0)
            {
                count++;
                int top = stack.Pop();
                tempStack.Push(top);
                if (top == target)
                {
                    Console.WriteLine("Target was found successfully, and the count is: " + count);
                    while (tempStack.Count > 0)
                    {
                        stack.Push(tempStack.Pop());
                    }

                    return;
                }
            }

            Console.WriteLine("Target was not found");
        }

        #endregion

        #region Q9

        public static int[] FindIntersection(int[] arr1, int[] arr2)
        {
            Dictionary<int, int> count = new Dictionary<int, int>();
            List<int> result = new List<int>();
            foreach (int item in arr1)
            {
                if (!count.ContainsKey(item))
                {
                    count.Add(item, 0);
                }
                count[item]++;
            }
            foreach (int item in arr2)
            {
                if (count.ContainsKey(item) && count[item] > 0)
                {
                    result.Add(item);
                    count[item]--;
                }
            }
            return result.ToArray();
        }

        #endregion

        #region Q10

        public static int[] ContiguosSubListTargetSum(ArrayList list, int target)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int sum = 0;
                for (int j = i; j < list.Count; j++)
                {
                    sum += (int)list[j];
                    if (sum == target)
                    {
                        int[] result = new int[j - i + 1];
                        for (int k = i; k <= j; k++)
                        {
                            result[k - i] = (int)list[k];
                        }

                        return result;
                    }
                }
            }
            return null;
        }

        #endregion

        #region Q11

        public static void ReverseQueueFirstKElements<T>(Queue<T> queue, int k)
        {
            Stack<T> stack = new Stack<T>();
            for (int i = 0; i < k; i++)
            {
                stack.Push(queue.Dequeue());
            }
            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }
            for (int i = 0; i < queue.Count - k; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
        }
        
        #endregion

        static void Main(string[] args)
        {
            #region Q1
            
            Console.WriteLine("Q1 - Enter N and Q (Space Seperated):");
            string[] input1 = Console.ReadLine().Split();
            int N1 = int.Parse(input1[0]);
            int Q1 = int.Parse(input1[1]);
            Console.WriteLine("Q1 - Enter the array elements (Space Seperated):");
            int[] arr1 = new int[N1];
            string[] inputArray1 = Console.ReadLine().Split();
            for (int i = 0; i < N1; i++)
            {
                arr1[i] = int.Parse(inputArray1[i]);
            }
            
            for (int i = 0; i < Q1; i++)
            {
                int X = int.Parse(Console.ReadLine());
                Console.WriteLine(GreatThanCounter(arr1, X));
            }
            
            #endregion

            #region Q2
            Console.WriteLine("Q2 - Enter N:");
            int N2 = int.Parse(Console.ReadLine());
            int[] arr2 = new int[N2];
            Console.WriteLine("Q2 - Enter the array elements (Space Seperated):");
            string[] inputArray2 = Console.ReadLine().Split();
            for (int i = 0; i < N2; i++)
            {
                arr2[i] = int.Parse(inputArray2[i]);
            }
            
            Console.WriteLine(IsPalindrome(arr2) ? "YES" : "NO");
            
            #endregion

            #region Q3
            
            Queue<int> queue3 = new Queue<int>();
            queue3.Enqueue(1);
            queue3.Enqueue(2);
            queue3.Enqueue(3);
            queue3.Enqueue(4);
            queue3.Enqueue(5);
            
            ReverseQueue(queue3);
            while (queue3.Count > 0)
            {
                Console.WriteLine(queue3.Dequeue());
            }
            
            #endregion

            #region Q4
            
            Console.WriteLine("Q4 - Enter the string: ");
            string str = Console.ReadLine();
            Console.WriteLine(BalancedParantheses(str) ? "Balanced" : "Unbalanced");
            
            #endregion

            #region Q5
            
            
            int[] arr5 = {1, 2, 2, 3, 4, 5, 6, 4, 7, 8, 2, 9, 10};
            arr5 = RemoveDuplicates(arr5);
            foreach (var item in arr5)
            {
                Console.WriteLine(item);
            }
            
            #endregion

            #region Q6
            
            ArrayList arrList6 = new ArrayList() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            RemoveOddNumbers(arrList6);
            foreach (object item in arrList6)
            {
                Console.WriteLine(item);
            }
            
            
            #endregion

            #region Q7
            
            Queue<object> queue7 = new Queue<object>();
            queue7.Enqueue(1);
            queue7.Enqueue("Apple");
            queue7.Enqueue(5.28);
            
            while (queue7.Count > 0)
            {
                Console.WriteLine(queue7.Dequeue());
            }
            
            #endregion

            #region Q8
            
            Stack<int> stack8 = new Stack<int>();
            
            stack8.Push(1);
            stack8.Push(2);
            stack8.Push(3);
            stack8.Push(4);
            stack8.Push(5);
            stack8.Push(6);
            stack8.Push(7);
            
            Console.WriteLine("Q8 - Enter the target number: ");
            int target = int.Parse(Console.ReadLine());
            FindTarget(stack8, target);
            
            #endregion

            #region Q9
            
            Console.WriteLine("Q9 - Enter N1 and N2 (Space Seperated):");
            string[] input9 = Console.ReadLine().Split();
            int N91 = int.Parse(input9[0]);
            int N92 = int.Parse(input9[1]);
            int[] arr91 = new int[N91];
            int[] arr92 = new int[N92];
            Console.WriteLine("Q9 - Enter the array elements of first array (Space Seperated):");
            string[] inputArray91 = Console.ReadLine().Split();
            for (int i = 0; i < N91; i++)
            {
                arr91[i] = int.Parse(inputArray91[i]);
            }
            Console.WriteLine("Q9 - Enter the array elements of second array (Space Seperated):");
            string[] inputArray92 = Console.ReadLine().Split();
            for (int i = 0; i < N92; i++)
            {
                arr92[i] = int.Parse(inputArray92[i]);
            }
            
            int[] result = FindIntersection(arr91, arr92);
            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            
            #endregion

            #region Q10

            
            ArrayList arr10 = new ArrayList();
            Console.WriteLine("Q10 - Enter the array elements of the array (Space Seperated):");
            string[] arr10Input = Console.ReadLine().Split();
            for (int i = 0; i < arr10Input.Length; i++)
            {
                arr10.Add(int.Parse(arr10Input[i]));
            }
            Console.WriteLine("Q10 - Enter the target number: ");
            int target10 = int.Parse(Console.ReadLine());
            int[] result10 = ContiguosSubListTargetSum(arr10, target10);
            if (result10 != null)
            {
                foreach (var item in result10)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No contiguous sub list found");
            }
            
            #endregion

            #region Q11
            
            Queue<int> queue11 = new Queue<int>();
            queue11.Enqueue(1);
            queue11.Enqueue(2);
            queue11.Enqueue(3);
            queue11.Enqueue(4);
            queue11.Enqueue(5);
            
            Console.WriteLine("Q11 - Enter the number of elements to reverse (k): ");
            int k = int.Parse(Console.ReadLine());
            ReverseQueueFirstKElements(queue11, k);
            while (queue11.Count > 0)
            {
                Console.Write(queue11.Dequeue() + " ");
            }
            Console.WriteLine();
            #endregion
        }
    }
}