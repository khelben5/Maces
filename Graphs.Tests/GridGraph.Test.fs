module GridGraphTests

open Xunit
open Graphs
open Utils

[<Fact>]
let ``Creates a non empty grid graph`` () =
    let vertex00 = createVertexOrRaise 0 0
    let vertex01 = createVertexOrRaise 0 1
    let vertex02 = createVertexOrRaise 0 2
    let vertex10 = createVertexOrRaise 1 0
    let vertex11 = createVertexOrRaise 1 1
    let vertex12 = createVertexOrRaise 1 2
    let vertex20 = createVertexOrRaise 2 0
    let vertex21 = createVertexOrRaise 2 1
    let vertex22 = createVertexOrRaise 2 2

    let expectedEdges =
        [| createEdgeOrRaise vertex00 vertex01
           createEdgeOrRaise vertex10 vertex20
           createEdgeOrRaise vertex00 vertex01
           createEdgeOrRaise vertex10 vertex11
           createEdgeOrRaise vertex20 vertex21
           createEdgeOrRaise vertex10 vertex11
           createEdgeOrRaise vertex11 vertex21
           createEdgeOrRaise vertex01 vertex02
           createEdgeOrRaise vertex11 vertex12
           createEdgeOrRaise vertex21 vertex22
           createEdgeOrRaise vertex02 vertex12
           createEdgeOrRaise vertex12 vertex22 |]

    let graph = GridGraph.create 3 3

    expectedEdges
    |> Array.iter (fun edge -> GraphAssertions.assertShouldContainEdge edge graph)

    Assert.Equal(9, GridGraph.vertexCount graph)
    Assert.Equal(12, GridGraph.edgeCount graph)
