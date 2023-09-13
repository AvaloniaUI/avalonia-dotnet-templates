namespace AvaloniaTest

open System
open Avalonia.Controls
open Avalonia.Controls.Templates
open AvaloniaTest.ViewModels

type ViewLocator() =
    interface IDataTemplate with
        
        member this.Build(data) =
            if isNull data then
                null
            else    
                let name = data.GetType().FullName.Replace("ViewModel", "View", StringComparison.Ordinal)
                let typ = Type.GetType(name)
                if isNull typ then
                    upcast TextBlock(Text = sprintf "Not Found: %s" name)
                else
                    downcast Activator.CreateInstance(typ)

        member this.Match(data) = data :? ViewModelBase
