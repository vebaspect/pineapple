import React, { useCallback, useEffect, useState } from 'react';
import { useHistory, useParams } from 'react-router-dom';

import {
  createStyles,
  makeStyles,
} from '@material-ui/core/styles';

import Box from '@material-ui/core/Box';
import Button from '@material-ui/core/Button';
import Paper from '@material-ui/core/Paper';

import AddIcon from '@material-ui/icons/Add';

import Details from './Details';
import List from './List';

const useStyles = makeStyles(() =>
  createStyles({
    add: {
      backgroundColor: '#4caf50',
      color: '#fff',
    },
  }),
);

const Environment: React.VFC = () => {
  const history = useHistory();
  const styles = useStyles();

  // Identyfikator wdrożenia.
  const { implementationId } = useParams();
  // Identyfikator środowiska.
  const { environmentId } = useParams();

  // Flaga określająca, czy środowisko zostało pobrane z API.
  const [isEnvironmentFetched, setIsEnvironmentFetched] = useState(false);
  // Środowisko.
  const [environment, setEnvironment] = useState(null);

  // Flaga określająca, czy lista serwerów została pobrana z API.
  const [isServersFetched, setIsServersFetched] = useState(false);
  // Lista serwerów.
  const [servers, setServers] = useState([]);

  const fetchEnvironment = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/implementations/${implementationId}/environments/${environmentId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsEnvironmentFetched(true);
        setEnvironment(data);
      });
  }, [implementationId, environmentId]);

  useEffect(() => {
    fetchEnvironment();
  }, [fetchEnvironment]);

  const fetchServers = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/implementations/${implementationId}/environments/${environmentId}/servers`)
      .then((response) => response.json())
      .then((data) => {
        setIsServersFetched(true);
        setServers(data);
      });
  }, [implementationId, environmentId]);

  useEffect(() => {
    fetchServers();
  }, [fetchServers]);

  const addServer = () => {
    history.push(`/implementations/${implementationId}/environments/${environmentId}/servers/create`);
  };

  const editServer = () => {
    // TODO
  };

  const deleteServer = async (id: string) => {
    await fetch(
      `${window['env'].API_URL}/implementations/${implementationId}/environments/${environmentId}/servers/${id}`,
      {
        method: 'DELETE',
      },
    )
    .then(() => {
      fetchServers();
    });
  };

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
            isDataFetched={isEnvironmentFetched}
            name={environment?.name}
            symbol={environment?.symbol}
            operatorId={environment?.operatorId}
            operatorFullName={environment?.operatorFullName}
            description={environment?.description}
          />
        </Paper>
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
            Serwery
          </Box>
          <List
            isDataFetched={isServersFetched}
            data={servers}
            implementationId={implementationId}
            environmentId={environmentId}
            onEdit={editServer}
            onDelete={deleteServer}
          />
          <Box
            p={1.5}
            textAlign="right"
          >
            <Button
              className={styles.add}
              size="small"
              startIcon={<AddIcon />}
              variant="contained"
              onClick={addServer}
            >
              Dodaj
            </Button>
          </Box>
        </Paper>
      </Box>
    </>
  );
}

export default Environment;
