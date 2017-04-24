using System;
using System.Collections.Generic;
using TWL_Algorithms_Samples.Arrays;

namespace TWL_Algorithms_Samples.LinkedList
{
    public class LinkedListUtility
    {
        public static MyLinkedListNode CreateLinkedListFromArray(int[] vals)
        {
            MyLinkedListNode head = new MyLinkedListNodeDoubly(vals[0], null, null);
            MyLinkedListNodeDoubly current = (MyLinkedListNodeDoubly)head;
            for (int i = 1; i < vals.Length; i++)
            {
                current = new MyLinkedListNodeDoubly(vals[i], null, current);
            }
            return head;
        }

        /// <summary>
        /// Use two pointers, walker and runner.
        /// walker moves step by step.runner moves two steps at time.
        /// if the Linked List has a cycle walker and runner will meet at some point.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool CycleExists(MyLinkedListNode head)
        {
            if (head == null) return false;
            MyLinkedListNode walker = head;
            MyLinkedListNode runner = head;
            while (runner.Next != null && runner.Next.Next != null)
            {
                walker = walker.Next;
                runner = runner.Next.Next;
                if (walker == runner) return true;
            }
            return false;
        }

        /// <summary>
        /// Use two pointers, walker and runner.
        /// walker moves step by step.runner moves two steps at time.
        /// if the Linked List has a cycle walker and runner will meet at some point.
        /// </summary>
        /// <param name="head"></param>
        /// <returns>runner (not slower)</returns>
        public static MyLinkedListNode CycleExistsReturnRunner(MyLinkedListNode head)
        {
            if (head == null) return null;
            MyLinkedListNode walker = head;
            MyLinkedListNode runner = head;
            while (runner.Next != null && runner.Next.Next != null)
            {
                walker = walker.Next;
                runner = runner.Next.Next;
                if (walker == runner)
                {
                    Console.WriteLine($"CycleExists: True runner.Data:{runner.Data}");
                    return runner;
                };
            }
            return null;
        }

        /// <summary>
        /// Use two pointers, walker and runner.
        /// walker moves step by step.runner moves two steps at time.
        /// if the Linked List has a cycle walker and runner will meet at some point.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static MyLinkedListNode CycleFindBeginning(MyLinkedListNode head)
        {
            var runner = CycleExistsReturnRunner(head);
            if (runner != null)
            {
                /* Move slow to Head. Keep fast at Meeting Point. Each are k steps
                /* from the Loop Start. If they move at the same pace, they must
                 * meet at Loop Start. */
                var walker = head;

                while (walker != runner)
                {
                    Console.WriteLine($"*slow.Data{walker.Data}");
                    Console.WriteLine($"*fast.Data{runner.Data}");
                    walker = walker.Next;
                    runner = runner.Next;
                }
            }
            // Both now point to the start of the loop.
            return runner;
        }

        public static void DeleteNode_Run()
        {
            var head = GetLinkedListSingly_Random(10, 0, 10);
            head.PrintForward("Input:");
            var deleted = head.DeleteNode(head.Next.Next.Next.Next); // delete node 5
            Console.WriteLine("deleted? {0}", deleted);
            head.PrintForward("Output:");
        }

        public static MyLinkedListNode GetLinkedListDoubly_Random(int N, int min, int max)
        {
            MyLinkedListNode root = new MyLinkedListNodeDoubly(AssortedMethods.RandomIntInRange(min, max), null, null);
            MyLinkedListNode prev = root;
            for (int i = 1; i < N; i++)
            {
                int data = AssortedMethods.RandomIntInRange(min, max);
                MyLinkedListNode next = new MyLinkedListNodeDoubly(data, null, null);
                prev.SetNext(next);
                prev = next;
            }
            return root;
        }

        public static MyLinkedListNode GetLinkedListSingly_Random(int N, int min, int max)
        {
            MyLinkedListNode root = new MyLinkedListNodeSingly(AssortedMethods.RandomIntInRange(min, max), null);
            MyLinkedListNode prev = root;
            for (int i = 1; i < N; i++)
            {
                int data = AssortedMethods.RandomIntInRange(min, max);
                MyLinkedListNode next = new MyLinkedListNodeSingly(data, null);
                prev.SetNext(next);
                prev = next;
            }
            return root;
        }

        public static MyLinkedListNode GetLinkedListSingly_Serial(int min, int max)
        {
            MyLinkedListNode root = new MyLinkedListNodeSingly(min, null);
            MyLinkedListNode prev = root;
            for (int i = min + 1; i <= max; i++)
            {
                MyLinkedListNode next = new MyLinkedListNodeSingly(i, null);
                prev.SetNext(next);
                prev = next;
            }
            return root;
        }

        public static MyLinkedListNode LinkedListWithValue(int N, int value)
        {
            MyLinkedListNode root = new MyLinkedListNodeDoubly(value, null, null);
            MyLinkedListNode prev = root;
            for (int i = 1; i < N; i++)
            {
                MyLinkedListNode next = new MyLinkedListNodeDoubly(value, null, null);
                prev.SetNext(next);
                prev = next;
            }
            return root;
        }

        public static MyLinkedListNode MergeTwoLists_Int(MyLinkedListNode l1, MyLinkedListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            if ((int)l1.Data < (int)l2.Data)
            {
                l1.Next = MergeTwoLists_Int(l1.Next, l2);
                return l1;
            }
            else
            {
                l2.Next = MergeTwoLists_Int(l2.Next, l1);
                return l2;
            }
        }

        public MyLinkedListNode Cycle_Create()
        {
            const int listLength = 10;
            const int k = 3;

            // Create linked list
            var nodes = new MyLinkedListNode[listLength];

            for (var i = 1; i <= listLength; i++)
            {
                nodes[i - 1] = new MyLinkedListNodeDoubly(i, null, i - 1 > 0 ? (MyLinkedListNodeDoubly)nodes[i - 2] : null);
                Console.Write("{0} -> ", nodes[i - 1].Data);
            }
            // Create loop;
            Console.WriteLine($"\n Create loop: nodes[listLength - 1].Next = nodes[listLength - k - 1]");
            nodes[listLength - k - 1].PrintForward("nodes[listLength - k - 1]");
            nodes[listLength - 1].PrintForward("nodes[listLength - 1]");

            nodes[listLength - 1].Next = nodes[listLength - k - 1];
            Console.WriteLine("\n{0} -> {1}", nodes[listLength - 1].Data, nodes[listLength - k - 1].Data);
            Console.WriteLine("Nodes:\n");

            return nodes[0];
        }

        public void Cycle_Run()
        {
            var cycle = Cycle_Create();
            var loop = CycleExists(cycle);
            Console.WriteLine($"Linked List Has Cycle:{loop}");

            var loop2 = CycleFindBeginning(cycle);
            if (loop2 == null)
            {
                Console.WriteLine("No Cycle.");
            }
            else
            {
                Console.WriteLine($"Cycle exists!!! loop starts at- '{loop2.Data}'");
            }
        }

        public void DeleteDups_Run()
        {
            Console.WriteLine($"{this.GetType().FullName}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            var first = new MyLinkedListNodeDoubly(0, null, null);
            var originalList = first;
            var second = first;

            for (var i = 1; i < 8; i++)
            {
                second = new MyLinkedListNodeDoubly(i % 2, null, null);
                first.SetNext(second);
                second.SetPrevious(first);
                first = second;
            }
            originalList.PrintForward("originalList");

            var list1 = originalList.CloneLinkedListNodeDoubly();
            var list2 = originalList.Clone();
            var list3 = originalList.Clone();
            var list4 = originalList.Clone();

            DeleteDups_UsingDictionary(list1);
            DeleteDups_UsingTwoPointer(list2);
            //DeleteDupsC_InProgress(list3);
            //DeleteDupsC2_InProgress(list4);
        }

        /// <summary>
        /// Delete dups using additional memory (e.g. Hash table or Dictionary)
        /// </summary>
        /// <param name="head"></param>
        public void DeleteDups_UsingDictionary(MyLinkedListNodeDoubly head)
        {
            Console.WriteLine($"{this.GetType().FullName}.{System.Reflection.MethodBase.GetCurrentMethod().Name}\n");
            head.PrintForward("List-Before:");
            var dictionaryTable = new Dictionary<int, bool>();
            MyLinkedListNodeDoubly previous = null;

            while (head != null)
            {
                if (dictionaryTable.ContainsKey((int)head.Data))
                {
                    if (previous != null)
                    {
                        previous.Next = head.Next;
                    }
                }
                else
                {
                    dictionaryTable.Add((int)head.Data, true);
                    previous = head;
                }

                head = (MyLinkedListNodeDoubly)head.Next;
            }

            Console.WriteLine($"dictionaryTable =[{string.Join(", ", dictionaryTable.Keys)}]");

            if (head != null)
            {
                head.PrintForward("List-After\n");
            }

            Console.WriteLine("-------------------------------------------------------");
        }

        public void DeleteDups_UsingTwoPointer(MyLinkedListNode head)
        {
            Console.WriteLine($"{this.GetType().FullName}.{System.Reflection.MethodBase.GetCurrentMethod().Name}\n");
            head.PrintForward("List-Before:");

            int tapB = 0;
            if (head == null) return;

            var current = head;

            while (current != null)
            {
                /* Remove all future nodes that have the same value */
                var runner = current;

                while (runner.Next != null)
                {
                    tapB++;
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

        public void DeleteDupsC_InProgress(MyLinkedListNode head)
        {
            int tabC = 0;
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

                    tabC++;
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

        public void DeleteDupsC2_InProgress(MyLinkedListNode head)
        {
            int tapC = 0;
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
                    tapC++;

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

        public void MeargeList_Run()
        {
            int[] firstVals = { 1, 3, 6, 8 };
            MyLinkedListNode firstList = CreateLinkedListFromArray(firstVals);
            firstList.PrintForward("firstList");
            int[] SecondVals = { 0, 2, 4, 5, 7, 9, 10 };
            MyLinkedListNode secondList = CreateLinkedListFromArray(SecondVals);
            secondList.PrintForward("secondList");
            var meargedList = MergeTwoLists_Int(firstList, secondList);
            meargedList.PrintForward("meargedList");
        }

        public void ReverseLinkedList_Run()
        {
            var head = GetLinkedListSingly_Serial(0, 5);
            //head.PrintForward("Input for ReverseLinkedListIterative Test:");
            //head = ReverseLinkedListIterative(head);
            //head.PrintForward("Output for ReverseLinkedListIterative:");
            head.PrintForward("Input for ReverseLinkedListRecursive Test:");
            head = ReverseLinkedListRecursive(head);
            head.PrintForward("Output for ReverseLinkedListRecursive:");
        }

        /// <summary>
        /// Changing pointer in reverse direction
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public MyLinkedListNode ReverseLinkedListIterative(MyLinkedListNode head)
        {
            /* iterative solution */
            MyLinkedListNode newHead = null;
            while (head != null)
            {
                //head.PrintForward("head");
                //Updating pointer
                MyLinkedListNode nextNode = head.Next;
                head.Next = newHead;

                //Link to New node
                //Moving both heads
                newHead = head;
                head = nextNode;
                //newHead.PrintForward("newHead");
            }
            return newHead;
        }

        public MyLinkedListNode ReverseLinkedListRecursive(MyLinkedListNode head)
        {
            /* recursive solution */
            return ReverseLinkedListRecursiveInt(head, null);
        }

        public MyLinkedListNode ReverseLinkedListRecursiveInt(MyLinkedListNode head, MyLinkedListNode newHead)
        {
            if (head == null)
                return newHead;
            head.PrintForward("*head");
            //if (newHead != null)
            //    newHead.PrintForward("*newHead");
            MyLinkedListNode nextNode = head.Next;
            head.Next = newHead;
            return ReverseLinkedListRecursiveInt(nextNode, head);
        }

        public void Run()
        {
            //new Remove_Dups().Run();
            //DeleteNode_Run();
            //ReverseLinkedList_Run();
            //new Return_Kth_To_Last().Run();
            //new Sum_Lists_Numbers().Run();
            //new Q2_04_Partition().Run();
            //new CheckIfPalindrome().Run();
            //new Q2_07_Intersection().Run();
            //Cycle_Run();
            //MeargeList_Run();
            //SwapPairsAlertnatly_Run();
        }

        public MyLinkedListNode SwapPairsAlertnatly(MyLinkedListNode head)
        {
            if ((head == null) || (head.Next == null))
                return head;
            MyLinkedListNode n = head.Next;
            head.Next = SwapPairsAlertnatly(head.Next.Next);
            n.Next = head;
            return n;
        }

        public void SwapPairsAlertnatly_Run()
        {
            MyLinkedListNode testLinkedList = GetLinkedListSingly_Serial(0, 10);
            testLinkedList.PrintForward("testLinkedList");
            var swapedList = SwapPairsAlertnatly(testLinkedList);
            swapedList.PrintForward("swapedList");
        }

        public class CheckIfPalindrome : IQuestion
        {
            /// <summary>
            /// ****NW:Compare first vs last
            /// </summary>
            /// <param name="head"></param>
            /// <param name="length"></param>
            /// <returns></returns>
            public Result IsPalindrome_UsingRecursion(MyLinkedListNode head, int length)
            {
                if (head == null || length == 0)
                {
                    Console.WriteLine($"length == 0 'true'");
                    return new Result(null, true);
                }

                if (length == 1)
                {
                    Console.WriteLine($"length == 1 'true'");
                    return new Result(head.Next, true);
                }

                if (length == 2)
                {
                    Console.WriteLine($"length == 2 head.Data{head.Data} == head.Next.Data {head.Next.Data}");
                    return new Result(head.Next.Next, head.Data == head.Next.Data);
                }

                //Compare first vs last recurresively
                var res = IsPalindrome_UsingRecursion(head.Next, length - 2);
                //Console.WriteLine($"*res.result:{res.result}");
                if (!res.result || res.Node == null)
                {
                    Console.WriteLine($"*res:{res}");
                    return res; // Only "result" member is actually used in the call stack.
                }

                res.result = head.Data == res.Node.Data;
                res.Node = res.Node.Next;
                Console.WriteLine($"$res.Node.Data:{res.Node.Data}");
                return res;
            }

            public bool IsPalindrome_UsingRecursionMain(MyLinkedListNode head)
            {
                var size = 0;
                var node = head;

                while (node != null)
                {
                    size++;
                    node = node.Next;
                }

                var palindrome = IsPalindrome_UsingRecursion(head, size);

                return palindrome.result;
            }

            public bool IsPalindrome_UsingStack(MyLinkedListNode head)
            {
                var fast = head;
                var slow = head;

                var stack = new Stack<int>();

                while (fast != null && fast.Next != null)
                {
                    stack.Push((int)slow.Data);
                    slow = slow.Next;
                    //traverse with two elements so that stack will have half values
                    fast = fast.Next.Next;
                }

                /* Has odd number of elements, so skip the middle */
                if (fast != null)
                {
                    slow = slow.Next;
                }

                //Traverse other half stack and compare elements
                while (slow != null)
                {
                    var top = stack.Pop();
                    Console.WriteLine(slow.Data + " " + top);

                    if (top != (int)slow.Data)
                    {
                        return false;
                    }
                    slow = slow.Next;
                }

                return true;
            }

            public void Run()
            {
                const int length = 10;
                var nodes = new MyLinkedListNodeDoubly[length];

                for (var i = 0; i < length; i++)
                {
                    nodes[i] = new MyLinkedListNodeDoubly(i >= length / 2 ? length - i - 1 : i, null, null);
                }

                for (var i = 0; i < length; i++)
                {
                    if (i < length - 1)
                    {
                        nodes[i].SetNext(nodes[i + 1]);
                    }

                    if (i > 0)
                    {
                        nodes[i].SetPrevious(nodes[i - 1]);
                    }
                }
                // nodes[length - 2].data = 9; // Uncomment to ruin palindrome

                var head = nodes[0];
                head.PrintForward("Original:");
                Console.WriteLine("\nIsPalindrome: " + IsPalindrome_UsingRecursionMain(head));
                Console.WriteLine("\nIsPalindrome2: " + IsPalindrome_UsingStack(head));
            }

            public class Result
            {
                public MyLinkedListNode Node;
                public bool result;

                public Result(MyLinkedListNode node, bool res)
                {
                    Node = node;
                    result = res;
                }
            }
        }

        public class Q2_04_Partition : IQuestion
        {
            public MyLinkedListNode Partition(MyLinkedListNode node, int pivot)
            {
                MyLinkedListNode beforeStart = null;
                MyLinkedListNode beforeEnd = null;
                MyLinkedListNode afterStart = null;
                MyLinkedListNode afterEnd = null;

                /* Partition list */
                while (node != null)
                {
                    var next = node.Next;
                    node.Next = null;

                    if ((int)node.Data < pivot)
                    {
                        if (beforeStart == null)
                        {
                            beforeStart = node;
                            beforeEnd = beforeStart;
                        }
                        else
                        {
                            beforeEnd.Next = node;
                            beforeEnd = node;
                        }
                    }
                    else
                    {
                        if (afterStart == null)
                        {
                            afterStart = node;
                            afterEnd = afterStart;
                        }
                        else
                        {
                            afterEnd.Next = node;
                            afterEnd = node;
                        }
                    }
                    node = next;
                }

                /* Merge before list and after list */
                if (beforeStart == null)
                {
                    return afterStart;
                }

                beforeEnd.Next = afterStart;

                return beforeStart;
            }

            public MyLinkedListNode Partition2(MyLinkedListNode node, int pivot)
            {
                MyLinkedListNode beforeStart = null;
                MyLinkedListNode afterStart = null;

                /* Partition list */
                while (node != null)
                {
                    var next = node.Next;

                    if ((int)node.Data < pivot)
                    {
                        /* Insert node into start of before list */
                        node.Next = beforeStart;
                        beforeStart = node;
                    }
                    else
                    {
                        /* Insert node into front of after list */
                        node.Next = afterStart;
                        afterStart = node;
                    }
                    node = next;
                }

                /* Merge before list and after list */
                if (beforeStart == null)
                {
                    return afterStart;
                }

                var head = beforeStart;

                while (beforeStart.Next != null)
                {
                    beforeStart = beforeStart.Next;
                }

                beforeStart.Next = afterStart;

                return head;
            }

            public MyLinkedListNode Partition3(MyLinkedListNode listHead, int pivot)
            {
                var leftList = new MyLinkedListNodeDoubly(); // empty temp node to not have an IF inside the loop
                var rightList = new MyLinkedListNodeDoubly(pivot, null, null);

                var leftListHead = leftList; // Used at the end to remove the empty node.
                var rightListHead = rightList; // Used at the end to merge lists.

                var currentNode = listHead;

                while (currentNode != null)
                {
                    if ((int)currentNode.Data < pivot)
                    {
                        leftList = new MyLinkedListNodeDoubly(currentNode.Data, null, leftList);
                    }
                    else if ((int)currentNode.Data > pivot)
                    {
                        rightList = new MyLinkedListNodeDoubly(currentNode.Data, null, rightList);
                    }

                    currentNode = currentNode.Next;
                }

                leftList.Next = rightListHead;

                var finalList = leftListHead.Next;
                leftListHead.Next = null; // remove the temp node, GC will release the mem

                return finalList;
            }

            public MyLinkedListNode Partition4(MyLinkedListNode listHead, int pivot)
            {
                MyLinkedListNode leftSubList = null;
                MyLinkedListNode rightSubList = null;
                MyLinkedListNode rightSubListHead = null;
                MyLinkedListNode pivotNode = null;

                var currentNode = listHead;

                while (currentNode != null)
                {
                    var nextNode = currentNode.Next;
                    currentNode.Next = null;

                    if ((int)currentNode.Data < pivot)
                    {
                        leftSubList = leftSubList == null
                            ? currentNode
                            : leftSubList = leftSubList.Next = currentNode;
                    }
                    else if ((int)currentNode.Data > pivot)
                    {
                        rightSubList = rightSubList == null
                            ? rightSubListHead = currentNode
                            : rightSubList = rightSubList.Next = currentNode;
                    }
                    else
                    {
                        pivotNode = currentNode;
                    }

                    currentNode = nextNode;
                }

                pivotNode.Next = rightSubListHead;
                rightSubListHead = pivotNode;
                leftSubList.Next = rightSubListHead;

                return listHead;
            }

            public void Run()
            {
                /* Create linked list */
                int[] vals = { 1, 3, 7, 5, 2, 9, 4 };
                var head = new MyLinkedListNodeDoubly(vals[0], null, null);
                var current = head;

                for (var i = 1; i < vals.Length; i++)
                {
                    current = new MyLinkedListNodeDoubly(vals[i], null, current);
                }
                head.PrintForward("Original:");

                var head2 = head.Clone();
                var head3 = head.Clone();
                var head4 = head.Clone();

                /* Partition */
                var h = Partition(head, 5);
                var h2 = Partition2(head2, 5);
                var h3 = Partition3(head3, 5);
                var h4 = Partition4(head4, 5);

                /* Print Result */
                h.PrintForward("Partition:");
                h2.PrintForward("Partition2");
                h3.PrintForward("Partition3");
                h4.PrintForward("Partition4");
            }
        }

        public class Q2_07_Intersection : IQuestion
        {
            public static MyLinkedListNode findIntersection(MyLinkedListNode list1, MyLinkedListNode list2)
            {
                if (list1 == null || list2 == null) return null;

                /* Get tail and sizes. */
                Result result1 = getTailAndSize(list1);
                Result result2 = getTailAndSize(list2);

                /* If different tail nodes, then there's no intersection. */
                if (result1.tail != result2.tail)
                {
                    return null;
                }

                /* Set pointers to the start of each linked list. */
                MyLinkedListNode shorter = result1.size < result2.size ? list1 : list2;
                MyLinkedListNode longer = result1.size < result2.size ? list2 : list1;

                /* Advance the pointer for the longer linked list by the difference in lengths. */
                longer = getKthNode(longer, Math.Abs(result1.size - result2.size));

                /* Move both pointers until you have a collision. */
                while (shorter != longer)
                {
                    shorter = shorter.Next;
                    longer = longer.Next;
                }

                /* Return either one. */
                return longer;
            }

            public static MyLinkedListNode getKthNode(MyLinkedListNode head, int k)
            {
                MyLinkedListNode current = head;
                while (k > 0 && current != null)
                {
                    current = current.Next;
                    k--;
                }
                return current;
            }

            public static Result getTailAndSize(MyLinkedListNode list)
            {
                if (list == null) return null;

                int size = 1;
                MyLinkedListNode current = list;
                while (current.Next != null)
                {
                    size++;
                    current = current.Next;
                }
                return new Result(current, size);
            }

            public void Run()
            {
                /* Create linked list */
                int[] vals = { -1, -2, 0, 1, 2, 3, 4, 5, 6, 7, 8 };
                MyLinkedListNode list1 = CreateLinkedListFromArray(vals);
                list1.PrintForward("list1");
                int[] vals2 = { 12, 14, 15 };
                MyLinkedListNode list2 = CreateLinkedListFromArray(vals2);
                list2.PrintForward("list2");
                //adding some common elements
                list2.Next.Next = list1.Next.Next.Next.Next;
                list2.PrintForward("list2");
                MyLinkedListNode intersection = findIntersection(list1, list2);
                intersection.PrintForward("intersection");
            }

            public class Result
            {
                public int size;
                public MyLinkedListNode tail;

                public Result(MyLinkedListNode tail, int size)
                {
                    this.tail = tail;
                    this.size = size;
                }
            }
        }

        public class Return_Kth_To_Last : IQuestion
        {
            public MyLinkedListNode NthToLast(MyLinkedListNode head, int n)
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

            public int NthToLast_1_Recurssive_InternalCounter(MyLinkedListNode head, int n)
            {
                if (n == 0 || head == null)
                {
                    return 0;
                }
                Console.WriteLine($"head.Data='{head.Data}' n='{n}'");
                var k = NthToLast_1_Recurssive_InternalCounter(head.Next, n) + 1;
                if (k == n)
                {
                    Console.WriteLine($"{n}th to last node is { head.Data} ");
                }
                Console.WriteLine($"*** n='{n}' k='{k}'");
                return k;
            }

            public MyLinkedListNode NthToLast_2_Recurssive_ExternalCounter(MyLinkedListNode head, int n, ref int i)
            {
                if (head == null)
                {
                    return null;
                }
                Console.WriteLine($"head.Data='{head.Data}' n='{n}' i='{i}'");
                var node = NthToLast_2_Recurssive_ExternalCounter(head.Next, n, ref i);
                i = i + 1;
                Console.WriteLine($"***head.Data='{head.Data}' n='{n}' i='{i}' node.Data='{node.NodeValue()}'");

                if (i == n)
                {
                    Console.WriteLine($"{n}th element is '{head.Data}'");
                    return head;
                }
                return node;
            }

            public MyLinkedListNode NthToLast_3_Recurssive_ExternalCounterAndNode(MyLinkedListNode head, int k)
            {
                //head.PrintForward("@");
                var result = NthToLast_3_Recurssive_ExternalCounterAndNode_Helper(head, k);

                if (result != null)
                {
                    return result.Node;
                }

                return null;
            }

            public Result NthToLast_3_Recurssive_ExternalCounterAndNode_Helper(MyLinkedListNode head, int k)
            {
                if (head == null)
                {
                    return new Result(null, 0);
                }
                head.PrintForward($"*** k='{k}'  result.Node='{head.NodeValue()}'");
                var result = NthToLast_3_Recurssive_ExternalCounterAndNode_Helper(head.Next, k);
                head.PrintForward($"*** k='{k}' result.Count='{result.Count}' result.Node='{result.Node.NodeValue()}'");

                if (result.Node == null)
                {
                    result.Count++;

                    if (result.Count == k)
                    {
                        Console.WriteLine($"{k}th element is '{head.Data}'");
                        result.Node = head;
                    }
                }

                return result;
            }

            public MyLinkedListNode NthToLast_4_Iterative_TwoPointers(MyLinkedListNode head, int n)
            {
                if (head == null)
                {
                    return null;
                }
                MyLinkedListNode p2KthElementPointer = head;
                MyLinkedListNode p1RunnerPointer = head;
                //setting p2RunnerPointer to kth postion from begining
                for (int i = 0; i < n; i++)
                {
                    if (p1RunnerPointer == null)
                    {
                        Console.WriteLine("Out of bound");
                        return null;
                    }
                    p1RunnerPointer = p1RunnerPointer.Next;
                }
                // traveser both pointer till end of p2RunnerPointer
                while (p1RunnerPointer != null)
                {
                    p1RunnerPointer = p1RunnerPointer.Next;
                    p2KthElementPointer = p2KthElementPointer.Next;
                }
                return p2KthElementPointer;
            }

            public void Run()
            {
                int[] nthCounts = new int[] { 1, 3 }; //, 2, 9, 10, 11,12
                nthCounts.Print("Get Positions:");
                var head = GetLinkedListSingly_Serial(0, 10);
                head.PrintForward("\nLink List:");

                foreach (int nth in nthCounts)
                {
                    int i = 0;
                    Console.WriteLine($"NthToLast_1_Recurssive_InternalCounter: {NthToLast_1_Recurssive_InternalCounter(head, nth)}");
                    AssortedMethods.PrintLine('-');
                    Console.WriteLine($"NthToLast_2_Recurssive_ExternalCounter: {NthToLast_2_Recurssive_ExternalCounter(head, nth, ref i).NodeValue()}");
                    AssortedMethods.PrintLine('-');
                    Console.WriteLine($"NthToLast_3_Recurssive_ExternalCounterAndNode{NthToLast_3_Recurssive_ExternalCounterAndNode(head, nth).NodeValue()}");
                    AssortedMethods.PrintLine('-');
                    Console.WriteLine($"NthToLast_4_Iterative_TwoPointers{NthToLast_4_Iterative_TwoPointers(head, nth).NodeValue()}");
                    AssortedMethods.PrintLine('=');
                }
            }

            public class Result
            {
                public Result(MyLinkedListNode node, int count)
                {
                    Node = node;
                    Count = count;
                }

                public int Count { get; set; }
                public MyLinkedListNode Node { get; set; }
            }

            //public LinkedListNode NthToLastR1(LinkedListNode head, int n)
            //{
            //    if (head != null)
            //    {
            //        head.PrintForward($"***n='{n}'");
            //    }

            //    if (n == 0 || head == null)
            //    {
            //        return head;
            //    }

            //    var k = NthToLastR1(head.Next, n) + 1;
        }

        public class Sum_Lists_Numbers : IQuestion
        {
            #region First Part

            public MyLinkedListNode AddLists(MyLinkedListNode list1, MyLinkedListNode list2, int carry)
            {
                if (list1 == null && list2 == null && carry == 0)
                {
                    return null;
                }

                var result = new MyLinkedListNodeDoubly();
                var value = carry;

                if (list1 != null)
                {
                    value += (int)list1.Data;
                }
                if (list2 != null)
                {
                    value += (int)list2.Data;
                }

                result.Data = value % 10;

                if (list1 != null || list2 != null)
                {
                    var more = AddLists(list1 == null ? null : list1.Next,
                                                   list2 == null ? null : list2.Next,
                                                   value >= 10 ? 1 : 0);
                    result.SetNext(more);
                }

                return result;
            }

            public int LinkedListToInt(MyLinkedListNode node)
            {
                int value = 0;

                if (node.Next != null)
                {
                    value = 10 * LinkedListToInt(node.Next);
                }

                return value + (int)node.Data;
            }

            #endregion First Part

            #region Followup

            public MyLinkedListNode AddLists2(MyLinkedListNode list1, MyLinkedListNode list2)
            {
                var len1 = Length(list1);
                var len2 = Length(list2);

                if (len1 < len2)
                {
                    list1 = PadList(list1, len2 - len1);
                }
                else
                {
                    list2 = PadList(list2, len1 - len2);
                }

                var sum = AddListsHelper(list1, list2);

                if (sum.Carry == 0)
                {
                    return sum.Sum;
                }
                else
                {
                    var result = insertBefore(sum.Sum, sum.Carry);
                    return result;
                }
            }

            public PartialSum AddListsHelper(MyLinkedListNode list1, MyLinkedListNode list2)
            {
                if (list1 == null && list2 == null)
                {
                    return new PartialSum();
                }

                var sum = new PartialSum();
                var val = 0;

                if (list1 != null)
                {
                    sum = AddListsHelper(list1.Next, list2.Next);
                    val = sum.Carry + (int)list1.Data + (int)list2.Data;
                }

                var fullResult = insertBefore(sum.Sum, val % 10);
                sum.Sum = fullResult;
                sum.Carry = val / 10;

                return sum;
            }

            public MyLinkedListNode insertBefore(MyLinkedListNode list, int data)
            {
                var listD = (MyLinkedListNodeDoubly)list;
                var node = new MyLinkedListNodeDoubly(data, null, null);

                if (listD != null)
                {
                    listD.Prev = node;
                    node.Next = listD;
                }

                return node;
            }

            public int Length(MyLinkedListNode l)
            {
                if (l == null)
                {
                    return 0;
                }
                else
                {
                    return 1 + Length(l.Next);
                }
            }

            public int linkedListToInt(MyLinkedListNode node)
            {
                int value = 0;

                while (node != null)
                {
                    value = value * 10 + (int)node.Data;
                    node = node.Next;
                }

                return value;
            }

            public MyLinkedListNode PadList(MyLinkedListNode listNode, int padding)
            {
                var head = (MyLinkedListNodeDoubly)listNode;

                for (var i = 0; i < padding; i++)
                {
                    var n = new MyLinkedListNodeDoubly(0, null, null);
                    head.Prev = n;
                    n.Next = head;
                    head = n;
                }

                return head;
            }

            public class PartialSum
            {
                public int Carry = 0;
                public MyLinkedListNode Sum = null;
            }

            #endregion Followup

            public void Run()
            {
                #region First Part

                {
                    var lA1 = new MyLinkedListNodeDoubly(9, null, null);
                    var lA2 = new MyLinkedListNodeDoubly(9, null, lA1);
                    var lA3 = new MyLinkedListNodeDoubly(9, null, lA2);

                    var lB1 = new MyLinkedListNodeDoubly(1, null, null);
                    var lB2 = new MyLinkedListNodeDoubly(0, null, lB1);
                    var lB3 = new MyLinkedListNodeDoubly(0, null, lB2);

                    var list3 = AddLists(lA1, lB1, 0);

                    lA1.PrintForward("");
                    lB1.PrintForward("+");
                    list3.PrintForward("=");

                    var l1 = LinkedListToInt(lA1);
                    var l2 = LinkedListToInt(lB1);
                    var l3 = LinkedListToInt(list3);

                    Console.Write(l1 + " + " + l2 + " = " + l3 + "\n");
                    Console.WriteLine(l1 + " + " + l2 + " = " + (l1 + l2));
                }

                #endregion First Part

                #region Followup

                {
                    var lA1 = new MyLinkedListNodeDoubly(3, null, null);
                    var lA2 = new MyLinkedListNodeDoubly(1, null, lA1);
                    //LinkedListNode lA3 = new LinkedListNode(5, null, lA2);

                    var lB1 = new MyLinkedListNodeDoubly(5, null, null);
                    var lB2 = new MyLinkedListNodeDoubly(9, null, lB1);
                    var lB3 = new MyLinkedListNodeDoubly(1, null, lB2);

                    var list3 = AddLists2(lA1, lB1);

                    lA1.PrintForward("");
                    lB1.PrintForward("+");
                    list3.PrintForward("=");

                    var l1 = linkedListToInt(lA1);
                    var l2 = linkedListToInt(lB1);
                    var l3 = linkedListToInt(list3);

                    Console.Write(l1 + " + " + l2 + " = " + l3 + "\n");
                    Console.WriteLine(l1 + " + " + l2 + " = " + (l1 + l2));
                }

                #endregion Followup
            }
        }
    }
}