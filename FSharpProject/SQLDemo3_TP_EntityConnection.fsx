// This provider is core library

#if INTERACTIVE
#r "FSharp.Data.TypeProviders.dll"
#r "System.Data.Entity.dll"
#r "System.Data.Linq.dll"
#endif

open System.Data.Linq
open System.Data.Entity
open Microsoft.FSharp.Data.TypeProviders

let [<Literal>] connStr = @"Data Source=.\sqlexpress;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"

type SQL = SqlEntityConnection<ConnectionString=connStr, Pluralize=true >
let db = SQL.GetDataContext()

// tables

db.Employees |> Seq.map(fun e -> e.Notes) |> Seq.toArray
db.Customers |> Seq.head

// views

db.Alphabetical_list_of_products |> Seq.map (fun p -> p.ProductName) |> Seq.toArray

// Metadata properties :)

db.Customers.EntitySet.MetadataProperties |> Seq.map(fun p -> p.Name) |> Seq.toArray

db.Customers.EntitySet.MetadataProperties 
            |> Seq.filter(fun p -> p.Name = "DefiningQuery") 
            |> Seq.toList
            |> List.head

// updating database

let newCustomer = 
  SQL.ServiceTypes.Customer( 
    CustomerID="MURTG", 
    ContactName="Murat Girgin", 
    City="Seattle",
    CompanyName= "Acme Inc"   
  )
db.Customers.AddObject newCustomer
db.DataContext.SaveChanges()



