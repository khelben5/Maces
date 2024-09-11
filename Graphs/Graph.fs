namespace Graphs

open Nodes

type Graph = private { map: Map<Node, Node array> }

module Graph =
    open System

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

    let private nodes graph =
        graph.map
        |> Map.fold (fun nodes node neighbours -> nodes |> Set.add node |> Set.union (set neighbours)) Set.empty

    let nodeCount graph = graph |> nodes |> Set.count

    let edges graph =
        graph.map
        |> Map.fold
            (fun edges node neighbours ->
                neighbours
                |> Array.map (fun neighbour -> node, neighbour)
                |> set
                |> Set.union edges)
            Set.empty

    type Step =
        { visited: Node array
          edgesToVisit: (Node * Node) Set
          spanningTree: (Node * Node) array }

    let private neighbours node graph =
        Map.fold
            (fun result currentNode neighbours ->
                if currentNode = node then
                    neighbours |> set |> Set.union result
                elif Array.contains node neighbours then
                    Set.add currentNode result
                else
                    result)
            Set.empty
            graph.map

    let private getOtherNode node edge =
        if node = fst edge then edge |> snd else edge |> fst

    [<TailCall>]
    let rec private spanningTreeRec graph step =
        if Array.length step.visited = nodeCount graph || Set.isEmpty step.edgesToVisit then
            step.spanningTree
        else
            let edge = Array.get (Set.toArray step.edgesToVisit) 0
            let remainingEdges = Set.remove edge step.edgesToVisit

            let currentNode = Array.last step.visited
            let anotherNode = getOtherNode currentNode edge

            [| anotherNode |]
            |> Array.collect (fun node ->
                if Array.contains node step.visited then
                    spanningTreeRec
                        graph
                        { step with
                            edgesToVisit = remainingEdges }
                else
                    let newVisited = Array.append step.visited [| node |]
                    let newSpanningTree = Array.append step.spanningTree [| edge |]

                    let newEdges =
                        neighbours node graph
                        |> Set.filter (fun n -> newVisited |> Array.contains n |> not)
                        |> Set.map (fun n -> node, n)

                    spanningTreeRec
                        graph
                        { visited = newVisited
                          edgesToVisit = Set.union step.edgesToVisit newEdges
                          spanningTree = newSpanningTree })

    let spanningTree startNode graph =
        let initialStep =
            { visited = Array.singleton startNode
              edgesToVisit =
                Map.tryFind startNode graph.map
                |> Option.map (fun neighbours -> neighbours |> Array.map (fun n -> startNode, n) |> set)
                |> Option.defaultValue Set.empty
              spanningTree = Array.empty }

        initialStep |> spanningTreeRec graph |> set

    let randomNode (random: Random) graph =
        let nodes = graph |> nodes |> Set.toArray
        nodes |> Array.length |> random.Next |> Array.get nodes
