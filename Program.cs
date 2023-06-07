using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        [DllImport("WHSerial.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool open(string port, uint baudrate, byte bytesize, byte parity, byte stopbits, byte flowcontrol, int timeout);

        [DllImport("WHSerial.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int write(string data, int len);

        [DllImport("WHSerial.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int read(string data, int len);

        [DllImport("WHSerial.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void close(string data, int len);
        static void Main(string[] args)
        {
            bool result = open("COM1", 9600, 8, 0, 1, 0, 1000);

            if (result)
            {
                Console.WriteLine("Open Success!");
                int len = write("Hello World!", 12);
                Console.WriteLine("Write Success! Length: " + len);

                string data = new string('\0', 100);
                len = read(data, 100);
                Console.WriteLine("Read Success! Length: " + len + " Data: " + data);

                close("", 0);
                Console.WriteLine("Close Success!");
            }
            else
            {
                Console.WriteLine("Open Failed!");
            }

            Console.ReadLine();
        }
    }
}
