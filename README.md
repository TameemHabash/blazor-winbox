# Blazor Winbox

Multiple Windows Library that wraps [WinBox.js](https://github.com/nextapps-de/winbox) in Blazor Components.

*Windows management and rendering processes were inspired  by [MudBlazor](https://mudblazor.com) dialogs*
<br />
<br />

## Compatibility
Only Blazor WASM (client-side) .NET 6 applications are currently supported. This library is not tested on Blazor Server applications.
<br />
<br />

## Getting Started
### Installation:
The Nuget package page can be found [here](https://www.nuget.org/packages/Blazor.Winbox/)

To install `Blazor.Winbox` from Nuget Gallery simply search for its name and install the latest version

<br />

##### Or using Package Manager run the following command
```bash
Install-Package Blazor.Winbox
```
##### Or using .NET CLI run the following command
```bash
dotnet add package Blazor.Winbox
```

### Configurations:
* Import `BlazorWinbox` by adding the following in `_Imports.razor`
```
@using BlazorWinbox
```

* Register Service in `Program` Class:
 ```c#
    using BlazorWinbox; 


    builder.Services.AddBlazorWinbox();
 ```
 * Add script references to `index.html` after Blazor script
  ```html
  <script src="_content/Blazor.Winbox/winbox.bundle.min.js"></script>
  <script src="_content/Blazor.Winbox/BlazorWinbox.min.js"></script>
  ```
  * Add the following component to your `MainLayout.razor` 
  ```html
<WindowProvider />
  ```

### Open a window
 Create a `window` component. Let's use `Counter` template as example:
```html
<Window>

    <h1>Counter</h1>

    <p role="status">Current count: @currentCount</p>

    <button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

</Window>

```
```c#
@code {

    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```
**Note that whole window content should surrounded with `<Window>` Tag**

<br/>

To open window inject `IWindowManager` service and use `Open<TComponent>()` method:

```c#
//Use in razor
@inject IWindowManager windowManager
//OR in C# 
[Inject] public IWindowManager WindowManager { get; set; }

//Open a window
void OpenCounter(){
    IWindowReference windowReference = WindowManager.Open<Counter>();
}
```

![Preview](./Docs/BlazorWinbox.gif)