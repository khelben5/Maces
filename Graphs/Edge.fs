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

    let connects vertex edge =
        edge.vertexA = vertex || edge.vertexB = vertex

    let description edge =
        $"({edge.vertexA |> Vertex.description}) - ({edge.vertexB |> Vertex.description})"
