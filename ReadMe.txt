Right Click on Solution->Set Startup Projects->Multiuple Startup Projects
Verify that 2 projects are selected (a) Wingtiptoy.Web (b)Wingtiptoys.Api
Change the connection string if required in Web.config of Wingtiptoys.Api project
If Wingtiptoys.Api is not running on https://localhost:44301 then Change Web.config of Wingtiptoy.Web ---- > configuration-> appSettings --> <add key="ApiUrl" value="ChangeThisValue" />