using BlazorApp1.Data.Services;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Components.Pages
{
    public partial class Personajes
    {
        [Inject]
        public NavigationManager Navigation { get; set; }
        [Inject]
        PersonajeService PersonajeService { get; set; }
        public List<Personaje>? lstPersonaje { get; set; }

        protected override async Task OnInitializedAsync()
        {
            lstPersonaje = new List<Personaje>();

            var response = await PersonajeService.GetAll();

            lstPersonaje = response.Data;

        }

        public void Create()
        {
            Navigation.NavigateTo("/crear-personaje");
        }

        public async Task GetAll()
        {
            var response = await PersonajeService.GetAll();

            lstPersonaje = response.Data;

            //return Task.CompletedTask;
        }
    }
}
