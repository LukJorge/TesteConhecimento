# Tecnologias

    Foi utilizado para o desenvolvimento do teste as seguintes tecnologias: 

    * .Net Core, com C#
    * Identity Server, para autenticação
    * Sql Server, como banco de dados
    * Dapper, para simplificar as chamadas ao banco 

# Sobre o teste

    O teste foi dividido em duas partes. A primeira é nossa Web Application(API), que é responsável por prover a autenticação e receber as chamadas do client, além de ser nosso "backend", realizando as operações com o banco de dados.

    A segunda parte é nosso client, foi criado um ConsoleApp que se autentica e dispara as chamadas de acordo com o programado.

# Como executar

    1. Execute os scripts de banco de dados
    2. Configure o "appsettings.json" do backend para acessar o banco
    3. Execute o backend
    4. Configurar no client (program.cs) as chamadas que serão executadas
    5. Execute o client 
