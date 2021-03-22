import React, { useEffect, useState } from 'react';

import Box from '@material-ui/core/Box';
import Link from '@material-ui/core/Link';
import Paper from '@material-ui/core/Paper';

import List from './List';

const Administrators = () => {
  // Flaga określająca, czy lista administratorów została pobrana z API.
  const [isAdministratorsFetched, setIsAdministratorsFetched] = useState(false);
  // Lista administratorów.
  const [administrators, setAdministrators] = useState([]);
  // Liczba administratorów, którzy mają zostać zwróceni.
  const [administratorsCount, setAdministratorsCount] = useState(10);

  useEffect(() => {
    fetchAdministrators();
  }, [administratorsCount]);

  const fetchAdministrators = async () => {
    await fetch(`${window['env'].API_URL}/users/administrators?count=${administratorsCount}`)
      .then(response => response.json())
      .then(data => {
        setIsAdministratorsFetched(true);
        setAdministrators(data);
      });
  };

  const fetchMoreAdministrators = () => {
    if (administratorsCount <= administrators.length) {
      setAdministratorsCount(administratorsCount + 10);
    }
  };

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Administratorzy
      </Box>
      <Box
        mb={3}
      >
        <Paper>
          <List
            isDataFetched={isAdministratorsFetched}
            data={administrators}
          />
          <Box
            py={1.5}
            textAlign="center"
          >
            <Link onClick={fetchMoreAdministrators}>
              Pobierz więcej
            </Link>
          </Box>
        </Paper>
      </Box>
    </>
  );
}

export default Administrators;
