

function StoryCard({ title, text }) {
  return (
    <article className="news-card"> 
      <h3>{title}</h3>
      <p>{text}</p>
      <a href="#" className="story-link">Conheça a história completa</a>
    </article>
  );
}

export default StoryCard;