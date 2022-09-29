using Blazor.Winbox.Wasm.Windows;
using BlazorWinbox;
using Microsoft.AspNetCore.Components;

namespace Blazor.Winbox.Wasm.Pages
{
    public partial class MultiWindowsUsage : ComponentBase
    {
        [Inject] public IWindowManager WindowManager { get; set; }

        private int _InitialCount = 0;
        private async Task OpenWindowWithResultAsync()
        {
            //You can create parameters like this
            //WindowParameters xWindowParameters = new()
            //{
            //    { nameof(ReturnValueWindow.CurrentCount), _InitialCount }
            //};
            //Or like this
            WindowParameters xWindowParameters = new();
            xWindowParameters.Add(nameof(ReturnValueWindow.CurrentCount), _InitialCount);

            WindowOptions xWindowOptions = new() { Height = "400px", Width = "350px", Icon = "./HITIcon.png" };

            var xCurrentCounter = await WindowManager.OpenReValAsync<ReturnValueWindow>("ReVal Window", xWindowParameters, xWindowOptions);

            Console.WriteLine($"currentCounter: {xCurrentCounter}");
        }
        private void OpenOptionsWindow()
        {
            WindowManager.Open<OptionsWindow>("Options window");
        }
    }
}
