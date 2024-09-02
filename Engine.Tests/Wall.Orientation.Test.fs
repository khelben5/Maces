module WallOrientationTests

open Xunit
open Engine

type TestCase =
    { a: Cell
      b: Cell
      expected: Orientation }

let testCases =
    [ [| { a = { x = 0; y = 0 }
           b = { x = 0; y = 1 }
           expected = Horizontal } |]
      [| { a = { x = 0; y = 0 }
           b = { x = 1; y = 0 }
           expected = Vertical } |]
      [| { a = { x = 1; y = 1 }
           b = { x = 0; y = 1 }
           expected = Vertical } |]
      [| { a = { x = 1; y = 1 }
           b = { x = 1; y = 0 }
           expected = Horizontal } |] ]

[<Theory>]
[<MemberData(nameof testCases)>]
let ``Computes wall orientation correctly`` testCase =
    let wallWidth = 4
    let orientation = Wall.create testCase.a testCase.b wallWidth |> Wall.orientation
    Assert.Equal(testCase.expected, orientation)
