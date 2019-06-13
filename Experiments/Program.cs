using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using CanvasRequestManager;

namespace Experiments
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var Canvas = new CanvasRequester();
            var path = "";
            List<JObject> responses = new List<JObject>();
            Console.WriteLine("Enter the API endpoint to hit. Type 'exit' to quit and print.");
            while ( path != "quit" && path != "exit" && path != "close" )
            {
                if (path != "")
                {
                    try
                    {
                        responses.Add(await Canvas.GetAsync(path));
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine(error.Message);
                    }
                }
                path = Console.ReadLine();
            }
            responses.ForEach((response) =>
            {
                Console.WriteLine(response);
            });
            return;
        }
    }
}
