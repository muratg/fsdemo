//Install-Package SQLProvider -prerelease
#if INTERACTIVE
#r @"C:\src\fsdemo\packages\SQLProvider.0.0.6-alpha\lib\net40\FSharp.Data.SqlProvider.dll"
#endif

open System
open System.Linq
open FSharp.Data.Sql

let [<Literal>] connStr = @"Data Source=.\sqlexpress;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"

type SQL = SqlDataProvider<connStr>

let db = SQL.GetDataContext()

// relationships..

let anton = db.``[dbo].[Customers]``.Individuals.``As Country``.``ANTON, Mexico``
let orders = anton.FK_Orders_Customers

// basic querying..

let q1 = 
    query { 
        for cat in db.``[dbo].[Categories]`` do
        select (cat.CategoryID, cat.CategoryName, cat.Description) }
    |> Seq.iter (fun (id, name, desc) ->
        printfn "ID: %d -- Cat. name: %s -- Description: %s\n" id name desc)

// filtering with "where"

let q2 = query {
    for cust in db.``[dbo].[Customers]`` do
    where (cust.Country = "Poland")
    select cust }  |> Seq.toArray

// nested conditional logic allowed in "where" clauses

let q3 = query {
    for cust in db.``[dbo].[Customers]`` do
    where (cust.Country = "USA" && cust.CompanyName.Contains("Market"))
    select cust } |> Seq.map (fun c -> c.ContactName)  |> Seq.toArray


// joins

let automaticJoinQuery =
   query { for customer in db.``[dbo].[Customers]`` do
           for order in customer.FK_Orders_Customers do
           where (customer.ContactName = "Mario Pontes")
           select (customer,order) } |> Seq.toArray

let explicitJoinQuery =
   query { for customer in db.``[dbo].[Customers]`` do
           join order in db.``[dbo].[Customers]`` on (customer.CustomerID = order.CustomerID)
           where (customer.ContactName = "Mario Pontes")
           select (customer,order) } |> Seq.toArray

let specificFieldsQuery = query { 
           for customer in db.``[dbo].[Customers]`` do
           for order in customer.FK_Orders_Customers do
           where (customer.ContactName = "Mario Pontes")
           select (customer.ContactName, order.OrderDate, order.ShipAddress) } |> Seq.toArray

// stored procedures

let salesByYear = db.``Stored Procedures``.``[dbo].[Sales by Year]``
salesByYear(new DateTime(1994,1,1), new DateTime(2012,1,1))



