module VertexTests

open Xunit
open Graphs
open Utils

[<Fact>]
let ``Cannot create vertex with negative x`` () =
    let result = Vertex.create -1 2

    match result with
    | Ok _ -> Assert.Fail "Should not be able to create a vertex with negative x."
    | Error error -> Assert.Equal(NegativeXError, error)

[<Fact>]
let ``Cannot create vertex with negative y`` () =
    let result = Vertex.create 1 -1

    match result with
    | Ok _ -> Assert.Fail "Should not be able to create a vertex with negative y."
    | Error error -> Assert.Equal(NegativeYError, error)

[<Fact>]
let ``Returns right vertex correctly`` () =
    let width = 3
    let original = createVertexOrRaise 1 2
    let result = Vertex.right original width

    match result with
    | Some vertex -> Assert.Equal(createVertexOrRaise 2 2, vertex)
    | None -> Assert.Fail "Should return right vertex correctly."

[<Fact>]
let ``Cannot return right vertex if the vertex is already on the right`` () =
    let width = 3
    let original = createVertexOrRaise 2 1
    let result = Vertex.right original width

    match result with
    | Some _ -> Assert.Fail "Should not return right vertex for a vertex already on the right."
    | None -> Assert.True true

[<Fact>]
let ``Returns bottom vertex correctly`` () =
    let height = 3
    let original = createVertexOrRaise 2 1
    let result = Vertex.bottom original height

    match result with
    | Some vertex -> Assert.Equal(createVertexOrRaise 2 2, vertex)
    | None -> Assert.Fail "Should return bottom vertex correctly."

[<Fact>]
let ``Cannot return bottom vertex if the vertex is already on the bottom`` () =
    let height = 3
    let original = createVertexOrRaise 1 2
    let result = Vertex.bottom original height

    match result with
    | Some _ -> Assert.Fail "Should not return bottom vertex for a vertex already on the bottom."
    | None -> Assert.True true
