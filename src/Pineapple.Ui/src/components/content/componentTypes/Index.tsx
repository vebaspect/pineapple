import React, { useEffect, useState } from 'react';

import Box from '@material-ui/core/Box';
import Link from '@material-ui/core/Link';
import Paper from '@material-ui/core/Paper';

import List from './List';

const ComponentTypes = () => {
  // Flaga określająca, czy lista typów komponentów została pobrana z API.
  const [isComponentTypesFetched, setIsComponentTypesFetched] = useState(false);
  // Lista typów komponentów.
  const [componentTypes, setComponentTypes] = useState([]);
  // Liczba typów komponentów, które mają zostać zwrócone.
  const [componentTypesCount, setComponentTypesCount] = useState(10);

  useEffect(() => {
    fetchComponentTypes();
  }, [componentTypesCount]);

  const fetchComponentTypes = async () => {
    await fetch(`${window['env'].API_URL}/configuration/component-types?count=${componentTypesCount}`)
      .then(response => response.json())
      .then(data => {
        setIsComponentTypesFetched(true);
        setComponentTypes(data);
      });
  };

  const fetchMoreComponentTypes = () => {
    if (componentTypesCount <= componentTypes.length) {
      setComponentTypesCount(componentTypesCount + 10);
    }
  };

  const deleteComponentType = async (id) => {
    await fetch(
      `${window['env'].API_URL}/configuration/component-types/${id}`,
      {
        method: 'DELETE',
      },
    )
    .then(() => {
      fetchComponentTypes();
    });
  };

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Typy komponentów
      </Box>
      <Box
        mb={3}
      >
        <Paper>
          <List
            isDataFetched={isComponentTypesFetched}
            data={componentTypes}
            onDelete={deleteComponentType}
          />
          <Box
            py={1.5}
            textAlign="center"
          >
            <Link onClick={fetchMoreComponentTypes}>
              Pobierz więcej
            </Link>
          </Box>
        </Paper>
      </Box>
    </>
  );
}

export default ComponentTypes;
