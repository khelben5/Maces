namespace Engine

open Graphs
open Nodes

type State =
    private
        { graph: Graph
          spanningTree: (Node * Node) Set }

module State =
    let private wallWidth = 8

    let create random size =
        let graph = Graph.createGrid size
        let spanningTree = Graph.spanningTree (Graph.randomNode random graph) graph

        { graph = graph
          spanningTree = spanningTree }

    let private toCell node = Cell.create node.x node.y

    let private toWall edge =
        Wall.create (edge |> fst |> toCell) (edge |> snd |> toCell) wallWidth

    let private areEqual pairA pairB =
        pairA = pairB || fst pairA = snd pairB && snd pairA = fst pairB

    let private removePairs pairsToRemove allPairs =
        allPairs
        |> Set.filter (fun pair ->
            pairsToRemove
            |> Set.exists (fun pairToRemove -> areEqual pair pairToRemove)
            |> not)

    let getWalls state =
        state.graph |> Graph.edges |> removePairs state.spanningTree |> Set.map toWall

    let generatePaths random state =
        { state with
            spanningTree = state.graph |> Graph.spanningTree random }
