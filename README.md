# API de Gerenciamento de Veículos | Bootcamp Avanade .NET & IA

![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet?style=for-the-badge&logo=.net)
![C#](https://img.shields.io/badge/C%23-12.0-green?style=for-the-badge&logo=c-sharp&logoColor=white)
![MySQL](https://img.shields.io/badge/MySQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)

> Projeto desenvolvido para o bootcamp **"Avanade - Back-end com .NET e IA"** da [Digital Innovation One (DIO)](https://dio.me/).

---

## 📖 Sobre o Projeto

Este projeto consiste na criação de uma API RESTful para o gerenciamento de uma frota de veículos. A aplicação foi desenvolvida utilizando .NET 8 com Minimal APIs, seguindo uma arquitetura limpa e organizada.

**Este projeto foi construído com base nas aulas e no passo a passo guiado pelo instrutor do bootcamp, servindo como uma aplicação prática para solidificar os conceitos de desenvolvimento back-end com .NET aprendidos durante o curso.**

---

## ✨ Funcionalidades

-   [x] **Autenticação de Administradores:** Sistema de login seguro utilizando tokens JWT (JSON Web Tokens).
-   [x] **Cadastro de Veículos:** Adição de novos veículos à base de dados.
-   [x] **Listagem de Veículos:** Consulta de todos os veículos cadastrados.
-   [x] **Busca de Veículo por ID:** Obtenção de detalhes de um veículo específico.
-   [x] **Atualização de Veículos:** Modificação dos dados de um veículo existente.
-   [x] **Exclusão de Veículos:** Remoção de um veículo da base de dados.
-   [x] **Documentação com Swagger:** Endpoints documentados e disponíveis para teste via Swagger UI.

---

## 🏛️ Arquitetura Aplicada

O projeto foi estruturado em camadas para garantir a separação de responsabilidades (Separation of Concerns), facilitando a manutenção e escalabilidade.

-   `📁 Dominio`: Camada central da aplicação. Contém as entidades (`Veiculo`, `Administrador`), os DTOs, as interfaces de serviço e as regras de negócio principais. É o coração do software.
-   `📁 Infraestrutura`: Responsável pela comunicação com tecnologias externas, como o banco de dados. Aqui se encontra o `DbContexto` do Entity Framework Core.
-   `🚀 API (Projeto Principal)`: Camada de entrada da aplicação. Responsável por expor os endpoints, receber as requisições HTTP, lidar com a autenticação e orquestrar as chamadas para a camada de domínio.

---

## 🛠️ Tecnologias Utilizadas

As seguintes ferramentas e tecnologias foram utilizadas na construção do projeto:

-   **Backend:**
    -   C# 12 e .NET 8
    -   ASP.NET Core (com Minimal APIs)
    -   Entity Framework Core 8
    -   Autenticação com JWT Bearer
-   **Banco de Dados:**
    -   MySQL
    -   Pomelo Entity Framework Core Provider for MySql
-   **Ferramentas e Documentação:**
    -   Swagger (Swashbuckle)
    -   Git & GitHub

---

## 🚀 Como Executar o Projeto

Siga os passos abaixo para rodar a aplicação localmente.

### Pré-requisitos:

-   [.NET 8 SDK](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)
-   Um servidor de banco de dados MySQL (local ou em nuvem)
-   Um editor de código de sua preferência (ex: VS Code, Visual Studio)

### Passos:

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/DimasRabelo/minimal-api.git](https://github.com/DimasRabelo/minimal-api.git)
    cd minimal-api
    ```

2.  **Configure a Conexão com o Banco de Dados:**
    -   Abra o arquivo `appsettings.json`.
    -   Altere a `DefaultConnection` com os dados de acesso ao seu banco de dados MySQL.
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;Database=nome_do_seu_banco;Uid=seu_usuario;Pwd=sua_senha;"
    }
    ```

3.  **Aplique as Migrations:**
    -   Abra um terminal na pasta raiz do projeto e execute o comando abaixo para criar o banco de dados e aplicar as tabelas.
    ```bash
    dotnet ef database update
    ```

4.  **Execute a Aplicação:**
    ```bash
    dotnet run
    ```
    A API estará disponível em `http://localhost:5000` (ou outra porta definida no `launchSettings.json`).

---

## 📄 Endpoints da API

Após iniciar a aplicação, a documentação completa dos endpoints, com exemplos de requisições e respostas, estará disponível na interface do Swagger.

-   **URL do Swagger:** [http://localhost:5000/swagger](http://localhost:5000/swagger)

---

## 👨‍💻 Autor

Feito com ❤️ por **Dimas Aparecido Rabelo de Souza**

[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/dimasrabelo/)

---

## 🙏 Agradecimentos

Agradeço à **DIO** e à **Avanade** pela oportunidade de aprendizado, **e especialmente ao instrutor do curso pela excelente didática e pelo passo a passo na construção deste projeto.**
