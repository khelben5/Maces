namespace Graphs

type GridGraph =
    private
        { vertices: Vertex array
          edges: Edge array }

module GridGraph =

    let private createVertices width height =
        let xPositions = Array.init width (fun i -> i)
        let yPositions = Array.init height (fun i -> i)

        xPositions
        |> Array.collect (fun x -> yPositions |> Array.choose (fun y -> Vertex.create x y |> Result.toOption))

    let private createEdge vertexA vertexB =
        Edge.create vertexA vertexB |> Result.toOption

    let private createEdgesForVertex width height vertex =
        [| Vertex.right vertex width; Vertex.bottom vertex height |]
        |> Array.choose (fun result -> result |> Option.bind (createEdge vertex))

    let create width height =
        let vertices = createVertices width height
        let edges = vertices |> Array.collect (createEdgesForVertex width height)
        { vertices = vertices; edges = edges }

    let vertexCount graph = Array.length graph.vertices

    let edgeCount graph = Array.length graph.edges

    let hasEdge edge graph = graph.edges |> Array.contains edge
