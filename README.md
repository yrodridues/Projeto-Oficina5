# Projeto-Oficina5
Projeto realizado como teste para candidato a parceiro da Oficina5.
Foram utilizadas as tecnologias: C# (para o back), Vue (para o front), e o banco utilizado foi o MongoDb

# Intruções para executar o código:

**Codigo Back-End:** 
* primeiramente entre na pasta: /back-Oficina5/back-projeto5
* nesta pasta digite os comandos: 
> 1. dotnet restore
> 2. dotnet build
> 3. dotnet run
* quando o programa rodar, abra o navegador, e acesse o link: "http://0.0.0.0:5500/swagger/index.html"
> (Desta forma sera aberta uma interface do swagger, com acesso as funçoes da API, para que seja o Teste seja avaliado)
> Se ocorrer algum erro devido a um Timeout, provavelmento é devido a string de conexão com o MongoDB, para corrigir esse erro acesse a pasta do projeto, e entre no arquivo: "appsettings.Development.json", nesse arquivo altere o campo "ConnectionString" para a sua string de conexão com o MongoDB:
 "MongoDB": {
    "ConnectionString": **"mongodb://localhost:27017"** -sua string aqui ,
    "Database": "SGUPO5"
  },
