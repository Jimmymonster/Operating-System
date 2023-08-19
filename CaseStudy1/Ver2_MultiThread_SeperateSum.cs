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
//         const int numberOfThread = 16;
//         const int dataCount = 1000000000;
//         static byte[] Data_Global = new byte[1000000000];
//         static long[] Sum_Global = new long[numberOfThread];
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
//         static void sum(int idx)
//         {
//             int G_index = idx;
//             for (int i = 0; i < dataCount / numberOfThread && G_index < dataCount; i++)
//             {
//                 if (Data_Global[G_index] % 2 == 0)
//                 {
//                     Sum_Global[idx] -= Data_Global[G_index];
//                 }
//                 else if (Data_Global[G_index] % 3 == 0)
//                 {
//                     Sum_Global[idx] += (Data_Global[G_index] * 2);
//                 }
//                 else if (Data_Global[G_index] % 5 == 0)
//                 {
//                     Sum_Global[idx] += (Data_Global[G_index] / 2);
//                 }
//                 else if (Data_Global[G_index] % 7 == 0)
//                 {
//                     Sum_Global[idx] += (Data_Global[G_index] / 3);
//                 }
//                 Data_Global[G_index] = 0;
//                 G_index += numberOfThread;
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

//             Thread[] th = new Thread[numberOfThread];
//             for (i = 0; i < numberOfThread; i++)
//             {
//                 th[i] = new Thread(() => { sum(i); });
//                 th[i].Start();
//                 th[i].Join();
//             }

//             sw.Stop();
//             Console.WriteLine("Done.");

//             /* Result */
//             Console.WriteLine("Summation result: {0}", Sum_Global.Sum());
//             Console.WriteLine("Time used: " + sw.ElapsedMilliseconds.ToString() + "ms");
//         }
//     }
// }