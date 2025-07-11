# 📚 Donation.API

Donation é uma aplicação web desenvolvida em C# com ASP.NET Core MVC e banco de dados SQL Server. O objetivo do sistema é facilitar a doação e troca de produtos entre usuários, promovendo o consumo consciente e solidário.

---

## 🛠️ Tecnologias Utilizadas

- **C#**
- **ASP.NET Core**
- **SQL** 
- **Entity Framework Core**
- **Swagger**
- **JWT Authentication**

---

## 🗂️ Funcionalidades Implementadas

A aplicação conta com as principais operações de CRUD (Create, Read, Update, Delete), além de regras específicas para controle de trocas e disponibilidade de produtos.

- **Usuários**- Cadastro, Login com autenticação, consulta, edição e exclusão de contas
- **Produtos**- Cadastro de produtos para troca, consulta de produtos disponiveis, atualização e exclusão de produtos, controle de disponibilidade
- **Categorias**- Cadastro e listagem de categorias associadas aos produtos
- **Trocas**- Solicitação de troca entre produtos, regras de validação baseadas na disponibilidade, valor e propriedade dos produtos

## 🗂️ Estrutura do Projeto
- **Models** - Definição das entidades de domínio
- **Data** - DataContext com configuração do EF Core
- **Controllers** - Controle de rotas e lógica de entrada/saída
- **Repository** - Camada de acesso a dados
- **Services** - Camada de regras de negócio (TrocaService)

---
