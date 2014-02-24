// basic variables

let name = "ASP"
let number = 999 

// types: Classes, records, discriminated unions, ..

type Colors = 
    | Red 
    | Green
    | Blue
    | RGBA of int*int*int*int  // red, green, blue, alpha


let myColor = RGBA (255,0,0,255)



// pattern matching

let getName color =
    match color with
    | Red -> "red"
    | Blue -> "blue"
    | Green -> "green"
    | RGBA (r,g,b,_) -> sprintf "hex: red: %x green: %x blue: %x"  r g b

getName Red
getName ( RGBA(255,200,200,100) )


// functions with tuple-like arguments

let addT(x, y) = x + y

printfn "%d" (addT (3,4)) 

System.Console.WriteLine("{0} {1}", "test", 3.13)

// functions with multiple arguments

let add x y = x + y 


printfn "%d" (add 3 4) 

// partial application / currying

let add100 = add 100

printfn "%d" (add100 4)

// piping operator

let title = "these two are equivalent"
title |> printfn "%s"  
(printfn "%s") title 

// lists

let numbers: list<int> = [1;  2; 3]


let myList = ["hello", 1; "world", 2] // list of tuples

myList |> List.map ( fun (str, num) -> str ) 
// equivalent to the expresssion below:
List.map (fun (str, num) -> str) myList

// folding (in C# LINQ this is Aggregate)
numbers |> List.fold (+) 0  // multiply all elements

let mulList = List.fold(*) 1 

mulList numbers

// arrays (== .NET arrays) (values mutable)
let numbersA = [| 1; 2; 3 |]

// sequences (== .NET IEnumerables)  
let mySeq1 = seq { for i in 1 .. 10 do yield i * i }
let mySeq2 = seq { for i in 1 .. 10 -> i * i }

Seq.iter (printf "%d ") mySeq1
mySeq1 |> Seq.iter (printf "%d")
Seq.iter (fun elem -> printf "%d" elem) mySeq1

// sequences, arrays, lists, can be converted to each other.

// comprehensions
// list
let squares = [ for x in 1..100 -> x*x ]
let evens = [ for x in 1..100 do if x % 2 = 0 then yield x ]
// array
let squaresA = [| for x in 1..100 -> x*x |]
let evensA=  [| for x in 1..100 do if x % 2 = 0 then yield x |]

// identifiers with non standard names
let ``..... my identifier 001" `` = 100;
let result = 100 * ``..... my identifier 001" `` 

