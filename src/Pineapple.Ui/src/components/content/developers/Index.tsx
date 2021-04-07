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

const Developers: React.VFC = () => {
  // Flaga określająca, czy lista programistów została pobrana z API.
  const [isDevelopersFetched, setIsDevelopersFetched] = useState(false);
  // Lista programistów.
  const [developers, setDevelopers] = useState([]);

  const history = useHistory();
  const styles = useStyles();

  useEffect(() => {
    fetchDevelopers();
  }, []);

  const fetchDevelopers = async () => {
    await fetch(`${window['env'].API_URL}/users/developers`)
      .then((response) => response.json())
      .then((data) => {
        setIsDevelopersFetched(true);
        setDevelopers(data);
      });
  };

  const addDeveloper = () => {
    history.push('/developers/create');
  };

  const editDeveloper = () => {
    // TODO
  };

  const deleteDeveloper = async (id) => {
    await fetch(
      `${window['env'].API_URL}/users/${id}`,
      {
        method: 'DELETE',
      },
    )
    .then(() => {
      fetchDevelopers();
    });
  };

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Programiści
      </Box>
      <Box
        mb={3}
      >
        <Paper>
          <List
            isDataFetched={isDevelopersFetched}
            data={developers}
            onEdit={editDeveloper}
            onDelete={deleteDeveloper}
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
              onClick={addDeveloper}
            >
              Dodaj
            </Button>
          </Box>
        </Paper>
      </Box>
    </>
  );
}

export default Developers;
