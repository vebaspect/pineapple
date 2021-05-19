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

const SoftwareApplications: React.VFC = () => {
  const history = useHistory();
  const styles = useStyles();

  // Flaga określająca, czy lista oprogramowania została pobrana z API.
  const [isSoftwareApplicationsFetched, setIsSoftwareApplicationsFetched] = useState(false);
  // Lista oprogramowania.
  const [softwareApplications, setSoftwareApplications] = useState([]);

  // Flaga określająca, czy okno dialogowe potwierdzające chęć usunięcia oprogramowania jest otwarte.
  const [isDeleteSoftwareApplicationDialogWindowOpen, setIsDeleteSoftwareApplicationDialogWindowOpen] = useState(false);
  // Dane wykorzystywane przez okno dialogowe potwierdzające chęć usunięcia oprogramowania.
  const [deleteSoftwareApplicationDialogWindowData, setDeleteSoftwareApplicationDialogWindowData] = useState(null);

  // Flaga określająca, czy okno wyświetlające informacje nt. błędu, który wystąpił podczas próby usunięcia oprogramowania jest otwarte.
  const [isDeleteSoftwareApplicationErrorWindowOpen, setIsDeleteSoftwareApplicationErrorWindowOpen] = useState(false);

  const fetchSoftwareApplications = async () => {
    await fetch(`${window['env'].API_URL}/configuration/software-applications`)
      .then((response) => response.json())
      .then((data) => {
        setIsSoftwareApplicationsFetched(true);
        setSoftwareApplications(data);
      });
  };

  useEffect(() => {
    fetchSoftwareApplications();
  }, []);

  const createSoftwareApplication = () => {
    history.push('/configuration/software-applications/create');
  };

  const editSoftwareApplication = () => {
    // TODO
  };

  const deleteSoftwareApplication = (id: string, fullName: string) => {
    setDeleteSoftwareApplicationDialogWindowData({
      id,
      fullName,
    });
    setIsDeleteSoftwareApplicationDialogWindowOpen(true);
  };

  const deleteSoftwareApplicationConfirmed = async () => {
    await fetch(
      `${window['env'].API_URL}/configuration/software-applications/${deleteSoftwareApplicationDialogWindowData?.id}`,
      {
        method: 'DELETE',
      },
    )
    .then((response) => {
      setIsDeleteSoftwareApplicationDialogWindowOpen(false);
      setDeleteSoftwareApplicationDialogWindowData(null);

      if (response.ok) {
        fetchSoftwareApplications();
      } else {
        setIsDeleteSoftwareApplicationErrorWindowOpen(true);
      }
    });
  };

  const deleteSoftwareApplicationCanceled = () => {
    setIsDeleteSoftwareApplicationDialogWindowOpen(false);
    setDeleteSoftwareApplicationDialogWindowData(null);
  };

  const deleteSoftwareApplicationFailed = () => {
    setIsDeleteSoftwareApplicationErrorWindowOpen(false);
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
              onClick={createSoftwareApplication}
            >
              Dodaj
            </Button>
          </Box>
        </Paper>
      </Box>
      <DialogWindow
        isOpen={isDeleteSoftwareApplicationDialogWindowOpen}
        title="Usunięcie oprogramowania"
        onConfirm={deleteSoftwareApplicationConfirmed}
        onCancel={deleteSoftwareApplicationCanceled}
      >
        Czy na pewno chcesz usunąć oprogramowanie <strong>{deleteSoftwareApplicationDialogWindowData?.fullName}</strong>?
      </DialogWindow>
      <ErrorWindow
        isOpen={isDeleteSoftwareApplicationErrorWindowOpen}
        onClose={deleteSoftwareApplicationFailed}
      >
        Próba usunięcia oprogramowania zakończyła się błędem.
      </ErrorWindow>
    </>
  );
}

export default SoftwareApplications;
