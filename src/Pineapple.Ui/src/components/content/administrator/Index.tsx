import React, { useCallback, useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Paper from '@material-ui/core/Paper';

import Details from './Details';

const Administrator: React.VFC = () => {
  // Identyfikator administratora.
  const { administratorId } = useParams();

  // Flaga określająca, czy administrator został pobrany z API.
  const [isAdministratorFetched, setIsAdministratorFetched] = useState(false);
  // Administrator.
  const [administrator, setAdministrator] = useState(null);

  const fetchAdministrator = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/users/${administratorId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsAdministratorFetched(true);
        setAdministrator(data);
      });
  }, [administratorId]);

  useEffect(() => {
    fetchAdministrator();
  }, [fetchAdministrator]);

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Administrator
        {
          isAdministratorFetched
            ? (
              <Box
                component="span"
                fontStyle="italic"
                px={0.5}
              >
                {administrator?.fullName}
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
            isDataFetched={isAdministratorFetched}
            fullName={administrator?.fullName}
            login={administrator?.login}
            phone={administrator?.phone}
            email={administrator?.email}
          />
        </Paper>
      </Box>
    </>
  );
}

export default Administrator;
