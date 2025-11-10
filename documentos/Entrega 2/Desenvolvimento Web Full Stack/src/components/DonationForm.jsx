// src/components/DonationForm.jsx
import { useState } from 'react';

function DonationForm() {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [amount, setAmount] = useState('');
  const [message, setMessage] = useState('');

  const handleSubmit = async (event) => {
    event.preventDefault(); 
    setMessage('Enviando doação...'); 

    const donationData = { name, email, amount };

    try {
      const response = await fetch('http://localhost:3001/doacoes', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(donationData),
      });

      const data = await response.json();

      if (response.ok) {
        setMessage('Doação enviada com sucesso! Obrigado!');
        setName('');
        setEmail('');
        setAmount('');
      } else {
        setMessage(`Erro: ${data.error}`);
      }
    } catch (error) {
      console.error('Erro de rede:', error);
      setMessage('Erro: Não foi possível conectar ao servidor. Tente mais tarde.');
    }
  };

  return (
    <section className="news-card">
      <h2>Faça Parte da Mudança</h2>
      <p>Sua doação ajuda a transformar vidas. Preencha os dados abaixo para contribuir.</p>
      
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="name">Nome Completo:</label>
          <input type="text" id="name" value={name} onChange={(e) => setName(e.target.value)} placeholder="Seu nome" required />
        </div>
        <div className="form-group">
          <label htmlFor="email">Email:</label>
          <input type="email" id="email" value={email} onChange={(e) => setEmail(e.target.value)} placeholder="seuemail@exemplo.com" required />
        </div>
        <div className="form-group">
          <label htmlFor="amount">Valor da Doação (R$):</label>
          <input type="number" id="amount" value={amount} onChange={(e) => setAmount(e.target.value)} placeholder="50,00" required min="1" />
        </div>
        <button type="submit">Doar Agora</button>
        {message && <p style={{ marginTop: '15px' }}>{message}</p>}
      </form>
    </section>
  );
}
export default DonationForm;