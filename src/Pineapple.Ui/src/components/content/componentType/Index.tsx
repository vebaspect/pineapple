import React, { useCallback, useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Paper from '@material-ui/core/Paper';

import Details from './Details';

const ComponentType: React.VFC = () => {
  // Identyfikator typu komponentu.
  const { componentTypeId } = useParams();

  // Flaga określająca, czy typ komponentu został pobrany z API.
  const [isComponentTypeFetched, setIsComponentTypeFetched] = useState(false);
  // Typ komponentu.
  const [componentType, setComponentType] = useState(null);

  const fetchComponentType = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/configuration/component-types/${componentTypeId}`)
      .then(response => response.json())
      .then(data => {
        setIsComponentTypeFetched(true);
        setComponentType(data);
      });
  }, [componentTypeId]);

  useEffect(() => {
    fetchComponentType();
  }, [fetchComponentType]);

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Typ komponentu
        {
          isComponentTypeFetched
            ? (
              <Box
                component="span"
                fontStyle="italic"
                px={0.5}
              >
                {componentType?.name}
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
            name={componentType?.name}
            symbol={componentType?.symbol}
            description={componentType?.description}
          />
        </Paper>
      </Box>
    </>
  );
}

export default ComponentType;
