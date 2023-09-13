// class Program
// {
//     private static string x = "";
//     private static int test = 0;
//     private static bool dataReady = false;
//     private static Object _Lock = new Object();

//     static void ThReadX(object i)
//     {
//             lock (_Lock)
//             {
//                 Monitor.Wait(_Lock); // รอคอยข้อมูลพร้อม
//                 Console.WriteLine("DEF");
//                 //Monitor.Pulse(_Lock); // แจ้งเตือนเธรดที่รอคอย
//             }
//     }

//     static void ThWriteX()
//     {
//         lock (_Lock)
//             {
//                 Console.Write("ABC ");
//                 Monitor.Pulse(_Lock); 
//             }
//     }

//     static void Main(string[] args)
//     {
//         Thread A = new Thread(ThWriteX);
//         Thread B = new Thread(ThReadX);

//         A.Start();
//         B.Start(1);
//     }
// }