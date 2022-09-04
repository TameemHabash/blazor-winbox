using Microsoft.AspNetCore.Components;

namespace Blazor.Winbox;

public class GlobalWindowOptions
{
    // configuration:
    /// <summary>
    /// Set the initial z-index of the window to this value (will be increased automatically when unfocused/focused).
    /// </summary>
    public int? Index { get; set; }
    /// <summary>
    /// The root is the unique element in a document where the window will append to. In most cases that is usually the document.body which is the default root. Multiple roots at the same time are just partially supported (they share the same viewport actually).
    /// <para>Defualt is 'document.body' </para>
    /// </summary>
    public ElementReference? Root { get; set; }
    /// <summary>
    /// Add one or more classnames to the window (multiple classnames as array or separated with whitespaces e.g. "class-a class-b"). Used to define custom styles in css, query elements by context (also within CSS) or just to tag the corresponding window instance.
    ///<para>WinBox provides you some useful Built-in Control Classes to easily setup a custom configurations:</para>
    /// <list type="table">
    ///    <item>
    ///        <term>no-animation</term>
    ///        <description>Disables the windows transition animation</description>
    ///    </item>
    ///    <item>
    ///        <term>no-shadow</term>
    ///        <description>Disables the windows drop shadow</description>
    ///    </item>
    ///    <item>
    ///        <term>no-header</term>
    ///        <description>Hide the window header incl. title and toolbar</description>
    ///    </item>
    ///    <item>
    ///        <term>no-min</term>
    ///        <description>Hide the minimize icon</description>
    ///    </item>
    ///    <item>
    ///        <term>no-max</term>
    ///        <description>Hide the maximize icon</description>
    ///    </item>
    ///    <item>
    ///        <term>no-full</term>
    ///        <description>Hide the fullscreen icon</description>
    ///    </item>
    ///    <item>
    ///        <term>no-close</term>
    ///        <description>Hide the close icon</description>
    ///    </item>
    ///    <item>
    ///        <term>no-resize</term>
    ///        <description>Disables the window resizing capability</description>
    ///    </item>
    ///    <item>
    ///        <term>no-move</term>
    ///        <description>Disables the window moving capability</description>
    ///    </item>
    ///</list>
    /// </summary>
    public string Class { get; set; }

    // appearance:
    /// <summary>
    /// Set the background of the window (supports all CSS styles which are also supported by the style-attribute "background", e.g. colors, transparent colors, hsl, gradients, background images)
    /// </summary>
    public string Background { get; set; }
    /// <summary>
    /// Set the border width of the window (supports all the browsers css units).
    /// </summary>
    public string Border { get; set; }
    //public string Icon { get; set; }

    // initial state:
    /// <summary>
    /// Shows the window as modal.
    /// <para>Default is false</para>
    /// </summary>
    public bool? Modal { get; set; } = false;

    // dimension:
    /// <summary>
    /// Set the initial width of the window (supports units "px" and "%")
    /// </summary>
    public string Width { get; set; }
    /// <summary>
    /// Set the initial height of the window (supports units "px" and "%")
    /// </summary>
    public string Height { get; set; }
    /// <summary>
    /// Set the minimal width of the window (supports units "px" and "%"). Should be at least the height of the window header title bar.
    /// </summary>
    public string MinWidth { get; set; }
    /// <summary>
    /// Set the minimal height of the window (supports units "px" and "%"). Should be at least the height of the window header title bar.
    /// </summary>
    public string MinHeight { get; set; }
    /// <summary>
    /// Set the maximum width of the window (supports units "px" and "%").
    /// </summary>
    public string MaxWidth { get; set; }
    /// <summary>
    /// Set the maximum height of the window (supports units "px" and "%").
    /// </summary>
    public string MaxHeight { get; set; }
    /// <summary>
    /// Automatically size the window to fit the window contents.
    /// </summary>
    public bool? AutoSize { get; set; }

    // position:
    /// <summary>
    /// Set the initial position of the window (supports: "right", "center", units "px" and "%").
    /// <para>Default is 'center'</para>
    /// </summary>
    public string X { get; set; }
    /// <summary>
    /// Set the initial position of the window (supports: "bottom", "center", units "px" and "%").
    /// <para>Default is 'center'</para>
    /// </summary>
    public string Y { get; set; }


    /// <summary>
    /// Set or limit the viewport of the window's available area (supports units "px" and "%"). Also used for custom splitscreen configurations.
    /// </summary>
    public string Top { get; set; }

    /// <summary>
    /// Set or limit the viewport of the window's available area (supports units "px" and "%"). Also used for custom splitscreen configurations.
    /// </summary>
    public string Bottom { get; set; }

    /// <summary>
    /// Set or limit the viewport of the window's available area (supports units "px" and "%"). Also used for custom splitscreen configurations.
    /// </summary>
    public string Right { get; set; }

    /// <summary>
    /// Set or limit the viewport of the window's available area (supports units "px" and "%"). Also used for custom splitscreen configurations.
    /// </summary>
    public string Left { get; set; }
}
