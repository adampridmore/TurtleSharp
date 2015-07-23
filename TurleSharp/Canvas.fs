module Canvas

open System.Windows.Forms
open System.Drawing
open TurtleTypes

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

let blankCanvas canvasWidth canvasHeight = 
  let image = new Bitmap((canvasWidth |> int), (canvasHeight |> int))
  let turtle = { position = { x = canvasWidth / 2. ; y = canvasHeight / 2.}; direction = 0. }
  let g = Graphics.FromImage(image);
  g.SmoothingMode <- System.Drawing.Drawing2D.SmoothingMode.HighQuality

  let penWidth = 1.f

  {g = g; p = new Pen(new SolidBrush(Color.Black),penWidth); i = image; turtle = turtle}

let runApplicaiton (form:Form) = 
  Application.Run(form)


