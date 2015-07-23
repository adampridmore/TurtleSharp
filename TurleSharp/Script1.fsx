#r "System.Windows.Forms.dll"
#load "Dragon.fs"
#load "TurtleTypes.fs"
#load "Turtle.fs"
#load "Canvas.fs"

open System.Drawing
open Dragon
open TurtleTypes
open Turtle
open Canvas

//dragon 3
//|> Seq.map (sprintf "%A")
//|> Seq.reduce (+)

let closeCanvas (canvas:Canvas) = 
  canvas.g.Dispose()

let saveCanvas (canvas:Canvas) = 
  let filename = System.IO.Path.GetTempFileName() + ".png"

  printf "%s" filename

  canvas.i.Save(filename, Imaging.ImageFormat.Png)

  System.Diagnostics.Process.Start(filename) |> ignore

  canvas

//let canvasWidth = 640.
//let canvasHeight = 480.

let canvasWidth = 4000.
let canvasHeight = 4000.

let dragonSequence = Dragon.dragon 15

let doTurn (turn) canvas = 
  match turn with 
  | L -> turnLeft canvas
  | R -> turnRight canvas


let dragonForward = moveForward 5.

Seq.unfold (function (canvas,dragonTail) -> match dragonTail with
                                            |[] -> None
                                            | hd::tail -> let nextCanvas = canvas 
                                                                           |> dragonForward
                                                                           |> doTurn hd 
                                                          Some(nextCanvas, (nextCanvas, tail))
            ) (blankCanvas canvasWidth canvasHeight, dragonSequence)
|> Seq.last
|> dragonForward
|> saveCanvas
|> closeCanvas

//|> showCanvas
//|> runApplicaiton