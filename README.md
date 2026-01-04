# Train!fy 🏋️‍♂️ - Inven!ra Activity Provider

O **Train!fy** é um *Activity Provider* (AP) desenvolvido para a plataforma de ensino **Inven!ra**, focado na gestão e monitorização de planos de atividade física e treinos personalizados.

Este projeto foi desenvolvido em **.NET 8 (Web API)** e utiliza padrões de design de estrutura e criação para garantir uma arquitetura limpa, modular e escalável.

## 🚀 Links do Projeto (Live)

O projeto está hospedado no Render. Pode testar a API diretamente através do Swagger:

* **Swagger UI (Documentação Interativa):**
    👉 [https://trainify-jksy.onrender.com/swagger](https://trainify-jksy.onrender.com/swagger)

* **Base URL:**
    `https://trainify-jksy.onrender.com`

---

## 🏗️ Arquitetura e Padrões de Design

A arquitetura do Train!fy foi refatorada para suportar a separação de responsabilidades através de padrões de desenho robustos:

### 1. Facade (Padrão de Estrutura)
Foi implementada uma camada de **Facade** para centralizar a lógica de negócio e simplificar os controladores da API.
* **ConfigurationFacade**: Centraliza a definição de parâmetros e a geração do formulário HTML de configuração.
* **RealizationFacade**: Abstrai a criação de URLs de acesso e gestão de sessões.
* **AnalyticsFacade**: Orquestra a recuperação e filtragem de métricas de desempenho.

### 2. Factory Method (Padrão de Criação)
A interface `IParameterFactory` é utilizada pelos Facades para instanciar dinamicamente:
* **Parâmetros de Configuração**: (`TextParameter`, `IntegerParameter`, `URLParameter`).
* **Métricas de Analytics**: (`QuantitativeAnalytics`, `QualitativeAnalytics`).

Isto permite que a lógica de criação de objetos esteja isolada da lógica de controlo de fluxo.

---

## 🔌 Endpoints Principais

### 1. Configuração (`/api/ap-configuration`)
Permite à plataforma Inven!ra configurar uma nova **Atividade (treino)**.
* `GET /config_url`: Retorna o formulário HTML para definição do treino (Nome, Foco, Tempo Estimado).
* `GET /json_params_url`: Retorna a lista de parâmetros aceites em formato JSON.

### 2. Realização (`/api/ap-realization`)
Gera os links únicos para execução da atividade física.
* `GET /user_url`: Gera o link base da atividade.
* `POST /provide_client_activity_url`: Regista o acesso de um **Cliente** específico e gera o URL com tracking de ID.

### 3. Analytics (`/api/ap-analytics`)
Fornece dados detalhados sobre o desempenho do utilizador.
* `GET /analytics_list_url`: Lista as métricas disponíveis (ex: Volume de Carga, Taxa de Conclusão, RPE).
* `POST /analytics_url`: Retorna os dados analíticos filtrados por `activityID`.

---

## 🛠️ Tecnologias Utilizadas

* **Framework:** .NET 8.0 (ASP.NET Core Web API).
* **Arquitetura:** MVC + Facade Pattern.
* **Hosting:** Render.
* **Documentação:** Swagger / OpenAPI.

---

## 💻 Como rodar localmente

1. Clone o repositório:
   ```bash
   git clone [https://github.com/SEU-USER/Trainify.git](https://github.com/SEU-USER/Trainify.git)