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
  }),
);

const Implementation: React.VFC = () => {
  const history = useHistory();
  const styles = useStyles();

  // Identyfikator wdrożenia.
  const { implementationId } = useParams();

  // Flaga określająca, czy wdrożenie zostało pobrane z API.
  const [isImplementationFetched, setIsImplementationFetched] = useState(false);
  // Flaga określająca, czy pobieranie wdrożenia z API zakończyło się błędem.
  const [isImplementationFetchingFailure, setIsImplementationFetchingFailure] = useState(false);
  // Wdrożenie.
  const [implementation, setImplementation] = useState(null);

  // Flaga określająca, czy lista środowisk została pobrana z API.
  const [isEnvironmentsFetched, setIsEnvironmentsFetched] = useState(false);
  // Flaga określająca, czy pobieranie listy środowisk z API zakończyło się błędem.
  const [isEnvironmentsFetchingFailure, setIsEnvironmentsFetchingFailure] = useState(false);
  // Lista środowisk.
  const [environments, setEnvironments] = useState([]);

  // Flaga określająca, czy okno dialogowe potwierdzające chęć usunięcia środowiska jest otwarte.
  const [isDeleteEnvironmentDialogWindowOpen, setIsDeleteEnvironmentDialogWindowOpen] = useState(false);
  // Dane wykorzystywane przez okno dialogowe potwierdzające chęć usunięcia środowiska.
  const [deleteEnvironmentDialogWindowData, setDeleteEnvironmentDialogWindowData] = useState(null);

  // Flaga określająca, czy okno wyświetlające informacje nt. błędu, który wystąpił podczas próby usunięcia środowiska jest otwarte.
  const [isDeleteEnvironmentErrorWindowOpen, setIsDeleteEnvironmentErrorWindowOpen] = useState(false);

  // Flaga określająca, czy lista logów została pobrana z API.
  const [isLogsFetched, setIsLogsFetched] = useState(false);
  // Lista logów.
  const [logs, setLogs] = useState([]);
  // Liczba logów, które mają zostać zwrócone.
  const [logsCount, setLogsCount] = useState(10);

  const fetchLogs = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/logs/implementations/${implementationId}?count=${logsCount}`)
      .then((response) => response.json())
      .then((data) => {
        setIsLogsFetched(true);
        setLogs(data);
      });
  }, [implementationId, logsCount]);

  useEffect(() => {
    fetchLogs();
  }, [implementationId, logsCount, fetchLogs]);

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

  const fetchEnvironments = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/implementations/${implementationId}/environments`)
      .then((response) => response.json())
      .then((data) => {
        setIsEnvironmentsFetched(true);
        setEnvironments(data);
      })
      .catch(() => {
        setIsEnvironmentsFetched(true);
        setIsEnvironmentsFetchingFailure(true);
      });
  }, [implementationId]);

  useEffect(() => {
    fetchEnvironments();
  }, [fetchEnvironments]);

  const createEnvironment = () => {
    history.push(`/implementations/${implementationId}/environments/create`);
  };

  const editEnvironment = () => {
    // TODO
  };

  const deleteEnvironment = (id: string, name: string) => {
    setDeleteEnvironmentDialogWindowData({
      id,
      name,
    });
    setIsDeleteEnvironmentDialogWindowOpen(true);
  };

  const deleteEnvironmentConfirmed = async () => {
    await fetch(
      `${window['env'].API_URL}/implementations/${implementationId}/environments/${deleteEnvironmentDialogWindowData?.id}`,
      {
        method: 'DELETE',
      },
    )
    .then((response) => {
      setIsDeleteEnvironmentDialogWindowOpen(false);
      setDeleteEnvironmentDialogWindowData(null);

      if (response.ok) {
        fetchEnvironments();
        fetchLogs();
      } else {
        setIsDeleteEnvironmentErrorWindowOpen(true);
      }
    });
  };

  const deleteEnvironmentCanceled = () => {
    setIsDeleteEnvironmentDialogWindowOpen(false);
    setDeleteEnvironmentDialogWindowData(null);
  };

  const deleteEnvironmentFailed = () => {
    setIsDeleteEnvironmentErrorWindowOpen(false);
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
      </Box>
      <Box
        mb={3}
      >
        {
          isImplementationFetchingFailure
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
                  Pobieranie informacji nt. wdrożenia zakończyło się błędem.
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
                  isDataFetched={isImplementationFetched}
                  name={implementation?.name}
                  managerId={implementation?.managerId}
                  managerFullName={implementation?.managerFullName}
                  description={implementation?.description}
                />
              </Paper>
            )
        }
      </Box>
      <Box
        mb={3}
      >
        {
          isEnvironmentsFetchingFailure
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
                  Pobieranie informacji nt. środowisk zakończyło się błędem.
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
                    className={styles.create}
                    size="small"
                    startIcon={<AddIcon />}
                    variant="contained"
                    onClick={createEnvironment}
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
          isImplementationFetchingFailure
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
        isOpen={isDeleteEnvironmentDialogWindowOpen}
        title="Usunięcie środowiska"
        onConfirm={deleteEnvironmentConfirmed}
        onCancel={deleteEnvironmentCanceled}
      >
        Czy na pewno chcesz usunąć środowisko <strong>{deleteEnvironmentDialogWindowData?.name}</strong>?
      </DialogWindow>
      <ErrorWindow
        isOpen={isDeleteEnvironmentErrorWindowOpen}
        onClose={deleteEnvironmentFailed}
      >
        Próba usunięcia środowiska zakończyła się błędem.
      </ErrorWindow>
    </>
  );
}

export default Implementation;
