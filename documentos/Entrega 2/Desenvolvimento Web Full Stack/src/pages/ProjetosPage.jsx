// src/pages/ProjetosPage.jsx
import Projetos from '../components/Projetos.jsx';

function ProjetosPage() {
  return (
    <div style={{padding: '40px 20px', maxWidth: '1200px', margin: 'auto'}}>
      <Projetos />
      <section className="projetos-section" style={{marginTop: '40px'}}>
        <h2>PROJETOS PASSADOS</h2>
        <div className="projetos-container">
          <div className="projeto-card">
            <h3>OFICINA DE ARTES 2024</h3>
            <p style={{padding: '20px'}}>Curso de grafite e pintura que revelou novos talentos na comunidade.</p>
          </div>
          <div className="projeto-card">
            <h3>ALFABETIZAÇÃO DIGITAL</h3>
            <p style={{padding: '20px'}}>Aulas de informática básica para adultos e idosos, promovendo inclusão digital.</p>
          </div>
        </div>
      </section>
    </div>
  );
}
export default ProjetosPage;