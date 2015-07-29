module Turtle

open TurtleTypes
open Canvas
open System
open System.Drawing

//let canvasWidth = 640.
//let canvasHeight = 480.

//let canvasWidth = 64000.
//let canvasHeight = 48000.

let sin x = Math.Sin(x)
let cos x = Math.Cos(x)
let PI = Math.PI |> double

let degreesToRadians (degrees:double) = 
  degrees * PI / 180.

let translate (v:Vector) (p:Position) = 
  let hoz = (v.length |> double) * sin (v.direction |> degreesToRadians)
  let vert = (v.length |> double) * cos (v.direction |> degreesToRadians);
  {
    x= p.x + hoz;
    y= p.y + vert
  }

let toCanvas (p:Position) (canvas:Canvas) = 
  new Point(p.x |> int, ((canvas.i.Height |> float) - p.y) |> int )

let drawLine (pos:Position) (vector:Vector) (canvas: Canvas) =
  let p1 = pos
  let p2 = pos |> translate vector
  canvas.g.DrawLine(canvas.p, (toCanvas p1 canvas), (toCanvas p2 canvas)) |> ignore
  canvas

let moveTutle (vector:Vector) (canvas: Canvas) =
  let absoluteDirection = canvas.turtle.direction + vector.direction
  let p1 = canvas.turtle.position
  let p2 = p1 |> translate {vector with direction = absoluteDirection}
  
  canvas.g.DrawLine(canvas.p, toCanvas p1 canvas, toCanvas p2 canvas) |> ignore
  { canvas with turtle = { canvas.turtle with position = p2; direction = absoluteDirection} }

let changeColor (color:Color) (c:Canvas) = 
  { c with p = newPen color }
  
let moveForward distance (c:Canvas) = 
  c |> moveTutle {length = distance; direction = 0.}

let turn x (c:Canvas) =
  c |> moveTutle {length = 0.; direction = x}

let turnRight (c:Canvas) = 
  c |> turn 90.

let turnLeft (c:Canvas) = 
  c |> turn -90.

