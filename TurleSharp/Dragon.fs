module Dragon

type Turn = 
  |L
  |R

let dragon generation = 
  let seed = R

  let nextDragon dirs = 
    let swap = (function | L -> R | R -> L)
    let invertedRev = dirs 
                      |> List.map swap
                      |> List.rev
    dirs @ [seed] @ invertedRev

  Seq.unfold (fun state -> let nextState = state |> nextDragon ;
                           Some(nextState,nextState)) []
  |> Seq.take generation
  |> Seq.last