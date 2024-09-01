module GraphAssertions

open Xunit
open Graphs

let assertShouldContainEdge edge graph =
    Assert.True(GridGraph.hasEdge edge graph, $"Graph should contain edge {edge |> Edge.description}")
