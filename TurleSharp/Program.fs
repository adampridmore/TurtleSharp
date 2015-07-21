open System.Windows.Forms
open System.Drawing
open TurtleTypes
open Turtle

let width = 640.
let height = 480.

let showImage (c:Canvas) = 
    let f = new System.Windows.Forms.Form();
    f.Width <- c.i.Width
    f.Height <- c.i.Height + 50
    
    let pb = new PictureBox()
    pb.Dock <- DockStyle.Fill
    pb.Image <- c.i
    
    f.Controls.Add(pb)

    f.ShowDialog() |> ignore
    //f.Show() |> ignore

let toCanvas (p:Position) = new Point(p.x |> int, (height - p.y) |> int )

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

[<EntryPoint>]
let main argv =
    let image = new Bitmap((width |> int), (height |> int))
    let g = Graphics.FromImage(image);
    let p = new Pen(new SolidBrush(Color.Black))

    let canvas = { 
        g = g; 
        p = p;
        i = image;
        turtle = { position = {x = width / 2. ; y = height / 2.};direction = 0.} 
    }
    
    Seq.unfold (fun (state:Canvas) -> let newC = state |> moveTutle {length=2.;direction=1. }
                                      Some(newC, newC)) canvas
    |> Seq.take 360
    |> Seq.last
    |> showImage

//    canvas 
//    |> moveTutle {length= 100;direction= 45 }
//    |> moveTutle {length= 100;direction= 45 }
//    |> moveTutle {length= 100;direction= 45 }
//    |> moveTutle {length= 100;direction= 45 }
//    |> moveTutle {length= 100;direction= 45 }
//    |> moveTutle {length= 100;direction= 45 }
//    |> moveTutle {length= 100;direction= 45 }
//    |> moveTutle {length= 100;direction= 45 }
//    |> showImage

    0
