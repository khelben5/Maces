namespace Graphs

type Edge =
    private
        { vertexA: Vertex
          vertexB: Vertex }

type EdgeError =
    | SameVertexError
    | DiagonalEdgeError
    | NotANeighbourError

module Edge =

    let create vertexA vertexB : Result<Edge, EdgeError> =
        if vertexA = vertexB then
            Error SameVertexError
        elif vertexA.x <> vertexB.x && vertexA.y <> vertexB.y then
            Error DiagonalEdgeError
        elif abs (vertexA.x - vertexB.x) > 1 || abs (vertexA.y - vertexB.y) > 1 then
            Error NotANeighbourError
        else
            Ok { vertexA = vertexA; vertexB = vertexB }

    let areEquivalent e1 e2 =
        e1.vertexA = e2.vertexA && e1.vertexB = e2.vertexB
        || e1.vertexA = e2.vertexB && e1.vertexB = e2.vertexA

    let describe edge =
        $"[{Vertex.describe edge.vertexA} <-> {Vertex.describe edge.vertexB}]"
