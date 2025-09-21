// src/App.jsx (VERSÃO CORRIGIDA E SIMPLIFICADA)

import Header from './components/Header';
import Footer from './components/Footer';
import QuemSomos from './components/QuemSomos';
import Projetos from './components/Projetos';
import Sponsors from './components/Sponsors'; // Seus patrocinadores

function App() {
  return (
    <>
      <Header />
      
      <main>
        {/* Renderiza o componente "Quem Somos" que você criou */}
        <QuemSomos />
        
        {/* Renderiza o componente "Projetos" que você criou */}
        <Projetos />
        
        {/* Renderiza a seção de Patrocinadores/Apoiadores */}
        <Sponsors />
      </main>
      
      <Footer />
    </>
  );
}

export default App;