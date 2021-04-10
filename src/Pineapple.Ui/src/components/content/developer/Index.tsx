import React, { useCallback, useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Paper from '@material-ui/core/Paper';

import Details from './Details';

const Developer: React.VFC = () => {
  // Identyfikator programisty.
  const { developerId } = useParams();

  // Flaga określająca, czy programista został pobrany z API.
  const [isDeveloperFetched, setIsDeveloperFetched] = useState(false);
  // Programista.
  const [developer, setDeveloper] = useState(null);

  const fetchDeveloper = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/users/${developerId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsDeveloperFetched(true);
        setDeveloper(data);
      });
  }, [developerId]);

  useEffect(() => {
    fetchDeveloper();
  }, [fetchDeveloper]);

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Programista
        {
          isDeveloperFetched
            ? (
              <Box
                component="span"
                fontStyle="italic"
                px={0.5}
              >
                {developer?.fullName}
              </Box>)
            : ''
        }
      </Box>
      <Box
        mb={3}
      >
        <Paper>
          <Box
            border={1}
            borderLeft={0}
            borderRight={0}
            borderTop={0}
            borderColor="#e0e0e0"
            py={1.5}
            textAlign="center"
          >
            Szczegóły
          </Box>
          <Details
            isDataFetched={isDeveloperFetched}
            fullName={developer?.fullName}
            login={developer?.login}
            phone={developer?.phone}
            email={developer?.email}
          />
        </Paper>
      </Box>
    </>
  );
}

export default Developer;
