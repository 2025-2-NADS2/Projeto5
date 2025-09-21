


import imagemNatal from '../assets/natal.jpeg'; 
import imagemSopa from '../assets/sopa.jpeg';   
import imagemCesta from '../assets/cesta.jpeg';

function Projetos() {
  return (
    <section className="projetos-section">
      <h2>PROJETOS</h2>
      <div className="projetos-container">
        
        <div className="projeto-card">
          <img src={imagemNatal} alt="Projeto Natal Solidário" className="projeto-imagem" />
          <h3>NATAL SOLIDÁRIO</h3>
        </div>
        
        <div className="projeto-card">
          <img src={imagemSopa} alt="Projeto Sopa Comunitária" className="projeto-imagem" />
          <h3>SOPA</h3>
        </div>
        
        <div className="projeto-card">
          <img src={imagemCesta} alt="Projeto Cesta Básica" className="projeto-imagem" />
          <h3>CESTA BÁSICA</h3>
        </div>

      </div>
    </section>
  );
}

export default Projetos;