// src/components/ProjectModal.jsx
import Modal from 'react-modal';

function ProjectModal({ isOpen, onRequestClose, project }) {
  if (!project) {
    return null; 
  }

  return (
    <Modal
      isOpen={isOpen}
      onRequestClose={onRequestClose}
      className="modal-content"
      overlayClassName="modal-overlay"
      contentLabel="História do Projeto"
    >
      <button onClick={onRequestClose} className="modal-close-btn">&times;</button>
      <h2>{project.title}</h2>
      <img src={project.image} alt={project.title} className="modal-image" />
      <p>{project.story}</p>
    </Modal>
  );
}

export default ProjectModal;