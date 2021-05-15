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

import Details from './Details';

const useStyles = makeStyles(() =>
  createStyles({
    operatingSystemFetchingFailureIcon: {
      color: '#f50057',
      fontSize: 12,
    },
  }),
);

const OperatingSystem: React.VFC = () => {
  const styles = useStyles();

  // Identyfikator systemu operacyjnego.
  const { operatingSystemId } = useParams();

  // Flaga określająca, czy system operacyjny został pobrany z API.
  const [isOperatingSystemFetched, setIsOperatingSystemFetched] = useState(false);
  // Flaga określająca, czy pobieranie systemu operacyjnego z API zakończyło się błędem.
  const [isOperatingSystemFetchingFailure, setIsOperatingSystemFetchingFailure] = useState(false);
  // System operacyjny.
  const [operatingSystem, setOperatingSystem] = useState(null);

  const fetchOperatingSystem = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/configuration/operating-systems/${operatingSystemId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsOperatingSystemFetched(true);
        setOperatingSystem(data);
      })
      .catch(() => {
        setIsOperatingSystemFetched(true);
        setIsOperatingSystemFetchingFailure(true);
      });
  }, [operatingSystemId]);

  useEffect(() => {
    fetchOperatingSystem();
  }, [fetchOperatingSystem]);

  return (
    <>
      <Box
        fontSize="0.9rem"
        m={2}
      >
        <Link
          component={RouterLink}
          to="/configuration"
        >
          Konfiguracja
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        <Link
          component={RouterLink}
          to="/configuration/operating-systems"
        >
          Systemy operacyjne
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        {
          isOperatingSystemFetched
            ? (
              <Box component="span">
                {
                  isOperatingSystemFetchingFailure
                    ? <SentimentVeryDissatisfiedIcon className={styles.operatingSystemFetchingFailureIcon} />
                    : operatingSystem?.name
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
          isOperatingSystemFetchingFailure
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
                  Pobieranie informacji nt. systemu operacyjnego zakończyło się błędem.
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
                  isDataFetched={isOperatingSystemFetched}
                  name={operatingSystem?.name}
                  symbol={operatingSystem?.symbol}
                  description={operatingSystem?.description}
                />
              </Paper>
            )
        }
      </Box>
    </>
  );
}

export default OperatingSystem;
