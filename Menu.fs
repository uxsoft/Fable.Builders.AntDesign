namespace Fable.Builders.AntDesign

open Browser.Types
open Fable.Builders.AntDesign
open Fable.Builders.Common
open Fable.Core
open Fable.Core.JsInterop
open Feliz

[<AutoOpen>]
module Menu =

    [<StringEnum; RequireQualifiedAccess>]
    type MenuMode = 
        | Vertical 
        | Horizontal 
        | Inline
    
    [<StringEnum; RequireQualifiedAccess>]
    type MenuTriggerSubMenuAction = 
        | Hover 
        | Click     
    
    type SelectParam = {
        key: string
        keyPath: string array
        item: ReactElement
        domEvent: DocumentEvent
        selectedKeys: string array
    }
    
    type ClickParam  = { 
        key: string
        keyPath: string
        item: ReactElement 
        domEvent: DocumentEvent 
    }
    
    type IMenuItem = interface end
    
    type MenuBuilder() =
        inherit ReactBuilder(null)
    
        [<CustomOperation("defaultOpenKeys")>] member inline _.defaultOpenKeys (x: DSLElement, v: string array) = x.attr "defaultOpenKeys" v 
        [<CustomOperation("defaultSelectedKeys")>] member inline _.defaultSelectedKeys (x: DSLElement, v: string array) = x.attr "defaultSelectedKeys" v 
        [<CustomOperation("expandIcon")>] member inline _.expandIcon (x: DSLElement, v: ReactElement) = x.attr "expandIcon" v
        [<CustomOperation("forceSubMenuRender")>] member inline _.forceSubMenuRender (x: DSLElement, v: bool) = x.attr "forceSubMenuRender" v 
        [<CustomOperation("inlineCollapsed")>] member inline _.inlineCollapsed (x: DSLElement, v: bool) = x.attr "inlineCollapsed" v 
        [<CustomOperation("inlineIndent")>] member inline _.inlineIndent (x: DSLElement, v: int) = x.attr "inlineIndent" v 
        [<CustomOperation("mode")>] member inline _.mode (x: DSLElement, v: MenuMode) = x.attr "mode" v 
        [<CustomOperation("multiple")>] member inline _.multiple (x: DSLElement, v: bool) = x.attr "multiple" v
        [<CustomOperation("openKeys")>] member inline _.openKeys (x: DSLElement, v: string array) = x.attr "openKeys" v 
        [<CustomOperation("overflowedIndicator")>] member inline _.overflowedIndicator (x: DSLElement, v: ReactElement) = x.attr "overflowedIndicator" v 
        [<CustomOperation("selectable")>] member inline _.selectable (x: DSLElement, v: bool) = x.attr "selectable" v 
        [<CustomOperation("selectedKeys")>] member inline _.selectedKeys (x: DSLElement, v: string array) = x.attr "selectedKeys" v 
        [<CustomOperation("subMenuCloseDelay")>] member inline _.subMenuCloseDelay (x: DSLElement, v: float) = x.attr "subMenuCloseDelay" v 
        [<CustomOperation("subMenuOpenDelay")>] member inline _.subMenuOpenDelay (x: DSLElement, v: float) = x.attr "subMenuOpenDelay" v 
        [<CustomOperation("theme")>] member inline _.theme (x: DSLElement, v: Theme) = x.attr "theme" v 
        [<CustomOperation("triggerSubMenuAction")>] member inline _.triggerSubMenuAction (x: DSLElement, v: MenuTriggerSubMenuAction) = x.attr "triggerSubMenuAction" v
        [<CustomOperation("onClick")>] member inline _.onClick (x: DSLElement, v: ClickParam -> unit) = x.attr "onClick" v 
        [<CustomOperation("onDeselect")>] member inline _.onDeselect (x: DSLElement, v: SelectParam -> unit) = x.attr "onDeselect" v 
        [<CustomOperation("onOpenChange")>] member inline _.onOpenChange (x: DSLElement, v: string array -> unit) = x.attr "onOpenChange" v 
        [<CustomOperation("onSelect")>] member inline _.onSelect (x: DSLElement, v: SelectParam -> unit) = x.attr "onSelect" v 
    
        member inline _.Yield (child: IMenuItem) =
            { Attributes = []; Children = [ child |> box |> unbox<ReactElement> ] }
        
        member _.Run(s: DSLElement) =
            let attrs = s.Attributes @ [
                ("items", s.Children |> List.toArray |> box)
            ]
            Browser.Dom.console.log (createObj attrs)
            Interop.reactApi.createElement(import "Menu" "antd", createObj attrs, [])
    
    type MenuItemBuilder() =
        inherit ReactBuilder(null)
    
        [<CustomOperation("danger")>] member inline _.danger (x: DSLElement, v: bool) = x.attr "danger" v 
        [<CustomOperation("disabled")>] member inline _.disabled (x: DSLElement, v: bool) = x.attr "disabled" v 
        [<CustomOperation("icon")>] member inline _.icon (x: DSLElement, v: ReactElement) = x.attr "icon" v
        [<CustomOperation("title")>] member inline _.title (x: DSLElement, v: string) = x.attr "title" v 
        [<CustomOperation("label")>] member inline _.label (x: DSLElement, v: ReactElement) = x.attr "label" v
        
        member inline _.Yield (child: IMenuItem) =
            { Attributes = []; Children = [ child |> box |> unbox<ReactElement> ] }
        
        member _.Run (s: DSLElement) =
            let attrs = s.Attributes
            (createObj attrs) |> box |> unbox<IMenuItem>
    
    type MenuSubMenuBuilder() =
        inherit ReactBuilder(null)
    
        [<CustomOperation("disabled")>] member inline _.disabled (x: DSLElement, v: bool) = x.attr "disabled" v
        [<CustomOperation("icon")>] member inline _.icon (x: DSLElement, v: ReactElement) = x.attr "icon" v
        [<CustomOperation("label")>] member inline _.label (x: DSLElement, v: ReactElement) = x.attr "label" v
        [<CustomOperation("popupClassName")>] member inline _.popupClassName (x: DSLElement, v: string) = x.attr "popupClassName" v 
        [<CustomOperation("popupOffset")>] member inline _.popupOffset (x: DSLElement, v: float array) = x.attr "popupOffset" v
        [<CustomOperation("title")>] member inline _.title (x: DSLElement, v: ReactElement) = x.attr "title" v 
        [<CustomOperation("theme")>] member inline _.theme (x: DSLElement, v: Theme) = x.attr "theme" v 
        [<CustomOperation("onTitleClick")>] member inline _.onTitleClick (x: DSLElement, v: {| key: string; domEvent: MouseEvent |} -> unit) = x.attr "onTitleClick" v 
        
        member inline _.Yield (child: IMenuItem) =
            { Attributes = []; Children = [ child |> box |> unbox<ReactElement> ] }
        
        member _.Run (s: DSLElement) =
            let attrs = s.Attributes @ [
                ("children", box (s.Children |> List.toArray))
            ]
            (createObj attrs) |> box |> unbox<IMenuItem>
        
    type MenuItemGroupBuilder() =
        inherit ReactBuilder(null)
    
        [<CustomOperation("label")>] member inline _.label (x: DSLElement, v: ReactElement) = x.attr "label" v
        
        member inline _.Yield (child: IMenuItem) =
            { Attributes = []; Children = [ child |> box |> unbox<ReactElement> ] }
        
        member _.Run (s: DSLElement) =
            let attrs = s.Attributes @ [
                ("type", "group")
                ("children", box (s.Children |> List.toArray))
            ]
            (createObj attrs) |> box |> unbox<IMenuItem>
        
    type MenuDividerBuilder() =
        inherit ReactBuilder(null)
        
        [<CustomOperation("dashed")>] member inline _.dashed (x: DSLElement, v: bool) = x.attr "dashed" v 
        
        member _.Run (s: DSLElement) =
            let attrs = s.Attributes @ [ ("type", box "divider") ]
            (createObj attrs) |> box |> unbox<IMenuItem>
    