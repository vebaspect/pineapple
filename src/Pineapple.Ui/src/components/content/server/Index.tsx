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
import InstalledComponentsList from './InstalledComponentsList';

const useStyles = makeStyles(() =>
  createStyles({
    install: {
      backgroundColor: '#4caf50',
      color: '#fff',
    },
  }),
);

const Server: React.VFC = () => {
  const history = useHistory();
  const styles = useStyles();

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

  const installComponent = () => {
    history.push(`/implementations/${implementationId}/environments/${environmentId}/servers/${serverId}/components/create`);
  };

  const uninstallComponent = async (id: string) => {
    await fetch(
      `${window['env'].API_URL}/implementations/${implementationId}/environments/${environmentId}/servers/${serverId}/components`,
      {
        body: JSON.stringify({
          componentVersionId: id,
        }),
        headers: {
          'Content-Type': 'application/json',
        },
        method: 'DELETE',
      },
    )
    .then(() => {
      fetchServer();
    });
  };

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
            onUninstall={uninstallComponent}
          />
          <Box
            p={1.5}
            textAlign="right"
          >
            <Button
              className={styles.install}
              size="small"
              startIcon={<AddIcon />}
              variant="contained"
              onClick={installComponent}
            >
              Zainstaluj
            </Button>
          </Box>
        </Paper>
      </Box>
    </>
  );
}

export default Server;
