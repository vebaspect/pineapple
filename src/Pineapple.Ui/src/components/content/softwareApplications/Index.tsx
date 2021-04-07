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

const SoftwareApplications: React.VFC = () => {
  // Flaga określająca, czy lista oprogramowania została pobrana z API.
  const [isSoftwareApplicationsFetched, setIsSoftwareApplicationsFetched] = useState(false);
  // Lista oprogramowania.
  const [softwareApplications, setSoftwareApplications] = useState([]);

  const history = useHistory();
  const styles = useStyles();

  useEffect(() => {
    fetchSoftwareApplications();
  }, []);

  const fetchSoftwareApplications = async () => {
    await fetch(`${window['env'].API_URL}/configuration/software-applications`)
      .then((response) => response.json())
      .then((data) => {
        setIsSoftwareApplicationsFetched(true);
        setSoftwareApplications(data);
      });
  };

  const addSoftwareApplication = () => {
    history.push('/software-applications/create');
  };

  const editSoftwareApplication = () => {
    // TODO
  };

  const deleteSoftwareApplication = async (id) => {
    await fetch(
      `${window['env'].API_URL}/configuration/software-applications/${id}`,
      {
        method: 'DELETE',
      },
    )
    .then(() => {
      fetchSoftwareApplications();
    });
  };

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Oprogramowanie
      </Box>
      <Box
        mb={3}
      >
        <Paper>
          <List
            isDataFetched={isSoftwareApplicationsFetched}
            data={softwareApplications}
            onEdit={editSoftwareApplication}
            onDelete={deleteSoftwareApplication}
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
              onClick={addSoftwareApplication}
            >
              Dodaj
            </Button>
          </Box>
        </Paper>
      </Box>
    </>
  );
}

export default SoftwareApplications;
