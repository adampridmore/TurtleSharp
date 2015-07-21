module Turtle

open TurtleTypes
open System

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

