import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import Box from '@material-ui/core/Box';

import Logs from './logs';

const Product = () => {
  const { productId } = useParams();

  // Flaga określająca, czy lista logów została pobrana z API.
  const [isLogsFetched, setIsLogsFetched] = useState(false);
  // Lista logów.
  const [logs, setLogs] = useState([]);

  useEffect(() => {
    fetchLogs();
  }, [productId]);

  const fetchLogs = async () => {
    await fetch(`${window['env'].API_URL}/logs/products/${productId}`)
      .then(response => response.json())
      .then(data => {
        setIsLogsFetched(true);
        setLogs(data);
      });
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
      </Box>
    </>
  );
}

export default Product;
