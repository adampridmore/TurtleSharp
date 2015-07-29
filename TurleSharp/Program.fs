open System.Windows.Forms
open System.Drawing
open Dragon
open TurtleTypes
open Turtle
open Canvas

[<EntryPoint>]
let main argv =
//    let numberOfSides = 7
//    let lengthInc = 50.
//    let directionIncrement = 360. / (numberOfSides |> float)
    
//    Seq.unfold (fun canvas -> let newCanvas = canvas |> moveTutle {length=lengthInc;direction=directionIncrement }
//                              Some(newCanvas, newCanvas)) blankCanvas
//    |> Seq.take numberOfSides
//    |> Seq.last

//    blankCanvas
//    |> moveForward 10.
//    |> turnRight
//    |> moveForward 20.
//    |> turnRight
//    |> moveForward 30.
//    |> turnRight
//    |> moveForward 40.
//    |> turnRight
//    |> moveForward 50.
//    |> turnLeft
//    |> moveForward 60.
//
//    |> showCanvas
//    |> runApplicaiton
  
    let dragonSequence = Dragon.dragon 5

    let doTurn (turn) canvas = 
      match turn with 
      | L -> turnLeft canvas
      | R -> turnRight canvas


    let dragonForward = moveForward 20.

    Seq.unfold (function (canvas,dragonTail) -> match dragonTail with
                                                |[] -> None
                                                | hd::tail -> let nextCanvas = canvas 
                                                                               |> dragonForward
                                                                               |> doTurn hd 
                                                              Some(nextCanvas, (nextCanvas, tail))
               ) (blankCanvas 640. 480. , dragonSequence)
    |> Seq.last
    |> dragonForward
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
