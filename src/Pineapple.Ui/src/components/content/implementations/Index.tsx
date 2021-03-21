import React, { useEffect, useState } from 'react';

import Box from '@material-ui/core/Box';
import Link from '@material-ui/core/Link';
import Paper from '@material-ui/core/Paper';

import Logs from '../../logs';

import List from './List';

const Implementations = () => {
  // Flaga określająca, czy lista wdrożeń została pobrana z API.
  const [isImplementationsFetched, setIsImplementationsFetched] = useState(false);
  // Lista wdrożeń.
  const [implementations, setImplementations] = useState([]);
  // Liczba wdrożeń, które mają zostać pobrane.
  const [implementationsCount, setImplementationsCount] = useState(10);

  // Flaga określająca, czy lista logów została pobrana z API.
  const [isLogsFetched, setIsLogsFetched] = useState(false);
  // Lista logów.
  const [logs, setLogs] = useState([]);
  // Liczba logów, które mają zostać zwrócone.
  const [logsCount, setLogsCount] = useState(10);

  useEffect(() => {
    fetchImplementations();
  }, [implementationsCount]);

  useEffect(() => {
    fetchLogs();
  }, [logsCount]);

  const fetchImplementations = async () => {
    await fetch(`${window['env'].API_URL}/implementations?count=${implementationsCount}`)
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

  const fetchMoreImplementations = () => {
    if (implementationsCount <= implementations.length) {
      setImplementationsCount(implementationsCount + 10);
    }
  };

  const fetchMoreLogs = () => {
    if (logsCount <= logs.length) {
      setLogsCount(logsCount + 10);
    }
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
          />
          <Box
            py={1.5}
            textAlign="center"
          >
            <Link onClick={fetchMoreImplementations}>
              Pobierz więcej
            </Link>
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
