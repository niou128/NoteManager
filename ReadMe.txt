



https://msdn.microsoft.com/fr-fr/dn434042.aspx
->version Express with Advanced Services (SQLEXPRADV) 64bits

Créer le web service : https://msdn.microsoft.com/fr-fr/library/bb386386.aspx
Entity framework : http://pmusso.developpez.com/tutoriels/dotnet/entity-framework/introduction/

Utiliser le WS :
- copier le fichier Service/App_to_copy.config en Service/App.config
- modifier le chemin dans App.config pour accéder à la bdd
 <add name="DatabaseEntities" connectionString="metadata=res://*/Model.DatabaseDbModel.csdl|res://*/Model.DatabaseDbModel.ssdl|res://*/Model.DatabaseDbModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=C:\Users\user\Documents\NoteManager\Service\Database.mdf;integrated security=True;connect timeout=30;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" /></connectionStrings>
- login : admin // password : admin