using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.ComponentModel;
using System.Reflection;

namespace Blazor.Winbox;

/// <summary>
/// All window options that contains only data properties (does not contains Actions or Funcs) so it can be serialized to javascript object by the framework
/// </summary>
public class BasicWindowOptions : GlobalWindowOptions
{
    // configuration:
    /// <summary>
    /// query elements by context or just to identify the corresponding window instance. If no ID was set it will automatically create one for you.
    /// </summary>
    public string Id { get; set; }
    ///// <summary>
    ///// Mount an element (widget, template, etc.) to the window body.
    ///// </summary>
    [Obsolete("Do not use this in your code, it is allowed to be used internally by Window")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ElementReference Mount { get; set; }

    // appearance:
    /// <summary>
    /// The window title.
    /// <para>This is overridden by Title in Window component</para>
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// Title bar height
    /// </summary>
    public double? Header { get; set; }
    /// <summary>
    /// Make the titlebar icon visible and set the image source url.
    /// </summary>
    public string Icon { get; set; }

    // initial state:
    /// <summary>
    /// Automatically toggles the window into maximized state when created.
    /// <para>Default is false</para>
    /// </summary>
    public bool? Max { get; set; } = false;
    /// <summary>
    /// Automatically toggles the window into minimized state when created.
    /// <para>Default is false</para>
    /// </summary>
    public bool? Min { get; set; } = false;
    /// <summary>
    /// Automatically toggles the window into hidden state when created.
    /// <para>Default is false</para>
    /// </summary>
    public bool? Hidden { get; set; } = false;

    [Obsolete("Do not use this in your code, it is allowed to be used internally by Window")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string XCloseHandlerName { get; set; }

    [Obsolete("Do not use this in your code, it is allowed to be used internally by Window")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public DotNetObjectReference<WindowInstance> BlazorWindowInstanceReference { get; set; }

    [Obsolete("Do not use this in your code, it is allowed to be used internally by Window")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string OnCloseHandlerName { get; set; }

    internal static BasicWindowOptions CreateCopy(BasicWindowOptions basicWindowOptions)
    {
        ArgumentNullException.ThrowIfNull(basicWindowOptions, nameof(basicWindowOptions));

        BasicWindowOptions xReVal = new();
        Type xType = typeof(BasicWindowOptions);
        foreach (PropertyInfo iProp in xType.GetProperties())
        {
            PropertyInfo xPi = xType.GetProperty(iProp.Name);
            if (xPi is not null && iProp.CanWrite)
            {
                iProp.SetValue(xReVal, xPi.GetValue(basicWindowOptions, null), null);
            }
        }

        return xReVal;
    }
}
