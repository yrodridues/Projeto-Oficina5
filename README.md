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
> 1. (Desta forma sera aberta uma interface do swagger, com acesso as funçoes da API, para que seja o Teste seja avaliado)
> 2. Se ocorrer algum erro devido a um Timeout, provavelmento é devido a string de conexão com o MongoDB, para corrigir esse erro acesse a pasta do projeto, e entre no arquivo: "appsettings.Development.json", nesse arquivo altere o campo "ConnectionString" para a sua string de conexão com o MongoDB:
> 3. "MongoDB":  {
    "ConnectionString": "mongodb://localhost:27017" -insira aqui sua string de conexão,
    "Database": "SGUPO5"}

**Codigo Front-End:** 
* primeiramente digite o comando:
> 1. npm i
> * tenha certeza que tudo foi instalado corretamente
* em seguida digite o comando:
> 1. npm run serve

* quando o site abrir sera aberta uma tela de login
> 1. Usuario: yuri
> 2. Senha: 123456

