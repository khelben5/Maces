namespace Engine

type Wall =
    private { a: Cell; b: Cell; width: int }

module Wall =

    let create a b width =
        if a.x < b.x || a.y < b.y then
            { a = a; b = b; width = width }
        else
            { a = b; b = a; width = width }

    let orientation wall =
        if wall.a.x <> wall.b.x then Vertical else Horizontal

    let renderPosition cellSize wall =
        match wall |> orientation with
        | Horizontal ->
            { x = wall.a.x * cellSize
              y = wall.a.y * cellSize + cellSize - wall.width / 2
              width = cellSize
              height = wall.width }
        | Vertical ->
            { x = wall.a.x * cellSize + cellSize - wall.width / 2
              y = wall.a.y * cellSize
              width = wall.width
              height = cellSize }
