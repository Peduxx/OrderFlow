# 🛒 OrderFlow - Sistema de Gerenciamento de Pedidos

![GitHub repo size](https://img.shields.io/github/repo-size/Peduxx/OrderFlow)
![GitHub license](https://img.shields.io/github/license/Peduxx/OrderFlow)
![GitHub contributors](https://img.shields.io/github/contributors/Peduxx/OrderFlow)
![GitHub Release](https://img.shields.io/github/v/release/Peduxx/OrderFlow)
![GitHub tag (latest by date)](https://img.shields.io/github/v/tag/Peduxx/OrderFlow)

![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)
![Version](https://img.shields.io/badge/version-1.0.0-blue.svg)

## 📌 Visão Geral

**OrderFlow** é um sistema de gerenciamento de pedidos para e-commerce, desenvolvido em **.NET 8**, utilizando **PostgreSQL** e **AWS** para infraestrutura e serviços em nuvem. O objetivo deste projeto é demonstrar **boas práticas de arquitetura**, **Clean Architecture**, **DDD (Domain-Driven Design)** e padrões de mercado utilizados em aplicações escaláveis.

## 🚀 Tecnologias e Ferramentas

- **Linguagem:** C# (.NET 8, ASP.NET Core)
- **Banco de Dados:** MongoDB
- **Mensageria:** SQS
- **Autenticação:** AWS Cognito
- **Infraestrutura:** AWS ECS, Terraform, Docker
- **Observabilidade:** AWS CloudWatch
- **CI/CD:** GitHub Actions

## 🏗️ Arquitetura

Este projeto segue os princípios da **Clean Architecture**, com separação clara entre camadas:

- **Domain:** Regras de negócio e agregados (Order, OrderItem)
- **Application:** Use cases, validações e mediadores
- **Infrastructure:** Implementação de repositórios, banco de dados e serviços externos

Também utiliza **CQRS** para separação entre comandos e consultas, além de eventos de domínio para comunicação interna.

## ⚡ Funcionalidades

- **📌 API de Pedidos (Order.API):**

  - Criar, atualizar e cancelar pedidos
  - Gerenciar status do pedido (pendente, processando, enviado, entregue)
  - Aplicação de eventos de domínio ao mudar status

- **🔐 API de Autenticação (Auth.API):**

  - Gerenciamento de usuários
  - Autenticação via AWS Cognito

- **📩 API de Notificações (Notification.API):**
  - Consome mensagens de RabbitMQ
  - Envia notificações via e-mail/SMS

## 🏗️ Deploy e Infraestrutura

### 🏗️ Infra como Código (Terraform)

A infraestrutura do **OrderFlow** é provisionada na AWS utilizando **Terraform**, incluindo:

- **ECS** para orquestração de containers
- **PostgreSQL (Amazon RDS)** como banco de dados relacional
- **RabbitMQ** para mensageria
- **Cognito** para autenticação
- **CloudWatch/OpenTelemetry** para monitoramento

### 🐳 Docker

O projeto é totalmente **containerizado** e pode ser iniciado localmente com **Docker Compose**:

```sh
docker-compose up --build
```

## 🔬 Testes

O projeto conta com:

- **Testes unitários** para regras de negócio
- **Testes de integração** para validação de endpoints
- **Cobertura de código** configurada

Rodar os testes:

```sh
dotnet test
```

## 🔧 CI/CD

A pipeline de CI/CD está configurada para:

- **Build e testes** com GitHub Actions
- **Deploy automatizado** na AWS via CodePipeline

## 📜 Licença

Este projeto é open-source sob a licença MIT.

---

💡 **Dúvidas ou sugestões?** Sinta-se à vontade para abrir uma issue ou pull request! 🚀
