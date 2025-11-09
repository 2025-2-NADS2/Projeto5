// src/components/Sponsors.jsx

import logoAzon from '../assets/azon.png';     
import logoBigpao from '../assets/bigpao.png';
import logoCacauShow from '../assets/cacaushow.png';
import logoMocoto from '../assets/mocoto.png';

function Sponsors() {
  return (
    <section className="sponsors-section">
      <h2 className="sponsors-title">Nossos Apoiadores</h2>
      <div className="sponsors-logos">
        <img src={logoAzon} alt="Logo Azon" />
        <img src={logoBigpao} alt="Logo Big Pão" />
        <img src={logoCacauShow} alt="Logo Cacau Show" />
        <img src={logoMocoto} alt="Logo Mocotó" />
      </div>
    </section>
  );
}
export default Sponsors;