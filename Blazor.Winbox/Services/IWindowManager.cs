using Microsoft.AspNetCore.Components;

namespace BlazorWinbox;

public interface IWindowManager
{
    event Action<IWindowReference> OnWindowInstanceAdded;
    event Action<IWindowReference, WindowResult> OnWindowCloseRequested;

    /// <summary>
    /// Open a window of any type
    /// </summary>
    /// <typeparam name="TComponent">Component type(must be blazor component)</typeparam>
    /// <param name="title">Optional title to appear on window title bar</param>
    /// <param name="windowParameters">Parameters that component has
    /// <para>should be a Key Value Pairs of parameters names and values</para>
    /// </param>
    /// <param name="windowOptions">Options of window</param>
    /// <returns>a window reference</returns>
    IWindowReference Open<TComponent>(string title = null, WindowParameters windowParameters = null, WindowOptions windowOptions = null) where TComponent : ComponentBase;

    /// <summary>
    /// Open a window of any type and get the result data returned by the window
    /// </summary>
    /// <typeparam name="TComponent">Component type(must be blazor component)</typeparam>
    /// <param name="title">Optional title to appear on window title bar</param>
    /// <param name="windowParameters">Parameters that component has
    /// <para>should be a Key Value Pairs of parameters names and values</para>
    /// </param>
    /// <param name="windowOptions">Options of window</param>
    /// <returns>data of the <see cref="WindowResult"/> returned by the window on close</returns>
    Task<object> OpenReValAsync<TComponent>(string title = null, WindowParameters windowParameters = null, WindowOptions windowOptions = null) where TComponent : ComponentBase;
    void InjectComponentIntoWindow(string title, WindowOptions options);
    bool HasJsWindowReference(Guid id);
    void CloseBlzr(Guid winId, WindowResult result);
    public void Close(Guid winId, WindowResult result);
    void Fullscreen(Guid winId, bool? state = null);
    void Hide(Guid winId, bool? state = null);
    void Maximize(Guid winId, bool? state = null);
    void Minimize(Guid winId, bool? state = null);
    void Move(Guid winId, string x, string y);
    void RemoveClass(Guid winId, string cssClass);
    void Resize(Guid winId, string width, string height);
    void Restore(Guid winId);
    void SetBackground(Guid winId, string backgroundColor);
    void SetTitle(Guid winId, string title);
    void Show(Guid winId, bool? state = null);
    void ToggleClass(Guid winId, string cssClass);
    void Focus(Guid winId, bool? state = null);
    void Blur(Guid winId, bool? state = null);
    void Mount(Guid winId, ElementReference windowContent);
    void AddClass(Guid id, string cssClass);
}
