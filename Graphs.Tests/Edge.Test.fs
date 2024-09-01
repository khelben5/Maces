module EdgeTests

open Xunit
open Graphs
open Utils

[<Fact>]
let ``Cannot create an edge with the same vertex`` () =
    let vertex = createVertexOrRaise 123 425
    let result = Edge.create vertex vertex

    match result with
    | Ok _ -> Assert.Fail "Should fail when creating an edge with the same vertex."
    | Error error -> Assert.Equal(SameVertexError, error)

[<Fact>]
let ``Cannot create a diagonal edge`` () =
    let vertexA = createVertexOrRaise 5 5
    let vertexB = createVertexOrRaise 4 4
    let result = Edge.create vertexA vertexB

    match result with
    | Ok _ -> Assert.Fail "Should fail when creating a diagonal edge."
    | Error error -> Assert.Equal(DiagonalEdgeError, error)

[<Fact>]
let ``Cannot create an edge to a vertex that is not a neighbour`` () =
    let vertexA = createVertexOrRaise 5 5
    let vertexB = createVertexOrRaise 5 7
    let result = Edge.create vertexA vertexB

    match result with
    | Ok _ -> Assert.Fail "Should fail when creating an edge to a vertex that is not a neighbour."
    | Error error -> Assert.Equal(NotANeighbourError, error)

[<Fact>]
let ``Can create a valid edge`` () =
    let vertexA = createVertexOrRaise 5 5
    let vertexB = createVertexOrRaise 6 5
    let result = Edge.create vertexA vertexB
    let expectedEdge = createEdgeOrRaise vertexA vertexB

    match result with
    | Ok edge -> Assert.Equal(expectedEdge, edge)
    | Error _ -> Assert.Fail "Should be able to create a valid edge."

[<Fact>]
let ``Edges are not directed`` () =
    let vertexA = createVertexOrRaise 1 1
    let vertexB = createVertexOrRaise 1 2
    let expected = createEdgeOrRaise vertexB vertexA // (1,2) -> (1,1)
    let actual = createEdgeOrRaise vertexA vertexB // (1,1) -> (1,2)

    Assert.True(Edge.areEquivalent expected actual, "Edges should not be directed.")

[<Fact>]
let ``Different edges are not equivalent`` () =
    let vertexA = createVertexOrRaise 5 5
    let vertexB = createVertexOrRaise 6 5
    let vertexC = createVertexOrRaise 4 5
    let expected = createEdgeOrRaise vertexB vertexA // (6,5) -> (5,5)
    let actual = createEdgeOrRaise vertexC vertexA // (4,5) -> (5,5)

    Assert.False(Edge.areEquivalent expected actual, "Different edges should not be equivalent.")
