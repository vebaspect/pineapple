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
import InstalledComponentsList from './InstalledComponentsList';
import InstalledSoftwareApplicationsList from './InstalledSoftwareApplicationsList';

const useStyles = makeStyles(() =>
  createStyles({
    install: {
      backgroundColor: '#4caf50',
      color: '#fff',
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

  // Flaga określająca, czy serwer został pobrany z API.
  const [isServerFetched, setIsServerFetched] = useState(false);
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

  const fetchServer = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/implementations/${implementationId}/environments/${environmentId}/servers/${serverId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsServerFetched(true);
        setServer(data);
      });
  }, [implementationId, environmentId, serverId]);

  useEffect(() => {
    fetchServer();
  }, [fetchServer]);

  const installComponent = () => {
    history.push(`/implementations/${implementationId}/environments/${environmentId}/servers/${serverId}/components/install`);
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
    .then(() => {
      setIsUninstallComponentDialogWindowOpen(false);
      setUninstallComponentDialogWindowData(null);

      fetchServer();
      fetchLogs();
    });
  };

  const uninstallComponentCanceled = () => {
    setIsUninstallComponentDialogWindowOpen(false);
    setUninstallComponentDialogWindowData(null);
  };

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
    .then(() => {
      setIsUninstallSoftwareApplicationDialogWindowOpen(false);
      setUninstallSoftwareApplicationDialogWindowData(null);

      fetchServer();
      fetchLogs();
    });
  };

  const uninstallSoftwareApplicationCanceled = () => {
    setIsUninstallSoftwareApplicationDialogWindowOpen(false);
    setUninstallSoftwareApplicationDialogWindowData(null);
  };

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Serwer
        {
          isServerFetched
            ? (
              <Box
                component="span"
                fontStyle="italic"
                px={0.5}
              >
                {server?.name}
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
            isDataFetched={isServerFetched}
            name={server?.name}
            symbol={server?.symbol}
            ipAddress={server?.ipAddress}
            operatingSystemId={server?.operatingSystemId}
            operatingSystemName={server?.operatingSystemName}
            description={server?.description}
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
            Zainstalowane komponenty
          </Box>
          <InstalledComponentsList
            isDataFetched={isServerFetched}
            data={server?.installedComponents}
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
        isOpen={isUninstallComponentDialogWindowOpen}
        title="Odinstalowanie komponentu"
        onConfirm={uninstallComponentConfirmed}
        onCancel={uninstallComponentCanceled}
      >
        Czy na pewno chcesz odinstalować komponent <strong>{uninstallComponentDialogWindowData?.name}</strong>?
      </DialogWindow>
      <DialogWindow
        isOpen={isUninstallSoftwareApplicationDialogWindowOpen}
        title="Odinstalowanie oprogramowania"
        onConfirm={uninstallSoftwareApplicationConfirmed}
        onCancel={uninstallSoftwareApplicationCanceled}
      >
        Czy na pewno chcesz odinstalować oprogramowanie <strong>{uninstallSoftwareApplicationDialogWindowData?.name}</strong>?
      </DialogWindow>
    </>
  );
}

export default Server;
