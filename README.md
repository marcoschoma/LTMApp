# Marcos Braga Choma - LTM Test

Este projeto visa atender as especificações do teste da LTM Group.
Possui duas aplicações: WebAPI (Asp.Net Core Web API) e WebUI (Angular 5.2).

# Banco de dados

O banco de dados é acessado pela aplicação WebAPI, e sua string de conexão está configurada no arquivo appsettings.json. Durante o desenvolvimento foi utilizado o SGBD Sql Server Express 2014.

Ao iniciar a aplicação a estrutura do banco é criada se o mesmo não existir, e as tabelas são populadas com dados de teste.

# WebAPI - Back-end

Aplicação back-end que expõe serviços REST de login e consulta a produtos.
Desenvolvida com Asp.Net Core 2.0, esta aplicação segue o padrão de arquitetura DDD.

## Executando a aplicação

Para executar a aplicação, basta possível abrir a solution no Visual Studio 2017 (Professional ou Community).
É necessário configurar a chave 'UrlApi' com a URL que o IISExpress irá atribuir a WebAPI durante a execução.

# WebUI - Front-end

Aplicação Angular 5.2 gerada a partir do angular-cli. Utiliza JWT para autenticar-se na WebAPI e possui uma página de login e a Home, na qual são listados os produtos cadastrados.

## Segurança

Ao acessar a aplicação é verificado o token de autenticação do usuário. Se não estiver presente, ou estiver expirado/inválido, o usuário é redirecionado para página de login. Ao identificar-se o usuário é redirecionado a listagem de produtos.

## Executando a aplicação cliente

Utilizando o terminal de sua preferência, acesse o diretório raíz da aplicação e utilize o comando `npm install` para restaurar os packages necessários, e então `ng serve --open` para executar o servidor de aplicação. Será aberto o navegador padão, apontando para o endereço `http://localhost:4200/`.

# O autor

Marcos desenvolve aplicações comerciais desde 2003 e já utilizou linguagens como C#, Java e Python.
marcos.choma@gmail.com
