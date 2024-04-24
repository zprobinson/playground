[<AutoOpen>]
module MoveContainerKleisli.Core

open FsToolkit.ErrorHandling

let compose (handler1: MoveHandler) (handler2: MoveHandler) : MoveHandler =
    fun (final: MoveFunc) ->
        let func = final |> handler2 |> handler1

        func

        // fun (db: DbConnection, containerId: string, locationId: string) ->
        //     // TODO: What is ctx.Response.HasStarted?
        //     // https://github.com/giraffe-fsharp/Giraffe/blob/master/src/Giraffe/Core.fs#L99
        //     match true with
        //     | true -> final (db, containerId, locationId)
        //     | false -> func (db, containerId, locationId)

let (>=>) = compose

let earlyReturn: MoveFunc = fun _ -> TaskResult.ok ()

let testHandler1: MoveHandler =
    fun next (db, containerId, locationId) ->
        taskResult {
            return! next (db, containerId, locationId)
        }

let testHandler2: MoveHandler =
    fun next (db, containerId, location) ->
        TaskResult.error ValidationError

let testHandler3: MoveHandler = testHandler1 >=> testHandler2