import React, { useCallback, useEffect, useState } from 'react';
import { Link as RouterLink, useParams } from 'react-router-dom';

import {
  createStyles,
  makeStyles,
} from '@material-ui/core/styles';

import Box from '@material-ui/core/Box';
import CircularProgress from '@material-ui/core/CircularProgress';
import Link from '@material-ui/core/Link';
import Paper from '@material-ui/core/Paper';

import SentimentVeryDissatisfiedIcon from '@material-ui/icons/SentimentVeryDissatisfied';

const useStyles = makeStyles(() =>
  createStyles({
    userFetchingFailureIcon: {
      color: '#f50057',
      fontSize: 12,
    },
  }),
);

import Details from './Details';

const User: React.VFC = () => {
  const styles = useStyles();

  // Identyfikator użytkownika.
  const { userId } = useParams();

  // Flaga określająca, czy użytkownik został pobrany z API.
  const [isUserFetched, setIsUserFetched] = useState(false);
  // Flaga określająca, czy pobieranie użytkownika z API zakończyło się błędem.
  const [isUserFetchingFailure, setIsUserFetchingFailure] = useState(false);
  // Użytkownik.
  const [user, setUser] = useState(null);

  const fetchUser = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/users/${userId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsUserFetched(true);
        setUser(data);
      })
      .catch(() => {
        setIsUserFetched(true);
        setIsUserFetchingFailure(true);
      });
  }, [userId]);

  useEffect(() => {
    fetchUser();
  }, [fetchUser]);

  return (
    <>
      <Box
        fontSize="0.9rem"
        m={2}
      >
        <Link
          component={RouterLink}
          to="/users"
        >
          Użytkownicy
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        {
          isUserFetched
            ? (
              <Box component="span">
                {
                  isUserFetchingFailure
                    ? <SentimentVeryDissatisfiedIcon className={styles.userFetchingFailureIcon} />
                    : user?.fullName
                }
              </Box>
            )
            : (
              <Box component="span">
                <CircularProgress size={10} />
              </Box>
            )
        }
      </Box>
      <Box
        mb={3}
      >
        {
          isUserFetchingFailure
            ? (
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
                  Pobieranie informacji nt. użytkownika zakończyło się błędem.
                </Box>
              </Paper>
            )
            : (
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
            )
        }
      </Box>
    </>
  );
}

export default User;
