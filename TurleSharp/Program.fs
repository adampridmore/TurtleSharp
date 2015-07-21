open System.Windows.Forms
open System.Drawing
open TurtleTypes
open Turtle

let width = 640
let height = 480

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

//let drawTurlte (turtle:Turtle) (g:Graphics) (p:Pen) =
//  g.DrawLine(p, turtle.position |> toPoint, turtle.position |> translate |> toPoint)

let toCanvas (p:Position) = new Point(p.x, height - p.y)

let drawLine (pos:Position) (vector:Vector) (canvas: Canvas) =
  let p1 = pos
  let p2 = pos |> translate vector
  canvas.g.DrawLine(canvas.p, p1 |> toCanvas , p2 |> toCanvas) |> ignore
  canvas
  
[<EntryPoint>]
let main argv =
    let image = new Bitmap(width,height)
    let g = Graphics.FromImage(image);
    let p = new Pen(new SolidBrush(Color.Black))

    let canvas = { 
        g = g; 
        p = p;
        i = image 
    }
    
    canvas 
    |> drawLine {x=10;y=10} {length= 100;direction= 45 }
    |> drawLine {x=20;y=10} {length= 100;direction= 45 }
    |> drawLine {x=30;y=10} {length= 100;direction= 45 }
    |> drawLine {x=40;y=10} {length= 100;direction= 45 } 
    |> drawLine {x=100;y=200} {length= 100;direction= 0 }
    |> drawLine {x=100;y=200} {length= 100;direction= 45 }
    |> drawLine {x=100;y=200} {length= 100;direction= 90 }
    |> drawLine {x=100;y=200} {length= 100;direction= 135}
    |> drawLine {x=100;y=200} {length= 100;direction= 180 }
    |> drawLine {x=100;y=200} {length= 100;direction= 225 }
    |> drawLine {x=100;y=200} {length= 100;direction= 270 }
    |> drawLine {x=100;y=200} {length= 100;direction= 315}
    |> showImage

    0
