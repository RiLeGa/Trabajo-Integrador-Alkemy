using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace TechOilF.Pages
{
    public class EditarServicioModel : PageModel
    {
        public ServicioAeditar Servicio { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5218/api/Servicios/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var jsonServicio = await response.Content.ReadAsStringAsync();
                    var servicio = JsonConvert.DeserializeObject<ServicioAeditar>(jsonServicio);

                    // Verifica si el Servicio tiene el mismo ID que el solicitado
                    if (servicio.CodServicio == id)
                    {
                        Servicio = servicio;
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


        public class ServicioAeditar
        {
            public int CodServicio { get; set; }
            public string Descr { get; set; }
            public Boolean Estado { get; set; }
        }
        public async Task<IActionResult> OnPostEditarServicio()
        {
            // Captura los valores de Servicio y contraseña desde la solicitud POST

            string codServicio = Request.Form["codServicio"];
            int id = string.IsNullOrEmpty(codServicio) ? 0 : int.Parse(codServicio);

            string descr = Request.Form["descripcionAEditar"];

            string estadoStr = Request.Form["estadoAEditar"];
            bool estado = estadoStr == "true";

            Console.WriteLine(descr + " " + codServicio + " " + estado);


            var data = new
            {
                Descr = descr,
                Estado = estado
            };
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.PutAsync("http://localhost:5218/api/Servicios/" + id, content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("/Servicios");
                }
                else
                {
                    return Page();
                }

            }
        }
    }
}
