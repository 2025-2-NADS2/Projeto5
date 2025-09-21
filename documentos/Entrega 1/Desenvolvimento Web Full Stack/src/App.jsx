

import Header from './components/Header';
import StoryCard from './components/StoryCard';
import Sidebar from './components/Sidebar';
import Footer from './components/Footer';
import Sponsors from './components/Sponsors'; 

const storiesData = [
  { id: 1, title: 'A História de Maria', text: 'Com o apoio do Instituto Alma, Maria conseguiu concluir seus estudos...' },
  { id: 2, title: 'João e a Oportunidade', text: 'Através de um de nossos programas de capacitação, João descobriu seu talento...' },
];

function App() {
  return (
    <>
      <Header />
      <div className="main-container">
        <main className="content">
          <section className="news-card">
            <h2>Quem Somos</h2>
            <p>O instituto alma surgiu com o proposito de promover mudanças socias através de ações diferenciadas, nossas ações visam encantar a vida de pessoas em situação de vulnerabilidade.</p>
          </section>
          <section>
            <h2>Histórias que Inspiram</h2>
            {storiesData.map(story => (
              <StoryCard 
                key={story.id}
                title={story.title}
                text={story.text}
              />
            ))}
          </section>
        </main>
        
        <Sidebar />
      </div>

     
      <Sponsors />

      <Footer />
    </>
  );
}

export default App;