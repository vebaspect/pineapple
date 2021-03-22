import React, { useEffect, useState } from 'react';

import Box from '@material-ui/core/Box';
import Link from '@material-ui/core/Link';
import Paper from '@material-ui/core/Paper';

import List from './List';

const Operators = () => {
  // Flaga określająca, czy lista wdrożeniowców została pobrana z API.
  const [isOperatorsFetched, setIsOperatorsFetched] = useState(false);
  // Lista wdrożeniowców.
  const [operators, setOperators] = useState([]);
  // Liczba wdrożeniowców, którzy mają zostać zwróceni.
  const [operatorsCount, setOperatorsCount] = useState(10);

  useEffect(() => {
    fetchOperators();
  }, [operatorsCount]);

  const fetchOperators = async () => {
    await fetch(`${window['env'].API_URL}/users/operators?count=${operatorsCount}`)
      .then(response => response.json())
      .then(data => {
        setIsOperatorsFetched(true);
        setOperators(data);
      });
  };

  const fetchMoreOperators = () => {
    if (operatorsCount <= operators.length) {
      setOperatorsCount(operatorsCount + 10);
    }
  };

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Wdrożeniowcy
      </Box>
      <Box
        mb={3}
      >
        <Paper>
          <List
            isDataFetched={isOperatorsFetched}
            data={operators}
          />
          <Box
            py={1.5}
            textAlign="center"
          >
            <Link onClick={fetchMoreOperators}>
              Pobierz więcej
            </Link>
          </Box>
        </Paper>
      </Box>
    </>
  );
}

export default Operators;
