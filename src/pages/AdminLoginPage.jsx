// src/pages/AdminLoginPage.jsx
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';

function AdminLoginPage() {
  const [usuario, setUsuario] = useState('');
  const [senha, setSenha] = useState('');
  const [message, setMessage] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (event) => {
    event.preventDefault();
    setMessage('Autenticando...');

    const loginData = { usuario, senha };

    try {
      const response = await fetch('http://localhost:3001/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(loginData),
      });

      const data = await response.json();

      if (response.ok) {
        setMessage(`Login bem-sucedido! Token: ${data.token}`);
        localStorage.setItem('adminToken', data.token); 
        navigate('/admin/dashboard'); 
      } else {
        setMessage(`Erro: ${data.error}`);
      }
    } catch (error) {
      setMessage('Erro: Não foi possível conectar ao servidor.');
    }
  };

  return (
    <section className="news-card" style={{maxWidth: '600px', margin: '40px auto'}}>
      <h2>Login do Administrador</h2>
      
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="usuario">Usuário:</label>
          <input type="text" id="usuario" value={usuario} onChange={(e) => setUsuario(e.target.value)} required />
        </div>
        <div className="form-group">
          <label htmlFor="senha">Senha:</label>
          <input type="password" id="senha" value={senha} onChange={(e) => setSenha(e.target.value)} required />
        </div>
        <button type="submit">Entrar</button>
        {message && <p style={{ marginTop: '15px' }}>{message}</p>}
      </form>
    </section>
  );
}
export default AdminLoginPage;