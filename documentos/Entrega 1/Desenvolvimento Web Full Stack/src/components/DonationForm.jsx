

import { useState } from 'react';

function DonationForm() {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [amount, setAmount] = useState('');

  const handleSubmit = (event) => {
    event.preventDefault();

    if (!name || !email || !amount) {
      alert('Por favor, preencha todos os campos para doar.');
      return;
    }

  
    alert(`Obrigado, ${name}!\nSua doação de R$ ${amount} foi recebida com sucesso.\nUm recibo foi enviado para ${email}.`);

   
    setName('');
    setEmail('');
    setAmount('');
  };

  return (
    <section className="news-card">
      <h2>Faça Parte da Mudança</h2>
      <p>Sua doação ajuda a transformar vidas. Preencha os dados abaixo para contribuir.</p>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="name">Nome Completo:</label>
          <input
            type="text"
            id="name"
            value={name}
            onChange={(e) => setName(e.target.value)}
            placeholder="Seu nome"
          />
        </div>
        <div className="form-group">
          <label htmlFor="email">Email:</label>
          <input
            type="email"
            id="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            placeholder="seuemail@exemplo.com"
          />
        </div>
        <div className="form-group">
          <label htmlFor="amount">Valor da Doação (R$):</label>
          <input
            type="number"
            id="amount"
            value={amount}
            onChange={(e) => setAmount(e.target.value)}
            placeholder="50,00"
          />
        </div>
        <button type="submit">Doar Agora</button>
      </form>
    </section>
  );
}

export default DonationForm;