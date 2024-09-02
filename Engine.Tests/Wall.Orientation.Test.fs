module WallOrientationTests

open Xunit
open Engine

type TestCase =
    { a: Cell
      b: Cell
      expected: Orientation }

let testCases =
    [ [| { a = Cell.create 0 0
           b = Cell.create 0 1
           expected = Horizontal } |]
      [| { a = Cell.create 0 0
           b = Cell.create 1 0
           expected = Vertical } |]
      [| { a = Cell.create 1 1
           b = Cell.create 0 1
           expected = Vertical } |]
      [| { a = Cell.create 1 1
           b = Cell.create 1 0
           expected = Horizontal } |] ]

[<Theory>]
[<MemberData(nameof testCases)>]
let ``Computes wall orientation correctly`` testCase =
    let wallWidth = 4
    let orientation = Wall.create testCase.a testCase.b wallWidth |> Wall.orientation
    Assert.Equal(testCase.expected, orientation)
