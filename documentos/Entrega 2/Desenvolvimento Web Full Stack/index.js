// backend/index.js

import express from 'express';
import cors from 'cors';
import pool, { testConnection } from './db.js';
import bcrypt from 'bcrypt';
import jwt from 'jsonwebtoken';
import checkToken from './middlewareAuth.js';
import multer from 'multer';
import path from 'path';
import dotenv from 'dotenv'; 

dotenv.config(); 


const app = express();
const PORT = 3001; 


app.use(cors()); 
app.use(express.json()); 


const storage = multer.diskStorage({
  destination: (req, file, cb) => {
    cb(null, 'uploads/'); 
  },
  filename: (req, file, cb) => {
    cb(null, Date.now() + '-' + file.originalname);
  }
});

const upload = multer({ storage: storage });


app.get('/', (req, res) => {
  res.send('Olá do Backend! O servidor está funcionando.');
});


app.post('/doacoes', async (req, res) => {
  const { name, email, amount } = req.body;
  const valorDoacao = parseFloat(amount);

  if (!name || !email || !valorDoacao || valorDoacao <= 0) {
    return res.status(400).json({ error: 'Todos os campos são obrigatórios e o valor deve ser positivo.' });
  }

  try {
    const connection = await pool.getConnection();

    try {
      const sqlInsertDoador = 'INSERT INTO doadores (nome, email, data_cadastro) VALUES (?, ?, CURDATE())';
      await connection.query(sqlInsertDoador, [name, email]);
      console.log(`Doador ${name} registrado.`);
    } catch (error) {
      if (error.code === 'ER_DUP_ENTRY') {
        console.log(`Doador com email ${email} já existe. Pulando inserção.`);
      } else {
        throw error;
      }
    }

    const descricaoDoacao = `Doação recebida de ${name} (${email})`;
    const sqlInsertTransparencia = 'INSERT INTO transparencia (descricao, valor, data_registro) VALUES (?, ?, CURDATE())';
    const [result] = await connection.query(sqlInsertTransparencia, [descricaoDoacao, valorDoacao]);

    connection.release();
    res.status(201).json({ 
      message: 'Doação e doador registrados com sucesso!', 
      registroId: result.insertId 
    });

  } catch (error) {
    console.error('Erro ao processar doação:', error);
    res.status(500).json({ error: 'Erro no servidor ao processar a doação.' });
  }
});


app.post('/register/admin', async (req, res) => {
  const { usuario, senha, nivelAcesso } = req.body;

  if (!usuario || !senha || !nivelAcesso) {
    return res.status(400).json({ error: 'Todos os campos são obrigatórios.' });
  }

  try {
    const salt = await bcrypt.genSalt(10);
    const senhaHash = await bcrypt.hash(senha, salt);

    const sql = 'INSERT INTO administracao (USUARIO, SENHA, NIVEL_ACESSO, DATA_CADASTRO) VALUES (?, ?, ?, CURDATE())';
    const [result] = await pool.query(sql, [usuario, senhaHash, nivelAcesso]);

    res.status(201).json({ message: 'Administrador cadastrado com sucesso!', adminId: result.insertId });

  } catch (error) {
    console.error('Erro ao cadastrar admin:', error);
    res.status(500).json({ error: 'Erro ao cadastrar administrador.' });
  }
});


app.post('/login', async (req, res) => {
  const { usuario, senha } = req.body;

  if (!usuario || !senha) {
    return res.status(400).json({ error: 'Usuário e senha são obrigatórios.' });
  }

  try {
    const sql = 'SELECT * FROM administracao WHERE USUARIO = ?';
    const [rows] = await pool.query(sql, [usuario]);

    if (rows.length === 0) {
      return res.status(404).json({ error: 'Usuário não encontrado.' });
    }

    const admin = rows[0];
    const senhaValida = await bcrypt.compare(senha, admin.SENHA);

    if (!senhaValida) {
      return res.status(401).json({ error: 'Senha inválida.' });
    }

    const token = jwt.sign(
      { id: admin.ID_ADMIN, usuario: admin.USUARIO, nivel: admin.NIVEL_ACESSO },
      process.env.JWT_SECRET, 
      { expiresIn: '1h' }
    );

    res.status(200).json({ message: 'Login bem-sucedido!', token: token });

  } catch (error) {
    console.error('Erro no login:', error);
    res.status(500).json({ error: 'Erro no servidor durante o login.' });
  }
});


app.get('/admin/dashboard', checkToken, (req, res) => {
  
  res.status(200).json({ 
    message: `Bem-vindo à área VIP, ${req.user.usuario}!`,
    usuario: req.user
  });
});


app.post('/upload/imagem', checkToken, upload.single('imagem'), (req, res) => {
  
  if (!req.file) {
    return res.status(400).json({ error: 'Nenhum arquivo enviado.' });
  }

  
  const filePath = `uploads/${req.file.filename}`;
  
  res.status(201).json({ 
    message: 'Upload da imagem bem-sucedido!',
    path: filePath 
  });
});



app.listen(PORT, () => {
  console.log(`Servidor Backend rodando na porta ${PORT}`);
  testConnection(); 
});