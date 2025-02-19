# 🛒 OrderFlow - Sistema de Gerenciamento de Pedidos

![GitHub repo size](https://img.shields.io/github/repo-size/Peduxx/ORderFlow)
![GitHub license](https://img.shields.io/github/license/Peduxx/ORderFlow)
![GitHub contributors](https://img.shields.io/github/contributors/Peduxx/OrderFlow)
![GitHub Release](https://img.shields.io/github/v/release/Peduxx/OrderFlow)
![GitHub tag (latest by date)](https://img.shields.io/github/v/tag/Peduxx/OrderFlow)

![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)
![Version](https://img.shields.io/badge/version-1.0.0-blue.svg)

## 📌 Visão Geral

**OrderFlow** é um sistema de gerenciamento de pedidos para e-commerce, desenvolvido em **.NET**, utilizando **AWS** para infraestrutura e serviços em nuvem. O objetivo deste projeto é demonstrar boas práticas de arquitetura, performance e escalabilidade.

## 🚀 Tecnologias e Ferramentas

- **Backend:** .NET 8, ASP.NET Core
- **Banco de Dados:** Amazon DynamoDB
- **Mensageria:** AWS SNS/SQS
- **Autenticação:** AWS Cognito
- **Infraestrutura:** Terraform, AWS ECS/EKS, Docker
- **Observabilidade:** AWS CloudWatch, AWS X-Ray
- **CI/CD:** GitHub Actions

## 🏗️ Arquitetura

Este projeto segue o modelo **Monorepo**, reunindo todas as APIs e infraestrutura dentro de um único repositório. Essa abordagem facilita o gerenciamento e a visualização do projeto.

### 📂 Estrutura do Repositório

```
📦 OrderFlow  
 ├── 📂 src  
 │   ├── 📂 Order.API         # API principal para pedidos  
 │   ├── 📂 Auth.API          # API de autenticação (AWS Cognito)  
 │   ├── 📂 Notification.API  # API para notificações via SNS/SQS  
 │   ├── 📂 Shared            # Código compartilhado (DTOs, Configs, etc.)  
 │  
 ├── 📂 infrastructure  
 │   ├── 📂 terraform         # Infra como código  
 │   ├── 📂 docker            # Configuração de Docker e Compose  
 │  
 ├── 📂 tests  
 │   ├── 📂 Order.Tests       # Testes unitários e de integração da Order API  
 │   ├── 📂 Auth.Tests        # Testes da API de Autenticação  
 │   ├── 📂 Notification.Tests # Testes da API de Notificações  
 │  
 ├── 📄 docker-compose.yml    # Orquestração dos serviços  
 ├── 📄 main.tf               # Arquivo principal do Terraform  
 ├── 📄 README.md             # Documentação principal  
```

## ⚡ Funcionalidades

- **📌 API de Pedidos (Order.API):**
  - Criar, atualizar e excluir pedidos
  - Gerenciar status do pedido (pendente, processando, enviado, entregue)
  - Enviar eventos para SNS/SQS ao mudar status

- **🔐 API de Autenticação (Auth.API):**
  - Gerenciamento de usuários
  - Autenticação via AWS Cognito

- **📩 API de Notificações (Notification.API):**
  - Consome mensagens de SNS/SQS
  - Envia notificações via e-mail/SMS

## 🏗️ Deploy e Infraestrutura

### 🏗️ Infra como Código (Terraform)
A infraestrutura do **OrderFlow** é provisionada na AWS utilizando **Terraform**. O módulo principal inclui:

- **ECS/EKS** para orquestração de containers
- **DynamoDB** como banco de dados NoSQL
- **SNS/SQS** para mensageria
- **Cognito** para autenticação
- **CloudWatch/X-Ray** para observabilidade

### 🐳 Docker
O projeto está totalmente **containerizado** e pode ser iniciado localmente com **Docker Compose**:

```sh
docker-compose up --build
```

## 🔬 Testes
Cada serviço inclui testes unitários e de integração para garantir qualidade e confiabilidade.

```sh
dotnet test
```

## 🔧 CI/CD
A pipeline de CI/CD está configurada para:
- **Build e testes** com GitHub Actions
- **Deploy automatizado** na AWS com CodePipeline

## 📜 Licença
Este projeto é open-source sob a licença MIT.

---

💡 **Dúvidas ou sugestões?** Sinta-se à vontade para abrir uma issue ou pull request! 🚀
