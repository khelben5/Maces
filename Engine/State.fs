namespace Engine

open Graphs

type State = private { graph: Graph }

module State =
    open Nodes

    let private wallWidth = 8

    let create size = { graph = Graph.createGrid size }

    let private toCell node = Cell.create node.x node.y

    let private toWall edge =
        Wall.create (edge |> fst |> toCell) (edge |> snd |> toCell) wallWidth

    let getWalls state =
        state.graph |> Graph.edges |> Array.map toWall
