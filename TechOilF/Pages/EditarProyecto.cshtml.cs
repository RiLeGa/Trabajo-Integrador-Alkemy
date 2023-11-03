using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace TechOilF.Pages
{
    public class EditarProyectoModel : PageModel
    {
        public ProyectoAeditar Proyecto { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5218/api/Proyectos/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var jsonProyecto = await response.Content.ReadAsStringAsync();
                    var proyecto = JsonConvert.DeserializeObject<ProyectoAeditar>(jsonProyecto);

                    // Verifica si el Proyecto tiene el mismo ID que el solicitado
                    if (proyecto.CodProyecto == id)
                    {
                        Proyecto = proyecto;
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


        public class ProyectoAeditar
        {
            public int CodProyecto { get; set; }
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public Boolean Estado { get; set; }
        }
        public async Task<IActionResult> OnPostEditarProyecto()
        {
            // Captura los valores de Proyecto y contraseña desde la solicitud POST

            string codProyecto = Request.Form["codProyecto"];
            int id = string.IsNullOrEmpty(codProyecto) ? 0 : int.Parse(codProyecto);

            string nombre = Request.Form["nombreAEditar"];

            string direccion = Request.Form["direccionAEditar"];

            string estadoStr = Request.Form["estadoAEditar"];
            bool estado = estadoStr == "true";

            Console.WriteLine(nombre + " " + direccion + " " + codProyecto + " " + estado);


            var data = new
            {
                Nombre = nombre,
                Direccion = direccion,
                Estado = estado
            };
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.PutAsync("http://localhost:5218/api/Proyectos/" + id, content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("/Proyectos");
                }
                else
                {
                    return Page();
                }

            }
        }
    }
}
