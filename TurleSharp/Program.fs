open System.Windows.Forms
open System.Drawing
open TurtleTypes

let toPoint (p:Position) = new Point(p.x, p.y)

let showImage (c:Canvas) = 
    let f = new System.Windows.Forms.Form();
    f.Width <- c.i.Width
    f.Height <- c.i.Height
    
    let pb = new PictureBox()
    pb.Dock <- DockStyle.Fill
    pb.Image <- c.i
    
    f.Controls.Add(pb)

    f.ShowDialog() |> ignore
    //f.Show() |> ignore

let translate (p:Position) = 
  {
    x = p.x + 10
    y = p.y + 5
  }

let drawTurlte (turtle:Turtle) (g:Graphics) (p:Pen) =
  g.DrawLine(p, turtle.position |> toPoint, turtle.position |> translate |> toPoint)

let drawLine (pos:Position) (vector:Vector) (canvas: Canvas) =
  let pt1 = pos |> toPoint
  let pt2 = {
              x = pos.x + 10
              y = pos.y + 10
            } |> toPoint

  canvas.g.DrawLine(canvas.p, pt1, pt2)
  
  canvas
  
[<EntryPoint>]
let main argv =
    let image = new Bitmap(200,200)
    let g = Graphics.FromImage(image);
    let p = new Pen(new SolidBrush(Color.Black))

    let canvas = { 
        g = g; 
        p = p;
        i = image 
    }
     
//    let t = {
//      position = { x = 50; y = 50 };
//      direction= 0.0
//    }
//            
//    drawTurlte t g p
    
    let v = {
      length= 10
      direction= 10
    }

    canvas 
    |> drawLine {x=10;y=10} v 
    |> drawLine {x=50;y=50} v
    |> showImage

    0
