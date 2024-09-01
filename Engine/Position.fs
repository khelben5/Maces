namespace Engine

type Position = private { x: int; y: int }

module Position =

    let create () = { x = 100; y = 100 }
