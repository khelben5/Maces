namespace Engine

type GameConfig =
    private
        { cellCount: int
          canvasSize: int
          cellSize: int }

module GameConfig =

    let create () =
        let cellCount = 10
        let canvasSize = 1280

        { cellCount = cellCount
          canvasSize = canvasSize
          cellSize = canvasSize / cellCount }
