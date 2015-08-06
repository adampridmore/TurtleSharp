#r "System.Windows.Forms.dll"
#r @"..\packages\FSharp.Collections.ParallelSeq.1.0.2\lib\net40\FSharp.Collections.ParallelSeq.dll"
#load "TurtleTypes.fs"
#load "Canvas.fs"
#load "Turtle.fs"

open Turtle
open Canvas

let rec drawSide length depth c = 
  let splitLength = length / 3.
  
  match depth with
  | 0 ->  c
          |> moveForward splitLength
          |> turn -60.
          |> moveForward splitLength
          |> turn 120.
          |> moveForward splitLength
          |> turn -60.
          |> moveForward splitLength
  | x ->  c
          |> drawSide splitLength (x-1)
          |> turn -60.
          |> drawSide splitLength (x-1)
          |> turn 120.
          |> drawSide splitLength (x-1)
          |> turn -60.
          |> drawSide splitLength (x-1)

let depth = 5

let sideLength = 5000.

blankCanvas 10240.0 10240.0
|> turn 90.
|> drawSide sideLength depth
|> turn 120.
|> drawSide sideLength depth
|> turn 120.
|> drawSide sideLength depth
|> turn 120.
//|> showCanvas
|> saveCanvas 1
|> closeCanvas

