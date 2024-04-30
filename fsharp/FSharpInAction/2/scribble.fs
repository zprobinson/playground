module Two.Scribble

// Declarative over Imperative
let getEvenNumbers = Seq.filter (fun number -> number % 2 = 0)

let evenNumbers = getEvenNumbers [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

// Composition over Inheritance
let squareNumbers = Seq.map (fun x -> x * x)

let geteventNumbersThenSquare = getEvenNumbers >> squareNumbers

// Train Stock and Inventory Domain
open System

type Feature = Quiet | Wifi | Toilet
type CarriageClass = First | Second

type CarriageKind =
    | Passenger of CarriageClass
    | Buffet of {| ColdFood : bool; HotFood : bool |}

type CarriageNumber = CarriageNumber of int

type Carriage =
    { Number : CarriageNumber
      Kind : CarriageKind
      Features : Feature Set
      NumberOfSeats : int }

type TrainId = TrainId of string
type Station = Station of string
type Stop = Station * TimeOnly

type Train =
    { Id : TrainId
      Carriages : Carriage list
      Origin : Stop
      Stops : Stop list
      Destination : Stop
      DriverChange : Station option }

// Writing your first F#
let run () =
    let name = "zach"
    let time = DateTime.UtcNow
    printfn $"Hello from F#! My name is {name}, the time is {time}"