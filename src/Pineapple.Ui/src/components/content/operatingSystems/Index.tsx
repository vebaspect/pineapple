import React, { useEffect, useState } from 'react';

import Box from '@material-ui/core/Box';
import Link from '@material-ui/core/Link';
import Paper from '@material-ui/core/Paper';

import List from './List';

const OperatingSystems = () => {
  // Flaga określająca, czy lista systemów operacyjnych została pobrana z API.
  const [isOperatingSystemsFetched, setIsOperatingSystemsFetched] = useState(false);
  // Lista systemów operacyjnych.
  const [operatingSystems, setOperatingSystems] = useState([]);
  // Liczba systemów operacyjnych, które mają zostać pobrane.
  const [operatingSystemsCount, setOperatingSystemsCount] = useState(10);

  useEffect(() => {
    fetchOperatingSystems();
  }, [operatingSystemsCount]);

  const fetchOperatingSystems = async () => {
    await fetch(`${window['env'].API_URL}/configuration/operating-systems?count=${operatingSystemsCount}`)
      .then(response => response.json())
      .then(data => {
        setIsOperatingSystemsFetched(true);
        setOperatingSystems(data);
      });
  };

  const fetchMoreOperatingSystems = () => {
    if (operatingSystemsCount <= operatingSystems.length) {
      setOperatingSystemsCount(operatingSystemsCount + 10);
    }
  };

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Systemy operacyjne
      </Box>
      <Box
        mb={3}
      >
        <Paper>
          <List
            isDataFetched={isOperatingSystemsFetched}
            data={operatingSystems}
          />
          <Box
            py={1.5}
            textAlign="center"
          >
            <Link onClick={fetchMoreOperatingSystems}>
              Pobierz więcej
            </Link>
          </Box>
        </Paper>
      </Box>
    </>
  );
}

export default OperatingSystems;
