import React, { useCallback, useEffect, useState } from 'react';
import { Link as RouterLink, useHistory, useParams } from 'react-router-dom';

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

import Details from './Details';
import List from './List';

const useStyles = makeStyles(() =>
  createStyles({
    add: {
      backgroundColor: '#4caf50',
      color: '#fff',
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
  // Produkt.
  const [product, setProduct] = useState(null);

  // Flaga określająca, czy komponent został pobrany z API.
  const [isComponentFetched, setIsComponentFetched] = useState(false);
  // Komponent.
  const [component, setComponent] = useState(null);

  // Flaga określająca, czy lista wersji komponentu została pobrana z API.
  const [isComponentVersionsFetched, setIsComponentVersionsFetched] = useState(false);
  // Lista wersji komponentu.
  const [componentVersions, setComponentVersions] = useState([]);

  // Flaga określająca, czy okno dialogowe potwierdzające chęć usunięcia wersji komponentu jest otwarte.
  const [isDeleteComponentVersionDialogWindowOpen, setIsDeleteComponentVersionDialogWindowOpen] = useState(false);
  // Dane wykorzystywane przez okno dialogowe potwierdzające chęć usunięcia wersji komponentu.
  const [deleteComponentVersionDialogWindowData, setDeleteComponentVersionDialogWindowData] = useState(null);
  
  // Flaga określająca, czy okno wyświetlające informacje nt. błędu, który wystąpił podczas próby usunięcia wersji komponentu jest otwarte.
  const [isDeleteComponentVersionErrorWindowOpen, setIsDeleteComponentVersionErrorWindowOpen] = useState(false);

  const fetchProduct = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/products/${productId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsProductFetched(true);
        setProduct(data);
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
                  {product?.name}
                </Box>)
              : ''
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
                {component?.name}
              </Box>)
            : ''
        }
      </Box>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Komponent
        
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
