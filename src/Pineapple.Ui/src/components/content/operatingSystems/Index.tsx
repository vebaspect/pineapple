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

const OperatingSystems: React.VFC = () => {
  const history = useHistory();
  const styles = useStyles();

  // Flaga określająca, czy lista systemów operacyjnych została pobrana z API.
  const [isOperatingSystemsFetched, setIsOperatingSystemsFetched] = useState(false);
  // Lista systemów operacyjnych.
  const [operatingSystems, setOperatingSystems] = useState([]);

  // Flaga określająca, czy okno dialogowe potwierdzające chęć usunięcia systemu operacyjnego jest otwarte.
  const [isDeleteOperatingSystemDialogWindowOpen, setIsDeleteOperatingSystemDialogWindowOpen] = useState(false);
  // Dane wykorzystywane przez okno dialogowe potwierdzające chęć usunięcia systemu operacyjnego.
  const [deleteOperatingSystemDialogWindowData, setDeleteOperatingSystemDialogWindowData] = useState(null);

  // Flaga określająca, czy okno wyświetlające informacje nt. błędu, który wystąpił podczas próby usunięcia systemu operacyjnego jest otwarte.
  const [isDeleteOperatingSystemErrorWindowOpen, setIsDeleteOperatingSystemErrorWindowOpen] = useState(false);

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

  const createOperatingSystem = () => {
    history.push('/configuration/operating-systems/create');
  };

  const editOperatingSystem = () => {
    // TODO
  };

  const deleteOperatingSystem = (id: string, fullName: string) => {
    setDeleteOperatingSystemDialogWindowData({
      id,
      fullName,
    });
    setIsDeleteOperatingSystemDialogWindowOpen(true);
  };

  const deleteOperatingSystemConfirmed = async () => {
    await fetch(
      `${window['env'].API_URL}/configuration/operating-systems/${deleteOperatingSystemDialogWindowData?.id}`,
      {
        method: 'DELETE',
      },
    )
    .then((response) => {
      setIsDeleteOperatingSystemDialogWindowOpen(false);
      setDeleteOperatingSystemDialogWindowData(null);

      if (response.ok) {
        fetchOperatingSystems();
      } else {
        setIsDeleteOperatingSystemErrorWindowOpen(true);
      }
    });
  };

  const deleteOperatingSystemCanceled = () => {
    setIsDeleteOperatingSystemDialogWindowOpen(false);
    setDeleteOperatingSystemDialogWindowData(null);
  };

  const deleteOperatingSystemFailed = () => {
    setIsDeleteOperatingSystemErrorWindowOpen(false);
  }

  return (
    <>
      <Box
        fontSize="0.9rem"
        m={2}
      >
        <Link
          component={RouterLink}
          to="/configuration"
        >
          Konfiguracja
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
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
              onClick={createOperatingSystem}
            >
              Dodaj
            </Button>
          </Box>
        </Paper>
      </Box>
      <DialogWindow
        isOpen={isDeleteOperatingSystemDialogWindowOpen}
        title="Usunięcie systemu operacyjnego"
        onConfirm={deleteOperatingSystemConfirmed}
        onCancel={deleteOperatingSystemCanceled}
      >
        Czy na pewno chcesz usunąć system operacyjny <strong>{deleteOperatingSystemDialogWindowData?.fullName}</strong>?
      </DialogWindow>
      <ErrorWindow
        isOpen={isDeleteOperatingSystemErrorWindowOpen}
        onClose={deleteOperatingSystemFailed}
      >
        Próba usunięcia systemu operacyjnego zakończyła się błędem.
      </ErrorWindow>
    </>
  );
}

export default OperatingSystems;
