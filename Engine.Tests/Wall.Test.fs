module WallTests

open Xunit
open Engine

type TestCase =
    { wall: Wall; expected: WallRenderInfo }

let private wallWidth = 4
let private horizontalWall = Wall.create { x = 2; y = 5 } { x = 2; y = 6 } wallWidth
let private verticalWall = Wall.create { x = 2; y = 5 } { x = 3; y = 5 } wallWidth

let testCases =
    [ [| { wall = horizontalWall
           expected =
             { x = 40
               y = 118
               width = 20
               height = 4 } } |]
      [| { wall = verticalWall
           expected =
             { x = 58
               y = 100
               width = 4
               height = 20 } } |] ]

[<Theory>]
[<MemberData(nameof testCases)>]
let ``Computes rendering info for walls correctly`` testCase =
    let cellSize = 20
    let renderInfo = Wall.renderPosition cellSize testCase.wall

    Assert.Equal(testCase.expected.x, renderInfo.x)
    Assert.Equal(testCase.expected.y, renderInfo.y)
    Assert.Equal(testCase.expected.width, renderInfo.width)
    Assert.Equal(testCase.expected.height, renderInfo.height)
