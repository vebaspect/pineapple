import React, { useCallback, useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Paper from '@material-ui/core/Paper';

import Details from './Details';

const Manager: React.VFC = () => {
  // Identyfikator menedżera.
  const { managerId } = useParams();

  // Flaga określająca, czy menedżer został pobrany z API.
  const [isManagerFetched, setIsManagerFetched] = useState(false);
  // Menedżer.
  const [manager, setManager] = useState(null);

  const fetchManager = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/users/${managerId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsManagerFetched(true);
        setManager(data);
      });
  }, [managerId]);

  useEffect(() => {
    fetchManager();
  }, [fetchManager]);

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Menedżer
        {
          isManagerFetched
            ? (
              <Box
                component="span"
                fontStyle="italic"
                px={0.5}
              >
                {manager?.fullName}
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
            isDataFetched={isManagerFetched}
            fullName={manager?.fullName}
            login={manager?.login}
            phone={manager?.phone}
            email={manager?.email}
          />
        </Paper>
      </Box>
    </>
  );
}

export default Manager;
