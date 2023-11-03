using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace TechOilF.Pages
{
    public class ServiciosModel : PageModel
    {
        public List<Servicios> Servicio { get; set; }
        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5218/api/Servicios");

                if (response.IsSuccessStatusCode)
                {
                    Servicio = await response.Content.ReadFromJsonAsync<List<Servicios>>();
                }
                else
                {
                    Servicio = new List<Servicios>();
                }
            }
        }
        public class Servicios
        {
            public int CodServicio { get; set; }
            public string Descr { get; set; }
            public Boolean Estado { get; set; }
        }
        public async Task<IActionResult> OnPostCrearServicios()
        {
            // Captura los valores de usuario y contraseña desde la solicitud POST

            string descripcion = Request.Form["descripcion"];

            string estadoStr = Request.Form["estado"];
            bool estado = estadoStr == "true";


            Console.WriteLine(descripcion + " " + estado);


            var data = new
            {
                descr = descripcion,
                estado = estado,
            };
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.PostAsync("http://localhost:5218/api/Servicios", content);
                if (response.IsSuccessStatusCode)
                {
                    await OnGetAsync();
                    return Page();
                }
                else
                {
                    return Page();
                }

            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync("http://localhost:5218/api/Servicios/" + id);
                if (response.IsSuccessStatusCode)
                {
                    await OnGetAsync();
                    return Page();
                }
                else
                {
                    await OnGetAsync();
                    return Page();
                }
            }
        }
    }
}
