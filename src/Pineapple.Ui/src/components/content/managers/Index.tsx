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

const Managers: React.VFC = () => {
  const history = useHistory();
  const styles = useStyles();

  // Flaga określająca, czy lista menedżerów została pobrana z API.
  const [isManagersFetched, setIsManagersFetched] = useState(false);
  // Lista menedżerów.
  const [managers, setManagers] = useState([]);

  // Flaga określająca, czy okno dialogowe potwierdzające chęć usunięcia menedżera jest otwarte.
  const [isDeleteManagerDialogWindowOpen, setIsDeleteManagerDialogWindowOpen] = useState(false);
  // Dane wykorzystywane przez okno dialogowe potwierdzające chęć usunięcia menedżera.
  const [deleteManagerDialogWindowData, setDeleteManagerDialogWindowData] = useState(null);  

  // Flaga określająca, czy okno wyświetlające informacje nt. błędu, który wystąpił podczas próby usunięcia menedżera jest otwarte.
  const [isDeleteManagerErrorWindowOpen, setIsDeleteManagerErrorWindowOpen] = useState(false);

  const fetchManagers = async () => {
    await fetch(`${window['env'].API_URL}/users/managers`)
      .then((response) => response.json())
      .then((data) => {
        setIsManagersFetched(true);
        setManagers(data);
      });
  };

  useEffect(() => {
    fetchManagers();
  }, []);

  const addManager = () => {
    history.push('/managers/create');
  };

  const editManager = () => {
    // TODO
  };

  const deleteManager = (id: string, fullName: string) => {
    setDeleteManagerDialogWindowData({
      id,
      fullName,
    });
    setIsDeleteManagerDialogWindowOpen(true);
  };

  const deleteManagerConfirmed = async () => {
    await fetch(
      `${window['env'].API_URL}/users/${deleteManagerDialogWindowData?.id}`,
      {
        method: 'DELETE',
      },
    )
    .then((response) => {
      setIsDeleteManagerDialogWindowOpen(false);
      setDeleteManagerDialogWindowData(null);

      if (response.ok) {
        fetchManagers();
      } else {
        setIsDeleteManagerErrorWindowOpen(true);
      }
    });
  };

  const deleteManagerCanceled = () => {
    setIsDeleteManagerDialogWindowOpen(false);
    setDeleteManagerDialogWindowData(null);
  };

  const deleteManagerFailed = () => {
    setIsDeleteManagerErrorWindowOpen(false);
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
      <DialogWindow
        isOpen={isDeleteManagerDialogWindowOpen}
        title="Usunięcie menedżera"
        onConfirm={deleteManagerConfirmed}
        onCancel={deleteManagerCanceled}
      >
        Czy na pewno chcesz usunąć menedżera <strong>{deleteManagerDialogWindowData?.fullName}</strong>?
      </DialogWindow>
      <ErrorWindow
        isOpen={isDeleteManagerErrorWindowOpen}
        onClose={deleteManagerFailed}
      >
        Próba usunięcia menedżera zakończyła się błędem.
      </ErrorWindow>
    </>
  );
}

export default Managers;
