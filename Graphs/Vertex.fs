namespace Graphs

type Vertex = private { x: int; y: int }

type VertexError =
    | NegativeXError
    | NegativeYError

module Vertex =

    let create x y =
        if x < 0 then Error NegativeXError
        elif y < 0 then Error NegativeYError
        else Ok { x = x; y = y }

    let right vertex width =
        if vertex.x = width - 1 then
            None
        else
            Some { vertex with x = vertex.x + 1 }

    let bottom vertex height =
        if vertex.y = height - 1 then
            None
        else
            Some { vertex with y = vertex.y + 1 }

    let describe vertex = $"({vertex.x},{vertex.y})"
