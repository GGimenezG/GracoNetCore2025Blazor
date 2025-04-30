using BlazorApp1.Data.Auth;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorApp1.Components
{
    public partial class HolaMundo
    {
        public string mensajeMostrar { get; set; } = "";
        [Parameter]
        public string? mensaje { get; set; }


        [Parameter]
        public EventCallback<string> patata { get; set; }

        public override async Task SetParametersAsync(ParameterView parameters)
        {

            if (parameters.TryGetValue<string>(nameof(mensaje), out var value))
            {
                if (value is null)
                { mensajeMostrar = "The value of 'Param' is null. <<---------"; }
                else
                { mensajeMostrar = $"The value of 'Param' is {value}."; }
            }
            await base.SetParametersAsync(parameters);
        }

        //public void ClickAction()
        //{
        //    OnClick.Invoke("Click al boton desde el hijo con tipo Action");
        //}
        public void CerrarSesion()
        {
            tokenContainer.Clear();
            NavigationManager.NavigateTo("/");

        }
        public async void ClickCallback()
        {
            await patata.InvokeAsync("Click al boton desde el hijo con tipo Callback");

        }

        protected override void OnInitialized()
        {
            //if(mensajeMostrar == null)
                mensajeMostrar = $"Initialized at {DateTime.Now}";

            stateContainer.CambiarColor += StateHasChanged;
            tokenContainer.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            stateContainer.CambiarColor -= StateHasChanged;
            tokenContainer.OnChange -= StateHasChanged;

        }

    }
}
