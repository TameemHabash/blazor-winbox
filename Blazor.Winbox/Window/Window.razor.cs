using Microsoft.AspNetCore.Components;

namespace BlazorWinbox;

public partial class Window : ComponentBase
{
    [Inject] public IWindowManager WindowManager { get; set; }

    /// <summary>
    /// This overrides Title in <see cref="WindowOptions" />
    /// </summary>
    [Parameter] public string Title { get; set; }
    /// <summary>
    /// Window inner body css class
    /// </summary>
    [Parameter] public string Class { get; set; }
    [Parameter] public RenderFragment ChildContent { get; set; }
    [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> UserAttributes { get; set; } = new Dictionary<string, object>();
    [CascadingParameter] public WindowInstance WindowInstance { get; set; }

    private ElementReference _WindowRef;

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            WindowInstance.Options.Mount = _WindowRef;
            WindowManager.InjectComponentIntoWindow(Title, WindowInstance.Options);
        }
    }
}
