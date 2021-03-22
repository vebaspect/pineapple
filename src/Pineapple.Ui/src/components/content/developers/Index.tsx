import React, { useEffect, useState } from 'react';

import Box from '@material-ui/core/Box';
import Link from '@material-ui/core/Link';
import Paper from '@material-ui/core/Paper';

import List from './List';

const Developers = () => {
  // Flaga określająca, czy lista programistów została pobrana z API.
  const [isDevelopersFetched, setIsDevelopersFetched] = useState(false);
  // Lista programistów.
  const [developers, setDevelopers] = useState([]);
  // Liczba programistów, którzy mają zostać zwróceni.
  const [developersCount, setDevelopersCount] = useState(10);

  useEffect(() => {
    fetchDevelopers();
  }, [developersCount]);

  const fetchDevelopers = async () => {
    await fetch(`${window['env'].API_URL}/users/developers?count=${developersCount}`)
      .then(response => response.json())
      .then(data => {
        setIsDevelopersFetched(true);
        setDevelopers(data);
      });
  };

  const fetchMoreDevelopers = () => {
    if (developersCount <= developers.length) {
      setDevelopersCount(developersCount + 10);
    }
  };

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Programiści
      </Box>
      <Box
        mb={3}
      >
        <Paper>
          <List
            isDataFetched={isDevelopersFetched}
            data={developers}
          />
          <Box
            py={1.5}
            textAlign="center"
          >
            <Link onClick={fetchMoreDevelopers}>
              Pobierz więcej
            </Link>
          </Box>
        </Paper>
      </Box>
    </>
  );
}

export default Developers;
