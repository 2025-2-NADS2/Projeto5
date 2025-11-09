// src/App.jsx
import { Routes, Route } from 'react-router-dom';
import Header from './components/Header.jsx';
import Footer from './components/Footer.jsx';


import HomePage from './pages/HomePage.jsx';
import QuemSomosPage from './pages/QuemSomosPage.jsx';
import ProjetosPage from './pages/ProjetosPage.jsx';
import DoacoesPage from './pages/DoacoesPage.jsx';
import ContatoPage from './pages/ContatoPage.jsx';
import ParceiroPage from './pages/ParceiroPage.jsx';
import AdminLoginPage from './pages/AdminLoginPage.jsx';
import AdminDashboardPage from './pages/AdminDashboardPage.jsx';

function App() {
  return (
    <> 
      <Header />
      
      <main>
        <Routes>
          
          <Route path="/" element={<HomePage />} />
          <Route path="/quem-somos" element={<QuemSomosPage />} />
          <Route path="/projetos" element={<ProjetosPage />} />
          <Route path="/doacoes" element={<DoacoesPage />} />
          <Route path="/contato" element={<ContatoPage />} />
          <Route path="/seja-parceiro" element={<ParceiroPage />} />
          
          
          <Route path="/admin/login" element={<AdminLoginPage />} />
          <Route path="/admin/dashboard" element={<AdminDashboardPage />} />
        </Routes>
      </main>
      
      <Footer />
    </>
  );
}

export default App;