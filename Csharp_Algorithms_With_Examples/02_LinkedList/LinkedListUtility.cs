using System;
using System.Collections.Generic;
using TWL_Algorithms_Samples.Arrays;

namespace TWL_Algorithms_Samples.LinkedList
{
    public class LinkedListUtility
    {
        public static LinkedListNode GetLinkedListDoubly_Random(int N, int min, int max)
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

        public static LinkedListNode GetLinkedListSingly_Random(int N, int min, int max)
        {
            LinkedListNode root = new LinkedListNodeSingly(AssortedMethods.RandomIntInRange(min, max), null);
            LinkedListNode prev = root;
            for (int i = 1; i < N; i++)
            {
                int data = AssortedMethods.RandomIntInRange(min, max);
                LinkedListNode next = new LinkedListNodeSingly(data, null);
                prev.SetNext(next);
                prev = next;
            }
            return root;
        }

        public static LinkedListNode GetLinkedListSingly_Serial(int min, int max)
        {
            LinkedListNode root = new LinkedListNodeSingly(min, null);
            LinkedListNode prev = root;
            for (int i = min + 1; i <= max; i++)
            {
                LinkedListNode next = new LinkedListNodeSingly(i, null);
                prev.SetNext(next);
                prev = next;
            }
            return root;
        }

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
        public void DeleteNode_Run()
        {
            var head = GetLinkedListSingly_Random(10, 0, 10);
            head.PrintForward("Input:");
            var deleted = head.DeleteNode(head.Next.Next.Next.Next); // delete node 5
            Console.WriteLine("deleted? {0}", deleted);
            head.PrintForward("Output:");
        }

        public void ReverseLinkedList_Run()
        {
            var head = GetLinkedListSingly_Serial(0, 5);
            head.PrintForward("Input for ReverseLinkedListIterative Test:");
            head = ReverseLinkedListIterative(head);
            head.PrintForward("Output for ReverseLinkedListIterative:");
            head.PrintForward("Input for ReverseLinkedListRecursive Test:");
            head = ReverseLinkedListRecursive(head);
            head.PrintForward("Output for ReverseLinkedListRecursive:");
        }

        /// <summary>
        /// Changing pointer in reverse direction
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public LinkedListNode ReverseLinkedListIterative(LinkedListNode head)
        {
            /* iterative solution */
            LinkedListNode newHead = null;
            while (head != null)
            {
                //head.PrintForward("head");
                LinkedListNode nextNode = head.Next;
                head.Next = newHead;

                //Link to New node
                newHead = head;
                head = nextNode;
                //newHead.PrintForward("newHead");
            }
            return newHead;
        }

        public LinkedListNode ReverseLinkedListRecursive(LinkedListNode head)
        {
            /* recursive solution */
            return ReverseLinkedListRecursiveInt(head, null);
        }

        public void Run()
        {
            //new Remove_Dups().Run();
            //DeleteNode_Run();
            ReverseLinkedList_Run();
            //new Return_Kth_To_Last().Run();
            //new Sum_Lists_Numbers().Run();
            //new Q2_04_Partition().Run();
            //new CheckIfPalindrome().Run();
            //new Q2_07_Intersection().Run();
            //new Loop_Detection().Run();
        }

        private LinkedListNode ReverseLinkedListRecursiveInt(LinkedListNode head, LinkedListNode newHead)
        {
            if (head == null)
                return newHead;
            LinkedListNode nextNode = head.Next;
            head.Next = newHead;
            return ReverseLinkedListRecursiveInt(nextNode, head);
        }
        public class CheckIfPalindrome : IQuestion
        {
            public void Run()
            {
                const int length = 10;
                var nodes = new LinkedListNodeDoubly[length];

                for (var i = 0; i < length; i++)
                {
                    nodes[i] = new LinkedListNodeDoubly(i >= length / 2 ? length - i - 1 : i, null, null);
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

            /// <summary>
            /// ****NW:Compare first vs last
            /// </summary>
            /// <param name="head"></param>
            /// <param name="length"></param>
            /// <returns></returns>
            private Result IsPalindrome_UsingRecursion(LinkedListNode head, int length)
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

            private bool IsPalindrome_UsingRecursionMain(LinkedListNode head)
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

            private bool IsPalindrome_UsingStack(LinkedListNode head)
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
            private class Result
            {
                public LinkedListNode Node;
                public bool result;

                public Result(LinkedListNode node, bool res)
                {
                    Node = node;
                    result = res;
                }
            }
        }

        public class Loop_Detection : IQuestion
        {
            public void Run()
            {
                const int listLength = 10;
                const int k = 3;

                // Create linked list
                var nodes = new LinkedListNode[listLength];

                for (var i = 1; i <= listLength; i++)
                {
                    nodes[i - 1] = new LinkedListNodeDoubly(i, null, i - 1 > 0 ? (LinkedListNodeDoubly)nodes[i - 2] : null);
                    Console.Write("{0} -> ", nodes[i - 1].Data);
                }
                // Create loop;
                Console.WriteLine($"\n Create loop: nodes[listLength - 1].Next = nodes[listLength - k - 1]");
                nodes[listLength - k - 1].PrintForward("nodes[listLength - k - 1]");
                nodes[listLength - 1].PrintForward("nodes[listLength - 1]");
                ////nodes[listLength - 1].Next.PrintForward("nodes[listLength - 1].Next");

                nodes[listLength - 1].Next = nodes[listLength - k - 1];
                Console.WriteLine("\n{0} -> {1}", nodes[listLength - 1].Data, nodes[listLength - k - 1].Data);
                Console.WriteLine("Nodes:\n");
                //foreach (var node in nodes)
                //{
                //    node.PrintForward();
                //}

                var loop = FindBeginning(nodes[0]);

                if (loop == null)
                {
                    Console.WriteLine("No Cycle.");
                }
                else
                {
                    Console.WriteLine(loop.Data);
                }
            }

            private LinkedListNode FindBeginning(LinkedListNode head)
            {
                var slow = head;
                var fast = head;

                // Find meeting point
                // slow will reach to half of link list
                while (fast != null && fast.Next != null)
                {
                    Console.WriteLine($"*slow.Data{slow.Data}");
                    Console.WriteLine($"*fast.Data{fast.Data}");

                    slow = slow.Next;
                    fast = fast.Next.Next;

                    if (slow == fast)
                    {
                        Console.WriteLine($"slow == fast");
                        break;
                    }
                }

                //slow.PrintForward("@slow");

                // Error check - there is no meeting point, and therefore no loop
                if (fast == null || fast.Next == null)
                {
                    Console.WriteLine("@fast == null || fast.Next == null");
                    return null;
                }
                else
                {
                    Console.WriteLine("@fast!=null");
                    //fast.PrintForward("@fast");
                }

                /* Move slow to Head. Keep fast at Meeting Point. Each are k steps
                /* from the Loop Start. If they move at the same pace, they must
                 * meet at Loop Start. */
                slow = head;
                //slow.PrintForward("*slow");
                Console.WriteLine("\n\n*slow!=null");
                //fast.PrintForward("*fast");
                Console.WriteLine("*fast!=null");
                while (slow != fast)
                {
                    Console.WriteLine($"*slow.Data{slow.Data}");
                    Console.WriteLine($"*fast.Data{fast.Data}");
                    slow = slow.Next;
                    fast = fast.Next;
                }

                // Both now point to the start of the loop.
                return fast;
            }
        }

        public class Q2_04_Partition : IQuestion
        {
            public void Run()
            {
                /* Create linked list */
                int[] vals = { 1, 3, 7, 5, 2, 9, 4 };
                var head = new LinkedListNodeDoubly(vals[0], null, null);
                var current = head;

                for (var i = 1; i < vals.Length; i++)
                {
                    current = new LinkedListNodeDoubly(vals[i], null, current);
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

            private LinkedListNode Partition(LinkedListNode node, int pivot)
            {
                LinkedListNode beforeStart = null;
                LinkedListNode beforeEnd = null;
                LinkedListNode afterStart = null;
                LinkedListNode afterEnd = null;

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

            private LinkedListNode Partition2(LinkedListNode node, int pivot)
            {
                LinkedListNode beforeStart = null;
                LinkedListNode afterStart = null;

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

            private LinkedListNode Partition3(LinkedListNode listHead, int pivot)
            {
                var leftList = new LinkedListNodeDoubly(); // empty temp node to not have an IF inside the loop
                var rightList = new LinkedListNodeDoubly(pivot, null, null);

                var leftListHead = leftList; // Used at the end to remove the empty node.
                var rightListHead = rightList; // Used at the end to merge lists.

                var currentNode = listHead;

                while (currentNode != null)
                {
                    if ((int)currentNode.Data < pivot)
                    {
                        leftList = new LinkedListNodeDoubly(currentNode.Data, null, leftList);
                    }
                    else if ((int)currentNode.Data > pivot)
                    {
                        rightList = new LinkedListNodeDoubly(currentNode.Data, null, rightList);
                    }

                    currentNode = currentNode.Next;
                }

                leftList.Next = rightListHead;

                var finalList = leftListHead.Next;
                leftListHead.Next = null; // remove the temp node, GC will release the mem

                return finalList;
            }

            private LinkedListNode Partition4(LinkedListNode listHead, int pivot)
            {
                LinkedListNode leftSubList = null;
                LinkedListNode rightSubList = null;
                LinkedListNode rightSubListHead = null;
                LinkedListNode pivotNode = null;

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
        }

        public class Q2_07_Intersection : IQuestion
        {
            public static LinkedListNode findIntersection(LinkedListNode list1, LinkedListNode list2)
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
                LinkedListNode shorter = result1.size < result2.size ? list1 : list2;
                LinkedListNode longer = result1.size < result2.size ? list2 : list1;

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

            public static LinkedListNode getKthNode(LinkedListNode head, int k)
            {
                LinkedListNode current = head;
                while (k > 0 && current != null)
                {
                    current = current.Next;
                    k--;
                }
                return current;
            }

            public static Result getTailAndSize(LinkedListNode list)
            {
                if (list == null) return null;

                int size = 1;
                LinkedListNode current = list;
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
                LinkedListNode list1 = AssortedMethods.CreateLinkedListFromArray(vals);
                list1.PrintForward("list1");
                int[] vals2 = { 12, 14, 15 };
                LinkedListNode list2 = AssortedMethods.CreateLinkedListFromArray(vals2);
                list2.PrintForward("list2");
                //adding some common elements
                list2.Next.Next = list1.Next.Next.Next.Next;
                list2.PrintForward("list2");
                LinkedListNode intersection = findIntersection(list1, list2);
                intersection.PrintForward("intersection");
            }

            public class Result
            {
                public int size;
                public LinkedListNode tail;

                public Result(LinkedListNode tail, int size)
                {
                    this.tail = tail;
                    this.size = size;
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

        public class Return_Kth_To_Last : IQuestion
        {
            public void Run()
            {
                //int[] nthCounts = new int[] { 1, 2, 9, 10, 11,12 };
                int[] nthCounts = new int[] { 1 };
                nthCounts.Print("Get Positions:");
                var head = GetLinkedListSingly_Random(10, 0, 10);
                head.PrintForward("\nLink List:");
                var node = head;
                foreach (int nth in nthCounts)
                {
                    int i = 0;
                    NthToLastR1(head, nth);
                    node = NthToLastR2(head, nth, ref i);
                    node = NthToLastR3(head, nth);

                    if (node != null)
                    {
                        Console.WriteLine("***" + nth + "th to last node is " + node.Data);
                    }
                    else
                    {
                        Console.WriteLine($"***Null.  n='{nth}' is out of bounds.");
                    }

                    Console.WriteLine("-----------------------------------------------------------");
                }
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

            private int NthToLastR1(LinkedListNode head, int n)
            {
                if (head != null)
                {
                    head.PrintForward($"***n='{n}'");
                }

                if (n == 0 || head == null)
                {
                    return 0;
                }

                var k = NthToLastR1(head.Next, n) + 1;

                if (k == n)
                {
                    Console.WriteLine(n + "th to last node is " + head.Data);
                }
                //else
                //{
                //    Console.WriteLine($"Null.  n='{n}' is out of bounds.");
                //}
                Console.WriteLine($"n='{n}' k='{k}'");
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

            private LinkedListNode NthToLastR3(LinkedListNode head, int k)
            {
                head.PrintForward("@");
                var result = NthToLastR3Helper(head, k);

                if (result != null)
                {
                    return result.Node;
                }

                return null;
            }

            //    if (k == n)
            //    {
            //        Console.WriteLine(n + "th to last node is " + head.Data);
            //    }
            //    //else
            //    //{
            //    //    Console.WriteLine($"Null.  n='{n}' is out of bounds.");
            //    //}
            //    Console.WriteLine($"n='{n}' k='{k}'");
            //    return k;
            //}
            private Result NthToLastR3Helper(LinkedListNode head, int k)
            {
                if (head == null)
                {
                    return new Result(null, 0);
                }
                else
                {
                    head.PrintForward("@**");
                }

                var result = NthToLastR3Helper(head.Next, k);

                head.PrintForward($"@*** k='{k}' result.Count='{result.Count}' result.Node='{result.Node}'");

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

            internal class Result
            {
                public Result(LinkedListNode node, int count)
                {
                    Node = node;
                    Count = count;
                }

                public int Count { get; set; }
                public LinkedListNode Node { get; set; }
            }

            //private LinkedListNode NthToLastR1(LinkedListNode head, int n)
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

            private LinkedListNode AddLists(LinkedListNode list1, LinkedListNode list2, int carry)
            {
                if (list1 == null && list2 == null && carry == 0)
                {
                    return null;
                }

                var result = new LinkedListNodeDoubly();
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

            private int LinkedListToInt(LinkedListNode node)
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

            private LinkedListNode AddLists2(LinkedListNode list1, LinkedListNode list2)
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

            private PartialSum AddListsHelper(LinkedListNode list1, LinkedListNode list2)
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

            private LinkedListNode insertBefore(LinkedListNode list, int data)
            {
                var listD = (LinkedListNodeDoubly)list;
                var node = new LinkedListNodeDoubly(data, null, null);

                if (listD != null)
                {
                    listD.Prev = node;
                    node.Next = listD;
                }

                return node;
            }

            private int Length(LinkedListNode l)
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

            private int linkedListToInt(LinkedListNode node)
            {
                int value = 0;

                while (node != null)
                {
                    value = value * 10 + (int)node.Data;
                    node = node.Next;
                }

                return value;
            }

            private LinkedListNode PadList(LinkedListNode listNode, int padding)
            {
                var head = (LinkedListNodeDoubly)listNode;

                for (var i = 0; i < padding; i++)
                {
                    var n = new LinkedListNodeDoubly(0, null, null);
                    head.Prev = n;
                    n.Next = head;
                    head = n;
                }

                return head;
            }

            private class PartialSum
            {
                public int Carry = 0;
                public LinkedListNode Sum = null;
            }

            #endregion Followup

            public void Run()
            {
                #region First Part

                {
                    var lA1 = new LinkedListNodeDoubly(9, null, null);
                    var lA2 = new LinkedListNodeDoubly(9, null, lA1);
                    var lA3 = new LinkedListNodeDoubly(9, null, lA2);

                    var lB1 = new LinkedListNodeDoubly(1, null, null);
                    var lB2 = new LinkedListNodeDoubly(0, null, lB1);
                    var lB3 = new LinkedListNodeDoubly(0, null, lB2);

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
                    var lA1 = new LinkedListNodeDoubly(3, null, null);
                    var lA2 = new LinkedListNodeDoubly(1, null, lA1);
                    //LinkedListNode lA3 = new LinkedListNode(5, null, lA2);

                    var lB1 = new LinkedListNodeDoubly(5, null, null);
                    var lB2 = new LinkedListNodeDoubly(9, null, lB1);
                    var lB3 = new LinkedListNodeDoubly(1, null, lB2);

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