dotnet ef database drop -p Infrastructure/ -s API/ <br>
dotnet ef migrations remove -p Infrastructure/ -s API/   <br>
dotnet ef migrations add InitialMigrations -p Infrastructure/ -s API/ <br>
dotnet ef migrations add InitialMigrations -p Infrastructure/ -s API/ -o Data/Migrations<br>