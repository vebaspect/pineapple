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

const OperatingSystems: React.VFC = () => {
  const history = useHistory();
  const styles = useStyles();

  // Flaga określająca, czy lista systemów operacyjnych została pobrana z API.
  const [isOperatingSystemsFetched, setIsOperatingSystemsFetched] = useState(false);
  // Lista systemów operacyjnych.
  const [operatingSystems, setOperatingSystems] = useState([]);

  const fetchOperatingSystems = async () => {
    await fetch(`${window['env'].API_URL}/configuration/operating-systems`)
      .then((response) => response.json())
      .then((data) => {
        setIsOperatingSystemsFetched(true);
        setOperatingSystems(data);
      });
  };

  useEffect(() => {
    fetchOperatingSystems();
  }, []);

  const addOperatingSystem = () => {
    history.push('/operating-systems/create');
  };

  const editOperatingSystem = () => {
    // TODO
  };

  const deleteOperatingSystem = async (id) => {
    await fetch(
      `${window['env'].API_URL}/configuration/operating-systems/${id}`,
      {
        method: 'DELETE',
      },
    )
    .then(() => {
      fetchOperatingSystems();
    });
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
            onEdit={editOperatingSystem}
            onDelete={deleteOperatingSystem}
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
              onClick={addOperatingSystem}
            >
              Dodaj
            </Button>
          </Box>
        </Paper>
      </Box>
    </>
  );
}

export default OperatingSystems;
