import React, { useCallback, useEffect, useState } from 'react';
import { Link as RouterLink, useParams } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Link from '@material-ui/core/Link';
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
      .then((response) => response.json())
      .then((data) => {
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
        fontSize="0.9rem"
        m={2}
      >
        <Link
          component={RouterLink}
          to="/configuration"
        >
          Konfiguracja
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        <Link
          component={RouterLink}
          to="/configuration/component-types"
        >
          Typy komponentów
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        {
          isComponentTypeFetched
            ? (
              <Box component="span">
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
            isDataFetched={isComponentTypeFetched}
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
