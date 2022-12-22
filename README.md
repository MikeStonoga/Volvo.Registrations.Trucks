# Volvo.Registrations.Trucks

Clone o repositório.

## Back-end
0. Está na versão .NET 7, portanto, é necessário que você tenha instalado o sdk [Download](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-7.0.101-windows-x64-installer)
1. A API está dentro da pasta **Volvo.Registrations.Trucks.WebHost.API** que está dentro da pasta da solução **Volvo.Registrations.Trucks**
2. Dentro da pasta da API, será necessário configurar sua connection string para o banco de dados *(SQL Server)*. 
  - Altere tanto a connection string do SqlServer quanto do HangfireConnection.
  - Sua connection string deve conter o parâmetro TrustServerCertificate=True
3. Abra o cmd na pasta da API e execute o comando *dotnet run --launch-profile "https"*


## Front-end
0. O projeto do frontend está dentro da pasta **Volvo.Registrations.Trucks.SPA.Angular** que está dentro de **Volvo.Registrations.Trucks**
1. Não se esqueça de executar o *npm install* logo dentro da pasta **Volvo.Registrations.Trucks.SPA.Angular**  após ter clonado o repositório.
2. Execute o comando *npm start*. 
3. Acesse seu navegador na url [localhost](http://localhost:4200) - http://localhost:4200
