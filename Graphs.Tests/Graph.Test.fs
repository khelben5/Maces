module WallOrientationTests

open Xunit
open Graphs
open Nodes

[<Fact>]
let ``Creates a grid graph correctly`` () =
    let expectedEdges =
        set
            [ Node.create 0 0, Node.create 1 0
              Node.create 0 0, Node.create 0 1
              Node.create 0 1, Node.create 1 1
              Node.create 0 1, Node.create 0 2
              Node.create 1 0, Node.create 1 1
              Node.create 1 0, Node.create 2 0
              Node.create 1 1, Node.create 1 2
              Node.create 1 1, Node.create 2 1
              Node.create 0 2, Node.create 1 2
              Node.create 2 0, Node.create 2 1
              Node.create 1 2, Node.create 2 2
              Node.create 2 1, Node.create 2 2 ]

    let size = 3
    let graph = Graph.createGrid size
    let edges = Graph.edges graph

    Assert.Equal<(Node * Node) Set>(expectedEdges, edges)
