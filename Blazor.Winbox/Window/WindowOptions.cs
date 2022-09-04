namespace Blazor.Winbox;

public class WindowOptions : BasicWindowOptions
{
    //Callback methods:
    ///// <summary>
    ///// Callback triggered when the winbox element is being created. You can modify all these winbox options from this table passed as first parameter.
    ///// </summary>
    //public Action<WindowOptions> OnCreate { get; set; }
    /// <summary>
    /// Callback triggered when the window moves. with X and Y values
    /// </summary>
    public Action<string, string> OnMove { get; set; }
    /// <summary>
    /// Callback triggered when the window resizes. with width and height
    /// </summary>
    public Action<string, string> OnResize { get; set; }
    /// <summary>
    /// Callback triggered when the window enters fullscreen.
    /// </summary>
    public Action<bool?> OnFullScreen { get; set; }
    /// <summary>
    /// Callback triggered when the window enters minimized mode.
    /// </summary>
    public Action<bool?> OnMinimize { get; set; }
    /// <summary>
    /// Callback triggered when the window enters maximize mode.
    /// </summary>
    public Action<bool?> OnMaximize { get; set; }
    /// <summary>
    /// Callback triggered when the window returns to a windowed state from a Fullscreen, Minimized or Maximized state.
    /// </summary>
    public Action OnRestore { get; set; }
    /// <summary>
    /// Callback triggered when the window is hidden with win.hide()
    /// </summary>
    public Action<bool?> OnHide { get; set; }
    /// <summary>
    /// Callback triggered when the window is shown with win.show()
    /// </summary>
    public Action<bool?> OnShow { get; set; }
    /// <summary>
    /// Callbacks triggered when the window is closing. The keyword this inside the callback function refers to the corresponding WinBox instance. Note: the event 'onclose' will be triggered right before closing and stops closing when a callback was applied and returns a truthy value.
    /// <para>takes force:bool parameter</para>
    /// <para>returns completeClose : bool</para>
    /// </summary>
    public Func<bool> OnClose { get; set; }

    /// <summary>
    /// Callbacks triggered when the window is closing. The keyword this inside the callback function refers to the corresponding WinBox instance. Note: the event 'onclose' will be triggered right before closing and stops closing when a callback was applied and returns a truthy value.
    /// <para>takes force:bool parameter</para>
    /// <para>returns completeClose : bool</para>
    /// </summary>
    public Func<Task<bool>> OnCloseAsync { get; set; }
    /// <summary>
    /// Callback triggered when a window goes into focused state. with force parameter
    /// </summary>
    public Action<bool?> OnFocus { get; set; }
    /// <summary>
    /// Callback triggered when a window lost the focused state.
    /// </summary>
    public Action<bool?> OnBlur { get; set; }
}
