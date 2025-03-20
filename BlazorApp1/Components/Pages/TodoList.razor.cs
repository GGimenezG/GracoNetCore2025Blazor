using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Components.Pages
{
    public class TodoListBase : ComponentBase
    {
        public string texto { get; set; } = "Prueba de texto inicial";
        public string error { get; set; } = "Prueba de texto inicial";
        public List<string> lstTareas { get; set; } = ["äctividad 1", "actividad 2", "actividad 3"];

        public void AgregarActividad()
        {

            if (!lstTareas.Any(item => item == texto))
            {
                if (!string.IsNullOrWhiteSpace(texto))
                {
                    lstTareas.Add(texto);
                    error = string.Empty;
                    texto = string.Empty;
                }
                else
                    error = "ingrese un texto";

            }
            else
            {
                error = "ya existe una actividad con esa descripción";
            }



        }
    }
}
