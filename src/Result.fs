namespace Fsconsole

module Result = 
    type Result<'a> = 
        | Success of 'a
        | Failure of string list

    let map f xResult =
        match xResult with
        | Success x -> 
            Success(f x)
        | Failure errs ->
            Failure errs
    
    let retn x = 
        Success x

    let apply fResult xResult =
        match fResult, xResult with
        | Success f, Success x ->
            Success (f x)
        | Success f, Failure errs -> 
            Failure errs
        | Failure errs, Success x -> 
            Failure errs
        | Failure errs1, Failure errs2 -> 
            Failure (errs1 @ errs2)

    let bind f xResult = 
        match xResult with
        | Success x ->
            f x
        | Failure errs -> 
            Failure errs