[<AutoOpen>]
module MoveContainerKleisli.Types

open FsToolkit.ErrorHandling

type MoveOption =
| General
| Shag
| Shipment
| DistributionCenter

type Error =
| ValidationError
| IOError
module Error =
    let validationError = ValidationError

    let ioError = IOError

type DbConnection = string
type ContainerId = string
type LocationId = string

type MoveFuncResult = TaskResult<unit, Error>

type MoveFunc = (DbConnection * ContainerId * LocationId) -> MoveFuncResult

type MoveHandler = MoveFunc -> MoveFunc
