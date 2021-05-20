import React, { useCallback, useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom';

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
import Logs from '../../logs';

import List from './List';

const useStyles = makeStyles(() =>
  createStyles({
    create: {
      backgroundColor: '#4caf50',
      color: '#fff',
    },
  }),
);

const Products: React.VFC = () => {
  const history = useHistory();
  const styles = useStyles();

  // Flaga określająca, czy lista produktów została pobrana z API.
  const [isProductsFetched, setIsProductsFetched] = useState(false);
  // Lista produktów.
  const [products, setProducts] = useState([]);

  // Flaga określająca, czy okno dialogowe potwierdzające chęć usunięcia produktu jest otwarte.
  const [isDeleteProductDialogWindowOpen, setIsDeleteProductDialogWindowOpen] = useState(false);
  // Dane wykorzystywane przez okno dialogowe potwierdzające chęć usunięcia produktu.
  const [deleteProductDialogWindowData, setDeleteProductDialogWindowData] = useState(null);

  // Flaga określająca, czy okno wyświetlające informacje nt. błędu, który wystąpił podczas próby usunięcia produktu jest otwarte.
  const [isDeleteProductErrorWindowOpen, setIsDeleteProductErrorWindowOpen] = useState(false);

  // Flaga określająca, czy lista logów została pobrana z API.
  const [isLogsFetched, setIsLogsFetched] = useState(false);
  // Lista logów.
  const [logs, setLogs] = useState([]);
  // Liczba logów, które mają zostać zwrócone.
  const [logsCount, setLogsCount] = useState(10);

  const fetchLogs = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/logs/products?count=${logsCount}`)
      .then((response) => response.json())
      .then((data) => {
        setIsLogsFetched(true);
        setLogs(data);
      });
  }, [logsCount]);

  useEffect(() => {
    fetchLogs();
  }, [logsCount, fetchLogs]);

  const fetchMoreLogs = () => {
    if (logsCount <= logs.length) {
      setLogsCount(logsCount + 10);
    }
  };

  const fetchProducts = async () => {
    await fetch(`${window['env'].API_URL}/products`)
      .then((response) => response.json())
      .then((data) => {
        setIsProductsFetched(true);
        setProducts(data);
      });
  };

  useEffect(() => {
    fetchProducts();
  }, []);

  const createProduct = () => {
    history.push('/products/create');
  };

  const editProduct = () => {
    // TODO
  };

  const deleteProduct = (id: string, name: string) => {
    setDeleteProductDialogWindowData({
      id,
      name,
    });
    setIsDeleteProductDialogWindowOpen(true);
  };

  const deleteProductConfirmed = async () => {
    await fetch(
      `${window['env'].API_URL}/products/${deleteProductDialogWindowData?.id}`,
      {
        method: 'DELETE',
      },
    )
    .then((response) => {
      setIsDeleteProductDialogWindowOpen(false);
      setDeleteProductDialogWindowData(null);

      if (response.ok) {
        fetchProducts();
        fetchLogs();
      } else {
        setIsDeleteProductErrorWindowOpen(true);
      }
    });
  };

  const deleteProductCanceled = () => {
    setIsDeleteProductDialogWindowOpen(false);
    setDeleteProductDialogWindowData(null);
  };

  const deleteProductFailed = () => {
    setIsDeleteProductErrorWindowOpen(false);
  }

  return (
    <>
      <Box
        fontSize="0.9rem"
        m={2}
      >
        Produkty
      </Box>
      <Box
        mb={3}
      >
        <Paper>
          <List
            isDataFetched={isProductsFetched}
            data={products}
            onEdit={editProduct}
            onDelete={deleteProduct}
          />
          <Box
            p={1.5}
            textAlign="right"
          >
            <Button
              className={styles.create}
              size="small"
              startIcon={<AddIcon />}
              variant="contained"
              onClick={createProduct}
            >
              Dodaj
            </Button>
          </Box>
        </Paper>
      </Box>
      <Box
        mb={3}
      >
        <Paper>
          <Box
            border={1}
            borderLeft={0}
            borderRight={0}
            borderTop={0}
            borderColor="#e0e0e0"
            py={1.5}
            textAlign="center"
          >
            Ostatnie aktywności
          </Box>
          <Box
            mx={2}
          >
            <Logs
              isDataFetched={isLogsFetched}
              data={logs}
            />
          </Box>
          <Box
            border={1}
            borderBottom={0}
            borderLeft={0}
            borderRight={0}
            borderColor="#e0e0e0"
            py={1.5}
            textAlign="center"
          >
            <Link onClick={fetchMoreLogs}>
              Pobierz więcej
            </Link>
          </Box>
        </Paper>
      </Box>
      <DialogWindow
        isOpen={isDeleteProductDialogWindowOpen}
        title="Usunięcie produktu"
        onConfirm={deleteProductConfirmed}
        onCancel={deleteProductCanceled}
      >
        Czy na pewno chcesz usunąć produkt <strong>{deleteProductDialogWindowData?.name}</strong>?
      </DialogWindow>
      <ErrorWindow
        isOpen={isDeleteProductErrorWindowOpen}
        onClose={deleteProductFailed}
      >
        Próba usunięcia produktu zakończyła się błędem.
      </ErrorWindow>
    </>
  );
}

export default Products;
