# WebApi_RepositoryPattern

# WebAPI de Gerenciamento de Funcionários da Empresa

Este repositório contém uma WebAPI desenvolvida em ASP.NET Core utilizando a linguagem C#, que oferece endpoints para gerenciar informações de funcionários de uma empresa. 
A aplicação está integrada a um banco de dados chamado "EmpresaFuncionarios", permitindo a realização de operações CRUD (Create, Read, Update e Delete) através dos verbos HTTP.

## Endpoints da API

A API oferece os seguintes endpoints para gerenciar informações de funcionários:

### 1. Listar Todos os Funcionários

- **Descrição:** Retorna uma lista de todos os funcionários cadastrados na empresa.
- **Verbo HTTP:** GET
- **Rota:** `/api/funcionarios`
- **Resposta de Sucesso:** Retorna uma lista de objetos `FuncionarioModel`.
- **Resposta de Erro:** Retorna uma mensagem de erro se ocorrer algum problema.

### 2. Consultar Informações de um Funcionário

- **Descrição:** Permite consultar informações detalhadas de um funcionário específico com base no seu ID.
- **Verbo HTTP:** GET
- **Rota:** `/api/funcionarios/{id}`
- **Parâmetro de Rota:** `id` (ID do funcionário)
- **Resposta de Sucesso:** Retorna um objeto `FuncionarioModel` com as informações do funcionário.
- **Resposta de Erro:** Retorna uma mensagem de erro se o funcionário não for encontrado.

### 3. Criar Novo Funcionário

- **Descrição:** Permite adicionar novos registros de funcionários à base de dados.
- **Verbo HTTP:** POST
- **Rota:** `/api/funcionarios`
- **Corpo da Requisição:** Um objeto `FuncionarioModel` com os detalhes do novo funcionário.
- **Resposta de Sucesso:** Retorna uma mensagem de sucesso e a lista atualizada de funcionários.
- **Resposta de Erro:** Retorna uma mensagem de erro se ocorrer algum problema durante a criação.

### 4. Atualizar Informações de um Funcionário

- **Descrição:** Permite atualizar as informações de um funcionário existente com base no seu ID.
- **Verbo HTTP:** PUT
- **Rota:** `/api/funcionarios/{id}`
- **Parâmetro de Rota:** `id` (ID do funcionário)
- **Corpo da Requisição:** Um objeto `FuncionarioModel` com as informações atualizadas.
- **Resposta de Sucesso:** Retorna uma mensagem de sucesso e a lista atualizada de funcionários.
- **Resposta de Erro:** Retorna uma mensagem de erro se o funcionário não for encontrado ou se ocorrer algum problema durante a atualização.

### 5. Excluir Funcionário

- **Descrição:** Permite excluir registros de funcionários com base no ID do funcionário.
- **Verbo HTTP:** DELETE
- **Rota:** `/api/funcionarios/{id}`
- **Parâmetro de Rota:** `id` (ID do funcionário)
- **Resposta de Sucesso:** Retorna uma mensagem de sucesso e a lista atualizada de funcionários após a exclusão.
- **Resposta de Erro:** Retorna uma mensagem de erro se o funcionário não for encontrado ou se ocorrer algum problema durante a exclusão.

### 6. Inativar Funcionário

- **Descrição:** Permite marcar um funcionário como inativo com base no ID do funcionário.
- **Verbo HTTP:** PUT
- **Rota:** `/api/funcionarios/inativar/{id}`
- **Parâmetro de Rota:** `id` (ID do funcionário)
- **Resposta de Sucesso:** Retorna uma mensagem de sucesso e a lista atualizada de funcionários após a inativação.
- **Resposta de Erro:** Retorna uma mensagem de erro se o funcionário não for encontrado ou se ocorrer algum problema durante a inativação.


## Configuração e Uso

Para configurar e usar esta WebAPI em sua máquina local, siga os seguintes passos:

1. Clone este repositório em sua máquina local.

2. Abra o projeto em sua IDE preferida.

3. Configure a conexão com o banco de dados no arquivo de configuração `appsettings.json`.

4. Execute as migrações para criar o esquema do banco de dados:

   ```bash
   dotnet ef database update
