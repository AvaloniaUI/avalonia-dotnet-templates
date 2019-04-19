// Copyright (c) The Avalonia Project. All rights reserved.
// Licensed under the MIT license. See licence.md file in the project root for full license information.

namespace AvaloniaAppTemplate

open System
open Avalonia.Controls
open Avalonia.Controls.Templates
open AvaloniaAppTemplate.ViewModels

type ViewLocator () =
    interface IDataTemplate with
        member __.SupportsRecycling with get() = false
        member __.Match data = data :? ViewModelBase
        member __.Build data : IControl =
            let name = data.GetType().FullName.Replace("ViewModel", "View")
            let _type = Type.GetType name
            match _type with
            | null -> TextBlock (Text = "Not Found: " + name) :> IControl
            | _    -> (Activator.CreateInstance _type) :?> IControl
