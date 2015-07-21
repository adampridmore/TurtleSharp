open System.Windows.Forms
open System.Drawing
open TurtleTypes
open Turtle

let showCanvas (c:Canvas) = 
    let f= new System.Windows.Forms.Form();
    f.Width <- c.i.Width
    f.Height <- c.i.Height + 50
    
    let pb = new PictureBox()
    pb.Dock <- DockStyle.Fill
    pb.Image <- c.i
    
    f.Controls.Add(pb)

    //f.ShowDialog() |> ignore
    f.Show()
    f

let blankCanvas = 
  let image = new Bitmap((canvasWidth |> int), (canvasHeight |> int))
  let turtle = { position = { x = canvasWidth / 2. ; y = canvasHeight / 2.}; direction = 0. }
  let g = Graphics.FromImage(image);
  g.SmoothingMode <- System.Drawing.Drawing2D.SmoothingMode.HighQuality

  let penWidth = 2.f

  {g = g; p = new Pen(new SolidBrush(Color.Black),penWidth); i = image; turtle = turtle}

let runApplicaiton (form:Form) = 
  Application.Run(form)

[<EntryPoint>]
let main argv =
    let numberOfSides = 7
    let lengthInc = 50.
    let directionIncrement = 360. / (numberOfSides |> float)
    
    Seq.unfold (fun canvas -> let newCanvas = canvas |> moveTutle {length=lengthInc;direction=directionIncrement }
                              Some(newCanvas, newCanvas)) blankCanvas
    |> Seq.take numberOfSides
    |> Seq.last
    |> showCanvas
    |> runApplicaiton

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
