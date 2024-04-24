open MoveContainerKleisli
open FsToolkit.ErrorHandling
open System


let result = testHandler3 earlyReturn ("db", "containerId", "locationId")

taskResult {
    let! res = result
    printfn "Result: %A" res
    return ()
}
|> TaskResult.teeError (fun err -> printfn "Error: %A" err)
|> ignore

Console.ReadLine() |> ignore