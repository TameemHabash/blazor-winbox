using Microsoft.AspNetCore.Components;

namespace BlazorWinbox;

/// <summary>
/// Windows reference that implements <see cref="IWindowReference" ></see> with WinBox.js needed, for more information visit `https://github.com/nextapps-de/winbox`
/// </summary>
public class WinBoxWindowReference : IWindowReference
{
    private readonly TaskCompletionSource<WindowResult> _resultCompletion = new();

    public WinBoxWindowReference(Guid elementId)
    {
        Id = elementId;
        Result = _resultCompletion.Task;
    }

    public Guid Id { get; }
    public RenderFragment RenderFragment { get; set; }
    public Task<WindowResult> Result { get; }
    public void Close()
    {
        Close(WindowResult.Cancel());
    }

    public void Close(WindowResult result)
    {
        _resultCompletion.TrySetResult(result);
    }

    public void InjectRenderFragment(RenderFragment rf)
    {
        RenderFragment = rf;
    }
}
