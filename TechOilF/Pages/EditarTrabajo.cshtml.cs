using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace TechOilF.Pages
{
    public class EditarTrabajoModel : PageModel
    {
        public TrabajoAeditar Trabajo { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5218/api/Trabajos/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var jsonTrabajo = await response.Content.ReadAsStringAsync();
                    var trabajo = JsonConvert.DeserializeObject<TrabajoAeditar>(jsonTrabajo);

                    // Verifica si el Trabajo tiene el mismo ID que el solicitado
                    if (trabajo.CodTrabajo == id)
                    {
                        Trabajo = trabajo;
                    }
                    else
                    {
                        return Page();
                    }
                }
                else
                {
                    return Page();
                }
            }

            return Page();
        }


        public class TrabajoAeditar
        {
            public int CodTrabajo { get; set; }
            public int CodProyecto { get; set; }
            public int CodServicio { get; set; }
            public int CantHoras { get; set; }
        }
        public async Task<IActionResult> OnPostEditarTrabajo()
        {
            // Captura los valores de Trabajo y contraseña desde la solicitud POST

            string codTrabajo = Request.Form["codTrabajo"];
            int id = string.IsNullOrEmpty(codTrabajo) ? 0 : int.Parse(codTrabajo);

            string codProyectoSrt = Request.Form["codProyectoAEditar"];
            int codProyecto = string.IsNullOrEmpty(codProyectoSrt) ? 0 : int.Parse(codProyectoSrt);
            
            string codServicioSrt = Request.Form["codServicioAEditar"];
            int codServicio = string.IsNullOrEmpty(codServicioSrt) ? 0 : int.Parse(codServicioSrt);

            string cantHorasSrt = Request.Form["cantHorasAEditar"];
            int cantHoras = string.IsNullOrEmpty(cantHorasSrt) ? 0 : int.Parse(cantHorasSrt);

            Console.WriteLine(codProyecto +" "+ codServicio + " " + cantHoras);


            var data = new
            {
                codProyecto= codProyecto,
                codServicio= codServicio,
                cantHoras=cantHoras
            };
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.PutAsync("http://localhost:5218/api/Trabajos/" + id, content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("/Trabajos");
                }
                else
                {
                    return Page();
                }

            }
        }
    }
}
