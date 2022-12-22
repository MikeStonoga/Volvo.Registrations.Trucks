# Volvo.Registrations.Trucks

# EN-US
## Back-end
0. It is in the .NET 7 version, so it is necessary that you have installed the sdk [Download](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-7.0.101-windows-x64-installer)
1. The API is inside the folder **Volvo.Registrations.Trucks.WebHost.API** which is inside the solution folder **Volvo.Registrations.Trucks**
2. Inside the API folder, you will need to configure your connection string for the *SQL Server* database.

  >  Change both SqlServer and HangfireConnection connection string.
  
  >  Your connection string must contain the parameter TrustServerCertificate=True;
  
3. Open cmd in API folder and run command *dotnet run --launch-profile "https"*

## Front-end
0. The frontend project is inside the folder **Volvo.Registrations.Trucks.SPA.Angular** which is inside **Volvo.Registrations.Trucks**
1. Don't forget to run *npm install* right inside the **Volvo.Registrations.Trucks.SPA.Angular** folder after cloning the repository.
2. Run the *npm start* command.
3. Access your browser at the url [localhost](http://localhost:4200) - http://localhost:4200


# PT-BR
## Back-end
0. Está na versão .NET 7, portanto, é necessário que você tenha instalado o sdk [Download](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-7.0.101-windows-x64-installer)
1. A API está dentro da pasta **Volvo.Registrations.Trucks.WebHost.API** que está dentro da pasta da solução **Volvo.Registrations.Trucks**
2. Dentro da pasta da API, será necessário configurar sua connection string para o banco de dados *SQL Server*. 

  >  Altere tanto a connection string do SqlServer quanto do HangfireConnection.
  
  >  Sua connection string deve conter o parâmetro TrustServerCertificate=True
  
3. Abra o cmd na pasta da API e execute o comando *dotnet run --launch-profile "https"*


## Front-end
0. O projeto do frontend está dentro da pasta **Volvo.Registrations.Trucks.SPA.Angular** que está dentro de **Volvo.Registrations.Trucks**
1. Não se esqueça de executar o *npm install* logo dentro da pasta **Volvo.Registrations.Trucks.SPA.Angular**  após ter clonado o repositório.
2. Execute o comando *npm start*. 
3. Acesse seu navegador na url [localhost](http://localhost:4200) - http://localhost:4200
