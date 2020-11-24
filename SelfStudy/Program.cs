using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text.Json;

namespace SelfStudy
{
    public class Program
    {

        static void Main(string[] args)
        {
            string directory = @"D:\";
            string directoryName = "lw";
            string fileName = "log.txt";
          string path= Path.Combine(directory, directoryName);
            Directory.CreateDirectory(path);

            path = Path.Combine(directory, directoryName, fileName);

            File.CreateText(path);
           
            File.WriteAllText(path,"Hello,word");



        }
    }












}
