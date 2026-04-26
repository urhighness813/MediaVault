import { useState, useEffect } from 'react';
import axios from 'axios';

export function useMedia() {
  const [data, setData] = useState([]);
  const [error, setError] = useState(null);

  const fetchData = async () => {
      try {
          const response = await axios.get('http://localhost:5150/api/media');
          setData(response.data);
      } catch (error) {
          setError(error.message);
      }
  };

  useEffect(() => {
    fetchData();
  }, []);

  return { data, error };
}
