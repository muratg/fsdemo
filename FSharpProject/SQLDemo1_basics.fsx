//Install-Package SQLProvider -prerelease
#if INTERACTIVE
#r @"C:\src\fsdemo\packages\SQLProvider.0.0.6-alpha\lib\net40\FSharp.Data.SqlProvider.dll"
#endif

open System
open System.Linq
open FSharp.Data.Sql


// One of the EF test databases

let [<Literal>] connStr = @"Data Source=.\sqlexpress;Initial Catalog=AdvancedPatternsDatabase;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"

type SQL = SqlDataProvider<connStr>
let db = SQL.GetDataContext();


// db.BuildingDe`tails |> 

let q1 = query {
    for bld in db.``[dbo].[Buildings]`` do 
    select bld
} 

q1 |> Seq.iter(fun b -> printfn "%s - %s" b.Name b.Address_City )

let q2 = query {
    for emp in db.``[dbo].[Employees]`` do select emp
} 

q2 |> Seq.iter(fun e -> printfn "%s %A" e.FirstName e.Manager_EmployeeId )

// individuals..
let rowan = db.``[dbo].[Employees]``.Individuals.``As FirstName``.``2, Rowan``

rowan.EmployeeId