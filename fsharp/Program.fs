open MoveContainerKleisli
open FsToolkit.ErrorHandling


let result = testHandler3 earlyReturn ("db", "containerId", "locationId")

result
|> TaskResult.foldResult
    (fun _ -> printfn "Success!")
    (printfn "Error: %A")
|> ignore