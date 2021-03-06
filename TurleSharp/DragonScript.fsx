﻿#r "System.Windows.Forms.dll"
#r @"..\packages\FSharp.Collections.ParallelSeq.1.0.2\lib\net40\FSharp.Collections.ParallelSeq.dll"
#load "Dragon.fs"
#load "TurtleTypes.fs"
#load "Canvas.fs"
#load "Turtle.fs"

open Dragon
open TurtleTypes
open Turtle
open Canvas

open System.Drawing
open FSharp.Collections.ParallelSeq



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

let dragonSequence = Dragon.dragon 18
let sequenceLength = dragonSequence |> Seq.length

let renderDragon turnAmount index = 
  let toColor i = 
//    let colorList = [
//      Color.Red; 
//      Color.Blue;
//      Color.Green;
//      Color.Yellow;
//    ]

    let colorList = 
      seq{
        for i in 0..255 do 
          yield Color.FromArgb(i,255-i,0)
        }
      |> Seq.toList

    let colorIndex = (i / (sequenceLength / (colorList.Length-1) ) ) % colorList.Length
    colorList.[colorIndex]

  let doTurn t canvas = 
    match t  with 
    | L -> canvas |> turn -turnAmount
    | R -> canvas |> turn turnAmount

  let startDistance = 1.
  let dragonForward = moveForward startDistance

  let unfolder (canvas, dragonTail, index) = 
    match dragonTail with
    | [] -> None
    | hd::tail -> let nextCanvas = 
                    canvas 
                    |> changeColor (toColor index)
                    |> dragonForward
                    |> doTurn hd 
                  Some(nextCanvas, (nextCanvas, tail, index+1))

  Seq.unfold unfolder (blankCanvas canvasWidth canvasHeight, dragonSequence, 0)
  |> Seq.last
  |> dragonForward
  |> saveCanvas "DragonCurve" index
  |> closeCanvas
  //|> showCanvas
  //|> runApplicaiton


Seq.singleton 9000
//seq{0..1000..18000} 
|> Seq.map (fun index -> index, ((index |> float) / 100.))
|> PSeq.iter (fun (index, angle) -> renderDragon angle index)
