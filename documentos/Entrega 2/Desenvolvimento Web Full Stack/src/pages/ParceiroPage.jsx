// src/pages/ParceiroPage.jsx
function ParceiroPage() {
  return (
    <section className="news-card" style={{maxWidth: '600px', margin: '40px auto', textAlign: 'center'}}>
      <h2>SEJA NOSSO PARCEIRO</h2>
      <p>Empresas que investem no social transformam o futuro.</p>
      <div style={{margin: '20px 0'}}>
        <strong>Envie sua proposta de parceria para:</strong>
        <p style={{fontSize: '1.2rem', fontWeight: 'bold', marginTop: '10px'}}>
          <a href="mailto:parcerias@institutoalma.org.br">parcerias@institutoalma.org.br</a>
        </p>
      </div>
    </section>
  );
}
export default ParceiroPage;