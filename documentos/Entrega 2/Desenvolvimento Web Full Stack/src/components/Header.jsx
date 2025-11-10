// src/components/Header.jsx
import { Link } from 'react-router-dom';


function Header() {
  return (
    <header className="site-header">
      <Link to="/">
        <img 
          src="https://placehold.co/150x60/006989/FFF?text=ALMA" 
          alt="Logo do Instituto Alma" 
          className="logo"
        />
      </Link>
      <nav>
        <Link to="/quem-somos">Quem Somos</Link>
        <Link to="/projetos">Projetos</Link>
        <Link to="/doacoes">Doações</Link>
        <Link to="/contato">Contato</Link>
        <Link to="/seja-parceiro">Seja Parceiro</Link>
      </nav>
    </header>
  );
}
export default Header;