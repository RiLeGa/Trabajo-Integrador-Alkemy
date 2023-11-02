using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace TechOilF.Pages
{
    public class LoginModel : PageModel
    {
        public string AuthToken { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            // Captura los valores de usuario y contraseña desde la solicitud POST
            string nombre = Request.Form["nombre"];
            string password = Request.Form["password"];

            Console.WriteLine(nombre + " " + password);
            
            var data = new
            {
                nombre = nombre, 
                password = password
            };
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.PostAsync("http://localhost:5218/api/Auth", content);
                if (response.IsSuccessStatusCode)
                {

                    string AuthToken = await response.Content.ReadAsStringAsync();
                    TempData["authToken"] = AuthToken; // Guarda el token en ViewData
                    Console.WriteLine("Token generado y asignado: " + AuthToken); // Agrega esta línea para depurar
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);
                    return RedirectToPage("/Index");

                }
                else
                {
                    return Page();

                }

            }
        }
    }

}
