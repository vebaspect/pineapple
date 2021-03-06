import React, { useCallback, useEffect, useState } from 'react';
import { Link as RouterLink, useHistory, useParams } from 'react-router-dom';

import {
  createStyles,
  makeStyles,
} from '@material-ui/core/styles';

import Box from '@material-ui/core/Box';
import Button from '@material-ui/core/Button';
import CircularProgress from '@material-ui/core/CircularProgress';
import Link from '@material-ui/core/Link';
import Paper from '@material-ui/core/Paper';

import AddIcon from '@material-ui/icons/Add';
import SentimentVeryDissatisfiedIcon from '@material-ui/icons/SentimentVeryDissatisfied';

import DialogWindow from '../../windows/DialogWindow';
import ErrorWindow from '../../windows/ErrorWindow';
import Logs from '../../logs';

import Details from './Details';
import List from './List';

const useStyles = makeStyles(() =>
  createStyles({
    create: {
      backgroundColor: '#4caf50',
      color: '#fff',
    },
    productFetchingFailureIcon: {
      color: '#f50057',
      fontSize: 12,
    },
  }),
);

const Product: React.VFC = () => {
  const history = useHistory();
  const styles = useStyles();

  // Identyfikator produktu.
  const { productId } = useParams();

  // Flaga określająca, czy produkt został pobrany z API.
  const [isProductFetched, setIsProductFetched] = useState(false);
  // Flaga określająca, czy pobieranie produktu z API zakończyło się błędem.
  const [isProductFetchingFailure, setIsProductFetchingFailure] = useState(false);
  // Produkt.
  const [product, setProduct] = useState(null);

  // Flaga określająca, czy lista komponentów została pobrana z API.
  const [isComponentsFetched, setIsComponentsFetched] = useState(false);
  // Flaga określająca, czy pobieranie listy komponentów z API zakończyło się błędem.
  const [isComponentsFetchingFailure, setIsComponentsFetchingFailure] = useState(false);
  // Lista komponentów.
  const [components, setComponents] = useState([]);

  // Flaga określająca, czy okno dialogowe potwierdzające chęć usunięcia komponentu jest otwarte.
  const [isDeleteComponentDialogWindowOpen, setIsDeleteComponentDialogWindowOpen] = useState(false);
  // Dane wykorzystywane przez okno dialogowe potwierdzające chęć usunięcia komponentu.
  const [deleteComponentDialogWindowData, setDeleteComponentDialogWindowData] = useState(null);

  // Flaga określająca, czy okno wyświetlające informacje nt. błędu, który wystąpił podczas próby usunięcia komponentu jest otwarte.
  const [isDeleteComponentErrorWindowOpen, setIsDeleteComponentErrorWindowOpen] = useState(false);

  // Flaga określająca, czy lista logów została pobrana z API.
  const [isLogsFetched, setIsLogsFetched] = useState(false);
  // Lista logów.
  const [logs, setLogs] = useState([]);
  // Liczba logów, które mają zostać zwrócone.
  const [logsCount, setLogsCount] = useState(10);

  const fetchLogs = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/logs/products/${productId}?count=${logsCount}`)
      .then((response) => response.json())
      .then((data) => {
        setIsLogsFetched(true);
        setLogs(data);
      });
  }, [productId, logsCount]);

  useEffect(() => {
    fetchLogs();
  }, [productId, logsCount, fetchLogs]);

  const fetchMoreLogs = () => {
    if (logsCount <= logs.length) {
      setLogsCount(logsCount + 10);
    }
  };

  const fetchProduct = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/products/${productId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsProductFetched(true);
        setProduct(data);
      })
      .catch(() => {
        setIsProductFetched(true);
        setIsProductFetchingFailure(true);
      });
  }, [productId]);

  useEffect(() => {
    fetchProduct();
  }, [fetchProduct]);

  const fetchComponents = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/products/${productId}/components`)
      .then((response) => response.json())
      .then((data) => {
        setIsComponentsFetched(true);
        setComponents(data);
      })
      .catch(() => {
        setIsComponentsFetched(true);
        setIsComponentsFetchingFailure(true);
      });
  }, [productId]);

  useEffect(() => {
    fetchComponents();
  }, [fetchComponents]);

  const createComponent = () => {
    history.push(`/products/${productId}/components/create`);
  };

  const editComponent = () => {
    // TODO
  };

  const deleteComponent = (id: string, name: string) => {
    setDeleteComponentDialogWindowData({
      id,
      name,
    });
    setIsDeleteComponentDialogWindowOpen(true);
  };

  const deleteComponentConfirmed = async () => {
    await fetch(
      `${window['env'].API_URL}/products/${productId}/components/${deleteComponentDialogWindowData?.id}`,
      {
        method: 'DELETE',
      },
    )
    .then((response) => {
      setIsDeleteComponentDialogWindowOpen(false);
      setDeleteComponentDialogWindowData(null);

      if (response.ok) {
        fetchComponents();
        fetchLogs();
      } else {
        setIsDeleteComponentErrorWindowOpen(true);
      }
    });
  };

  const deleteComponentCanceled = () => {
    setIsDeleteComponentDialogWindowOpen(false);
    setDeleteComponentDialogWindowData(null);
  };

  const deleteComponentFailed = () => {
    setIsDeleteComponentErrorWindowOpen(false);
  }

  return (
    <>
      <Box
        fontSize="0.9rem"
        m={2}
      >
        <Link
          component={RouterLink}
          to="/products"
        >
          Produkty
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        {
          isProductFetched
            ? (
              <Box component="span">
                {
                  isProductFetchingFailure
                    ? <SentimentVeryDissatisfiedIcon className={styles.productFetchingFailureIcon} />
                    : product?.name
                }
              </Box>
            )
            : (
              <Box component="span">
                <CircularProgress size={10} />
              </Box>
            )
        }
      </Box>
      <Box
        mb={3}
      >
        {
          isProductFetchingFailure
            ? (
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
                  Pobieranie informacji nt. produktu zakończyło się błędem.
                </Box>
              </Paper>
            )
            : (
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
                  Szczegóły
                </Box>
                <Details
                  isDataFetched={isProductFetched}
                  name={product?.name}
                  description={product?.description}
                />
              </Paper>
            )
        }
      </Box>
      <Box
        mb={3}
      >
        {
          isComponentsFetchingFailure
            ? (
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
                  Pobieranie informacji nt. komponentów zakończyło się błędem.
                </Box>
              </Paper>
            )
            : (
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
                  Komponenty
                </Box>
                <List
                  isDataFetched={isComponentsFetched}
                  data={components}
                  productId={productId}
                  onEdit={editComponent}
                  onDelete={deleteComponent}
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
                    onClick={createComponent}
                  >
                    Dodaj
                  </Button>
                </Box>
              </Paper>
            )
        }
      </Box>
      <Box
        mb={3}
      >
        {
          isProductFetchingFailure
            ? (
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
                  Pobieranie informacji nt. logów zakończyło się błędem.
                </Box>
              </Paper>
            )
            : (
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
            )
        }
      </Box>
      <DialogWindow
        isOpen={isDeleteComponentDialogWindowOpen}
        title="Usunięcie komponentu"
        onConfirm={deleteComponentConfirmed}
        onCancel={deleteComponentCanceled}
      >
        Czy na pewno chcesz usunąć komponent <strong>{deleteComponentDialogWindowData?.name}</strong>?
      </DialogWindow>
      <ErrorWindow
        isOpen={isDeleteComponentErrorWindowOpen}
        onClose={deleteComponentFailed}
      >
        Próba usunięcia komponentu zakończyła się błędem.
      </ErrorWindow>
    </>
  );
}

export default Product;
