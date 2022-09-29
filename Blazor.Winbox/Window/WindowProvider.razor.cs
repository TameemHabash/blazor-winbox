using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;

namespace BlazorWinbox;

public partial class WindowProvider : IDisposable
{
    [Inject] public IWindowManager WindowManager { get; set; }
    [Parameter] public GlobalWindowOptions GlobalWindowsOptions { get; set; } = new();

    private readonly Collection<IWindowReference> _windows = new();
    private readonly NotAllowToUse _notAllowToUse = new();

    protected override void OnInitialized()
    {
        WindowManager.OnWindowInstanceAdded += AddInstance;
        WindowManager.OnWindowCloseRequested += RemoveInstance;
    }

    private void AddInstance(IWindowReference window)
    {
        _windows.Add(window);
        StateHasChanged();
    }

    private void RemoveInstance(IWindowReference window, WindowResult result)
    {
        IWindowReference xWindow = GetWindowReference(window.Id);
        if (xWindow != null)
        {
            _windows.Remove(window);
            StateHasChanged();
        }
    }
    private IWindowReference GetWindowReference(Guid id)
    {
        return _windows.SingleOrDefault(x => x.Id == id);
    }

    public void Dispose()
    {
        if (WindowManager is not null)
        {
            WindowManager.OnWindowInstanceAdded -= AddInstance;
            WindowManager.OnWindowCloseRequested -= RemoveInstance;
        }
    }

    /// <summary>
    /// This class is used as cascading value to let Blazor ignores rerendering windows that haven't changed when re-render windows list. This is achieved by using @key directive attribute
    /// </summary>
    private class NotAllowToUse
    {

    }
}
