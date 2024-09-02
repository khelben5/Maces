namespace Engine

type GameEngine() =

    let canvasSize = 1280
    let cellCount = 10
    let cellSize = canvasSize / cellCount

    let mutable state = State.create cellCount

    member _.ComputeWallsRenderInfo() =
        state |> State.getWalls |> Seq.map (Wall.renderPosition cellSize)
