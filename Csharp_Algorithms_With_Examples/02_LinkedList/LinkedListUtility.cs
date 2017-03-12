using System;
using System.Collections.Generic;
using TWL_Algorithms_Samples.Arrays;

namespace TWL_Algorithms_Samples.LinkedList
{
    public class LinkedListUtility
    {
        public static LinkedListNode LinkedListWithValue(int N, int value)
        {
            LinkedListNode root = new LinkedListNodeDoubly(value, null, null);
            LinkedListNode prev = root;
            for (int i = 1; i < N; i++)
            {
                LinkedListNode next = new LinkedListNodeDoubly(value, null, null);
                prev.SetNext(next);
                prev = next;
            }
            return root;
        }

        public static LinkedListNode RandomLinkedList(int N, int min, int max)
        {
            LinkedListNode root = new LinkedListNodeDoubly(AssortedMethods.RandomIntInRange(min, max), null, null);
            LinkedListNode prev = root;
            for (int i = 1; i < N; i++)
            {
                int data = AssortedMethods.RandomIntInRange(min, max);
                LinkedListNode next = new LinkedListNodeDoubly(data, null, null);
                prev.SetNext(next);
                prev = next;
            }
            return root;
        }

        public void DeleteNode_Run()
        {
            var head = AssortedMethods.RandomLinkedListSingly(10, 0, 10);
            head.PrintForward();
            var deleted = head.DeleteNode(head.Next.Next.Next.Next); // delete node 4
            Console.WriteLine("deleted? {0}", deleted);
            head.PrintForward();
        }

        public void Run()
        {
            //new Q2_01_Remove_Dups().Run();
            //DeleteNode_Run();
            //new Q2_02_Return_Kth_To_Last().Run();
        }

        public class Q2_02_Return_Kth_To_Last : IQuestion
        {
            internal class Result
            {
                public LinkedListNode Node { get; set; }
                public int Count { get; set; }

                public Result(LinkedListNode node, int count)
                {
                    Node = node;
                    Count = count;
                }
            }

            private int NthToLastR1(LinkedListNode head, int n)
            {
                if (n == 0 || head == null)
                {
                    return 0;
                }

                var k = NthToLastR1(head.Next, n) + 1;

                if (k == n)
                {
                    Console.WriteLine(n + "th to last node is " + head.Data);
                }

                return k;
            }

            private LinkedListNode NthToLastR2(LinkedListNode head, int n, ref int i)
            {
                if (head == null)
                {
                    return null;
                }

                var node = NthToLastR2(head.Next, n, ref i);
                i = i + 1;

                if (i == n)
                {
                    return head;
                }

                return node;
            }

            private Result NthToLastR3Helper(LinkedListNode head, int k)
            {
                if (head == null)
                {
                    return new Result(null, 0);
                }

                var result = NthToLastR3Helper(head.Next, k);

                if (result.Node == null)
                {
                    result.Count++;

                    if (result.Count == k)
                    {
                        result.Node = head;
                    }
                }

                return result;
            }

            private LinkedListNode NthToLastR3(LinkedListNode head, int k)
            {
                var result = NthToLastR3Helper(head, k);

                if (result != null)
                {
                    return result.Node;
                }

                return null;
            }

            private LinkedListNode NthToLast(LinkedListNode head, int n)
            {
                var p1 = head;
                var p2 = head;

                if (n <= 0) return null;

                // Move p2 n nodes into the list.  Keep n1 in the same position.
                for (var i = 0; i < n - 1; i++)
                {
                    if (p2 == null)
                    {
                        return null; // Error: list is too small.
                    }

                    p2 = p2.Next;
                }
                if (p2 == null)
                { // Another error check.
                    return null;
                }

                // Move them at the same pace.  When p2 hits the end,
                // p1 will be at the right element.
                while (p2.Next != null)
                {
                    p1 = p1.Next;
                    p2 = p2.Next;
                }

                return p1;
            }

            public void Run()
            {
                int[] nthCounts = new int[] { 1, 2, 9, 10, 11 };
                nthCounts.Print("Get Positions:");
                var head = AssortedMethods.RandomLinkedListSingly(10, 0, 10);
                head.PrintForward("\nLink List:");
                foreach (int nth in nthCounts)
                {
                    var node = NthToLastR3(head, nth);
                    NthToLastR1(head, nth);

                    if (node != null)
                    {
                        Console.WriteLine(nth + "th to last node is " + node.Data);
                    }
                    else
                    {
                        Console.WriteLine($"Null.  n='{nth}' is out of bounds.");
                    }
                }
            }
        }

        public class Remove_Dups : IQuestion
        {
            private int _tapB = 0;
            private int _tapC = 0;

            public void Run()
            {
                Console.WriteLine($"{this.GetType().FullName}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
                var first = new LinkedListNodeDoubly(0, null, null);
                var originalList = first;
                var second = first;

                for (var i = 1; i < 8; i++)
                {
                    second = new LinkedListNodeDoubly(i % 2, null, null);
                    first.SetNext(second);
                    second.SetPrevious(first);
                    first = second;
                }
                originalList.PrintForward("originalList");

                var list1 = originalList.CloneLinkedListNodeDoubly();
                var list2 = originalList.Clone();
                var list3 = originalList.Clone();

                //DeleteDups_UsingDictionary(list1);
                //DeleteDupsB(list2);
                DeleteDupsC2(list3);

                //Console.WriteLine(_tapB);
                //Console.WriteLine(_tapC);
            }

            /// <summary>
            /// Delete dups using additional memory (e.g. Hash table or Dictionary)
            /// </summary>
            /// <param name="head"></param>
            private void DeleteDups_UsingDictionary(LinkedListNodeDoubly head)
            {
                head.PrintForward("List-Before\n");
                Console.WriteLine($"{this.GetType().FullName}.{System.Reflection.MethodBase.GetCurrentMethod().Name}\n");
                var table = new Dictionary<int, bool>();
                LinkedListNodeDoubly previous = null;

                while (head != null)
                {
                    if (table.ContainsKey((int)head.Data))
                    {
                        if (previous != null)
                        {
                            previous.Next = head.Next;
                        }
                    }
                    else
                    {
                        table.Add((int)head.Data, true);
                        previous = head;
                    }

                    head = (LinkedListNodeDoubly)head.Next;
                }
                head.PrintForward("List-After\n");
                Console.WriteLine("-------------------------------------------------------");
            }

            private void DeleteDupsB(LinkedListNode head)
            {
                head.PrintForward("List-Before\n");
                Console.WriteLine($"{this.GetType().FullName}.{System.Reflection.MethodBase.GetCurrentMethod().Name}\n");
                if (head == null) return;

                var current = head;

                while (current != null)
                {
                    /* Remove all future nodes that have the same value */
                    var runner = current;

                    while (runner.Next != null)
                    {
                        Tap(0);
                        Console.WriteLine($"current.Data '{current.Data}' runner.Next.Data: '{runner.Next.Data}'");

                        if (runner.Next.Data.Equals(current.Data))
                        {
                            Console.WriteLine($"Removing runner '{runner.Next.Data}'");
                            runner.Next = runner.Next.Next;
                            head.PrintForward();
                        }
                        else
                        {
                            runner = runner.Next;
                        }
                    }
                    current = current.Next;
                }
                head.PrintForward("List-After\n");
                Console.WriteLine("-------------------------------------------------------");
            }

            private void DeleteDupsC(LinkedListNode head)
            {
                head.PrintForward("List-Before\n");
                Console.WriteLine($"{this.GetType().FullName}.{System.Reflection.MethodBase.GetCurrentMethod().Name}\n");

                if (head == null) return;

                var previous = head;
                //Next element
                var current = previous.Next;

                while (current != null)
                {
                    // Look backwards for dups, and remove any that you see.
                    var runner = head;

                    head.PrintForward();
                    current.PrintForward();
                    runner.PrintForward();

                    while (runner != current && current != null)
                    {
                        runner.PrintForward();

                        Tap(1);
                        Console.WriteLine($"@@current.Data '{current.Data}' runner.Data: '{runner.Data}'");
                        if (runner.Data.Equals(current.Data))
                        {
                            head.PrintForward();
                            current.PrintForward();
                            previous.PrintForward();
                            //Console.WriteLine($"@@Removing current '{current.Data}'");
                            //urrent = current.Next;

                            var temp = current.Next;
                            previous.Next = temp;
                            current = temp;
                            //Console.WriteLine($"***Inner current {current.PrintForward()}");
                            //previous = current;
                            //current = temp;
                            /* We know we can't have more than one dup preceding
                             * our element since it would have been removed
                             * earlier. */
                            //break;
                            //Console.WriteLine($"{head.PrintForward()}");
                        }

                        runner = runner.Next;
                        runner.PrintForward();
                    }

                    /* If runner == current, then we didn�t find any duplicate
                     * elements in the previous for loop.  We then need to
                     * increment current.
                     * If runner != current, then we must have hit the �break�
                     * condition, in which case we found a dup and current has
                     * already been incremented.*/
                    if (runner == current)
                    {
                        head.PrintForward();
                        previous.PrintForward();
                        current.PrintForward();
                        runner.PrintForward();
                        previous = current;
                        current = current.Next;
                        previous.PrintForward();
                        //Console.WriteLine($"@@@current {current.PrintForward()}");
                    }
                }
                head.PrintForward("List-After\n");
                Console.WriteLine("-------------------------------------------------------");
            }

            private void DeleteDupsC2(LinkedListNode head)
            {
                head.PrintForward("List-Before\n");
                Console.WriteLine($"{this.GetType().FullName}.{System.Reflection.MethodBase.GetCurrentMethod().Name}\n");

                if (head == null) return;

                var previous = head;
                var current = previous.Next;

                while (current != null)
                {
                    // Look backwards for dups, and remove any that you see.
                    var runner = head;

                    while (runner != current)
                    {
                        Tap(1);

                        if (runner.Data == current.Data)
                        {
                            var temp = current.Next;
                            previous.Next = temp;
                            current = temp;
                            /* We know we can't have more than one dup preceding
                             * our element since it would have been removed
                             * earlier. */
                            break;
                        }
                        runner = runner.Next;
                    }

                    /* If runner == current, then we didn�t find any duplicate
                     * elements in the previous for loop.  We then need to
                     * increment current.
                     * If runner != current, then we must have hit the �break�
                     * condition, in which case we found a dup and current has
                     * already been incremented.*/
                    if (runner == current)
                    {
                        previous = current;
                        current = current.Next;
                    }
                }
                head.PrintForward("List-After\n");
                Console.WriteLine("-------------------------------------------------------");
            }

            private void Tap(int i)
            {
                if (i == 0)
                {
                    _tapB++;
                }
                else
                {
                    _tapC++;
                }
            }
        }
    }
}