#dotnet ef migrations add InitialCreate --project FormulaOne.Presistence --startup-project FormulaOne.Api --output-dir Migrations --context ApplicationDbContext
dotnet ef database update --project FormulaOne.Presistence --startup-project FormulaOne.Api --context ApplicationDbContext
pause