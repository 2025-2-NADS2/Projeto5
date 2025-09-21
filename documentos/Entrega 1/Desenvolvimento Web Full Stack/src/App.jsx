

import Header from './components/Header';
import Footer from './components/Footer';
import QuemSomos from './components/QuemSomos';
import Projetos from './components/Projetos';
import Sponsors from './components/Sponsors'; 

function App() {
  return (
    <>
      <Header />
      
      <main>
        
        <QuemSomos />
        
      
        <Projetos />
        
        
        <Sponsors />
      </main>
      
      <Footer />
    </>
  );
}

export default App;