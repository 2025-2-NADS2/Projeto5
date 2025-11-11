import { useState } from 'react';
import { Link } from 'react-router-dom';
import logoAlma from '../assets/logo.alma.novo.jpeg'; 

function Header() {
  const [menuAberto, setMenuAberto] = useState(false);

  const fecharMenu = () => {
    setMenuAberto(false);
  };

  return (
    <header className="site-header">
      <Link to="/" onClick={fecharMenu} className="logo-link">
        <img 
          src={logoAlma} 
          alt="Logo do Instituto Alma" 
          className="logo"
        />
      </Link>

      <button 
        className="menu-toggle" 
        onClick={() => setMenuAberto(!menuAberto)}
      >
        {menuAberto ? '✕' : '☰'}
      </button>

      <nav className={menuAberto ? 'menu-aberto' : ''}>
        <Link to="/quem-somos" onClick={fecharMenu}>Quem Somos</Link>
        <Link to="/projetos" onClick={fecharMenu}>Projetos</Link>
        <Link to="/doacoes" onClick={fecharMenu}>Doações</Link>
        <Link to="/contato" onClick={fecharMenu}>Contato</Link>
        <Link to="/seja-parceiro" onClick={fecharMenu}>Seja Parceiro</Link>
        <Link to="/admin/login" style={{fontWeight: 'bold'}} onClick={fecharMenu}>Acesso</Link>
      </nav>
    </header>
  );
}

export default Header;