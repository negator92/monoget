using System;
using System.Net;

namespace monoget
{
    internal static class Program
    {
        private static void Main()
        {
            do
            {
                Console.WriteLine("Enter source url: ");
                string uriString = Console.ReadLine();
                Console.WriteLine("Enter file.name: ");
                string fileName = Console.ReadLine();
                using (WebClient hc = new WebClient())
                    hc.DownloadFileAsync(new Uri(uriString), fileName);
                Console.WriteLine("\nStop downloading and quit press 'q' and enter or just enter to continue: ");
            } while (Console.ReadLine() != "q");
        }

        private static string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num) + suf[place];
        }
    }
}