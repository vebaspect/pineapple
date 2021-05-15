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
    add: {
      backgroundColor: '#4caf50',
      color: '#fff',
    },
    productFetchingFailureIcon: {
      color: '#f50057',
      fontSize: 12,
    },
    componentFetchingFailureIcon: {
      color: '#f50057',
      fontSize: 12,
    },
  }),
);

const Component: React.VFC = () => {
  const history = useHistory();
  const styles = useStyles();

  // Identyfikator produktu.
  const { productId } = useParams();
  // Identyfikator komponentu.
  const { componentId } = useParams();

  // Flaga określająca, czy produkt został pobrany z API.
  const [isProductFetched, setIsProductFetched] = useState(false);
  // Flaga określająca, czy pobieranie produktu z API zakończyło się błędem.
  const [isProductFetchingFailure, setIsProductFetchingFailure] = useState(false);
  // Produkt.
  const [product, setProduct] = useState(null);

  // Flaga określająca, czy komponent został pobrany z API.
  const [isComponentFetched, setIsComponentFetched] = useState(false);
  // Flaga określająca, czy pobieranie komponentu z API zakończyło się błędem.
  const [isComponentFetchingFailure, setIsComponentFetchingFailure] = useState(false);
  // Komponent.
  const [component, setComponent] = useState(null);

  // Flaga określająca, czy lista wersji komponentu została pobrana z API.
  const [isComponentVersionsFetched, setIsComponentVersionsFetched] = useState(false);
  // Flaga określająca, czy pobieranie listy wersji komponentu z API zakończyło się błędem.
  const [isComponentVersionsFetchingFailure, setIsComponentVersionsFetchingFailure] = useState(false);
  // Lista wersji komponentu.
  const [componentVersions, setComponentVersions] = useState([]);

  // Flaga określająca, czy okno dialogowe potwierdzające chęć usunięcia wersji komponentu jest otwarte.
  const [isDeleteComponentVersionDialogWindowOpen, setIsDeleteComponentVersionDialogWindowOpen] = useState(false);
  // Dane wykorzystywane przez okno dialogowe potwierdzające chęć usunięcia wersji komponentu.
  const [deleteComponentVersionDialogWindowData, setDeleteComponentVersionDialogWindowData] = useState(null);
  
  // Flaga określająca, czy okno wyświetlające informacje nt. błędu, który wystąpił podczas próby usunięcia wersji komponentu jest otwarte.
  const [isDeleteComponentVersionErrorWindowOpen, setIsDeleteComponentVersionErrorWindowOpen] = useState(false);

  // Flaga określająca, czy lista logów została pobrana z API.
  const [isLogsFetched, setIsLogsFetched] = useState(false);
  // Lista logów.
  const [logs, setLogs] = useState([]);
  // Liczba logów, które mają zostać zwrócone.
  const [logsCount, setLogsCount] = useState(10);

  const fetchLogs = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/logs/components/${componentId}?count=${logsCount}`)
      .then((response) => response.json())
      .then((data) => {
        setIsLogsFetched(true);
        setLogs(data);
      });
  }, [componentId, logsCount]);

  useEffect(() => {
    fetchLogs();
  }, [componentId, logsCount, fetchLogs]);

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

  const fetchComponent = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/products/${productId}/components/${componentId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsComponentFetched(true);
        setComponent(data);
      })
      .catch(() => {
        setIsComponentFetched(true);
        setIsComponentFetchingFailure(true);
      });
  }, [productId, componentId]);

  useEffect(() => {
    fetchComponent();
  }, [fetchComponent]);

  const fetchComponentVersions = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/products/${productId}/components/${componentId}/component-versions`)
      .then((response) => response.json())
      .then((data) => {
        setIsComponentVersionsFetched(true);
        setComponentVersions(data);
      })
      .catch(() => {
        setIsComponentVersionsFetched(true);
        setIsComponentVersionsFetchingFailure(true);
      });
  }, [productId, componentId]);

  useEffect(() => {
    fetchComponentVersions();
  }, [fetchComponentVersions]);

  const addComponentVersion = () => {
    history.push(`/products/${productId}/components/${componentId}/component-versions/create`);
  };

  const editComponentVersion = () => {
    // TODO
  };

  const deleteComponentVersion = (id: string, number: string) => {
    setDeleteComponentVersionDialogWindowData({
      id,
      number,
    });
    setIsDeleteComponentVersionDialogWindowOpen(true);
  };

  const deleteComponentVersionConfirmed = async () => {
    await fetch(
      `${window['env'].API_URL}/products/${productId}/components/${componentId}/component-versions/${deleteComponentVersionDialogWindowData?.id}`,
      {
        method: 'DELETE',
      },
    )
    .then((response) => {
      setIsDeleteComponentVersionDialogWindowOpen(false);
      setDeleteComponentVersionDialogWindowData(null);

      if (response.ok) {
        fetchComponentVersions();
        fetchLogs();
      } else {
        setIsDeleteComponentVersionErrorWindowOpen(true);
      }
    });
  };

  const deleteComponentVersionCanceled = () => {
    setIsDeleteComponentVersionDialogWindowOpen(false);
    setDeleteComponentVersionDialogWindowData(null);
  };

  const deleteComponentVersionFailed = () => {
    setIsDeleteComponentVersionErrorWindowOpen(false);
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
        <Link
          component={RouterLink}
          to={`/products/${productId}`}
        >
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
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        <Box component="span">
          Komponenty
        </Box>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        {
          isComponentFetched
            ? (
              <Box component="span">
                {
                  isComponentFetchingFailure
                    ? <SentimentVeryDissatisfiedIcon className={styles.componentFetchingFailureIcon} />
                    : component?.name
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
          isComponentFetchingFailure
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
                  Pobieranie informacji nt. komponentu zakończyło się błędem.
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
                  isDataFetched={isComponentFetched}
                  name={component?.name}
                  componentTypeId={component?.componentTypeId}
                  componentTypeName={component?.componentTypeName}
                  description={component?.description}
                />
              </Paper>
            )
        }
      </Box>
      <Box
        mb={3}
      >
        {
          isComponentVersionsFetchingFailure
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
                  Pobieranie informacji nt. wersji zakończyło się błędem.
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
                  Wersje
                </Box>
                <List
                  isDataFetched={isComponentVersionsFetched}
                  data={componentVersions}
                  productId={productId}
                  componentId={componentId}
                  onEdit={editComponentVersion}
                  onDelete={deleteComponentVersion}
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
                    onClick={addComponentVersion}
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
          isComponentFetchingFailure
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
        isOpen={isDeleteComponentVersionDialogWindowOpen}
        title="Usunięcie wersji"
        onConfirm={deleteComponentVersionConfirmed}
        onCancel={deleteComponentVersionCanceled}
      >
        Czy na pewno chcesz usunąć wersję <strong>{deleteComponentVersionDialogWindowData?.number}</strong>?
      </DialogWindow>
      <ErrorWindow
        isOpen={isDeleteComponentVersionErrorWindowOpen}
        onClose={deleteComponentVersionFailed}
      >
        Próba usunięcia wersji zakończyła się błędem.
      </ErrorWindow>
    </>
  );
}

export default Component;
