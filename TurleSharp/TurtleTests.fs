module TurtleTests

open FsUnit 
open NUnit.Framework
open TurtleTypes
open Turtle

[<Test>]
let ``90 degree apply vector``()=
  let p = {x=100.;y=200.}
  let v = {length=10.;direction=90.}

  p |> translate v |> should equal {x=110.;y=200.}

[<Test>]
let ``45 degree apply vector``()=
  let p = {x=10.;y=10.}
  let v = {length=10.;direction=45.}

  p |> translate v |> should equal {x=17.;y=17.}

[<Test>]
let ``30 degree apply vector``()=
  let p = {x=0.;y=1.}
  let v = {length=500.;direction=37.}

  p |> translate v |> should equal {x=300.;y=400.}
