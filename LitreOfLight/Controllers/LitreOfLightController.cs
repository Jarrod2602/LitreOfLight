using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LitreOfLight.Controllers
{
    public class LitreOfLightController : Controller
    {
        private readonly HttpClient client;

        public LitreOfLightController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.4.1");
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> TurnOn()
        {
            await SendRequest("/LED=ON");
            return RedirectToAction("Index");
        }

        // POST: Turn LED Off
        [HttpPost]
        public async Task<ActionResult> TurnOff()
        {
            await SendRequest("/LED=OFF");
            return RedirectToAction("Index");
        }

        private async Task SendRequest(string path)
        {
            try
            {
                var response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                // Optionally handle exception
                Console.WriteLine(ex.Message);
            }
        }
    }
}