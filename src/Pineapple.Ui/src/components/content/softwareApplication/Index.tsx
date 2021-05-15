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
    softwareApplicationFetchingFailureIcon: {
      color: '#f50057',
      fontSize: 12,
    },
  }),
);

import Details from './Details';

const SoftwareApplication: React.VFC = () => {
  const styles = useStyles();

  // Identyfikator oprogramowania.
  const { softwareApplicationId } = useParams();

  // Flaga określająca, czy oprogramowanie zostało pobrane z API.
  const [isSoftwareApplicationFetched, setIsSoftwareApplicationFetched] = useState(false);
  // Flaga określająca, czy pobieranie oprogramowania z API zakończyło się błędem.
  const [isSoftwareApplicationFetchingFailure, setIsSoftwareApplicationFetchingFailure] = useState(false);
  // Oprogramowanie.
  const [softwareApplication, setSoftwareApplication] = useState(null);

  const fetchSoftwareApplication = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/configuration/software-applications/${softwareApplicationId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsSoftwareApplicationFetched(true);
        setSoftwareApplication(data);
      })
      .catch(() => {
        setIsSoftwareApplicationFetched(true);
        setIsSoftwareApplicationFetchingFailure(true);
      });
  }, [softwareApplicationId]);

  useEffect(() => {
    fetchSoftwareApplication();
  }, [fetchSoftwareApplication]);

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
          to="/configuration/software-applications"
        >
          Oprogramowanie
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        {
          isSoftwareApplicationFetched
            ? (
              <Box component="span">
                {
                  isSoftwareApplicationFetchingFailure
                    ? <SentimentVeryDissatisfiedIcon className={styles.softwareApplicationFetchingFailureIcon} />
                    : softwareApplication?.name
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
          isSoftwareApplicationFetchingFailure
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
                  Pobieranie informacji nt. oprogramowania zakończyło się błędem.
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
                  isDataFetched={isSoftwareApplicationFetched}
                  name={softwareApplication?.name}
                  symbol={softwareApplication?.symbol}
                  description={softwareApplication?.description}
                />
              </Paper>
            )
        }
      </Box>
    </>
  );
}

export default SoftwareApplication;
