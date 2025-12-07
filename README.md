# Train!fy 🏋️‍♂️ - Inven!ra Activity Provider

O **Train!fy** é um *Activity Provider* (AP) desenvolvido para a plataforma de ensino **Inven!ra**, focado na gestão e monitorização de planos de treino físico e corporativo.

Este projeto foi desenvolvido em **.NET 8 (Web API)** e utiliza o padrão de desenho **Factory Method** para garantir a extensibilidade dos parâmetros de configuração e métricas analíticas.

## 🚀 Links do Projeto (Live)

O projeto está hospedado no Render. Pode testar a API diretamente através do Swagger:

* **Swagger UI (Documentação Interativa):**
    👉 [https://trainify-jksy.onrender.com/swagger](https://trainify-jksy.onrender.com/swagger)

* **Base URL:**
    `https://trainify-jksy.onrender.com`

---

## 🏗️ Arquitetura e Padrões de Design

### Factory Method
O núcleo deste projeto baseia-se no padrão **Factory Method**.
A interface `IParameterFactory` e a sua implementação `ConfigurableParameterFactory` são responsáveis por instanciar dinamicamente:
1.  **Parâmetros de Configuração:** (`TextParameter`, `IntegerParameter`, `URLParameter`) usados para construir o formulário de treino.
2.  **Métricas de Analytics:** (`QuantitativeAnalytics`, `QualitativeAnalytics`) usadas para relatórios de desempenho.

Isto permite adicionar novos tipos de exercícios ou métricas sem alterar a lógica dos Controladores.

---

## 🔌 Endpoints Principais

### 1. Configuração (`/api/ap-configuration`)
Permite à plataforma Inven!ra saber como configurar um treino.
* `GET /config_url`: Retorna o formulário HTML para o Personal Trainer (PT) definir o treino (Nome, Carga, RPE, etc.).
* `GET /json_params_url`: Retorna a lista de parâmetros aceites em formato JSON.

### 2. Realização (`/api/ap-realization`)
Gera os links únicos para execução da atividade.
* `GET /user_url`: Gera o link da atividade.
* `POST /provide_client_activity_url`: Regista o acesso de um **Cliente** específico a um treino.

### 3. Analytics (`/api/ap-analytics`)
Fornece dados sobre o desempenho do cliente.
* `GET /analytics_list_url`: Lista as métricas disponíveis (ex: Volume de Carga, Taxa de Conclusão, RPE).
* `POST /analytics_url`: Retorna os dados simulados de uma sessão de treino.

---

## 🛠️ Tecnologias Utilizadas

* **Framework:** .NET 8.0 (ASP.NET Core Web API)
* **Containerização:** Docker
* **Hosting:** Render
* **Documentação:** Swagger / OpenAPI

---

## 💻 Como rodar localmente

1.  Clone o repositório:
    ```bash
    git clone [https://github.com/SEU-USER/Trainify.git](https://github.com/SEU-USER/Trainify.git)
    ```
2.  Entre na pasta do projeto:
    ```bash
    cd Trainify
    ```
3.  Execute a aplicação:
    ```bash
    dotnet run
    ```
4.  Aceda ao Swagger local:
    `http://localhost:5253/swagger`
