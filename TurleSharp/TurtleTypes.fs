module TurtleTypes

open System.Windows.Forms
open System.Drawing
  
type Position = 
    { 
      x : int ; 
      y : int 
    } 
    override m.ToString() = sprintf "x:%i y:%i" m.x m.y

type Direction = int


type Turtle = {
  position : Position
  direction : Direction
}

type Vector = 
  {
    length : int
    direction: Direction
  }
  override m.ToString() = sprintf "l:%i d:%i" m.length m.direction
  
type Canvas = {
  g : Graphics
  p : Pen
  i : Image
  turtle: Turtle
}

