namespace Engine

open System

type GameEngine() =

    let config = GameConfig.create ()
    let mutable state = State.create Random.Shared config.cellCount

    member _.ComputeWallsRenderInfo() =
        state |> State.getWalls |> Set.map (Wall.renderPosition config.cellSize)

    member _.getCanvasSize() = config.canvasSize
