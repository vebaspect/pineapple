import React, { useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom';

import {
  createStyles,
  makeStyles,
} from '@material-ui/core/styles';

import Box from '@material-ui/core/Box';
import Button from '@material-ui/core/Button';
import Paper from '@material-ui/core/Paper';

import AddIcon from '@material-ui/icons/Add';

import List from './List';

const useStyles = makeStyles(() =>
  createStyles({
    add: {
      backgroundColor: '#4caf50',
      color: '#fff',
    },
  }),
);

const ComponentTypes: React.VFC = () => {
  // Flaga określająca, czy lista typów komponentów została pobrana z API.
  const [isComponentTypesFetched, setIsComponentTypesFetched] = useState(false);
  // Lista typów komponentów.
  const [componentTypes, setComponentTypes] = useState([]);

  const history = useHistory();
  const styles = useStyles();

  useEffect(() => {
    fetchComponentTypes();
  }, []);

  const fetchComponentTypes = async () => {
    await fetch(`${window['env'].API_URL}/configuration/component-types`)
      .then(response => response.json())
      .then(data => {
        setIsComponentTypesFetched(true);
        setComponentTypes(data);
      });
  };

  const addComponentType = () => {
    history.push('/component-types/create');
  };

  const editComponentType = () => {
    // TODO
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
            onEdit={editComponentType}
            onDelete={deleteComponentType}
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
              onClick={addComponentType}
            >
              Dodaj
            </Button>
          </Box>
        </Paper>
      </Box>
    </>
  );
}

export default ComponentTypes;
