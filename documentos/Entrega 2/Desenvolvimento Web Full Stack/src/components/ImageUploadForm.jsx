// src/components/ImageUploadForm.jsx
import { useState } from 'react';

function ImageUploadForm() {
  const [file, setFile] = useState(null); 
  const [message, setMessage] = useState('');

  
  const handleFileChange = (event) => {
    setFile(event.target.files[0]);
  };

  
  const handleSubmit = async (event) => {
    event.preventDefault();
    setMessage('Enviando imagem...');

    if (!file) {
      setMessage('Por favor, selecione um arquivo.');
      return;
    }

    
    const token = localStorage.getItem('adminToken');
    if (!token) {
      setMessage('Erro: Você não está autenticado.');
      return;
    }

    
    const formData = new FormData();
    formData.append('imagem', file); 

    try {
      
      const response = await fetch('http://localhost:3001/upload/imagem', {
        method: 'POST',
        headers: {
          
          'Authorization': `Bearer ${token}`
        },
        body: formData, 
      });

      const data = await response.json();

      if (response.ok) {
        setMessage(`Upload bem-sucedido! Caminho: ${data.path}`);
        setFile(null); 
        event.target.reset(); 
      } else {
        setMessage(`Erro: ${data.error}`);
      }

    } catch (error) {
      console.error('Erro no upload:', error);
      setMessage('Erro de conexão ao enviar imagem.');
    }
  };

  return (
    <section className="news-card" style={{ marginTop: '30px' }}>
      <h3>Adicionar Nova Imagem de Projeto</h3>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="imagem">Selecionar Imagem:</label>
          <input
            type="file"
            id="imagem"
            onChange={handleFileChange}
            required
          />
        </div>
        <button type="submit">Enviar Imagem</button>
        {message && <p style={{ marginTop: '15px' }}>{message}</p>}
      </form>
    </section>
  );
}

export default ImageUploadForm;