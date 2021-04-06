import React, { useCallback, useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Paper from '@material-ui/core/Paper';

import Details from './Details';

const Component: React.VFC = () => {
  // Identyfikator produktu.
  const { productId } = useParams();
  // Identyfikator komponentu.
  const { componentId } = useParams();

  // Flaga określająca, czy komponent został pobrany z API.
  const [isComponentFetched, setIsComponentFetched] = useState(false);
  // Komponent.
  const [component, setComponent] = useState(null);

  const fetchComponent = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/products/${productId}/components/${componentId}`)
      .then(response => response.json())
      .then(data => {
        setIsComponentFetched(true);
        setComponent(data);
      });
  }, [productId, componentId]);

  useEffect(() => {
    fetchComponent();
  }, [fetchComponent]);

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
            name={component?.name}
            description={component?.description}
          />
        </Paper>
      </Box>
    </>
  );
}

export default Component;
