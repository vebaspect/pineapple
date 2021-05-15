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
    componentTypeFetchingFailureIcon: {
      color: '#f50057',
      fontSize: 12,
    },
  }),
);

import Details from './Details';

const ComponentType: React.VFC = () => {
  const styles = useStyles();

  // Identyfikator typu komponentu.
  const { componentTypeId } = useParams();

  // Flaga określająca, czy typ komponentu został pobrany z API.
  const [isComponentTypeFetched, setIsComponentTypeFetched] = useState(false);
  // Flaga określająca, czy pobieranie typu komponentu z API zakończyło się błędem.
  const [isComponentTypeFetchingFailure, setIsComponentTypeFetchingFailure] = useState(false);
  // Typ komponentu.
  const [componentType, setComponentType] = useState(null);

  const fetchComponentType = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/configuration/component-types/${componentTypeId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsComponentTypeFetched(true);
        setComponentType(data);
      })
      .catch(() => {
        setIsComponentTypeFetched(true);
        setIsComponentTypeFetchingFailure(true);
      });
  }, [componentTypeId]);

  useEffect(() => {
    fetchComponentType();
  }, [fetchComponentType]);

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
          to="/configuration/component-types"
        >
          Typy komponentów
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        {
          isComponentTypeFetched
            ? (
              <Box component="span">
                {
                  isComponentTypeFetchingFailure
                    ? <SentimentVeryDissatisfiedIcon className={styles.componentTypeFetchingFailureIcon} />
                    : componentType?.name
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
          isComponentTypeFetchingFailure
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
                  Pobieranie informacji nt. typu komponentu zakończyło się błędem.
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
                  isDataFetched={isComponentTypeFetched}
                  name={componentType?.name}
                  symbol={componentType?.symbol}
                  description={componentType?.description}
                />
              </Paper>
            )
        }
      </Box>
    </>
  );
}

export default ComponentType;
