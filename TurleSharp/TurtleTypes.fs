module TurtleTypes

open System.Windows.Forms
open System.Drawing
  
type Position = 
    { 
      x : double ; 
      y : double
    } 
    override m.ToString() = sprintf "x:%f y:%f" m.x m.y

type Direction = double

type Turtle = {
  position : Position
  direction : Direction
}

type Vector = 
  {
    length : double
    direction: Direction
  }
  override m.ToString() = sprintf "l:%f d:%f" m.length m.direction
  
type Canvas = {
  g : Graphics
  p : Pen
  i : Image
  turtle: Turtle
}

