// src/pages/AdminDashboardPage.jsx
import { useState, useEffect } from 'react';
import ImageUploadForm from '../components/ImageUploadForm.jsx';

function AdminDashboardPage() {
  const [message, setMessage] = useState('Carregando...');

  useEffect(() => {
    const token = localStorage.getItem('adminToken');

    const fetchDashboard = async () => {
      if (!token) {
        setMessage('Acesso negado. Você precisa estar logado.');
        return;
      }

      try {
        const response = await fetch('http://localhost:3001/admin/dashboard', {
          method: 'GET',
          headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}` 
          }
        });

        const data = await response.json();

        if (response.ok) {
          setMessage(data.message);
        } else {
          setMessage(`Erro: ${data.error}`);
        }
      } catch (error) {
        setMessage('Erro de conexão com o servidor.');
      }
    };

    fetchDashboard();
  }, []); 

  return (
    <section className="news-card" style={{maxWidth: '600px', margin: '40px auto'}}>
      <h2>Painel do Administrador</h2>
      <p>Esta é uma área protegida.</p>
      
      <h3 style={{marginTop: '20px'}}>{message}</h3>

      <ImageUploadForm /> 
    </section>
  );
}
export default AdminDashboardPage;