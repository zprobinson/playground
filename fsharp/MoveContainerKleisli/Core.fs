[<AutoOpen>]
module MoveContainerKleisli.Core

open FsToolkit.ErrorHandling

let compose (handler1: MoveHandler) (handler2: MoveHandler) : MoveHandler =
    fun (final: MoveFunc) ->
        final |> handler2 |> handler1

let (>=>) = compose

let private earlyReturnWith (x: MoveFuncResult) =
    fun (_: DbConnection * ContainerId * LocationId) ->
        x

let earlyReturn: MoveFunc = earlyReturnWith <| TaskResult.ok ()
let earlyReturnError (error: Error): MoveFunc =
    earlyReturnWith <| TaskResult.error error


let testHandler1: MoveHandler =
    fun next (db, containerId, locationId) ->
        taskResult {
            return! next (db, containerId, locationId)
        }

let testHandler2: MoveHandler =
    fun next ctx ->
        earlyReturnError Error.ioError ctx

let testHandler3: MoveHandler = testHandler1 >=> testHandler2