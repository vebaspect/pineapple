import React, { useEffect, useState } from 'react';
import { useHistory } from "react-router-dom";

import {
  createStyles,
  makeStyles,
  Theme,
} from '@material-ui/core/styles';

import Box from '@material-ui/core/Box';
import Button from '@material-ui/core/Button';
import Link from '@material-ui/core/Link';
import Paper from '@material-ui/core/Paper';

import AddIcon from '@material-ui/icons/Add';

import Logs from '../../logs';
import List from './List';

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    add: {
      backgroundColor: '#4caf50',
      color: '#fff',
    },
  }),
);

const Implementations = () => {
  // Flaga określająca, czy lista wdrożeń została pobrana z API.
  const [isImplementationsFetched, setIsImplementationsFetched] = useState(false);
  // Lista wdrożeń.
  const [implementations, setImplementations] = useState([]);

  // Flaga określająca, czy lista logów została pobrana z API.
  const [isLogsFetched, setIsLogsFetched] = useState(false);
  // Lista logów.
  const [logs, setLogs] = useState([]);
  // Liczba logów, które mają zostać zwrócone.
  const [logsCount, setLogsCount] = useState(10);

  const history = useHistory();
  const styles = useStyles();

  useEffect(() => {
    fetchImplementations();
  }, []);

  useEffect(() => {
    fetchLogs();
  }, [logsCount]);

  const fetchImplementations = async () => {
    await fetch(`${window['env'].API_URL}/implementations`)
      .then(response => response.json())
      .then(data => {
        setIsImplementationsFetched(true);
        setImplementations(data);
      });
  };

  const fetchLogs = async () => {
    await fetch(`${window['env'].API_URL}/logs/implementations?count=${logsCount}`)
      .then(response => response.json())
      .then(data => {
        setIsLogsFetched(true);
        setLogs(data);
      });
  };

  const fetchMoreLogs = () => {
    if (logsCount <= logs.length) {
      setLogsCount(logsCount + 10);
    }
  };

  const addImplementation = () => {
    history.push("/implementations/create");
  };

  const editImplementation = () => {
    // TODO
  };

  const deleteImplementation = async (id) => {
    await fetch(
      `${window['env'].API_URL}/implementations/${id}`,
      {
        method: 'DELETE',
      },
    )
    .then(() => {
      fetchImplementations();
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
    </>
  );
}

export default Implementations;
