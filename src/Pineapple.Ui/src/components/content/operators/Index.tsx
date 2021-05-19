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

const Operators: React.VFC = () => {
  const history = useHistory();
  const styles = useStyles();

  // Flaga określająca, czy lista wdrożeniowców została pobrana z API.
  const [isOperatorsFetched, setIsOperatorsFetched] = useState(false);
  // Lista wdrożeniowców.
  const [operators, setOperators] = useState([]);

  // Flaga określająca, czy okno dialogowe potwierdzające chęć usunięcia wdrożeniowca jest otwarte.
  const [isDeleteOperatorDialogWindowOpen, setIsDeleteOperatorDialogWindowOpen] = useState(false);
  // Dane wykorzystywane przez okno dialogowe potwierdzające chęć usunięcia wdrożeniowca.
  const [deleteOperatorDialogWindowData, setDeleteOperatorDialogWindowData] = useState(null);

  // Flaga określająca, czy okno wyświetlające informacje nt. błędu, który wystąpił podczas próby usunięcia wdrożeniowca jest otwarte.
  const [isDeleteOperatorErrorWindowOpen, setIsDeleteOperatorErrorWindowOpen] = useState(false);

  const fetchOperators = async () => {
    await fetch(`${window['env'].API_URL}/users/operators`)
      .then((response) => response.json())
      .then((data) => {
        setIsOperatorsFetched(true);
        setOperators(data);
      });
  };

  useEffect(() => {
    fetchOperators();
  }, []);

  const createOperator = () => {
    history.push('/users/operators/create');
  };

  const editOperator = () => {
    // TODO
  };

  const deleteOperator = (id: string, fullName: string) => {
    setDeleteOperatorDialogWindowData({
      id,
      fullName,
    });
    setIsDeleteOperatorDialogWindowOpen(true);
  };

  const deleteOperatorConfirmed = async () => {
    await fetch(
      `${window['env'].API_URL}/users/${deleteOperatorDialogWindowData?.id}`,
      {
        method: 'DELETE',
      },
    )
    .then((response) => {
      setIsDeleteOperatorDialogWindowOpen(false);
      setDeleteOperatorDialogWindowData(null);

      if (response.ok) {
        fetchOperators();
      } else {
        setIsDeleteOperatorErrorWindowOpen(true);
      }
    });
  };

  const deleteOperatorCanceled = () => {
    setIsDeleteOperatorDialogWindowOpen(false);
    setDeleteOperatorDialogWindowData(null);
  };

  const deleteOperatorFailed = () => {
    setIsDeleteOperatorErrorWindowOpen(false);
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
        Wdrożeniowcy
      </Box>
      <Box
        mb={3}
      >
        <Paper>
          <List
            isDataFetched={isOperatorsFetched}
            data={operators}
            onEdit={editOperator}
            onDelete={deleteOperator}
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
              onClick={createOperator}
            >
              Dodaj
            </Button>
          </Box>
        </Paper>
      </Box>
      <DialogWindow
        isOpen={isDeleteOperatorDialogWindowOpen}
        title="Usunięcie wdrożeniowca"
        onConfirm={deleteOperatorConfirmed}
        onCancel={deleteOperatorCanceled}
      >
        Czy na pewno chcesz usunąć wdrożeniowca <strong>{deleteOperatorDialogWindowData?.fullName}</strong>?
      </DialogWindow>
      <ErrorWindow
        isOpen={isDeleteOperatorErrorWindowOpen}
        onClose={deleteOperatorFailed}
      >
        Próba usunięcia wdrożeniowca zakończyła się błędem.
      </ErrorWindow>
    </>
  );
}

export default Operators;
