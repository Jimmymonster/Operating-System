// using System;
// using System.Threading;

// namespace OS_Problem_02
// {
//     class Thread_safe_buffer
//     {
//         static int[] TSBuffer = new int[10];
//         static int Front = 0;
//         static int Back = 0;
//         static int Count = 0;
//         private static Object _Lockqueue = new Object();
//         private static Object _Lock = new Object();
//         static void EnQueue(int eq)
//         {
//             lock (_Lockqueue)
//              {
//             //if full wait for dequeue
//                 if(Count==10) Monitor.Wait(_Lockqueue);
//                 TSBuffer[Back] = eq;
//                 Back++;
//                 Back %= 10;
//                 Count += 1;
//                 Monitor.Pulse(_Lockqueue); 
//             }
//         }

//         static int DeQueue()
//         {
//             lock (_Lockqueue)
//              {
//             //if empty wait for enqueue
//                 if(Count==0) Monitor.Wait(_Lockqueue);
//                 int x = 0;
//                 x = TSBuffer[Front];
//                 Front++;
//                 Front %= 10;
//                 Count -= 1;
//                 Monitor.Pulse(_Lockqueue); 
//                 return x;
//             }
//         }

//         static void th01()
//         {
//             int i;

//             for (i = 1; i < 51; i++)
//             {
//                 EnQueue(i);
//                 Thread.Sleep(5);
//             }
//         }

//         static void th011()
//         {
//             int i;

//             for (i = 100; i < 151; i++)
//             {
//                 EnQueue(i);
//                 Thread.Sleep(5);
//             }
//         }


//         static void th02(object t)
//         {
//             int i;
//             int j;

//             for (i=0; i< 60; i++)
//             {
//                 lock(_Lock){
//                     j = DeQueue();
//                     Console.WriteLine("j={0}, thread:{1}", j, t);
//                 }
//                     Thread.Sleep(100);
//             }
//         }
//         static void Main(string[] args)
//         {
//             Thread t1 = new Thread(th01);
//           //  Thread t11 = new Thread(th011);
//             Thread t2 = new Thread(th02);
//             Thread t21 = new Thread(th02);
//             Thread t22 = new Thread(th02);

//             t1.Start();
//           //  t11.Start();
//             t2.Start(1);
//             t21.Start(2);
//             t22.Start(3);
//         }
//     }
// }
