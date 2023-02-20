<div>
  <h1>DevEncurtaUrl</h1>
  <p>É um projeto de uma Web API de encurtador de url desenvolvido com C#, .NET 7, EntityFramework Core com SQLServer e ASP.NET Core durante a Jornada .NET 8, da Luis Dev Treinamentos em Programação.</p>
  <p>Como desafios para o projeto, decidi implementa-lo utilizando a arquitetura limpa, utilização dos padrões CQRS (Command-Query Responsibility Segregation) e Repository e também foram desenvolvidos testes unitários com xUnit, para fins de prática e aprendizado.</p>

  <h3>Tecnologias utilizadas:</h3>
  <pre>
  1. Linguagem C#
  2. .NET 7
  3. Desenvolvimento de Web APIs Rest com ASP.NET Core
  4. Utilização de Clean Architecture, Command-Query Responsility Segregation (CQRS) para
     separar as consultas (Queries) das ações que alteram o estado do sistema (Commands) e Padrão
     Repository para encapsular o acesso a dados, desacoplando detalhes de implementação através 
     de interfaces.
  5. Persistência e acesso à dados com Entity Framework Core e SQL Server
  6. Testes Unitários com xUnit
  7. Logs com Serilog
  </pre>
  
  <h3>Instruções para obter o repositório e rodar o projeto:</h3>
  <h4>1. Pré-requisitos:</h4>
  <pre>
  a. <a href="https://git-scm.com/">Git</a>
  b. <a href="https://dotnet.microsoft.com/en-us/download">.NET SDK e Runtime</a>
  c. <a href="https://code.visualstudio.com/">Visual Studio Code</a> ou <a href="https://visualstudio.microsoft.com/pt-br/downloads/">Visual Studio</a>
  d. <a href="https://www.microsoft.com/pt-br/sql-server/sql-server-downloads">MSSQL Server (Express)</a> e <a href="https://www.microsoft.com/pt-br/sql-server/sql-server-downloads">SQL Sever Management Studio</a> ou <a href="https://azure.microsoft.com/pt-br/products/data-studio">Azure Data Studio</a>
  </pre>
  
  <h4>2. Clonando o Repositório</h4>
  <p>a. Crie a pasta que irá receber o clone do projeto.</p>
  <p>b. Abra um terminal no caminho da pasta e insira o comando abaixo.</p>
  <pre><code>git clone git@github.com:Thiago-Gonzalez/DevEncurtaUrl.Server.git</code></pre>   

  <h4>3. Configurações para rodar o projeto:</h4>
  <p>a. Instalando o Entity Framework Core globalmente na sua máquina:<p>
  <p>No terminal, inserir o comando abaixo para instalar o EF Core globalmente.</p>
  <pre><code>dotnet tool install --global dotnet-ef</code></pre>
  <p>b. Abrindo o projeto utilizando o Visual Studio:</p>
  <p>Abra a pasta do projeto no exporador de arquivos e abra o arquivo solução (.sln).</p>
  <p>c. Abrindo o projeto pelo Visual Studio Code:</p>
  <p>Com o terminal aberto na pasta do projeto, insira o comando abaixo ou então abra o VSCode, vá em Arquivo => Abrir pasta 
e selecione a pasta do projeto.</p>
  <pre><code>code .</code></pre>
  <p>d. Aplicar as migrations:</p>
  <blockquote>Caso tenha instalado o SQL Server com o SQL Login, será necessário alterar a connectionString na aplicação antes
de aplicar as migrations. Para isso, no arquivo **appsetting.json** localizado dentro do projeto de API, altere a 
connectionString conforme código abaixo.</blockquote>
  <pre><code>"ConnectionStrings": {
   "DevEncurtaUrlCs": "Server=localhost;Database=DevEncurtaUrl;User Id=sa;Password=********;trustServerCertificate=true"
}</code></pre>
  <p>Com o projeto aberto no terminal na pasta DevEncurtaUrl.Infrastructre, inserir o comando abaixo para aplicar
as migrations no banco.</p>
  <pre><code>dotnet ef database update -s ../DevEncurtaUrl.API/DevEncurtaUrl.API.csproj</code></pre>
  <blockquote>Nota: Caso ocorra algum problema com o comando anterior, verifique se está na pasta correta, pois isso inflencia
no path do csproj da camada API passado como parâmetro.</blockquote>
  <p>e. Rodando o projeto:</p>
  <p>Antes de rodar o projeto, com o terminal aberto na raíz do projeto, insira os comandos abaixo para restaurar
os pacotes nuget e buildar a aplicação.</p>
  <pre><code>dotnet restore</code></pre>
  <pre><code>dotnet build</code></pre>
  <p>Rode a aplicação pelo Visual Studio clicando no botão com ícone play de cor verde "DevEncurtaUrl.API".</p>
  <p>Já pelo Visual Studio Code, com a pasta da web api DevEncurtaUrl.API aberta no terminal, insira o comando abaixo.</p>
  <pre><code>dotnet run</code></pre>

  <h4>4. Rota para testes e documentação da API com Swagger:</h4>
  <a href="https://localhost:9000/swagger/index.html">[Swagger]</a>

  <h4>5. Acesso ao banco de dados:</h4>
  <p>a. Se você optou por utilizar o Azure Data Studio com SQL Login:</p>
  <pre>
  Connection Type: Microsoft SQL Server
  Server: localhost
  Authentication type: SQL Login
  User name: sa
  Password: ********
  </pre>
  <p>b. Se você optou por utilizar o SQL Server Management Studio com Windows Authentication:</p>
  <pre>Selecione o tipo de autenticação com Windows Authentication e ao aplicar as migrations, o banco 
do DevEncurtaUrl estará disponível para uso.</pre>

  <h3>Consumindo a API:</h3>
  <h4>Url base:</h4>
  <p>localhost:3000</p>
  <h4>Listar links encurtados:</h4>
  <p>Endpoint: localhost:3000/api/shortenedLinks</p>
  <h4>Cadastrar um link encurtado:</h4>
  <p>Enpoint: localhost:3000/api/shortenedLinks</p>
  <p>Request Body: { "title": "string", "destinationLink": "string" }</p>
  <p>Exemplo: { "title": "linkedin-thiagogonzalez Social", "destionationLink": "https://www.linkedin.com/in/thiago-gonz%C3%A1lez/" }</p>
  <p>Link encurtado: localhost:3000/linkedin-thiagogonzalez</p>
  <h4>Buscar link encurtado por Id:</h4>
  <p>Endpoint: localhost:3000/api/shortenedLinks/id</p>
  <h4>Atualizar link encurtado:</h4>
  <p>Endpoint: localhost:3000/api/shortenedLinks/id</p>
  <p>Request Body: { "title": "string", "destinationLink": "string" }</p>
  <h4>Deletar link encurtado:</h4>
  <p>Endpoint: localhost:3000/api/shortenedLinks/id</p>
  <h4>Redirecionar link encurtado:</h4>
  <p>Endpoint: localhost:3000/code</p>
  <p>Nota:</p>
  <pre>Code: Consiste no primeiro elemento da lista formada pelos elementos da string Title com separador 
sendo um espaço em branco (Title.Split(" ")[0]).</pre>

  <h3>Pré-visualização:</h3>
  <img src="https://cdn.discordapp.com/attachments/1073613352091271279/1077030207581597726/deepin-screen-recorder_Select_area_20230217172144.gif" />
  <img src="https://cdn.discordapp.com/attachments/1073613352091271279/1077030472661610506/Captura_de_tela_de_2023-02-17_16-44-15.png" />
  
  <h4>Nota:</h4>
  <pre>Front-end da aplicação exibido no preview foi desenvolvido pela equipe LuisDev para consumo
durante a Jornada .NET 8 e seu repositório está disponível no github do @luisdeol (<a href="https://github.com/luisdeol/dev-encurta-url-front">link</a>).</pre>
<p align="center">© Thiago González</p>
</div>
