namespace Engine

type GameEngine() =

    let gameSize = 50

    let mutable state = State.create gameSize

    member _.ComputeWallsRenderInfo() : WallRenderInfo array = [||]
