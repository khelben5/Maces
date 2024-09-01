module Utils

open Graphs

let private raiseError error =
    error |> string |> System.Exception |> raise

let createVertexOrRaise x y =
    Vertex.create x y |> Result.defaultWith raiseError

let createEdgeOrRaise vertexA vertexB =
    Edge.create vertexA vertexB |> Result.defaultWith raiseError
