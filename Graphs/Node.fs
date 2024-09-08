namespace Nodes

type Node = { x: int; y: int }

module Node =

    let create x y = { x = x; y = y }

    let right width node =
        if node.x + 1 < width then
            Some { node with x = node.x + 1 }
        else
            None

    let bottom height node =
        if node.y + 1 < height then
            Some { node with y = node.y + 1 }
        else
            None
