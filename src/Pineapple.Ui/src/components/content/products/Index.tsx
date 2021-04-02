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

const Products: React.VFC = () => {
  // Flaga określająca, czy lista produktów została pobrana z API.
  const [isProductsFetched, setIsProductsFetched] = useState(false);
  // Lista produktów.
  const [products, setProducts] = useState([]);

  // Flaga określająca, czy lista logów została pobrana z API.
  const [isLogsFetched, setIsLogsFetched] = useState(false);
  // Lista logów.
  const [logs, setLogs] = useState([]);
  // Liczba logów, które mają zostać zwrócone.
  const [logsCount, setLogsCount] = useState(10);

  const history = useHistory();
  const styles = useStyles();

  const fetchLogs = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/logs/products?count=${logsCount}`)
      .then(response => response.json())
      .then(data => {
        setIsLogsFetched(true);
        setLogs(data);
      });
  }, [logsCount]);

  useEffect(() => {
    fetchLogs();
  }, [logsCount, fetchLogs]);

  const fetchProducts = async () => {
    await fetch(`${window['env'].API_URL}/products`)
      .then(response => response.json())
      .then(data => {
        setIsProductsFetched(true);
        setProducts(data);
      });
  };

  useEffect(() => {
    fetchProducts();
  }, []);

  const fetchMoreLogs = () => {
    if (logsCount <= logs.length) {
      setLogsCount(logsCount + 10);
    }
  };

  const addProduct = () => {
    history.push('/products/create');
  };

  const editProduct = () => {
    // TODO
  };

  const deleteProduct = async (id) => {
    await fetch(
      `${window['env'].API_URL}/products/${id}`,
      {
        method: 'DELETE',
      },
    )
    .then(() => {
      fetchProducts();
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
        Produkty
      </Box>
      <Box
        mb={3}
      >
        <Paper>
          <List
            isDataFetched={isProductsFetched}
            data={products}
            onEdit={editProduct}
            onDelete={deleteProduct}
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
              onClick={addProduct}
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

export default Products;
