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

const ComponentTypes: React.VFC = () => {
  const history = useHistory();
  const styles = useStyles();

  // Flaga określająca, czy lista typów komponentów została pobrana z API.
  const [isComponentTypesFetched, setIsComponentTypesFetched] = useState(false);
  // Lista typów komponentów.
  const [componentTypes, setComponentTypes] = useState([]);

  // Flaga określająca, czy okno dialogowe potwierdzające chęć usunięcia typu komponentu jest otwarte.
  const [isDeleteComponentTypeDialogWindowOpen, setIsDeleteComponentTypeDialogWindowOpen] = useState(false);
  // Dane wykorzystywane przez okno dialogowe potwierdzające chęć usunięcia typu komponentu.
  const [deleteComponentTypeDialogWindowData, setDeleteComponentTypeDialogWindowData] = useState(null);
  
  const fetchComponentTypes = async () => {
    await fetch(`${window['env'].API_URL}/configuration/component-types`)
      .then((response) => response.json())
      .then((data) => {
        setIsComponentTypesFetched(true);
        setComponentTypes(data);
      });
  };

  useEffect(() => {
    fetchComponentTypes();
  }, []);

  const addComponentType = () => {
    history.push('/component-types/create');
  };

  const editComponentType = () => {
    // TODO
  };

  const deleteComponentType = (id: string, name: string) => {
    setDeleteComponentTypeDialogWindowData({
      id,
      name,
    });
    setIsDeleteComponentTypeDialogWindowOpen(true);
  };

  const deleteComponentTypeConfirmed = async () => {
    await fetch(
      `${window['env'].API_URL}/configuration/component-types/${deleteComponentTypeDialogWindowData?.id}`,
      {
        method: 'DELETE',
      },
    )
    .then(() => {
      setIsDeleteComponentTypeDialogWindowOpen(false);
      setDeleteComponentTypeDialogWindowData(null);

      fetchComponentTypes();
    });
  };

  const deleteComponentTypeCanceled = () => {
    setIsDeleteComponentTypeDialogWindowOpen(false);
    setDeleteComponentTypeDialogWindowData(null);
  };

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Typy komponentów
      </Box>
      <Box
        mb={3}
      >
        <Paper>
          <List
            isDataFetched={isComponentTypesFetched}
            data={componentTypes}
            onEdit={editComponentType}
            onDelete={deleteComponentType}
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
              onClick={addComponentType}
            >
              Dodaj
            </Button>
          </Box>
        </Paper>
      </Box>
      <DialogWindow
        isOpen={isDeleteComponentTypeDialogWindowOpen}
        title="Usunięcie typu komponentu"
        onConfirm={deleteComponentTypeConfirmed}
        onCancel={deleteComponentTypeCanceled}
      >
        Czy na pewno chcesz usunąć typ komponentu <strong>{deleteComponentTypeDialogWindowData?.name}</strong>?
      </DialogWindow>
    </>
  );
}

export default ComponentTypes;
