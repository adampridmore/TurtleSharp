#r "System.Windows.Forms.dll"
#r @"..\packages\FSharp.Collections.ParallelSeq.1.0.2\lib\net40\FSharp.Collections.ParallelSeq.dll"
#load "TurtleTypes.fs"
#load "Canvas.fs"
#load "Turtle.fs"

open Turtle
open Canvas

let rec drawKochSide length depth c = 
  match depth with
  | n when n <= 0 -> c |> moveForward length
  | n ->  let drawMiniKochSide = drawKochSide (length / 3.) (depth-1)
          c
          |> drawMiniKochSide
          |> turn -60.
          |> drawMiniKochSide
          |> turn 120.
          |> drawMiniKochSide
          |> turn -60.
          |> drawMiniKochSide

let canvasSize = 1024. * 4.

let sideLength = canvasSize / 1.5

let drawSnowflake depth = 
  let index = depth 

  blankCanvas canvasSize canvasSize
  |> setTurtlePos {x = canvasSize / 5. ;y=canvasSize /5.}
  |> drawKochSide sideLength depth
  |> turn 120.
  |> drawKochSide sideLength depth
  |> turn 120.
  |> drawKochSide sideLength depth
  |> saveCanvas "KochCurve" index
  |> closeCanvas

//let depth = 5

seq{0..8}
|> Seq.iter drawSnowflake 