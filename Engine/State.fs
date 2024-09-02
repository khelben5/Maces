namespace Engine

open Graphs

type State = private { graph: GridGraph }

module State =

    let private wallWidth = 8

    let create size = { graph = GridGraph.create size size }

    let private toCell vertex : Cell =
        { x = Vertex.x vertex
          y = Vertex.y vertex }

    let private toWall edge =
        let vertices = edge |> Edge.vertices
        Wall.create (vertices |> fst |> toCell) (vertices |> snd |> toCell) wallWidth

    let getWalls state =
        state.graph |> GridGraph.edges |> Seq.map toWall
