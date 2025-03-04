﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleDemo {
    class Program {
        static void Main(string[] args) {
            DownloadAsync();

            while (true) {
                Thread.Sleep(100);
            }
        }

        private static async Task DownloadAsync() {
            try {
                Debug.WriteLine($"BEFORE {Thread.CurrentThread.ManagedThreadId}");
                HttpClient client = new HttpClient();
                Task<string> task = client.GetStringAsync("https://www.symas.ch");
                string result = await task;
                Debug.WriteLine($"AFTER {Thread.CurrentThread.ManagedThreadId}");
            } catch (Exception e) {
                Debug.WriteLine($"Error {e.Message}");
            }
        }
    }
}
