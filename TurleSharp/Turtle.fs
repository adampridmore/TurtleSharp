module Turtle

open TurtleTypes
open System
open System.Drawing

let canvasWidth = 640.
let canvasHeight = 480.

let sin x = Math.Sin(x)
let cos x = Math.Cos(x)
let PI = Math.PI |> double

let degreesToRadians (degrees:double) = 
  degrees * PI / 180.

let toCanvas (p:Position) = new Point(p.x |> int, (canvasHeight - p.y) |> int )

let translate (v:Vector) (p:Position) = 
  let hoz = (v.length |> double) * sin (v.direction |> degreesToRadians)
  let vert = (v.length |> double) * cos (v.direction |> degreesToRadians);
  {
    x= p.x + hoz;
    y= p.y + vert
  }

let drawLine (pos:Position) (vector:Vector) (canvas: Canvas) =
  let p1 = pos
  let p2 = pos |> translate vector
  canvas.g.DrawLine(canvas.p, p1 |> toCanvas , p2 |> toCanvas) |> ignore
  canvas

let moveTutle (vector:Vector) (canvas: Canvas) =
  let absoluteDirection = canvas.turtle.direction + vector.direction
  let p1 = canvas.turtle.position
  let p2 = p1 |> translate {vector with direction = absoluteDirection}
  
  canvas.g.DrawLine(canvas.p, p1 |> toCanvas , p2 |> toCanvas) |> ignore
  { canvas with turtle = { canvas.turtle with position = p2; direction = absoluteDirection} }

let moveForward distance (c:Canvas) = 
  c |> moveTutle {length = distance; direction = 0.}

let turnRight (c:Canvas) = 
  c |> moveTutle {length = 0.; direction = 45.}

let turnLeft (c:Canvas) = 
  c |> moveTutle {length = 0.; direction = -45.}

