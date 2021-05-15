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
import InstalledComponentsList from './InstalledComponentsList';
import InstalledSoftwareApplicationsList from './InstalledSoftwareApplicationsList';

const useStyles = makeStyles(() =>
  createStyles({
    install: {
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
    serverFetchingFailureIcon: {
      color: '#f50057',
      fontSize: 12,
    },
  }),
);

const Server: React.VFC = () => {
  const history = useHistory();
  const styles = useStyles();

  // Identyfikator wdrożenia.
  const { implementationId } = useParams();
  // Identyfikator środowiska.
  const { environmentId } = useParams();
  // Identyfikator serwera.
  const { serverId } = useParams();

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

  // Flaga określająca, czy serwer został pobrany z API.
  const [isServerFetched, setIsServerFetched] = useState(false);
  // Flaga określająca, czy pobieranie serwera z API zakończyło się błędem.
  const [isServerFetchingFailure, setIsServerFetchingFailure] = useState(false);
  // Serwer.
  const [server, setServer] = useState(null);

  // Flaga określająca, czy okno dialogowe potwierdzające chęć odinstalowania komponentu jest otwarte.
  const [isUninstallComponentDialogWindowOpen, setIsUninstallComponentDialogWindowOpen] = useState(false);
  // Dane wykorzystywane przez okno dialogowe potwierdzające chęć odinstalowania komponentu.
  const [uninstallComponentDialogWindowData, setUninstallComponentDialogWindowData] = useState(null);

  // Flaga określająca, czy okno dialogowe potwierdzające chęć odinstalowania oprogramowania jest otwarte.
  const [isUninstallSoftwareApplicationDialogWindowOpen, setIsUninstallSoftwareApplicationDialogWindowOpen] = useState(false);
  // Dane wykorzystywane przez okno dialogowe potwierdzające chęć odinstalowania oprogramowania.
  const [uninstallSoftwareApplicationDialogWindowData, setUninstallSoftwareApplicationDialogWindowData] = useState(null);

  // Flaga określająca, czy okno wyświetlające informacje nt. błędu, który wystąpił podczas próby odinstalowania komponentu jest otwarte.
  const [isUninstallComponentErrorWindowOpen, setIsUninstallComponentErrorWindowOpen] = useState(false);

  // Flaga określająca, czy okno wyświetlające informacje nt. błędu, który wystąpił podczas próby odinstalowania oprogramowania jest otwarte.
  const [isUninstallSoftwareApplicationErrorWindowOpen, setIsUninstallSoftwareApplicationErrorWindowOpen] = useState(false);

  // Flaga określająca, czy lista logów została pobrana z API.
  const [isLogsFetched, setIsLogsFetched] = useState(false);
  // Lista logów.
  const [logs, setLogs] = useState([]);
  // Liczba logów, które mają zostać zwrócone.
  const [logsCount, setLogsCount] = useState(10);

  const fetchLogs = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/logs/servers/${serverId}?count=${logsCount}`)
      .then((response) => response.json())
      .then((data) => {
        setIsLogsFetched(true);
        setLogs(data);
      });
  }, [serverId, logsCount]);

  useEffect(() => {
    fetchLogs();
  }, [serverId, logsCount, fetchLogs]);

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

  const fetchServer = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/implementations/${implementationId}/environments/${environmentId}/servers/${serverId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsServerFetched(true);
        setServer(data);
      })
      .catch(() => {
        setIsServerFetched(true);
        setIsServerFetchingFailure(true);
      });
  }, [implementationId, environmentId, serverId]);

  useEffect(() => {
    fetchServer();
  }, [fetchServer]);

  const installComponent = () => {
    history.push(`/implementations/${implementationId}/environments/${environmentId}/servers/${serverId}/components/install`);
  };

  const updateComponent = () => {
    // TODO
  };

  const uninstallComponent = (id: string, name: string) => {
    setUninstallComponentDialogWindowData({
      id,
      name,
    });
    setIsUninstallComponentDialogWindowOpen(true);
  };

  const uninstallComponentConfirmed = async () => {
    await fetch(
      `${window['env'].API_URL}/implementations/${implementationId}/environments/${environmentId}/servers/${serverId}/components`,
      {
        body: JSON.stringify({
          componentVersionId: uninstallComponentDialogWindowData.id,
        }),
        headers: {
          'Content-Type': 'application/json',
        },
        method: 'DELETE',
      },
    )
    .then((response) => {
      setIsUninstallComponentDialogWindowOpen(false);
      setUninstallComponentDialogWindowData(null);

      if (response.ok) {
        fetchServer();
        fetchLogs();
      } else {
        setIsUninstallComponentErrorWindowOpen(true);
      }
    });
  };

  const uninstallComponentCanceled = () => {
    setIsUninstallComponentDialogWindowOpen(false);
    setUninstallComponentDialogWindowData(null);
  };

  const uninstallComponentFailed = () => {
    setIsUninstallComponentErrorWindowOpen(false);
  }

  const installSoftwareApplication = () => {
    history.push(`/implementations/${implementationId}/environments/${environmentId}/servers/${serverId}/software-applications/install`);
  };

  const uninstallSoftwareApplication = (id: string, name: string) => {
    setUninstallSoftwareApplicationDialogWindowData({
      id,
      name,
    });
    setIsUninstallSoftwareApplicationDialogWindowOpen(true);
  };

  const uninstallSoftwareApplicationConfirmed = async () => {
    await fetch(
      `${window['env'].API_URL}/implementations/${implementationId}/environments/${environmentId}/servers/${serverId}/software-applications`,
      {
        body: JSON.stringify({
          softwareApplicationId: uninstallSoftwareApplicationDialogWindowData.id,
        }),
        headers: {
          'Content-Type': 'application/json',
        },
        method: 'DELETE',
      },
    )
    .then((response) => {
      setIsUninstallSoftwareApplicationDialogWindowOpen(false);
      setUninstallSoftwareApplicationDialogWindowData(null);

      if (response.ok) {
        fetchServer();
        fetchLogs();
      } else {
        setIsUninstallSoftwareApplicationErrorWindowOpen(true);
      }
    });
  };

  const uninstallSoftwareApplicationCanceled = () => {
    setIsUninstallSoftwareApplicationDialogWindowOpen(false);
    setUninstallSoftwareApplicationDialogWindowData(null);
  };

  const uninstallSoftwareApplicationFailed = () => {
    setIsUninstallSoftwareApplicationErrorWindowOpen(false);
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
        <Link
          component={RouterLink}
          to={`/implementations/${implementationId}/environments/${environmentId}`}
        >
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
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        <Box component="span">
          Serwery
        </Box>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        {
          isServerFetched
            ? (
              <Box component="span">
                {
                  isServerFetchingFailure
                    ? <SentimentVeryDissatisfiedIcon className={styles.serverFetchingFailureIcon} />
                    : server?.name
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
          isServerFetchingFailure
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
                  Pobieranie informacji nt. serwera zakończyło się błędem.
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
                  isDataFetched={isServerFetched}
                  name={server?.name}
                  symbol={server?.symbol}
                  ipAddress={server?.ipAddress}
                  operatingSystemId={server?.operatingSystemId}
                  operatingSystemName={server?.operatingSystemName}
                  description={server?.description}
                />
              </Paper>
            )
        }
      </Box>
      <Box
        mb={3}
      >
        {
          isServerFetchingFailure
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
                  Pobieranie informacji nt. zainstalowanych komponentów zakończyło się błędem.
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
                  Zainstalowane komponenty
                </Box>
                <InstalledComponentsList
                  isDataFetched={isServerFetched}
                  data={server?.installedComponents}
                  onUpdate={updateComponent}
                  onUninstall={uninstallComponent}
                />
                <Box
                  p={1.5}
                  textAlign="right"
                >
                  <Button
                    className={styles.install}
                    size="small"
                    startIcon={<AddIcon />}
                    variant="contained"
                    onClick={installComponent}
                  >
                    Zainstaluj
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
          isServerFetchingFailure
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
                  Pobieranie informacji nt. zainstalowanego oprogramowania zakończyło się błędem.
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
                  Zainstalowane oprogramowanie
                </Box>
                <InstalledSoftwareApplicationsList
                  isDataFetched={isServerFetched}
                  data={server?.installedSoftwareApplications}
                  onUninstall={uninstallSoftwareApplication}
                />
                <Box
                  p={1.5}
                  textAlign="right"
                >
                  <Button
                    className={styles.install}
                    size="small"
                    startIcon={<AddIcon />}
                    variant="contained"
                    onClick={installSoftwareApplication}
                  >
                    Zainstaluj
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
          isServerFetchingFailure
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
        isOpen={isUninstallComponentDialogWindowOpen}
        title="Odinstalowanie komponentu"
        onConfirm={uninstallComponentConfirmed}
        onCancel={uninstallComponentCanceled}
      >
        Czy na pewno chcesz odinstalować komponent <strong>{uninstallComponentDialogWindowData?.name}</strong>?
      </DialogWindow>
      <ErrorWindow
        isOpen={isUninstallComponentErrorWindowOpen}
        onClose={uninstallComponentFailed}
      >
        Próba odinstalowania komponentu zakończyła się błędem.
      </ErrorWindow>
      <DialogWindow
        isOpen={isUninstallSoftwareApplicationDialogWindowOpen}
        title="Odinstalowanie oprogramowania"
        onConfirm={uninstallSoftwareApplicationConfirmed}
        onCancel={uninstallSoftwareApplicationCanceled}
      >
        Czy na pewno chcesz odinstalować oprogramowanie <strong>{uninstallSoftwareApplicationDialogWindowData?.name}</strong>?
      </DialogWindow>
      <ErrorWindow
        isOpen={isUninstallSoftwareApplicationErrorWindowOpen}
        onClose={uninstallSoftwareApplicationFailed}
      >
        Próba odinstalowania oprogramowania zakończyła się błędem.
      </ErrorWindow>
    </>
  );
}

export default Server;
