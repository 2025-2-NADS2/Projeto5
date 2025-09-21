

function Projetos() {
  return (
    <section className="projetos-section">
      <h2>PROJETOS</h2>
      <div className="projetos-container">
        <div className="projeto-card">
          {/* Idealmente, aqui iria uma imagem 600x400 */}
          <div className="projeto-imagem-placeholder"></div>
          <h3>NATAL SOLIDÁRIO</h3>
        </div>
        <div className="projeto-card">
          <div className="projeto-imagem-placeholder"></div>
          <h3>SOPA</h3>
        </div>
        <div className="projeto-card">
          <div className="projeto-imagem-placeholder"></div>
          <h3>CESTA BÁSICA</h3>
        </div>
      </div>
    </section>
  );
}

export default Projetos;