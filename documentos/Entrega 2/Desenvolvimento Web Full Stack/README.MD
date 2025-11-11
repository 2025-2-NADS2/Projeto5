# Projeto Integrador: Instituto Alma (Full Stack)

Este projeto é a entrega final da disciplina de Desenvolvimento Web Full Stack, simulando uma aplicação web completa para a ONG "Instituto Alma".

A aplicação consiste em um **Frontend** (site público e painel admin) construído em **React** e um **Backend** (API RESTful) construído em **Node.js**, conectado a um banco de dados **MySQL**.

---

## Funcionalidades Principais

### Frontend (React)
* Site público com múltiplas páginas usando **React Router DOM**.
* Componentes reutilizáveis (Header, Footer, Cards de Projeto).
* Modal interativo para exibir histórias dos projetos.
* Formulário de Doação que se integra com o backend.
* Painel de Administrador com rotas protegidas.
* Formulário de Login que armazena um **Token JWT** no `localStorage`.
* Formulário de Upload de Imagens que envia arquivos para o backend usando `FormData`.

### Backend (Node.js)
* API RESTful completa construída com **Express**.
* Conexão com banco de dados **MySQL** (usando `mysql2`).
* Rota `/doacoes` para **CRUD (Create)** de doações, salvando em duas tabelas (`doadores` e `transparencia`).
* Sistema de Autenticação de Admin (`/register/admin` e `/login`).
* Criptografia de senhas usando **Bcrypt**.
* Geração e verificação de **Token JWT** para rotas protegidas.
* Middleware de autenticação para proteger "áreas VIP" da API.
* Upload de imagens para o servidor usando **Multer**.
* Uso de **Variáveis de Ambiente** (`.env`) para proteger dados sensíveis (senhas de banco e segredo JWT).

---

##  Como Rodar o Projeto Localmente

Você precisará ter o **Node.js** (v20+) e um servidor **MySQL** (como o **XAMPP**) instalados e rodando.

### 1. Preparação (Banco de Dados)

1.  Inicie o Apache e o MySQL no seu painel XAMPP.
2.  Acesse `http://localhost/phpmyadmin/`.
3.  Crie um novo banco de dados chamado `instituto_alma`.
4.  Clique no banco `instituto_alma`, vá na aba **SQL** e execute o script de criação de tabelas (disponível no repositório).

### 2. Backend (Servidor)

O backend deve ser iniciado primeiro.

```bash
# 1. Abra um terminal e navegue até a pasta do backend
cd "documentos/Entrega 2/backend"

# 2. Crie um arquivo .env na pasta 'backend' com os dados do seu banco:
# DB_HOST=localhost
# DB_USER=root
# DB_PASSWORD=
# DB_DATABASE=instituto_alma
# JWT_SECRET=seu_segredo_jwt_super_secreto

# 3. Instale as dependências
npm install

# 4. Inicie o servidor
node index.js

# O servidor estará rodando em http://localhost:3001
```

### 3. Frontend (Site React)

Deixe o terminal do backend rodando e abra um **novo terminal**.

```bash
# 1. Navegue até a pasta do frontend (que agora é a 'Entrega 2')
cd "documentos/Entrega 2"

# 2. Instale as dependências
npm install

# 3. Inicie o site
npm run dev

# O site estará rodando em http://localhost:5173
```

---

## Rotas da API (Backend)

| Método | Rota | Protegida? | Descrição |
| :--- | :--- | :--- | :--- |
| `POST` | `/doacoes` | Não | Recebe um JSON com `name`, `email` e `amount` e salva no banco. |
| `POST` | `/register/admin` | Não | Registra um novo administrador no banco (senha é criptografada). |
| `POST` | `/login` | Não | Autentica um admin (`usuario` e `senha`) e retorna um token JWT. |
| `GET` | `/admin/dashboard`| **Sim (JWT)** | Rota de teste para verificar se o token do usuário é válido. |
| `POST`| `/upload/imagem` | **Sim (JWT)** | Faz upload de um arquivo (`imagem`) para a pasta `/uploads`. |

---

