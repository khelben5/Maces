namespace Engine

type CellWalls =
    private
        { left: bool
          top: bool
          right: bool
          bottom: bool }

module CellWalls =

    let createFull () =
        { left = true
          top = true
          right = true
          bottom = true }
