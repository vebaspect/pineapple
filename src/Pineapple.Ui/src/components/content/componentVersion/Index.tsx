import React, { useCallback, useEffect, useState } from 'react';
import { Link as RouterLink, useParams } from 'react-router-dom';

import {
  createStyles,
  makeStyles,
} from '@material-ui/core/styles';

import Box from '@material-ui/core/Box';
import CircularProgress from '@material-ui/core/CircularProgress';
import Link from '@material-ui/core/Link';
import Paper from '@material-ui/core/Paper';

import SentimentVeryDissatisfiedIcon from '@material-ui/icons/SentimentVeryDissatisfied';

import {
  formatNumber,
} from '../../../helpers/componentVersionHelpers';

import Details from './Details';

const useStyles = makeStyles(() =>
  createStyles({
    productFetchingFailureIcon: {
      color: '#f50057',
      fontSize: 12,
    },
    componentFetchingFailureIcon: {
      color: '#f50057',
      fontSize: 12,
    },
    componentVersionFetchingFailureIcon: {
      color: '#f50057',
      fontSize: 12,
    },
  }),
);

const ComponentVersion: React.VFC = () => {
  const styles = useStyles();

  // Identyfikator produktu.
  const { productId } = useParams();
  // Identyfikator komponentu.
  const { componentId } = useParams();
  // Identyfikator wersji komponentu.
  const { componentVersionId } = useParams();

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

  // Flaga określająca, czy wersja komponentu została pobrana z API.
  const [isComponentVersionFetched, setIsComponentVersionFetched] = useState(false);
  // Flaga określająca, czy pobieranie wersji komponentu z API zakończyło się błędem.
  const [isComponentVersionFetchingFailure, setIsComponentVersionFetchingFailure] = useState(false);
  // Wersja komponentu.
  const [componentVersion, setComponentVersion] = useState(null);

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

  const fetchComponentVersion = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/products/${productId}/components/${componentId}/component-versions/${componentVersionId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsComponentVersionFetched(true);
        setComponentVersion(data);
      })
      .catch(() => {
        setIsComponentVersionFetched(true);
        setIsComponentVersionFetchingFailure(true);
      });
  }, [productId, componentId, componentVersionId]);

  useEffect(() => {
    fetchComponentVersion();
  }, [fetchComponentVersion]);

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
        <Link
          component={RouterLink}
          to={`/products/${productId}/components/${componentId}`}
        >
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
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        <Box component="span">
          Wersje
        </Box>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        {
          isComponentVersionFetched
            ? (
              <Box component="span">
                {
                  isComponentVersionFetchingFailure
                    ? <SentimentVeryDissatisfiedIcon className={styles.componentVersionFetchingFailureIcon} />
                    : formatNumber(componentVersion?.major, componentVersion?.minor, componentVersion?.patch, componentVersion?.suffix)
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
          isComponentVersionFetchingFailure
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
                  Szczegóły
                </Box>
                <Details
                  isDataFetched={isComponentVersionFetched}
                  kind={componentVersion?.kind}
                  releaseDate={componentVersion?.releaseDate}
                  major={componentVersion?.major}
                  minor={componentVersion?.minor}
                  patch={componentVersion?.patch}
                  suffix={componentVersion?.suffix}
                  description={componentVersion?.description}
                />
              </Paper>
            )
        }
      </Box>
    </>
  );
}

export default ComponentVersion;
