open System.Windows.Forms
open System.Drawing
open TurtleTypes
open Turtle

let showCanvas (c:Canvas) = 
    let f = new System.Windows.Forms.Form();
    f.Width <- c.i.Width
    f.Height <- c.i.Height + 50
    
    let pb = new PictureBox()
    pb.Dock <- DockStyle.Fill
    pb.Image <- c.i
    
    f.Controls.Add(pb)

    f.ShowDialog() |> ignore
    //f.Show() |> ignore

let blankCanvas = 
  let image = new Bitmap((canvasWidth |> int), (canvasHeight |> int))
  let turtle = { position = { x = canvasWidth / 2. ; y = canvasHeight / 2.}; direction = 0. }
  {g = Graphics.FromImage(image); p = new Pen(new SolidBrush(Color.Black)); i = image; turtle = turtle}

[<EntryPoint>]
let main argv =
    let numberOfSides = 5
    let lengthInc = 50.
    let directionIncrement = 360. / (numberOfSides |> float)
    
    Seq.unfold (fun canvas -> let newCanvas = canvas |> moveTutle {length=lengthInc;direction=directionIncrement }
                              Some(newCanvas, newCanvas)) blankCanvas
    |> Seq.take numberOfSides
    |> Seq.last
    |> showCanvas
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
