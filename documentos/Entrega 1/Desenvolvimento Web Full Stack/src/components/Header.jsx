

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
        <a href="#">Histórias</a>
        <a href="#">Faça uma Doação</a>
      </nav>
    </header>
  );
}

export default Header;