using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorWinbox;

public class WinBoxWindowManager : IWindowManager
{
    private readonly IJSRuntime _js;
    private readonly Dictionary<Guid, IJSInProcessObjectReference> _windowsJsReferences;
    private readonly Dictionary<Guid, IWindowReference> _windowsBlzrReferences;


    public event Action<IWindowReference> OnWindowInstanceAdded;
    public event Action<IWindowReference, WindowResult> OnWindowCloseRequested;

    public WinBoxWindowManager(IJSRuntime js)
    {
        _js = js;
        _windowsJsReferences = new Dictionary<Guid, IJSInProcessObjectReference>();
        _windowsBlzrReferences = new Dictionary<Guid, IWindowReference>();
    }

    public IWindowReference Open<TComponent>(string title = null, WindowParameters windowParameters = null, WindowOptions windowOptions = null) where TComponent : ComponentBase
    {
        IWindowReference xWindowReference = CreateReference();
        RenderFragment xWindowContent = new(builder =>
        {
            var xAttributesCount = 0;
            builder.OpenComponent<TComponent>(xAttributesCount++);
            if (windowParameters is { Count: > 0 })
            {
                foreach (KeyValuePair<string, object> iParameter in windowParameters)
                {
                    builder.AddAttribute(xAttributesCount++, iParameter.Key, iParameter.Value);
                }
            }
            builder.CloseComponent();
        });

        RenderFragment xWindowInstance = new(builder =>
        {
            builder.OpenComponent<WindowInstance>(0);
            builder.SetKey(xWindowReference.Id);
            builder.AddAttribute(1, "Options", windowOptions);
            builder.AddAttribute(2, "Content", xWindowContent);
            builder.AddAttribute(3, "Id", xWindowReference.Id);
            builder.CloseComponent();
        });
        xWindowReference.InjectRenderFragment(xWindowInstance);
        _windowsBlzrReferences.Add(xWindowReference.Id, xWindowReference);
        OnWindowInstanceAdded?.Invoke(xWindowReference);

        return xWindowReference;
    }

    public async Task<object> OpenReValAsync<TComponent>(string title = null, WindowParameters windowParameters = null, WindowOptions windowOptions = null) where TComponent : ComponentBase
    {
        IWindowReference xWindowReference = Open<TComponent>(title, windowParameters, windowOptions);
        WindowResult xResult = await xWindowReference.Result;

        if (xResult?.Cancelled is not false)
        {
            return null;
        }
        else
        {
            return xResult.Data;
        }
    }

    public virtual IWindowReference CreateReference()
    {
        return new WinBoxWindowReference(Guid.NewGuid());
    }

    public void InjectComponentIntoWindow(string title, WindowOptions options)
    {
        if (!string.IsNullOrEmpty(title))
        {
            options.Title = title;
            title = null;
        }
        BasicWindowOptions xJsWindowOptions = BasicWindowOptions.CreateCopy(options);
        IJSInProcessRuntime xJsInProcess = (IJSInProcessRuntime)_js;
        IJSObjectReference xJsWindowReference = xJsInProcess.Invoke<IJSObjectReference>("WinBoxWindowManager.OpenWindow", title, xJsWindowOptions);
        _windowsJsReferences.Add(Guid.Parse(options.Id), xJsWindowReference as IJSInProcessObjectReference);
    }

    public bool HasJsWindowReference(Guid id)
    {
        return _windowsJsReferences.ContainsKey(id);
    }

    public void CloseBlzr(Guid winId, WindowResult result)
    {

        _windowsBlzrReferences.TryGetValue(winId, out IWindowReference xWindowReference);
        if (xWindowReference is not null)
        {
            xWindowReference.Close(result);
            OnWindowCloseRequested.Invoke(xWindowReference, result);
            _windowsBlzrReferences.Remove(winId);
        }

        _windowsJsReferences.TryGetValue(winId, out IJSInProcessObjectReference xWindowJsReference);
        if (xWindowJsReference is not null)
        {
            _windowsJsReferences.Remove(winId);
        }
    }

    public void Close(Guid winId, WindowResult result)
    {

        _windowsBlzrReferences.TryGetValue(winId, out IWindowReference xWindowReference);
        if (xWindowReference is not null)
        {
            xWindowReference.Close(result);
            OnWindowCloseRequested.Invoke(xWindowReference, result);
            _windowsBlzrReferences.Remove(winId);
        }
        //to close  window in javascript
        _windowsJsReferences.TryGetValue(winId, out IJSInProcessObjectReference xWindowJsReference);
        if (xWindowJsReference is not null)
        {
            _windowsJsReferences[winId].InvokeVoid("close", true);
            _windowsJsReferences.Remove(winId);
        }
    }

    public void Fullscreen(Guid winId, bool? state = null)
    {
        _windowsJsReferences.TryGetValue(winId, out IJSInProcessObjectReference xWindowJsReference);
        if (xWindowJsReference is not null)
        {
            _windowsJsReferences[winId].InvokeVoid("fullscreen", state);
        }
    }

    public void Hide(Guid winId, bool? state = null)
    {
        _windowsJsReferences.TryGetValue(winId, out IJSInProcessObjectReference xWindowJsReference);
        if (xWindowJsReference is not null)
        {
            _windowsJsReferences[winId].InvokeVoid("hide", state);
        }
    }

    public void Maximize(Guid winId, bool? state = null)
    {
        _windowsJsReferences.TryGetValue(winId, out IJSInProcessObjectReference xWindowJsReference);
        if (xWindowJsReference is not null)
        {
            _windowsJsReferences[winId].InvokeVoid("maximize", state);
        }
    }

    public void Minimize(Guid winId, bool? state = null)
    {
        _windowsJsReferences.TryGetValue(winId, out IJSInProcessObjectReference xWindowJsReference);
        if (xWindowJsReference is not null)
        {
            _windowsJsReferences[winId].InvokeVoid("minimize", state);
        }
    }

    public void Move(Guid winId, string x, string y)
    {
        _windowsJsReferences.TryGetValue(winId, out IJSInProcessObjectReference xWindowJsReference);
        if (xWindowJsReference is not null)
        {
            _windowsJsReferences[winId].InvokeVoid("move", x, y);
        }
    }

    public void RemoveClass(Guid winId, string cssClass)
    {
        _windowsJsReferences.TryGetValue(winId, out IJSInProcessObjectReference xWindowJsReference);
        if (xWindowJsReference is not null)
        {
            _windowsJsReferences[winId].InvokeVoid("removeClass", cssClass);
        }
    }

    public void AddClass(Guid winId, string cssClass)
    {
        _windowsJsReferences.TryGetValue(winId, out IJSInProcessObjectReference xWindowJsReference);
        if (xWindowJsReference is not null)
        {
            _windowsJsReferences[winId].InvokeVoid("addClass", cssClass);
        }
    }

    public void Resize(Guid winId, string width, string height)
    {
        _windowsJsReferences.TryGetValue(winId, out IJSInProcessObjectReference xWindowJsReference);
        if (xWindowJsReference is not null)
        {
            _windowsJsReferences[winId].InvokeVoid("resize", width, height);
        }
    }

    public void Restore(Guid winId)
    {
        _windowsJsReferences.TryGetValue(winId, out IJSInProcessObjectReference xWindowJsReference);
        if (xWindowJsReference is not null)
        {
            _windowsJsReferences[winId].InvokeVoid("restore");
        }
    }

    public void SetBackground(Guid winId, string backgroundColor)
    {
        _windowsJsReferences.TryGetValue(winId, out IJSInProcessObjectReference xWindowJsReference);
        if (xWindowJsReference is not null)
        {
            _windowsJsReferences[winId].InvokeVoid("setBackground", backgroundColor);
        }
    }

    public void SetTitle(Guid winId, string title)
    {
        _windowsJsReferences.TryGetValue(winId, out IJSInProcessObjectReference xWindowJsReference);
        if (xWindowJsReference is not null)
        {
            _windowsJsReferences[winId].InvokeVoid("setTitle", title);
        }
    }

    public void Show(Guid winId, bool? state = null)
    {
        _windowsJsReferences.TryGetValue(winId, out IJSInProcessObjectReference xWindowJsReference);
        if (xWindowJsReference is not null)
        {
            _windowsJsReferences[winId].InvokeVoid("show", state);
        }
    }

    public void ToggleClass(Guid winId, string cssClass)
    {
        _windowsJsReferences.TryGetValue(winId, out IJSInProcessObjectReference xWindowJsReference);
        if (xWindowJsReference is not null)
        {
            _windowsJsReferences[winId].InvokeVoid("toggleClass", cssClass);
        }
    }

    public void Focus(Guid winId, bool? state = null)
    {
        _windowsJsReferences.TryGetValue(winId, out IJSInProcessObjectReference xWindowJsReference);
        if (xWindowJsReference is not null)
        {
            _windowsJsReferences[winId].InvokeVoid("focus", state);
        }
    }

    public void Blur(Guid winId, bool? state = null)
    {
        _windowsJsReferences.TryGetValue(winId, out IJSInProcessObjectReference xWindowJsReference);
        if (xWindowJsReference is not null)
        {
            _windowsJsReferences[winId].InvokeVoid("blur", state);
        }
    }

    public void Mount(Guid winId, ElementReference windowContent)
    {
        _windowsJsReferences.TryGetValue(winId, out IJSInProcessObjectReference xWindowJsReference);
        if (xWindowJsReference is not null)
        {
            _windowsJsReferences[winId].InvokeVoid("mount", windowContent);
        }
    }
}
