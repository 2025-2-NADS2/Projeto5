# Instituto Alma - API

Este projeto é a API do Instituto Alma, criada como trabalho de faculdade. A aplicação está funcional e publicada no **Azure**, permitindo acessar dados de usuários, doações, atividades, eventos e documentos.

---

## 🌐 URL do Azure

A API está publicada em:  
[https://institutoalma-bca3ewgchpgjb3dx.canadacentral-01.azurewebsites.net/](https://institutoalma-bca3ewgchpgjb3dx.canadacentral-01.azurewebsites.net/)

---

## 🚀 Endpoints disponíveis

| Rota | Método | Descrição |
|------|--------|-----------|
| `/` | GET | Testa se a API está rodando |
| `/usuarios` | GET | Retorna a lista de usuários |
| `/doacoes` | GET | Retorna a lista de doações |
| `/atividades` | GET | Retorna a lista de atividades |
| `/eventos` | GET | Retorna a lista de eventos |
| `/documentos` | GET | Retorna a lista de documentos |

---

## 💻 Como rodar localmente

1. Abra o projeto no **Visual Studio 2022**.  
2. Certifique-se de que o .NET 8.0 SDK está instalado.  
3. Compile o projeto para garantir que não há erros.  
4. Rode a aplicação (`F5` ou `Ctrl+F5`) para testar localmente.  
5. Acesse `https://localhost:{porta}/` para verificar se a API está funcionando.

---

## 📦 Estrutura do projeto

- **Program.cs** → contém os dados em memória e endpoints HTTP mínimos.  
- **Classes** → Usuario, Doacao, Atividade, Evento, Documento.  
- **Dados** → Inicializados diretamente no `Program.cs`.

---

## ⚡ Observações

- Os dados estão em memória (não há conexão com banco de dados neste projeto).  
- Para testes via navegador, basta acessar os endpoints listados.  
- Pode ser utilizado **Postman** ou qualquer cliente HTTP para testar os endpoints `/usuarios`, `/doacoes`, etc.
