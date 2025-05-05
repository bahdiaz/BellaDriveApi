# 🚗 BellaDrive API - CP2 de Desenvolvimento Web

Este é o projeto da CP2 para a disciplina de Desenvolvimento Web, utilizando ASP.NET Core com Entity Framework e arquitetura de API REST.

## 📌 Objetivo
O sistema simula uma locadora de carros, permitindo ao usuário calcular o valor de uma locação com base na quantidade de dias. O projeto foi criado do zero, incluindo conexão com banco de dados, organização em camadas e boas práticas como uso de DTOs.

---

## 🛠️ Tecnologias utilizadas

- ASP.NET Core 7
- Entity Framework Core
- SQLite (ou outro banco via EF)
- C#
- Swagger (para testes dos endpoints)

---

## 📁 Estrutura do projeto

BellaDriveApi/
├── Controllers/
│ └── SimulacoesController.cs
├── DTOs/
│ ├── LocacaoRequest.cs
│ └── LocacaoResponse.cs
├── Models/
│ └── Carro.cs
├── Data/
│ └── AppDbContext.cs
├── Program.cs
└── BellaDriveApi.csproj


---

## 🔄 Como rodar o projeto

1. Clone ou extraia o projeto compactado:
   git clone <repositório> ou extraia o ZIP enviado
   
2. Acesse a pasta:
cd BellaDriveApi

3. Restaure os pacotes:
dotnet restore

4. Aplique a migration e crie o banco:
dotnet ef database update

5. Rode o projeto:
dotnet run

6. Acesse o Swagger:
https://localhost:<porta>/swagger

📮 Endpoint principal
POST /api/simulacoes/calcular
🔽 Corpo da requisição (JSON):
{
  "carroId": 1,
  "dataInicio": "2025-05-10",
  "dataFim": "2025-05-15"
}
🔼 Resposta (200 OK):
json
Copiar
Editar
{
  "carro": "HB20",
  "marca": "Hyundai",
  "dataInicio": "2025-05-10T00:00:00",
  "dataFim": "2025-05-15T00:00:00",
  "valorDiaria": 120.0,
  "subtotal": 600.0,
  "desconto": "10%",
  "valorFinal": 540.0
}
💡 Regras de negócio
Desconto de 5% para locações com 3 a 6 dias

Desconto de 10% para locações com 7 dias ou mais

Validações aplicadas para:

Datas inválidas

Carros não encontrados

📚 Observações finais
O projeto está dividido em camadas para manter a organização e separação de responsabilidades.

Foram utilizados DTOs para melhorar a clareza dos dados de entrada e saída.

Código comentado e com mensagens amigáveis para o usuário.
