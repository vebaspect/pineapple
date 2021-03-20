import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import Box from '@material-ui/core/Box';

import Logs from '../../logs';

const Implementation = () => {
  const { implementationId } = useParams();

  // Flaga określająca, czy lista logów została pobrana z API.
  const [isLogsFetched, setIsLogsFetched] = useState(false);
  // Lista logów.
  const [logs, setLogs] = useState([]);
  // Liczba logów, które mają zostać zwrócone.
  const [count, setCount] = useState(10);

  useEffect(() => {
    fetchLogs();
  }, [implementationId]);

  const fetchLogs = async () => {
    await fetch(`${window['env'].API_URL}/logs/implementations/${implementationId}?count=${count}`)
      .then(response => response.json())
      .then(data => {
        setIsLogsFetched(true);
        setLogs(data);
      });
  };

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Wdrożenie
      </Box>
      <Box>
        <Box>
          Ostatnie aktywności:
        </Box>
        <Logs
          isDataFetched={isLogsFetched}
          data={logs}
        />
      </Box>
    </>
  );
}

export default Implementation;
