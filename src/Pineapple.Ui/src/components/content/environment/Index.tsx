import React, { useCallback, useEffect, useState } from 'react';
import { Link as RouterLink, useHistory, useParams } from 'react-router-dom';

import {
  createStyles,
  makeStyles,
} from '@material-ui/core/styles';

import Box from '@material-ui/core/Box';
import Button from '@material-ui/core/Button';
import CircularProgress from '@material-ui/core/CircularProgress';
import Link from '@material-ui/core/Link';
import Paper from '@material-ui/core/Paper';

import AddIcon from '@material-ui/icons/Add';
import SentimentVeryDissatisfiedIcon from '@material-ui/icons/SentimentVeryDissatisfied';

import DialogWindow from '../../windows/DialogWindow';
import ErrorWindow from '../../windows/ErrorWindow';
import Logs from '../../logs';

import Details from './Details';
import List from './List';

const useStyles = makeStyles(() =>
  createStyles({
    create: {
      backgroundColor: '#4caf50',
      color: '#fff',
    },
    implementationFetchingFailureIcon: {
      color: '#f50057',
      fontSize: 12,
    },
    environmentFetchingFailureIcon: {
      color: '#f50057',
      fontSize: 12,
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

  // Flaga określająca, czy wdrożenie zostało pobrane z API.
  const [isImplementationFetched, setIsImplementationFetched] = useState(false);
  // Flaga określająca, czy pobieranie wdrożenia z API zakończyło się błędem.
  const [isImplementationFetchingFailure, setIsImplementationFetchingFailure] = useState(false);
  // Wdrożenie.
  const [implementation, setImplementation] = useState(null);

  // Flaga określająca, czy środowisko zostało pobrane z API.
  const [isEnvironmentFetched, setIsEnvironmentFetched] = useState(false);
  // Flaga określająca, czy pobieranie środowiska z API zakończyło się błędem.
  const [isEnvironmentFetchingFailure, setIsEnvironmentFetchingFailure] = useState(false);
  // Środowisko.
  const [environment, setEnvironment] = useState(null);

  // Flaga określająca, czy lista serwerów została pobrana z API.
  const [isServersFetched, setIsServersFetched] = useState(false);
  // Flaga określająca, czy pobieranie listy serwerów z API zakończyło się błędem.
  const [isServersFetchingFailure, setIsServersFetchingFailure] = useState(false);
  // Lista serwerów.
  const [servers, setServers] = useState([]);

  // Flaga określająca, czy okno dialogowe potwierdzające chęć usunięcia serwera jest otwarte.
  const [isDeleteServerDialogWindowOpen, setIsDeleteServerDialogWindowOpen] = useState(false);
  // Dane wykorzystywane przez okno dialogowe potwierdzające chęć usunięcia serwera.
  const [deleteServerDialogWindowData, setDeleteServerDialogWindowData] = useState(null);

  // Flaga określająca, czy okno wyświetlające informacje nt. błędu, który wystąpił podczas próby usunięcia serwera jest otwarte.
  const [isDeleteServerErrorWindowOpen, setIsDeleteServerErrorWindowOpen] = useState(false);

  // Flaga określająca, czy lista logów została pobrana z API.
  const [isLogsFetched, setIsLogsFetched] = useState(false);
  // Lista logów.
  const [logs, setLogs] = useState([]);
  // Liczba logów, które mają zostać zwrócone.
  const [logsCount, setLogsCount] = useState(10);

  const fetchLogs = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/logs/environments/${environmentId}?count=${logsCount}`)
      .then((response) => response.json())
      .then((data) => {
        setIsLogsFetched(true);
        setLogs(data);
      });
  }, [environmentId, logsCount]);

  useEffect(() => {
    fetchLogs();
  }, [environmentId, logsCount, fetchLogs]);

  const fetchMoreLogs = () => {
    if (logsCount <= logs.length) {
      setLogsCount(logsCount + 10);
    }
  };

  const fetchImplementation = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/implementations/${implementationId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsImplementationFetched(true);
        setImplementation(data);
      })
      .catch(() => {
        setIsImplementationFetched(true);
        setIsImplementationFetchingFailure(true);
      });
  }, [implementationId]);

  useEffect(() => {
    fetchImplementation();
  }, [fetchImplementation]);

  const fetchEnvironment = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/implementations/${implementationId}/environments/${environmentId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsEnvironmentFetched(true);
        setEnvironment(data);
      })
      .catch(() => {
        setIsEnvironmentFetched(true);
        setIsEnvironmentFetchingFailure(true);
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
      })
      .catch(() => {
        setIsServersFetched(true);
        setIsServersFetchingFailure(true);
      });
  }, [implementationId, environmentId]);

  useEffect(() => {
    fetchServers();
  }, [fetchServers]);

  const createServer = () => {
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
    .then((response) => {
      setIsDeleteServerDialogWindowOpen(false);
      setDeleteServerDialogWindowData(null);

      if (response.ok) {
        fetchServers();
        fetchLogs();
      } else {
        setIsDeleteServerErrorWindowOpen(true);
      }
    });
  };

  const deleteServerCanceled = () => {
    setIsDeleteServerDialogWindowOpen(false);
    setDeleteServerDialogWindowData(null);
  };

  const deleteServerFailed = () => {
    setIsDeleteServerErrorWindowOpen(false);
  }

  return (
    <>
      <Box
        fontSize="0.9rem"
        m={2}
      >
        <Link
          component={RouterLink}
          to="/implementations"
        >
          Wdrożenia
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        <Link
          component={RouterLink}
          to={`/implementations/${implementationId}`}
        >
          {
            isImplementationFetched
              ? (
                <Box component="span">
                  {
                    isImplementationFetchingFailure
                      ? <SentimentVeryDissatisfiedIcon className={styles.implementationFetchingFailureIcon} />
                      : implementation?.name
                  }
                </Box>
              )
              : (
                <Box component="span">
                  <CircularProgress size={10} />
                </Box>
              )
          }
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        <Box component="span">
          Środowiska
        </Box>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        {
          isEnvironmentFetched
            ? (
              <Box component="span">
                {
                  isEnvironmentFetchingFailure
                    ? <SentimentVeryDissatisfiedIcon className={styles.environmentFetchingFailureIcon} />
                    : environment?.name
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
          isEnvironmentFetchingFailure
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
                  Pobieranie informacji nt. środowiska zakończyło się błędem.
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
                  isDataFetched={isEnvironmentFetched}
                  name={environment?.name}
                  symbol={environment?.symbol}
                  operatorId={environment?.operatorId}
                  operatorFullName={environment?.operatorFullName}
                  description={environment?.description}
                />
              </Paper>
            )
        }
      </Box>
      <Box
        mb={3}
      >
        {
          isServersFetchingFailure
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
                  Pobieranie informacji nt. serwerów zakończyło się błędem.
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
                    className={styles.create}
                    size="small"
                    startIcon={<AddIcon />}
                    variant="contained"
                    onClick={createServer}
                  >
                    Dodaj
                  </Button>
                </Box>
              </Paper>
            )
        }
      </Box>
      <Box
        mb={3}
      >
        {
          isEnvironmentFetchingFailure
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
                  Pobieranie informacji nt. logów zakończyło się błędem.
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
            )
        }
      </Box>
      <DialogWindow
        isOpen={isDeleteServerDialogWindowOpen}
        title="Usunięcie serwera"
        onConfirm={deleteServerConfirmed}
        onCancel={deleteServerCanceled}
      >
        Czy na pewno chcesz usunąć serwer <strong>{deleteServerDialogWindowData?.number}</strong>?
      </DialogWindow>
      <ErrorWindow
        isOpen={isDeleteServerErrorWindowOpen}
        onClose={deleteServerFailed}
      >
        Próba usunięcia serwera zakończyła się błędem.
      </ErrorWindow>
    </>
  );
}

export default Environment;
