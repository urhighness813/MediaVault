import { useMedia } from './hooks/useMedia.jsx'
import MediaCard from './components/MediaCard.jsx'

function App() {
  const { data, error } = useMedia();

  if (error) return <p>Error: {error}</p>;

  return (
    <div className="App">
      <h1>Media Vault</h1>
      {data.map(item => (
        <MediaCard key={item.id} {...item} />
      ))}
    </div>
  );
}

export default App
