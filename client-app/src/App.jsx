import { useMedia } from './hooks/useMedia.jsx'

function App() {
  const { data, loading, error } = useMedia();

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;

  return (
    <ul>
      {data.map(item => <li key={item.id}>{item.title}, {item.genre}</li>)}
    </ul>
  );
}

export default App
