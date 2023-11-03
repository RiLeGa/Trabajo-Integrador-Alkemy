using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace TechOilF.Pages
{
    public class ProyectosModel : PageModel
    {
        public List<Proyectos> Proyecto { get; set; }
        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5218/api/Proyectos");

                if (response.IsSuccessStatusCode)
                {
                    Proyecto = await response.Content.ReadFromJsonAsync<List<Proyectos>>();
                }
                else
                {
                    Proyecto = new List<Proyectos>();
                }
            }
        }
        public class Proyectos
        {
            public int CodProyecto { get; set; }
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public bool Estado { get; set; }
        }

            public async Task<IActionResult> OnPostCrearProyecto()
            {
                // Captura los valores de usuario y contraseña desde la solicitud POST

                string nombre = Request.Form["nombre"];

                string direccion = Request.Form["direccion"];

                string estadoStr = Request.Form["estado"];
                bool estado = estadoStr == "true";


                Console.WriteLine(nombre +" "+ direccion + " " + estado);


            var data = new
            {
                Nombre = nombre,
                Direccion = direccion,
                Estado = estado
            };
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient())
                {

                    var response = await httpClient.PostAsync("http://localhost:5218/api/Proyectos", content);
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
