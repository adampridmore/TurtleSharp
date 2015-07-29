#r "System.Windows.Forms.dll"
#r @"..\packages\FSharp.Collections.ParallelSeq.1.0.2\lib\net40\FSharp.Collections.ParallelSeq.dll"

#load "Dragon.fs"
#load "TurtleTypes.fs"
#load "Canvas.fs"
#load "Turtle.fs"


open Dragon
open TurtleTypes
open Turtle
open Canvas
open System.IO
open System.Drawing
open FSharp.Collections.ParallelSeq

//dragon 3
//|> Seq.map (sprintf "%A")
//|> Seq.reduce (+)

let closeCanvas (canvas:Canvas) = 
  canvas.g.Dispose()
  canvas.i.Dispose()

let tmpFolder = @"C:\Temp\Dragon"
System.IO.Directory.CreateDirectory (tmpFolder) |> ignore

let saveCanvas index (canvas:Canvas) = 
  let imageFormat = Imaging.ImageFormat.Bmp

  let filename = sprintf "Dragon_%d.%A" index imageFormat
  let fullFileName = Path.Combine(tmpFolder,filename) //System.IO.Path.GetTempFileName()

  printf "%s" fullFileName

  canvas.i.Save(fullFileName, imageFormat)

  System.Diagnostics.Process.Start(fullFileName) |> ignore

  canvas

//let canvasWidth = 640.
//let canvasHeight = 480.

// Full HD
//let canvasWidth = 1920.
//let canvasHeight = 1080.

let canvasWidth = 1920. *2.
let canvasHeight = 1080. * 2.

// Full 4K
//let canvasWidth = 3840.
//let canvasHeight = 2160.

let dragonSequence = Dragon.dragon 23
let sequenceLength = dragonSequence |> Seq.length

let renderDragon turnAmount index = 
  let toColor i = 
    let colorList = [
      Color.Red; 
      Color.Blue;
      Color.Green;
      Color.Yellow;
    ]

    let colorIndex = (i / (sequenceLength / colorList.Length) ) % colorList.Length
    colorList.[colorIndex]

//    let r = i % 256
//    let g = (i / 256) % 256
//    let b = (i / (256 * 256)) % 256
//    Color.FromArgb(r,g,b)

  let doTurn t canvas = 
    match t  with 
    | L -> canvas |> turn -turnAmount
    | R -> canvas |> turn turnAmount

  let startDistance = 1.
  let dragonForward = moveForward startDistance

  Seq.unfold (function (canvas,dragonTail, index) ->  match dragonTail with
                                                      | [] -> None
                                                      | hd::tail -> let nextCanvas = 
                                                                      canvas 
                                                                      |> changeColor (toColor index)
                                                                      |> dragonForward
                                                                      |> doTurn hd 
                                                                    Some(nextCanvas, (nextCanvas, tail, index+1))
              ) (blankCanvas canvasWidth canvasHeight, dragonSequence, 0)
  |> Seq.last
  |> dragonForward
  |> saveCanvas index
  |> closeCanvas
  //|> showCanvas
  //|> runApplicaiton


Seq.singleton 9000
//seq{0..1000..18000} 
|> Seq.map (fun index -> index, ((index |> float) / 100.))
|> PSeq.iter (fun (index, angle) -> renderDragon angle index)
