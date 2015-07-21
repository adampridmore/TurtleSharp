#r "System.Windows.Forms.dll"

open System.Windows.Forms
open System.Drawing

let f = new System.Windows.Forms.Form();
f.Width <- 100
f.Height <- 100
    
f.Show()

Application.Run(f)

f.Width <- 500


