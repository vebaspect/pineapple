import React, { useEffect, useState } from 'react';
import { Link as RouterLink, useHistory } from 'react-router-dom';

import {
  createStyles,
  makeStyles,
} from '@material-ui/core/styles';

import Box from '@material-ui/core/Box';
import Button from '@material-ui/core/Button';
import Link from '@material-ui/core/Link';
import Paper from '@material-ui/core/Paper';

import AddIcon from '@material-ui/icons/Add';

import DialogWindow from '../../windows/DialogWindow';
import ErrorWindow from '../../windows/ErrorWindow';

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
  const history = useHistory();
  const styles = useStyles();

  // Flaga określająca, czy lista programistów została pobrana z API.
  const [isDevelopersFetched, setIsDevelopersFetched] = useState(false);
  // Lista programistów.
  const [developers, setDevelopers] = useState([]);

  // Flaga określająca, czy okno dialogowe potwierdzające chęć usunięcia programisty jest otwarte.
  const [isDeleteDeveloperDialogWindowOpen, setIsDeleteDeveloperDialogWindowOpen] = useState(false);
  // Dane wykorzystywane przez okno dialogowe potwierdzające chęć usunięcia programisty.
  const [deleteDeveloperDialogWindowData, setDeleteDeveloperDialogWindowData] = useState(null);

  // Flaga określająca, czy okno wyświetlające informacje nt. błędu, który wystąpił podczas próby usunięcia programisty jest otwarte.
  const [isDeleteDeveloperErrorWindowOpen, setIsDeleteDeveloperErrorWindowOpen] = useState(false);

  const fetchDevelopers = async () => {
    await fetch(`${window['env'].API_URL}/users/developers`)
      .then((response) => response.json())
      .then((data) => {
        setIsDevelopersFetched(true);
        setDevelopers(data);
      });
  };

  useEffect(() => {
    fetchDevelopers();
  }, []);

  const addDeveloper = () => {
    history.push('/users/developers/create');
  };

  const editDeveloper = () => {
    // TODO
  };

  const deleteDeveloper = (id: string, fullName: string) => {
    setDeleteDeveloperDialogWindowData({
      id,
      fullName,
    });
    setIsDeleteDeveloperDialogWindowOpen(true);
  };

  const deleteDeveloperConfirmed = async () => {
    await fetch(
      `${window['env'].API_URL}/users/${deleteDeveloperDialogWindowData?.id}`,
      {
        method: 'DELETE',
      },
    )
    .then((response) => {
      setIsDeleteDeveloperDialogWindowOpen(false);
      setDeleteDeveloperDialogWindowData(null);

      if (response.ok) {
        fetchDevelopers();
      } else {
        setIsDeleteDeveloperErrorWindowOpen(true);
      }
    });
  };

  const deleteDeveloperCanceled = () => {
    setIsDeleteDeveloperDialogWindowOpen(false);
    setDeleteDeveloperDialogWindowData(null);
  };

  const deleteDeveloperFailed = () => {
    setIsDeleteDeveloperErrorWindowOpen(false);
  }

  return (
    <>
      <Box
        fontSize="0.9rem"
        m={2}
      >
        <Link
          component={RouterLink}
          to="/users"
        >
          Użytkownicy
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
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
      <DialogWindow
        isOpen={isDeleteDeveloperDialogWindowOpen}
        title="Usunięcie programisty"
        onConfirm={deleteDeveloperConfirmed}
        onCancel={deleteDeveloperCanceled}
      >
        Czy na pewno chcesz usunąć programistę <strong>{deleteDeveloperDialogWindowData?.fullName}</strong>?
      </DialogWindow>
      <ErrorWindow
        isOpen={isDeleteDeveloperErrorWindowOpen}
        onClose={deleteDeveloperFailed}
      >
        Próba usunięcia programisty zakończyła się błędem.
      </ErrorWindow>
    </>
  );
}

export default Developers;
