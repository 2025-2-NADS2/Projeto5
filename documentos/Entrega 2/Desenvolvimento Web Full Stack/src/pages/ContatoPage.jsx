// src/pages/ContatoPage.jsx
function ContatoPage() {
  return (
    <section className="news-card" style={{maxWidth: '600px', margin: '40px auto', textAlign: 'center'}}>
      <h2>ENTRE EM CONTATO</h2>
      <p>Adoraríamos ouvir você. Mande uma mensagem!</p>
      <div style={{margin: '20px 0'}}>
        <strong>Email:</strong> <a href="mailto:contato@institutoalma.org.br">contato@institutoalma.org.br</a>
      </div>
      <div style={{margin: '20px 0'}}>
        <strong>Telefone (WhatsApp):</strong> +55 (11) 98765-4321
      </div>
    </section>
  );
}
export default ContatoPage;