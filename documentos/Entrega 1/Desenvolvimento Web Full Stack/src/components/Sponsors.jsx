import logoBigao from '../assets/bigpao.png';
import logoCacauShow from '../assets/cacaushow.png';
import logoAzon from '../assets/azon.png';
import logoMocoto from '../assets/mocoto.png';

function Sponsors() {
  return (
    <section className="sponsors-section">
      <h2 className="sponsors-title">Nossos Apoiadores</h2>
      <div className="sponsors-logos">
        <img src={logoBigao} alt="Logo do Patrocinador Bigão" />
        <img src={logoCacauShow} alt="Logo do Patrocinador Cacau Show" />
        <img src={logoAzon} alt="Logo do Patrocinador Azon" />
        <img src={logoMocoto} alt="Logo do Patrocinador Mocotó" />
      </div>
    </section>
  );
}

export default Sponsors;