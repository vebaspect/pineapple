import React, { useEffect, useState } from 'react';

import Box from '@material-ui/core/Box';
import Link from '@material-ui/core/Link';
import Paper from '@material-ui/core/Paper';

import List from './List';

const Managers = () => {
  // Flaga określająca, czy lista menedżerów została pobrana z API.
  const [isManagersFetched, setIsManagersFetched] = useState(false);
  // Lista menedżerów.
  const [managers, setManagers] = useState([]);
  // Liczba menedżerów, którzy mają zostać zwróceni.
  const [managersCount, setManagersCount] = useState(10);

  useEffect(() => {
    fetchManagers();
  }, [managersCount]);

  const fetchManagers = async () => {
    await fetch(`${window['env'].API_URL}/users/managers?count=${managersCount}`)
      .then(response => response.json())
      .then(data => {
        setIsManagersFetched(true);
        setManagers(data);
      });
  };

  const fetchMoreManagers = () => {
    if (managersCount <= managers.length) {
      setManagersCount(managersCount + 10);
    }
  };

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Menedżerowie
      </Box>
      <Box
        mb={3}
      >
        <Paper>
          <List
            isDataFetched={isManagersFetched}
            data={managers}
          />
          <Box
            py={1.5}
            textAlign="center"
          >
            <Link onClick={fetchMoreManagers}>
              Pobierz więcej
            </Link>
          </Box>
        </Paper>
      </Box>
    </>
  );
}

export default Managers;
