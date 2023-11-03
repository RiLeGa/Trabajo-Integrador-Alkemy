using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace TechOilF.Pages
{
    public class FormEditUsModel : PageModel
    {
        public UsuarioAeditar Usuario { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5218/api/Usuarios/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var jsonUsuario = await response.Content.ReadAsStringAsync();
                    var usuario = JsonConvert.DeserializeObject<UsuarioAeditar>(jsonUsuario);

                    // Verifica si el usuario tiene el mismo ID que el solicitado
                    if (usuario.CodUsuario == id)
                    {
                        Usuario = usuario;
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


        public class UsuarioAeditar
        {
            public int CodUsuario { get; set; }
            public string Nombre { get; set; }
            public int Dni { get; set; }
        }
        public async Task<IActionResult> OnPostEditarUsuario()
        {
            // Captura los valores de usuario y contraseña desde la solicitud POST
            string nombreAEditar = Request.Form["nombreAEditar"];

            string codUsuario = Request.Form["codUsuario"];
            int id = string.IsNullOrEmpty(codUsuario) ? 0 : int.Parse(codUsuario);

            Console.WriteLine(nombreAEditar);


            var data = new
            {
                nombre = nombreAEditar
            };
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.PutAsync("http://localhost:5218/api/Usuarios/" + id, content);
                if (response.IsSuccessStatusCode)
                {
                    
                    return RedirectToPage("/Usuarios");
                }
                else
                {
                    return Page();
                }

            }
        }
    }
}
