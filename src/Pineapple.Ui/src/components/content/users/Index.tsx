import React, { useEffect, useState } from 'react';

import Box from '@material-ui/core/Box';

import Logs from '../../logs';

const Users = () => {
  // Flaga określająca, czy lista logów została pobrana z API.
  const [isLogsFetched, setIsLogsFetched] = useState(false);
  // Lista logów.
  const [logs, setLogs] = useState([]);

  useEffect(() => {
    fetchLogs();
  }, []);

  const fetchLogs = async () => {
    await fetch(`${window['env'].API_URL}/logs/users`)
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
        Użytkownicy
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

export default Users;
