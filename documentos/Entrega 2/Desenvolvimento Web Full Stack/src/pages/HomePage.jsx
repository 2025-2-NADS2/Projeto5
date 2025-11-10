// src/pages/HomePage.jsx
import QuemSomos from '../components/QuemSomos.jsx';
import Projetos from '../components/Projetos.jsx';
import Sponsors from '../components/Sponsors.jsx';
import DonationForm from '../components/DonationForm.jsx';

function HomePage() {
  return (
    <>
      <QuemSomos />
      <Projetos />
      <Sponsors />
      <div style={{maxWidth: '600px', margin: '40px auto'}}>
        <DonationForm />
      </div>
    </>
  );
}
export default HomePage;