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

const Managers: React.VFC = () => {
  const history = useHistory();
  const styles = useStyles();

  // Flaga określająca, czy lista menedżerów została pobrana z API.
  const [isManagersFetched, setIsManagersFetched] = useState(false);
  // Lista menedżerów.
  const [managers, setManagers] = useState([]);

  useEffect(() => {
    fetchManagers();
  }, []);

  const fetchManagers = async () => {
    await fetch(`${window['env'].API_URL}/users/managers`)
      .then((response) => response.json())
      .then((data) => {
        setIsManagersFetched(true);
        setManagers(data);
      });
  };

  const addManager = () => {
    history.push('/managers/create');
  };

  const editManager = () => {
    // TODO
  };

  const deleteManager = async (id) => {
    await fetch(
      `${window['env'].API_URL}/users/${id}`,
      {
        method: 'DELETE',
      },
    )
    .then(() => {
      fetchManagers();
    });
  };

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Menedżerowie
      </Box>
      <Box
        mb={3}
      >
        <Paper>
          <List
            isDataFetched={isManagersFetched}
            data={managers}
            onEdit={editManager}
            onDelete={deleteManager}
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
              onClick={addManager}
            >
              Dodaj
            </Button>
          </Box>
        </Paper>
      </Box>
    </>
  );
}

export default Managers;
