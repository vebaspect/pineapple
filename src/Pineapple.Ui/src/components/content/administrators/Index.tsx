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

const Administrators: React.VFC = () => {
  const history = useHistory();
  const styles = useStyles();

  // Flaga określająca, czy lista administratorów została pobrana z API.
  const [isAdministratorsFetched, setIsAdministratorsFetched] = useState(false);
  // Lista administratorów.
  const [administrators, setAdministrators] = useState([]);

  // Flaga określająca, czy okno dialogowe potwierdzające chęć usunięcia administratora jest otwarte.
  const [isDeleteAdministratorDialogWindowOpen, setIsDeleteAdministratorDialogWindowOpen] = useState(false);
  // Dane wykorzystywane przez okno dialogowe potwierdzające chęć usunięcia administratora.
  const [deleteAdministratorDialogWindowData, setDeleteAdministratorDialogWindowData] = useState(null);

  // Flaga określająca, czy okno wyświetlające informacje nt. błędu, który wystąpił podczas próby usunięcia administratora jest otwarte.
  const [isDeleteAdministratorErrorWindowOpen, setIsDeleteAdministratorErrorWindowOpen] = useState(false);

  const fetchAdministrators = async () => {
    await fetch(`${window['env'].API_URL}/users/administrators`)
      .then((response) => response.json())
      .then((data) => {
        setIsAdministratorsFetched(true);
        setAdministrators(data);
      });
  };

  useEffect(() => {
    fetchAdministrators();
  }, []);

  const createAdministrator = () => {
    history.push('/users/administrators/create');
  };

  const editAdministrator = () => {
    // TODO
  };

  const deleteAdministrator = (id: string, fullName: string) => {
    setDeleteAdministratorDialogWindowData({
      id,
      fullName,
    });
    setIsDeleteAdministratorDialogWindowOpen(true);
  };

  const deleteAdministratorConfirmed = async () => {
    await fetch(
      `${window['env'].API_URL}/users/${deleteAdministratorDialogWindowData?.id}`,
      {
        method: 'DELETE',
      },
    )
    .then((response) => {
      setIsDeleteAdministratorDialogWindowOpen(false);
      setDeleteAdministratorDialogWindowData(null);

      if (response.ok) {
        fetchAdministrators();
      } else {
        setIsDeleteAdministratorErrorWindowOpen(true);
      }
    });
  };

  const deleteAdministratorCanceled = () => {
    setIsDeleteAdministratorDialogWindowOpen(false);
    setDeleteAdministratorDialogWindowData(null);
  };

  const deleteAdministratorFailed = () => {
    setIsDeleteAdministratorErrorWindowOpen(false);
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
              onClick={createAdministrator}
            >
              Dodaj
            </Button>
          </Box>
        </Paper>
      </Box>
      <DialogWindow
        isOpen={isDeleteAdministratorDialogWindowOpen}
        title="Usunięcie administratora"
        onConfirm={deleteAdministratorConfirmed}
        onCancel={deleteAdministratorCanceled}
      >
        Czy na pewno chcesz usunąć administratora <strong>{deleteAdministratorDialogWindowData?.fullName}</strong>?
      </DialogWindow>
      <ErrorWindow
        isOpen={isDeleteAdministratorErrorWindowOpen}
        onClose={deleteAdministratorFailed}
      >
        Próba usunięcia administratora zakończyła się błędem.
      </ErrorWindow>
    </>
  );
}

export default Administrators;
