using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Components
{
    public partial class HolaMundo
    {
        public string mensajeMostrar { get; set; } = "";
        [Parameter]
        public string? mensaje { get; set; }

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

        protected override void OnInitialized()
        {
            //if(mensajeMostrar == null)
                mensajeMostrar = $"Initialized at {DateTime.Now}";
        }


    }
}
