namespace Engine

type GameEngine() =

    let mutable state = State.create ()

    member _.ComputeWallsRenderInfo() =
        State.cells state |> Array.collect Cell.renderInfo
