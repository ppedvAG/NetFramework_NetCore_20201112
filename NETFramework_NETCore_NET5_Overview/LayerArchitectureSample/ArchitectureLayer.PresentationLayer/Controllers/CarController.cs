using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LayerArchitecture.DataLayer.EFContext;
using LayerArchitecture.Domain.Entities;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace ArchitectureLayer.PresentationLayer.Controllers
{
    public class CarController : Controller
    {
       string baseAddress = "https://localhost:44373/api/Car/";

        public CarController()
        {
            
        }

        // GET: Car
        public async Task<IActionResult> Index()
        {
            IList<Car> resultList = new List<Car>();

            HttpClient client = new HttpClient();

            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, baseAddress);
            HttpResponseMessage response = await client.SendAsync(message);

            string jsonText = await response.Content.ReadAsStringAsync();

            resultList = JsonConvert.DeserializeObject<List<Car>>(jsonText);
            return View(resultList);
        }

        // GET: Car/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car car = null;

            string url = baseAddress + id.ToString();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string jsonText = await response.Content.ReadAsStringAsync();
                car = JsonConvert.DeserializeObject<Car>(jsonText);
            }


            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Car/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Model,ConstructYear,Farbe,IsCaprio,MitRadio")] Car car)
        {
            if (ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(car);

                var data = new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PostAsync(baseAddress, data);
                    string result = await response.Content.ReadAsStringAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Car/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car car = null;

            string url = baseAddress + id.ToString();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string jsonText = await response.Content.ReadAsStringAsync();
                car = JsonConvert.DeserializeObject<Car>(jsonText);
            }

            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Brand,Model,ConstructYear,Farbe,IsCaprio,MitRadio")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            string url = baseAddress + id.ToString();

            string json = JsonConvert.SerializeObject(car);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                var response = client.PutAsync(url, data);
                string result = await response.Result.Content.ReadAsStringAsync();
            }

            if (ModelState.IsValid)
            {
                
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Car/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car car = null;

            string url = baseAddress + id.ToString();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string jsonText = await response.Content.ReadAsStringAsync();
                car = JsonConvert.DeserializeObject<Car>(jsonText);
            }


            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            string url = baseAddress + id.ToString();

            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync(url);

                string result = await response.Content.ReadAsStringAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        
    }
}
