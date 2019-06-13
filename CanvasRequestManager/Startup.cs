using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CanvasRequestManager
{
    internal static class Startup
    {
        public static readonly HttpClient HttpClient = new HttpClient();
    }
}
