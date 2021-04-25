import React, { useCallback, useEffect, useState } from 'react';
import { useHistory, useParams } from 'react-router-dom';

import {
  createStyles,
  makeStyles,
} from '@material-ui/core/styles';

import Box from '@material-ui/core/Box';
import Button from '@material-ui/core/Button';
import Paper from '@material-ui/core/Paper';

import AddIcon from '@material-ui/icons/Add';

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

  // Flaga określająca, czy komponent został pobrany z API.
  const [isComponentFetched, setIsComponentFetched] = useState(false);
  // Komponent.
  const [component, setComponent] = useState(null);

  // Flaga określająca, czy lista wersji komponentu została pobrana z API.
  const [isComponentVersionsFetched, setIsComponentVersionsFetched] = useState(false);
  // Lista wersji komponentu.
  const [componentVersions, setComponentVersions] = useState([]);

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

  const deleteComponentVersion = async (id: string) => {
    await fetch(
      `${window['env'].API_URL}/products/${productId}/components/${componentId}/component-versions/${id}`,
      {
        method: 'DELETE',
      },
    )
    .then(() => {
      fetchComponentVersions();
    });
  };

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Komponent
        {
          isComponentFetched
            ? (
              <Box
                component="span"
                fontStyle="italic"
                px={0.5}
              >
                {component?.name}
              </Box>)
            : ''
        }
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
    </>
  );
}

export default Component;
