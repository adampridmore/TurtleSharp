module Turtle

open TurtleTypes
open System

let sin x = Math.Sin(x)
let cos x = Math.Cos(x)
let PI = Math.PI

let degreesToRadians (degrees:int) = 
  (degrees |> float) * PI / 180.

let translate (v:Vector) (p:Position) = 
  let hoz = (v.length |> float) * sin (v.direction |> degreesToRadians)
  let vert = (v.length |> float) * cos (v.direction |> degreesToRadians);
  {
    x= (p.x + (hoz |> int));
    y= (p.y + (vert |> int))
  }

