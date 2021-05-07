import React, { useCallback, useEffect, useState } from 'react';
import { Link as RouterLink, useParams } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Link from '@material-ui/core/Link';
import Paper from '@material-ui/core/Paper';

import Details from './Details';

const OperatingSystem: React.VFC = () => {
  // Identyfikator systemu operacyjnego.
  const { operatingSystemId } = useParams();

  // Flaga określająca, czy system operacyjny został pobrany z API.
  const [isOperatingSystemFetched, setIsOperatingSystemFetched] = useState(false);
  // System operacyjny.
  const [operatingSystem, setOperatingSystem] = useState(null);

  const fetchOperatingSystem = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/configuration/operating-systems/${operatingSystemId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsOperatingSystemFetched(true);
        setOperatingSystem(data);
      });
  }, [operatingSystemId]);

  useEffect(() => {
    fetchOperatingSystem();
  }, [fetchOperatingSystem]);

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
          to="/configuration/operating-systems"
        >
          Systemy operacyjne
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        {
          isOperatingSystemFetched
            ? (
              <Box component="span">
                {operatingSystem?.name}
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
            isDataFetched={isOperatingSystemFetched}
            name={operatingSystem?.name}
            symbol={operatingSystem?.symbol}
            description={operatingSystem?.description}
          />
        </Paper>
      </Box>
    </>
  );
}

export default OperatingSystem;
