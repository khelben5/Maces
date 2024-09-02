namespace Engine

type GameEngine() =

    let config = GameConfig.create ()
    let mutable state = State.create config.cellCount

    member _.ComputeWallsRenderInfo() =
        state |> State.getWalls |> Seq.map (Wall.renderPosition config.cellSize)

    member _.getCanvasSize() = config.canvasSize
