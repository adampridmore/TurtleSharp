#r "System.Windows.Forms.dll"
#r @"..\packages\FSharp.Collections.ParallelSeq.1.0.2\lib\net40\FSharp.Collections.ParallelSeq.dll"
#load "TurtleTypes.fs"
#load "Canvas.fs"
#load "Turtle.fs"

open Turtle
open Canvas

let rec drawKockSide length depth c = 
  let splitLength = length / 3.
  
  let moveOperation = match depth with
                      | n when n <= 0 -> moveForward splitLength
                      | n -> drawKockSide splitLength (n-1)

  c
  |> moveOperation
  |> turn -60.
  |> moveOperation
  |> turn 120.
  |> moveOperation
  |> turn -60.
  |> moveOperation

let depth = 5

let sideLength = 1600.

blankCanvas (1024.*4.) (1024.*4.)
|> turn 90.
|> drawKockSide sideLength depth
|> turn 120.
|> drawKockSide sideLength depth
|> turn 120.
|> drawKockSide sideLength depth
|> saveCanvas 1
|> closeCanvas
