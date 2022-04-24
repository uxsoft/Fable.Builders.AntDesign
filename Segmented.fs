namespace Fable.Builders.AntDesign

open Fable.Builders
open Fable.Builders.AntDesign
open Fable.Builders.Common
open Fable.Core
open Feliz
open Fable.Core.JsInterop

[<AutoOpen>]
module Segmented =

    type SegmentedItem =
        {| label: string
           value: string
           icon: ReactElement
           disabled: bool
           className: string |}

    type SegmentedBuilder() =
        inherit ReactBuilder(import "Segmented" "antd")
        
        [<CustomOperation("block")>] member inline _.block (x: DSLElement, v: bool) = x.attr "block" v
        [<CustomOperation("defaultValue")>] member inline _.defaultValue (x: DSLElement, v: string) = x.attr "defaultValue" v
        [<CustomOperation("disabled")>] member inline _.href (x: DSLElement, v: bool) = x.attr "disabled" v
        [<CustomOperation("onChange")>] member inline _.onChange (x: DSLElement, v: string -> unit) = x.attr "onChange" v
        [<CustomOperation("optionItems")>] member inline _.optionItems (x: DSLElement, v: SegmentedItem array) = x.attr "options" v
        [<CustomOperation("options")>] member inline _.options (x: DSLElement, v: string array) = x.attr "options" v
        [<CustomOperation("size")>] member inline _.size (x: DSLElement, v: Size) = x.attr "size" v
        [<CustomOperation("value")>] member inline _.value (x: DSLElement, v: string) = x.attr "value" v