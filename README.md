The .NET projects require .NET 8 SDK.
The Angular UI application performs CRUD operations.
CGC is written in .NET5 (cloned from AZURE DEVOPS API PROJECT).
Implemented Identity server and Ocelot gatway.
The Authorization is commented because the interceptors were not implemented in Angular UI.

LIST TO DO: 
  Display of all bugs in a list - Bug Id, Title, State, Priority, Assigned To ------ Implemented
  Select and multi-select ---- Implemented
  Delete a bug ---- Implemented
  To "delete", in Azure DevOps, you set the WorkItem State = Removed ----- Implemented
  Log the delete in the revisions history ---- Added comments to Fields/System.Hitory
  View further bug details,Severity, Repro Steps, etc. ----- Implemented
  Edit and save updates   E.g., change Title, Priority, Severity, Repro Steps------ implemented
  Log all changes to revisions history ---- there is no API end point to Update evisions history.