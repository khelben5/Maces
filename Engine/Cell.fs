namespace Engine

type Cell =
    private
        { position: Position
          size: Size
          walls: CellWalls }

module Cell =

    let private wallWidth = 2

    let create position size walls =
        { position = position
          size = size
          walls = walls }

    let private leftWallRenderInfo cell =
        if cell.walls.left then
            Some
                { x = cell.position.x
                  y = cell.position.y
                  width = wallWidth
                  height = cell.size.height }
        else
            None

    let private topWallRenderInfo cell =
        if cell.walls.top then
            Some
                { x = cell.position.x
                  y = cell.position.y
                  width = cell.size.width
                  height = wallWidth }
        else
            None

    let private rightWallRenderInfo cell =
        if cell.walls.right then
            Some
                { x = cell.size.width - wallWidth
                  y = cell.position.y
                  width = wallWidth
                  height = cell.size.height }
        else
            None

    let private bottomWallRenderInfo cell =
        if cell.walls.bottom then
            Some
                { x = cell.position.x
                  y = cell.size.height - wallWidth
                  width = cell.size.width
                  height = wallWidth }
        else
            None

    let renderInfo cell =
        [| cell |> leftWallRenderInfo
           cell |> topWallRenderInfo
           cell |> rightWallRenderInfo
           cell |> bottomWallRenderInfo |]
        |> Array.choose (fun result -> result)
