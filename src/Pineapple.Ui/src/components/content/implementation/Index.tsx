import React, { useCallback, useEffect, useState } from 'react';
import { useHistory, useParams } from 'react-router-dom';

import {
  createStyles,
  makeStyles,
} from '@material-ui/core/styles';

import Box from '@material-ui/core/Box';
import Button from '@material-ui/core/Button';
import Link from '@material-ui/core/Link';
import Paper from '@material-ui/core/Paper';

import AddIcon from '@material-ui/icons/Add';

import Logs from '../../logs';

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

const Implementation: React.VFC = () => {
  const history = useHistory();
  const styles = useStyles();

  // Identyfikator wdrożenia.
  const { implementationId } = useParams();

  // Flaga określająca, czy wdrożenie zostało pobrane z API.
  const [isImplementationFetched, setIsImplementationFetched] = useState(false);
  // Wdrożenie.
  const [implementation, setImplementation] = useState(null);

  // Flaga określająca, czy lista środowisk została pobrana z API.
  const [isEnvironmentsFetched, setIsEnvironmentsFetched] = useState(false);
  // Lista środowisk.
  const [environments, setEnvironments] = useState([]);

  // Flaga określająca, czy lista logów została pobrana z API.
  const [isLogsFetched, setIsLogsFetched] = useState(false);
  // Lista logów.
  const [logs, setLogs] = useState([]);
  // Liczba logów, które mają zostać zwrócone.
  const [count, setCount] = useState(10);

  const fetchLogs = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/logs/implementations/${implementationId}?count=${count}`)
      .then((response) => response.json())
      .then((data) => {
        setIsLogsFetched(true);
        setLogs(data);
      });
  }, [implementationId, count]);

  useEffect(() => {
    fetchLogs();
  }, [implementationId, count, fetchLogs]);

  const fetchImplementation = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/implementations/${implementationId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsImplementationFetched(true);
        setImplementation(data);
      });
  }, [implementationId]);

  useEffect(() => {
    fetchImplementation();
  }, [fetchImplementation]);

  const fetchEnvironments = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/implementations/${implementationId}/environments`)
      .then((response) => response.json())
      .then((data) => {
        setIsEnvironmentsFetched(true);
        setEnvironments(data);
      });
  }, [implementationId]);

  useEffect(() => {
    fetchEnvironments();
  }, [fetchEnvironments]);

  const fetchMoreLogs = () => {
    if (count <= logs.length) {
      setCount(count + 10);
    }
  };

  const addEnvironment = () => {
    history.push(`/implementations/${implementationId}/environments/create`);
  };

  const editEnvironment = () => {
    // TODO
  };

  const deleteEnvironment = async (id) => {
    await fetch(
      `${window['env'].API_URL}/implementations/${implementationId}/environments/${id}`,
      {
        method: 'DELETE',
      },
    )
    .then(() => {
      fetchEnvironments();
      fetchLogs();
    });
  };

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Wdrożenie
        {
          isImplementationFetched
            ? (
              <Box
                component="span"
                fontStyle="italic"
                px={0.5}
              >
                {implementation?.name}
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
            isDataFetched={isImplementationFetched}
            name={implementation?.name}
            managerId={implementation?.managerId}
            managerFullName={implementation?.managerFullName}
            description={implementation?.description}
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
            Środowiska
          </Box>
          <List
            isDataFetched={isEnvironmentsFetched}
            data={environments}
            implementationId={implementationId}
            onEdit={editEnvironment}
            onDelete={deleteEnvironment}
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
              onClick={addEnvironment}
            >
              Dodaj
            </Button>
          </Box>
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
            Ostatnie aktywności
          </Box>
          <Box
            mx={2}
          >
            <Logs
              isDataFetched={isLogsFetched}
              data={logs}
            />
          </Box>
          <Box
            border={1}
            borderBottom={0}
            borderLeft={0}
            borderRight={0}
            borderColor="#e0e0e0"
            py={1.5}
            textAlign="center"
          >
            <Link onClick={fetchMoreLogs}>
              Pobierz więcej
            </Link>
          </Box>
        </Paper>
      </Box>
    </>
  );
}

export default Implementation;
