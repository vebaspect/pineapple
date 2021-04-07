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

const Administrators: React.VFC = () => {
  // Flaga określająca, czy lista administratorów została pobrana z API.
  const [isAdministratorsFetched, setIsAdministratorsFetched] = useState(false);
  // Lista administratorów.
  const [administrators, setAdministrators] = useState([]);

  const history = useHistory();
  const styles = useStyles();

  useEffect(() => {
    fetchAdministrators();
  }, []);

  const fetchAdministrators = async () => {
    await fetch(`${window['env'].API_URL}/users/administrators`)
      .then((response) => response.json())
      .then((data) => {
        setIsAdministratorsFetched(true);
        setAdministrators(data);
      });
  };

  const addAdministrator = () => {
    history.push('/administrators/create');
  };

  const editAdministrator = () => {
    // TODO
  };

  const deleteAdministrator = async (id) => {
    await fetch(
      `${window['env'].API_URL}/users/${id}`,
      {
        method: 'DELETE',
      },
    )
    .then(() => {
      fetchAdministrators();
    });
  };

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Administratorzy
      </Box>
      <Box
        mb={3}
      >
        <Paper>
          <List
            isDataFetched={isAdministratorsFetched}
            data={administrators}
            onEdit={editAdministrator}
            onDelete={deleteAdministrator}
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
              onClick={addAdministrator}
            >
              Dodaj
            </Button>
          </Box>
        </Paper>
      </Box>
    </>
  );
}

export default Administrators;
