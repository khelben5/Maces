namespace Engine

type State = private { cells: Cell array }

module State =

    let private generateCells () =
        let position = Position.create ()
        let size = Size.create ()
        let walls = CellWalls.createFull ()
        [| Cell.create position size walls |]

    let create () = { cells = generateCells () }

    let cells state = state.cells
