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

import DialogWindow from '../../windows/DialogWindow';

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

  const addAdministrator = () => {
    history.push('/administrators/create');
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
    .then(() => {
      setIsDeleteAdministratorDialogWindowOpen(false);
      setDeleteAdministratorDialogWindowData(null);

      fetchAdministrators();
    });
  };

  const deleteAdministratorCanceled = () => {
    setIsDeleteAdministratorDialogWindowOpen(false);
    setDeleteAdministratorDialogWindowData(null);
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
      <DialogWindow
        isOpen={isDeleteAdministratorDialogWindowOpen}
        title="Usunięcie administratora"
        onConfirm={deleteAdministratorConfirmed}
        onCancel={deleteAdministratorCanceled}
      >
        Czy na pewno chcesz usunąć administratora <strong>{deleteAdministratorDialogWindowData?.fullName}</strong>?
      </DialogWindow>
    </>
  );
}

export default Administrators;
