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
    
let newPen (color:Color) = 
  let penWidth = 2.f
  new Pen(new SolidBrush(color),penWidth)

let blankCanvas canvasWidth canvasHeight = 
  let image = new Bitmap((canvasWidth |> int), (canvasHeight |> int))
  
  let turtle = 
    { 
      position = 
        { 
          x = canvasWidth / 2. ; 
          y = canvasHeight / 2. + 500.
        };
      direction = 0. 
    }
  
  let g = Graphics.FromImage(image);
  g.Clear(Color.White)

  //g.SmoothingMode <- System.Drawing.Drawing2D.SmoothingMode.HighQuality

  {g = g; p = newPen Color.Black ; i = image; turtle = turtle}

let runApplicaiton (form:Form) = 
  Application.Run(form)


