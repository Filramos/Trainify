# Train!fy 🏋️‍♂️ - Inven!ra Activity Provider

O **Train!fy** é um *Activity Provider* (AP) desenvolvido para a plataforma de ensino **Inven!ra**, focado na gestão e monitorização de planos de atividade física e treinos personalizados.

Este projeto foi desenvolvido em **.NET 8 (Web API)** e utiliza padrões de desenho (GoF) para garantir uma arquitetura limpa, modular e altamente desacoplada.

## 🚀 Links do Projeto (Live)

O projeto está hospedado no Render. Pode testar a API diretamente através do Swagger:

* **Swagger UI (Documentação Interativa):** 👉 [https://trainify-jksy.onrender.com/swagger](https://trainify-jksy.onrender.com/swagger)
* **Base URL:** `https://trainify-jksy.onrender.com`

---

## 🏗️ Arquitetura e Padrões de Design

A arquitetura do Train!fy foi estruturada para suportar a evolução do sistema através de padrões de desenho robustos:

### 1. Facade (Padrão de Estrutura)
Centraliza a lógica de negócio complexa em interfaces simplificadas para os controladores.
* **ConfigurationFacade**: Centraliza a definição de parâmetros e a geração do formulário HTML de configuração.
* **RealizationFacade**: Abstrai a criação de URLs de acesso e atua como o **Sujeito (Subject)** no padrão Observer.
* **AnalyticsFacade**: Orquestra a recuperação e filtragem de métricas de desempenho.

### 2. Factory Method (Padrão de Criação)
A interface `IParameterFactory` isola a instanciação de objetos dinâmicos:
* **Parâmetros**: (`TextParameter`, `IntegerParameter`, `URLParameter`).
* **Métricas**: (`QuantitativeAnalytics`, `QualitativeAnalytics`).

### 3. Observer (Padrão de Comportamento) 🚀 **NOVO**
Implementado para desacoplar tarefas secundárias (monitorização e auditoria) do fluxo principal de negócio.
* **Sujeito (`IActivitySubject`)**: O `RealizationFacade` gere a lista de subscritores e dispara as notificações.
* **Observadores (`IActivityObserver`)**:
    * **ActivityLoggingObserver**: Regista logs de auditoria (quem acedeu e quando) de forma independente.
    * **ActivityAnalyticsObserver**: Atua como ponte para o `AnalyticsFacade`, atualizando métricas de frequência de treino em tempo real.

---

## 🔌 Endpoints Principais

### 1. Configuração (`/api/ap-configuration`)
* `GET /config_url`: Retorna o formulário HTML para definição do treino.
* `GET /json_params_url`: Retorna a lista de parâmetros configuráveis (JSON).

### 2. Realização (`/api/ap-realization`)
* `GET /user_url`: Gera o link base da atividade.
* `POST /provide_client_activity_url`: Regista o acesso de um **Cliente** e **notifica automaticamente os observadores** de Log e Analytics.

### 3. Analytics (`/api/ap-analytics`)
* `GET /analytics_list_url`: Lista as métricas disponíveis (ex: Volume de Carga, RPE).
* `POST /analytics_url`: Retorna os dados analíticos filtrados por `activityID`.

---

## 💻 Funcionamento do Padrão Observer

O fluxo de funcionamento do padrão de comportamento segue estas etapas:
1. **Inicialização**: Os observadores são registados no `RealizationFacade` durante a criação do controlador.
2. **Processamento**: O controlador chama `RegisterClientAccess` no Facade.
3. **Notificação**: O Facade gera o URL e executa o método `NotifyObservers()`.
4. **Execução**: Os observadores executam as suas tarefas específicas sem que o Facade precise de conhecer os seus detalhes internos.

---

## 🛠️ Tecnologias Utilizadas

* **Framework:** .NET 8.0 (ASP.NET Core Web API).
* **Padrões:** Factory Method, Facade, Observer.
* **Hosting:** Render.
* **Documentação:** Swagger / OpenAPI.

---

## 💻 Como rodar localmente

1. Clone o repositório:
   ```bash
   git clone [https://github.com/SEU-USER/Trainify.git](https://github.com/SEU-USER/Trainify.git)
