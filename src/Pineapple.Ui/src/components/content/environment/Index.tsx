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

import DialogWindow from '../../windows/DialogWindow';
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

  // Flaga określająca, czy okno dialogowe potwierdzające chęć usunięcia serwera jest otwarte.
  const [isDeleteServerDialogWindowOpen, setIsDeleteServerDialogWindowOpen] = useState(false);
  // Dane wykorzystywane przez okno dialogowe potwierdzające chęć usunięcia serwera.
  const [deleteServerDialogWindowData, setDeleteServerDialogWindowData] = useState(null);

  // Flaga określająca, czy lista logów została pobrana z API.
  const [isLogsFetched, setIsLogsFetched] = useState(false);
  // Lista logów.
  const [logs, setLogs] = useState([]);
  // Liczba logów, które mają zostać zwrócone.
  const [count, setCount] = useState(10);

  const fetchLogs = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/logs/environments/${environmentId}?count=${count}`)
      .then((response) => response.json())
      .then((data) => {
        setIsLogsFetched(true);
        setLogs(data);
      });
  }, [environmentId, count]);

  useEffect(() => {
    fetchLogs();
  }, [environmentId, count, fetchLogs]);

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

  const fetchMoreLogs = () => {
    if (count <= logs.length) {
      setCount(count + 10);
    }
  };

  const addServer = () => {
    history.push(`/implementations/${implementationId}/environments/${environmentId}/servers/create`);
  };

  const editServer = () => {
    // TODO
  };

  const deleteServer = (id: string, number: string) => {
    setDeleteServerDialogWindowData({
      id,
      number,
    });
    setIsDeleteServerDialogWindowOpen(true);
  };

  const deleteServerConfirmed = async () => {
    await fetch(
      `${window['env'].API_URL}/implementations/${implementationId}/environments/${environmentId}/servers/${deleteServerDialogWindowData?.id}`,
      {
        method: 'DELETE',
      },
    )
    .then(() => {
      setIsDeleteServerDialogWindowOpen(false);
      setDeleteServerDialogWindowData(null);

      fetchServers();
      fetchLogs();
    });
  };

  const deleteServerCanceled = () => {
    setIsDeleteServerDialogWindowOpen(false);
    setDeleteServerDialogWindowData(null);
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
      <DialogWindow
        isOpen={isDeleteServerDialogWindowOpen}
        title="Usunięcie serwera"
        onConfirm={deleteServerConfirmed}
        onCancel={deleteServerCanceled}
      >
        Czy na pewno chcesz usunąć serwer <strong>{deleteServerDialogWindowData?.number}</strong>?
      </DialogWindow>
    </>
  );
}

export default Environment;
