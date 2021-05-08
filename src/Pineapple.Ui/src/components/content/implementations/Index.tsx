import React, { useCallback, useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom';

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
import ErrorWindow from '../../windows/ErrorWindow';
import Logs from '../../logs';

import List from './List';

const useStyles = makeStyles(() =>
  createStyles({
    add: {
      backgroundColor: '#4caf50',
      color: '#fff',
    },
  }),
);

const Implementations: React.VFC = () => {
  const history = useHistory();
  const styles = useStyles();

  // Flaga określająca, czy lista wdrożeń została pobrana z API.
  const [isImplementationsFetched, setIsImplementationsFetched] = useState(false);
  // Lista wdrożeń.
  const [implementations, setImplementations] = useState([]);

  // Flaga określająca, czy okno dialogowe potwierdzające chęć usunięcia wdrożenia jest otwarte.
  const [isDeleteImplementationDialogWindowOpen, setIsDeleteImplementationDialogWindowOpen] = useState(false);
  // Dane wykorzystywane przez okno dialogowe potwierdzające chęć usunięcia wdrożenia.
  const [deleteImplementationDialogWindowData, setDeleteImplementationDialogWindowData] = useState(null);

  // Flaga określająca, czy okno wyświetlające informacje nt. błędu, który wystąpił podczas próby usunięcia wdrożenia jest otwarte.
  const [isDeleteImplementationErrorWindowOpen, setIsDeleteImplementationErrorWindowOpen] = useState(false);

  // Flaga określająca, czy lista logów została pobrana z API.
  const [isLogsFetched, setIsLogsFetched] = useState(false);
  // Lista logów.
  const [logs, setLogs] = useState([]);
  // Liczba logów, które mają zostać zwrócone.
  const [logsCount, setLogsCount] = useState(10);

  const fetchLogs = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/logs/implementations?count=${logsCount}`)
      .then((response) => response.json())
      .then((data) => {
        setIsLogsFetched(true);
        setLogs(data);
      });
  }, [logsCount]);

  useEffect(() => {
    fetchLogs();
  }, [logsCount, fetchLogs]);

  const fetchMoreLogs = () => {
    if (logsCount <= logs.length) {
      setLogsCount(logsCount + 10);
    }
  };

  const fetchImplementations = async () => {
    await fetch(`${window['env'].API_URL}/implementations`)
      .then((response) => response.json())
      .then((data) => {
        setIsImplementationsFetched(true);
        setImplementations(data);
      });
  };

  useEffect(() => {
    fetchImplementations();
  }, []);

  const addImplementation = () => {
    history.push('/implementations/create');
  };

  const editImplementation = () => {
    // TODO
  };

  const deleteImplementation = (id: string, name: string) => {
    setDeleteImplementationDialogWindowData({
      id,
      name,
    });
    setIsDeleteImplementationDialogWindowOpen(true);
  };

  const deleteImplementationConfirmed = async () => {
    await fetch(
      `${window['env'].API_URL}/implementations/${deleteImplementationDialogWindowData?.id}`,
      {
        method: 'DELETE',
      },
    )
    .then((response) => {
      setIsDeleteImplementationDialogWindowOpen(false);
      setDeleteImplementationDialogWindowData(null);

      if (response.ok) {
        fetchImplementations();
        fetchLogs();
      } else {
        setIsDeleteImplementationErrorWindowOpen(true);
      }
    });
  };

  const deleteImplementationCanceled = () => {
    setIsDeleteImplementationDialogWindowOpen(false);
    setDeleteImplementationDialogWindowData(null);
  };

  const deleteImplementationFailed = () => {
    setIsDeleteImplementationErrorWindowOpen(false);
  }

  return (
    <>
      <Box
        fontSize="0.9rem"
        m={2}
      >
        Wdrożenia
      </Box>
      <Box
        mb={3}
      >
        <Paper>
          <List
            isDataFetched={isImplementationsFetched}
            data={implementations}
            onEdit={editImplementation}
            onDelete={deleteImplementation}
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
              onClick={addImplementation}
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
        isOpen={isDeleteImplementationDialogWindowOpen}
        title="Usunięcie wdrożenia"
        onConfirm={deleteImplementationConfirmed}
        onCancel={deleteImplementationCanceled}
      >
        Czy na pewno chcesz usunąć wdrożenie <strong>{deleteImplementationDialogWindowData?.name}</strong>?
      </DialogWindow>
      <ErrorWindow
        isOpen={isDeleteImplementationErrorWindowOpen}
        onClose={deleteImplementationFailed}
      >
        Próba usunięcia wdrożenia zakończyła się błędem.
      </ErrorWindow>
    </>
  );
}

export default Implementations;
