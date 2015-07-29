open System.Drawing

//let max a b = if a > b then a else b
//
//[1;2;3;4;5;9;8;7;6] 
//|> Seq.fold (fun (count, sum) value -> (count+1, sum+value)) (0,0)
//|> fun (count, sum) -> sum / count
//
//[1;2;3;4;5;9;8;7;6] 
//|> Seq.reduce(+)
//
//[1;2;3;4;5;9;8;7;6] 
//|> Seq.fold(fun sum value -> sum+value) 0
//
//[1;2;3;4;5;9;8;7;6]
//|> Seq.scan(fun sum value -> sum+value) 0
//|> Seq.iter (printfn "%A")


let toColor i = 
  let r = i % 256
  let g = (i / 256) % 256
  let b = (i / (256 * 256)) % 256
  Color.FromArgb(r,g,b)

let every x seq =
  seq
  |> Seq.mapi (fun i x -> (i,x))
  |> Seq.filter (fun (i, _) -> i % x = 0)
  |> Seq.map (fun (_, x) -> x)
  
let drawColors (colors: System.Drawing.Color seq) = 
  let toPen (c:System.Drawing.Color) = new Pen(new SolidBrush(c))
    
  use image = new Bitmap(1000,1000)
  use g = System.Drawing.Graphics.FromImage(image)
   
  seq{
    for x in 0..1000 do 
      for y in 0..1000 do
        yield (x,y)
  }
  |> Seq.iter2 (fun c (x,y) -> let p = c |> toPen
                               g.DrawLine(p,x,y,x+1,y) ) colors
  
//  colors 
//  |> Seq.map toPen
//  |> Seq.iteri (fun i p -> g.DrawLine(p, i,0,i+1,0))

  let format = System.Drawing.Imaging.ImageFormat.Bmp

  let filename = sprintf "%s.%A" (System.IO.Path.GetTempFileName()) format

  image.Save(filename, format)
  System.Diagnostics.Process.Start(filename) |> ignore
  ()


//seq{0..1..256*256*256} 
Seq.initInfinite id
|> every 100
|> Seq.map toColor
//|> Seq.skip 10
//|> Seq.take 1000
|> drawColors
//|> Seq.iter (printfn "%A")


