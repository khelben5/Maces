namespace Engine

type Cell = private { x: int; y: int }

module Cell =

    let create x y = { x = x; y = y }
