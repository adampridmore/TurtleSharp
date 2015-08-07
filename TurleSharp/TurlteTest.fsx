#r "System.Windows.Forms.dll"
#r @"..\packages\FSharp.Collections.ParallelSeq.1.0.2\lib\net40\FSharp.Collections.ParallelSeq.dll"
#load "TurtleTypes.fs"
#load "Canvas.fs"
#load "Turtle.fs"

open Turtle
open Canvas

blankCanvas 1024. 768.
|> moveForward 100.
|> turn 90.
|> moveForward 50.
|> turn 90.
|> moveForward 25.
|> turn 90.
|> showCanvas
|> runApplicaiton
