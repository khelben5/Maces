namespace Engine

open Graphs

type State = private { graph: GridGraph }

module State =

    let create size = { graph = GridGraph.create size size }

    let getWalls state = GridGraph.edgeCount
