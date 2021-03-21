import React, { useEffect, useState } from 'react';

import Box from '@material-ui/core/Box';
import Link from '@material-ui/core/Link';
import Paper from '@material-ui/core/Paper';

import Logs from '../../logs';

import List from './List';

const Products = () => {
  // Flaga określająca, czy lista produktów została pobrana z API.
  const [isProductsFetched, setIsProductsFetched] = useState(false);
  // Lista produktów.
  const [products, setProducts] = useState([]);
  // Liczba produktów, które mają zostać pobrane.
  const [productsCount, setProductsCount] = useState(10);

  // Flaga określająca, czy lista logów została pobrana z API.
  const [isLogsFetched, setIsLogsFetched] = useState(false);
  // Lista logów.
  const [logs, setLogs] = useState([]);
  // Liczba logów, które mają zostać zwrócone.
  const [logsCount, setLogsCount] = useState(10);

  useEffect(() => {
    fetchProducts();
  }, [productsCount]);

  useEffect(() => {
    fetchLogs();
  }, [logsCount]);

  const fetchProducts = async () => {
    await fetch(`${window['env'].API_URL}/products?count=${productsCount}`)
      .then(response => response.json())
      .then(data => {
        setIsProductsFetched(true);
        setProducts(data);
      });
  };

  const fetchLogs = async () => {
    await fetch(`${window['env'].API_URL}/logs/products?count=${logsCount}`)
      .then(response => response.json())
      .then(data => {
        setIsLogsFetched(true);
        setLogs(data);
      });
  };

  const fetchMoreProducts = () => {
    if (productsCount <= products.length) {
      setProductsCount(productsCount + 10);
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
        Produkty
      </Box>
      <Box
        mb={3}
      >
        <Paper>
          <List
            isDataFetched={isProductsFetched}
            data={products}
          />
          <Box
            py={1.5}
            textAlign="center"
          >
            <Link onClick={fetchMoreProducts}>
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

export default Products;
