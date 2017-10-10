namespace MT103DEFAULT.TransformationRule

open System
open System.ComponentModel.Composition
open Swift.Transformation.Rules.Contracts.MT103
open Swift.Transformation.Common

[<Export(typeof<ITransformationRule>)>]
[<RuleInfo("key-1","TBCBGE22AXXX")>]
type MT103_Default_Rule() = 
    inherit MT103_DEFAULT_Rule(
        fun (a) -> 
            let b6 = new B6MT103()
            b6
    )
