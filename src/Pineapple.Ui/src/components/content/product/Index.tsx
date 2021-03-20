import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Link from '@material-ui/core/Link';

import Logs from '../../logs';

const Product = () => {
  const { productId } = useParams();

  // Flaga określająca, czy lista logów została pobrana z API.
  const [isLogsFetched, setIsLogsFetched] = useState(false);
  // Lista logów.
  const [logs, setLogs] = useState([]);
  // Liczba logów, które mają zostać zwrócone.
  const [count, setCount] = useState(10);

  useEffect(() => {
    fetchLogs();
  }, [productId, count]);

  const fetchLogs = async () => {
    await fetch(`${window['env'].API_URL}/logs/products/${productId}?count=${count}`)
      .then(response => response.json())
      .then(data => {
        setIsLogsFetched(true);
        setLogs(data);
      });
  };

  const fetchMoreLogs = () => {
    if (count <= logs.length) {
      setCount(count + 10);
    }
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
      <Box>
        <Box>
          Ostatnie aktywności:
        </Box>
        <Logs
          isDataFetched={isLogsFetched}
          data={logs}
        />
        <Box
          m={2}
          textAlign="center"
        >
          <Link onClick={fetchMoreLogs}>
            Pobierz więcej
          </Link>
        </Box>
      </Box>
    </>
  );
}

export default Product;
