using Microsoft.AspNetCore.Components;

namespace BlazorWinbox;

public interface IWindowReference
{
    public Guid Id { get; }
    public Task<WindowResult> Result { get; }
    public RenderFragment RenderFragment { get; set; }
    public void Close();
    public void Close(WindowResult result);
    public void InjectRenderFragment(RenderFragment rf);
}
