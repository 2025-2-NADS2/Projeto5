
import { useState } from 'react';
import ProjectModal from './ProjectModal.jsx';


import imagemNatal from '../assets/natal.jpeg';
import imagemSopa from '../assets/sopa.jpeg';
import imagemCesta from '../assets/cesta.jpeg';

const projectData = [
  {
    id: 1,
    title: 'NATAL SOLIDÁRIO',
    image: imagemNatal,
    story: 'Todo ano, nossa campanha de Natal Solidário arrecada brinquedos e alimentos para mais de 200 famílias...'
  },
  {
    id: 2,
    title: 'SOPA',
    image: imagemSopa,
    story: 'Semanalmente, nossa equipe de voluntários prepara e distribui mais de 500 litros de sopa nutritiva...'
  },
  {
    id: 3,
    title: 'CESTA BÁSICA',
    image: imagemCesta,
    story: 'A campanha de Cesta Básica é contínua e atende famílias cadastradas em situação de vulnerabilidade...'
  }
];

function Projetos() {
  const [modalIsOpen, setModalIsOpen] = useState(false);
  const [selectedProject, setSelectedProject] = useState(null);

  const openModal = (project) => {
    setSelectedProject(project);
    setModalIsOpen(true);
  };

  const closeModal = () => {
    setModalIsOpen(false);
    setSelectedProject(null);
  };

  return (
    <section className="projetos-section">
      <h2>PROJETOS</h2>
      <div className="projetos-container">
        
        {projectData.map((project) => (
          <div 
            key={project.id} 
            className="projeto-card" 
            onClick={() => openModal(project)}
            style={{cursor: 'pointer'}}
          >
            <img src={project.image} alt={project.title} className="projeto-imagem" />
            <h3>{project.title}</h3>
          </div>
        ))}

      </div>

      <ProjectModal
        isOpen={modalIsOpen}
        onRequestClose={closeModal}
        project={selectedProject}
      />
    </section>
  );
}
export default Projetos;