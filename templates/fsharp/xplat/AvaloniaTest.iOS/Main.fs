open UIKit
// This is the main entry point of the application.
let [<EntryPoint>] Main(args: string array) =
    // if you want to use a different Application Delegate class from "AppDelegate"
    // you can specify it here.
    UIApplication.Main(args, null, typeof<AvaloniaTest.iOS.AppDelegate>)
    0