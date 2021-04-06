import React, { useCallback, useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Paper from '@material-ui/core/Paper';

import Details from './Details';

const Environment: React.VFC = () => {
  // Identyfikator wdrożenia.
  const { implementationId } = useParams();
  // Identyfikator środowiska.
  const { environmentId } = useParams();

  // Flaga określająca, czy środowisko zostało pobrane z API.
  const [isEnvironmentFetched, setIsEnvironmentFetched] = useState(false);
  // Środowisko.
  const [environment, setEnvironment] = useState(null);

  const fetchEnvironment = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/implementations/${implementationId}/environments/${environmentId}`)
      .then(response => response.json())
      .then(data => {
        setIsEnvironmentFetched(true);
        setEnvironment(data);
      });
  }, [implementationId, environmentId]);

  useEffect(() => {
    fetchEnvironment();
  }, [fetchEnvironment]);

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Środowisko
        {
          isEnvironmentFetched
            ? (
              <Box
                component="span"
                fontStyle="italic"
                px={0.5}
              >
                {environment?.name}
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
            name={environment?.name}
            description={environment?.description}
          />
        </Paper>
      </Box>
    </>
  );
}

export default Environment;
