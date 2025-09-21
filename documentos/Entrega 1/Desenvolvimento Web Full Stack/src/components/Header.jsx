

import logoAlma from '../assets/logo-alma-transparente.png';

function Header() {
  return (
    <header className="site-header">
      <img 
        src={logoAlma} 
        alt="Logo do Instituto Alma" 
        className="logo"
      />
      <nav>
        <a href="#">Quem Somos</a>
        <a href="#">Projetos</a>
        <a href="#">Doações</a>
        <a href="#">Contato</a>
        <a href="#">Seja Parceiro</a>
      </nav>
    </header>
  );
}

export default Header;