import React, { useCallback, useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Paper from '@material-ui/core/Paper';

import Details from './Details';
import InstalledComponentsList from './InstalledComponentsList';

const Server: React.VFC = () => {
  // Identyfikator wdrożenia.
  const { implementationId } = useParams();
  // Identyfikator środowiska.
  const { environmentId } = useParams();
  // Identyfikator serwera.
  const { serverId } = useParams();

  // Flaga określająca, czy serwer został pobrany z API.
  const [isServerFetched, setIsServerFetched] = useState(false);
  // Serwer.
  const [server, setServer] = useState(null);

  const fetchServer = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/implementations/${implementationId}/environments/${environmentId}/servers/${serverId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsServerFetched(true);
        setServer(data);
      });
  }, [implementationId, environmentId, serverId]);

  useEffect(() => {
    fetchServer();
  }, [fetchServer]);

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Serwer
        {
          isServerFetched
            ? (
              <Box
                component="span"
                fontStyle="italic"
                px={0.5}
              >
                {server?.name}
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
            isDataFetched={isServerFetched}
            name={server?.name}
            symbol={server?.symbol}
            ipAddress={server?.ipAddress}
            operatingSystemId={server?.operatingSystemId}
            operatingSystemName={server?.operatingSystemName}
            description={server?.description}
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
            Zainstalowane komponenty
          </Box>
          <InstalledComponentsList
            isDataFetched={isServerFetched}
            data={server?.installedComponents}
          />
        </Paper>
      </Box>
    </>
  );
}

export default Server;
