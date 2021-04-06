import React, { useCallback, useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Paper from '@material-ui/core/Paper';

import Details from './Details';

const SoftwareApplication: React.VFC = () => {
  // Identyfikator oprogramowania.
  const { softwareApplicationId } = useParams();

  // Flaga określająca, czy oprogramowanie zostało pobrane z API.
  const [isSoftwareApplicationFetched, setIsSoftwareApplicationFetched] = useState(false);
  // Oprogramowanie.
  const [softwareApplication, setSoftwareApplication] = useState(null);

  const fetchSoftwareApplication = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/configuration/software-applications/${softwareApplicationId}`)
      .then(response => response.json())
      .then(data => {
        setIsSoftwareApplicationFetched(true);
        setSoftwareApplication(data);
      });
  }, [softwareApplicationId]);

  useEffect(() => {
    fetchSoftwareApplication();
  }, [fetchSoftwareApplication]);

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Oprogramowanie
        {
          isSoftwareApplicationFetched
            ? (
              <Box
                component="span"
                fontStyle="italic"
                px={0.5}
              >
                {softwareApplication?.name}
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
            name={softwareApplication?.name}
            symbol={softwareApplication?.symbol}
            description={softwareApplication?.description}
          />
        </Paper>
      </Box>
    </>
  );
}

export default SoftwareApplication;
