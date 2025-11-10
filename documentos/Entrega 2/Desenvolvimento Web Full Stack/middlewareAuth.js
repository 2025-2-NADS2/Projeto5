// backend/middlewareAuth.js
import jwt from 'jsonwebtoken';
import dotenv from 'dotenv'; 

dotenv.config(); 


const checkToken = (req, res, next) => {
  
  const authHeader = req.headers['authorization'];
  const token = authHeader && authHeader.split(' ')[1]; 

  
  if (!token) {
    return res.status(401).json({ error: 'Acesso negado! Token não fornecido.' });
  }

  
  try {
    const segredo = process.env.JWT_SECRET; 

    
    const decoded = jwt.verify(token, segredo);
    
   
    req.user = decoded;
    
    
    next(); 

  } catch (error) {
    
    res.status(400).json({ error: 'Token inválido.' });
  }
};

export default checkToken;