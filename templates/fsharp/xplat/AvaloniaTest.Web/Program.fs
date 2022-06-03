open Microsoft.AspNetCore.Components.WebAssembly.Hosting
open Microsoft.AspNetCore.Components

open Avalonia.ReactiveUI
open Avalonia.Web.Blazor

open Bolero
open Bolero.Html

open AvaloniaTest

type MainView() =
  inherit Component()

  override _.OnInitialized() =
    base.OnInitialized()

    WebAppBuilder
      .Configure<App>()
      .UseReactiveUI()
      .SetupWithSingleViewLifetime()
    |> ignore


  override _.Render() = comp<AvaloniaView> { attr.empty () }

let builder = WebAssemblyHostBuilder.CreateDefault([||])
builder.RootComponents.Add<MainView>("#app")

builder.Build().RunAsync()
|> Async.AwaitTask
|> Async.Start
