open MoveContainerKleisli
open FsToolkit.ErrorHandling
open System

// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"


let result = testHandler3 earlyReturn ("db", "containerId", "locationId")

taskResult {
    let! res = result
    printfn "Result: %A" res
    return ()
} |> TaskResult.teeError (fun err -> printfn "Error: %A" err)
|> ignore

Console.ReadLine() |> ignore