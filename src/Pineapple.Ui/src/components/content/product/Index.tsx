import React, { useCallback, useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

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
import List from './List';

const useStyles = makeStyles(() =>
  createStyles({
    add: {
      backgroundColor: '#4caf50',
      color: '#fff',
    },
  }),
);

const Product: React.VFC = () => {
  const { productId } = useParams();

  // Flaga określająca, czy lista komponentów została pobrana z API.
  const [isComponentsFetched, setIsComponentsFetched] = useState(false);
  // Lista komponentów.
  const [components, setComponents] = useState([]);

  // Flaga określająca, czy lista logów została pobrana z API.
  const [isLogsFetched, setIsLogsFetched] = useState(false);
  // Lista logów.
  const [logs, setLogs] = useState([]);
  // Liczba logów, które mają zostać zwrócone.
  const [count, setCount] = useState(10);

  const styles = useStyles();

  const fetchLogs = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/logs/products/${productId}?count=${count}`)
      .then(response => response.json())
      .then(data => {
        setIsLogsFetched(true);
        setLogs(data);
      });
  }, [productId, count]);

  useEffect(() => {
    fetchLogs();
  }, [productId, count, fetchLogs]);

  const fetchComponents = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/products/${productId}/components`)
      .then(response => response.json())
      .then(data => {
        setIsComponentsFetched(true);
        setComponents(data);
      });
  }, [productId]);

  useEffect(() => {
    fetchComponents();
  }, [fetchComponents]);

  const fetchMoreLogs = () => {
    if (count <= logs.length) {
      setCount(count + 10);
    }
  };

  const addComponent = () => {
    // TODO
  };

  const editComponent = () => {
    // TODO
  };

  const deleteComponent = () => {
    // TODO
  };

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Produkt
      </Box>
      <Box
        mb={3}
      >
        <Paper>
          <List
            isDataFetched={isComponentsFetched}
            data={components}
            onEdit={editComponent}
            onDelete={deleteComponent}
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
              onClick={addComponent}
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

export default Product;
