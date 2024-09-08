namespace Graphs

open Nodes

type Graph = private { map: Map<Node, Node array> }

module Graph =

    let create () = { map = Map.empty }

    let private add nodeA nodeB graph =
        let newNeighbours =
            match graph.map |> Map.tryFind nodeA with
            | Some neighbours -> [| nodeB |] |> Array.append neighbours
            | None -> [| nodeB |]

        { map = graph.map |> Map.add nodeA newNeighbours }

    [<TailCall>]
    let rec private createGridRec size node graph =
        let maybeRightNeighbour = node |> Node.right size
        let maybeBottomNeighbour = node |> Node.bottom size

        let addIfPresent node maybeNeighbour graph =
            maybeNeighbour
            |> Option.map (fun neighbour -> graph |> add node neighbour |> createGridRec size neighbour)
            |> Option.defaultValue graph

        graph
        |> addIfPresent node maybeRightNeighbour
        |> addIfPresent node maybeBottomNeighbour

    let createGrid size =
        create () |> createGridRec size (Node.create 0 0)

    let edges graph =
        graph.map
        |> Map.fold
            (fun edges node neighbours ->
                neighbours |> Array.map (fun neighbour -> node, neighbour) |> Array.append edges)
            [||]
