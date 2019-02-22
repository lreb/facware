# DB


### Scaffold models from db

`Scaffold-DbContext "Data Source=MXCHIM0MIDSQL01;User ID=jabil\\chisqladmin;Password=N3w5q1Adm1n2012;Initial Catalog=JabilMaster;Integrated Security=True;Timeout=1200;MultipleActiveResultSets=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir ModelsJabilMaster -Context ModelsJabilMaster`

´Scaffold-DbContext "Data Source=MXCHIM0MIDSQL01;User ID=jabil\\chisqladmin;Password=N3w5q1Adm1n2012;Initial Catalog=JabilMaster;Integrated Security=True;Timeout=1200;MultipleActiveResultSets=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DataAccessModels/Dashboards -ContextDir DataAccessContext/Dashboards -Context DashboardsContext -DataAnnotations´

`Scaffold-DbContext "Data Source=MXCHIM0MIDSQL01;User ID=jabil\\chisqladmin;Password=N3w5q1Adm1n2012;Initial Catalog=JabilMaster2;Integrated Security=True;Timeout=1200;MultipleActiveResultSets=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DataAccessModels/Dashboards -Schemas productionplan -ContextDir DataAccessContext/Dashboards -Context DashboardsContext -DataAnnotations -Force`

### 



## Source
(https://www.learnentityframeworkcore.com/walkthroughs/existing-database)[ef]