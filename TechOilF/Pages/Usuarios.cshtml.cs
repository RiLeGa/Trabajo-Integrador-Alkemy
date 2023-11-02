using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace TechOilF.Pages
{
    public class UsuariosModel : PageModel
    {
        public List<Usuarios> Usuario { get; set; }
        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5218/api/Usuarios");

                if (response.IsSuccessStatusCode)
                {
                    Usuario = await response.Content.ReadFromJsonAsync<List<Usuarios>>();
                }
                else
                {
                    Usuario = new List<Usuarios>();
                }
            }
        }
        public class Usuarios
        {
            public int CodUsuario { get; set; }
            public string Nombre { get; set; }
            public int Dni { get; set; }
        }

        public async Task<IActionResult> OnPostCrearUsuario()
        {
            // Captura los valores de usuario y contraseña desde la solicitud POST
            string nombre = Request.Form["nombre"];
            string dni = Request.Form["dni"];
            string password = Request.Form["password"];

            Console.WriteLine(nombre + " " + dni + " " + password);


            var data = new
            {
                nombre = nombre,
                dni = dni,
                password = password
            };
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.PostAsync("http://localhost:5218/api/Usuarios", content);
                if (response.IsSuccessStatusCode)
                {
                    // response = await httpClient.GetAsync("http://localhost:5218/api/Usuarios");

                    //if (response.IsSuccessStatusCode)
                    //{
                    //    Usuario = await response.Content.ReadFromJsonAsync<List<Usuarios>>();
                    //}
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
        {  using (var httpClient = new HttpClient()) 
            {
                var response = await httpClient.DeleteAsync("http://localhost:5218/api/Usuarios/" + id);
                if (response.IsSuccessStatusCode)
                {
                    //response = await httpClient.GetAsync("http://localhost:5218/api/Usuarios");

                    //if (response.IsSuccessStatusCode)
                    //{
                    //    Usuario = await response.Content.ReadFromJsonAsync<List<Usuarios>>();
                    //}
                    await OnGetAsync();
                    return Page();
                }
                else
                {
                    return Page();
                }
            } 
        }
    }
}
