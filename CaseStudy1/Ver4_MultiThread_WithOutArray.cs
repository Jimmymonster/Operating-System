// using System;
// using System.Diagnostics;
// using System.IO;
// using System.Runtime.Serialization;
// using System.Runtime.Serialization.Formatters.Binary;
// using System.Threading;

// namespace Problem01
// {
//     class Program
//     {
//         static byte[] Data_Global = new byte[1000000000];
//         static long s1 = 0, s2 = 0;
//         // static int G_index = 0;


//         static int ReadData()
//         {
//             int returnData = 0;
//             FileStream fs = new FileStream("Problem01_Data/Problem01.dat", FileMode.Open);
//             BinaryFormatter bf = new BinaryFormatter();

//             try
//             {
//                 Data_Global = (byte[])bf.Deserialize(fs);
//             }
//             catch (SerializationException se)
//             {
//                 Console.WriteLine("Read Failed:" + se.Message);
//                 returnData = 1;
//             }
//             finally
//             {
//                 fs.Close();
//             }

//             return returnData;
//         }
//         static void sum1()
//         {
//             int G_index = 0;
//             for (int i = 0; i < 500000000; i++)
//             {
//                 if (Data_Global[G_index] % 2 == 0)
//                 {
//                     s1 -= Data_Global[G_index];
//                 }
//                 else if (Data_Global[G_index] % 3 == 0)
//                 {
//                     s1 += (Data_Global[G_index] * 2);
//                 }
//                 else if (Data_Global[G_index] % 5 == 0)
//                 {
//                     s1 += (Data_Global[G_index] / 2);
//                 }
//                 else if (Data_Global[G_index] % 7 == 0)
//                 {
//                     s1 += (Data_Global[G_index] / 3);
//                 }
//                 Data_Global[G_index] = 0;
//                 G_index++;
//             }
//         }
//         static void sum2()
//         {
//             int G_index = 500000000;
//             for (int i = 0; i < 500000000; i++)
//             {
//                 if (Data_Global[G_index] % 2 == 0)
//                 {
//                     s2 -= Data_Global[G_index];
//                 }
//                 else if (Data_Global[G_index] % 3 == 0)
//                 {
//                     s2 += (Data_Global[G_index] * 2);
//                 }
//                 else if (Data_Global[G_index] % 5 == 0)
//                 {
//                     s2 += (Data_Global[G_index] / 2);
//                 }
//                 else if (Data_Global[G_index] % 7 == 0)
//                 {
//                     s2 += (Data_Global[G_index] / 3);
//                 }
//                 Data_Global[G_index] = 0;
//                 G_index++;
//             }
//         }
//         static void Main(string[] args)
//         {
//             Stopwatch sw = new Stopwatch();
//             int i, y;

//             /* Read data from file */
//             Console.Write("Data read...");
//             y = ReadData();
//             if (y == 0)
//             {
//                 Console.WriteLine("Complete.");
//             }
//             else
//             {
//                 Console.WriteLine("Read Failed!");
//             }

//             /* Start */
//             Console.Write("\n\nWorking...");
//             sw.Start();
//             Thread t1 = new Thread(sum1), t2 = new Thread(sum2);
//             t1.Start(); t2.Start();
//             t1.Join(); t2.Join();

//             sw.Stop();
//             Console.WriteLine("Done.");

//             /* Result */
//             Console.WriteLine("Summation result: {0}", s1 + s2);
//             Console.WriteLine("Time used: " + sw.ElapsedMilliseconds.ToString() + "ms");
//         }
//     }
// }