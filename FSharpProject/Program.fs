#if COMPILED
module FSDemo  
#endif

// class
type Test(x:int, y:int) = 
    member val X = x with get, set
    member val Y = y with get, set
    member val Name = "" with get, set
    
    member th.Mul() = th.X * th.Y
    member this.MulSquares() = this.X * this.X + this.Y * this.Y
    
    new(x:string) as this = Test(0,0) then 
        this.Name <- x
    
    override a.ToString() = sprintf "(%s %d,%d)" a.Name a.X a.Y 


// no need to have a seperate Program class with a "Main" method -- 
// body of the file can be considered as "Main"

let x = (1, 3.14, "hello")  // tuple
let (_,pi,_) = x            // basic pattern matching
printfn "%f" pi             // typed "print"
let a = new Test(3,4);      
printfn "%A" a
let (a1, a2) = (float a.X * 3.4, a.Y * 1000)


(*
// "record" == immutable type with structural equality semantics (instead of ref. semantics)
type Test2 = { X: int; Y: int } with
    override a.ToString() = sprintf "(%d,%d)" a.X a.Y
let b = {X=100; Y=200}  // instantiate
//*)

(*  

// Explicit entrypoint (== C# Main) is possible

[<EntryPoint>]
let mymain argv = 
    printfn "%A" argv
    0 // return an integer exit code

// *)
