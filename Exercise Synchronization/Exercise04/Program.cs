using System;
using System.Diagnostics;
using System.Threading;

namespace Exercise04{
    class Program{
        private static string x="";
        private static int exitflag=0;
        private static int rubInput=1;
        private static object _Lock = new object();
        static void ThReadX(){
            while(exitflag==0){
                while(rubInput==0){
                    lock(_Lock){
                    rubInput=1;
                    Console.WriteLine("X = {0}",x);
                    }
                }
            }
        }
        static void ThWriteX(){
            string xx;

            while(exitflag==0){
                while(rubInput==1){
                    lock(_Lock){
                    rubInput=0;
                    Console.Write("Input: ");
                    xx=Console.ReadLine();
                    if(xx=="exit") exitflag=1;
                    else x=xx;
                    }
                }
            }
        }
        static void Main(string[] args){
            Thread A = new Thread(ThReadX);
            Thread B = new Thread(ThWriteX);
            
            A.Start();
            B.Start();
        }
    }
}