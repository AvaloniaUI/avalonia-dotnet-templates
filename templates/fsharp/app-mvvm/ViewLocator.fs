namespace AvaloniaAppTemplate

open System
#if (!ReactiveUIToolkitChosen)
open System.ComponentModel
#endif
open Avalonia.Controls
open Avalonia.Controls.Templates
#if (ReactiveUIToolkitChosen)
open AvaloniaAppTemplate.ViewModels
#endif

type ViewLocator() =
    interface IDataTemplate with
        
        member this.Build(data) =
            let name = data.GetType().FullName.Replace("ViewModel", "View")
            let typ = Type.GetType(name)
            if isNull typ then
                upcast TextBlock(Text = sprintf "Not Found: %s" name)
            else
                downcast Activator.CreateInstance(typ)
                
#if (ReactiveUIToolkitChosen)
        member this.Match(data) = data :? ViewModelBase
#else
        member this.Match(data) = data :? INotifyPropertyChanged
#endif
