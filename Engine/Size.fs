namespace Engine

type Size = private { width: int; height: int }

module Size =

    let create () = { width = 100; height = 100 }
