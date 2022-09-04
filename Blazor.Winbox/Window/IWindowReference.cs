using Microsoft.AspNetCore.Components;

namespace Blazor.Winbox;

public interface IWindowReference
{
    public Guid Id { get; }
    public Task<WindowResult> Result { get; }
    public RenderFragment RenderFragment { get; set; }
    public void Close();
    public void Close(WindowResult result);
    public void InjectRenderFragment(RenderFragment rf);
}
