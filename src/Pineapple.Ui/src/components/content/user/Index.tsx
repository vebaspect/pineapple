import React, { useCallback, useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Paper from '@material-ui/core/Paper';

import Details from './Details';

const User: React.VFC = () => {
  // Identyfikator użytkownika.
  const { userId } = useParams();

  // Flaga określająca, czy użytkownik został pobrany z API.
  const [isUserFetched, setIsUserFetched] = useState(false);
  // Użytkownik.
  const [user, setUser] = useState(null);

  const fetchUser = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/users/${userId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsUserFetched(true);
        setUser(data);
      });
  }, [userId]);

  useEffect(() => {
    fetchUser();
  }, [fetchUser]);

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Użytkownik
        {
          isUserFetched
            ? (
              <Box
                component="span"
                fontStyle="italic"
                px={0.5}
              >
                {user?.fullName}
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
            isDataFetched={isUserFetched}
            fullName={user?.fullName}
            login={user?.login}
            phone={user?.phone}
            email={user?.email}
          />
        </Paper>
      </Box>
    </>
  );
}

export default User;
