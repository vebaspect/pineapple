import React, { useEffect, useState } from 'react';

import Box from '@material-ui/core/Box';
import Link from '@material-ui/core/Link';
import Paper from '@material-ui/core/Paper';

import List from './List';

const SoftwareApplications = () => {
  // Flaga określająca, czy lista oprogramowania została pobrana z API.
  const [isSoftwareApplicationsFetched, setIsSoftwareApplicationsFetched] = useState(false);
  // Lista oprogramowania.
  const [softwareApplications, setSoftwareApplications] = useState([]);
  // Liczba oprogramowania, które mają zostać zwrócone.
  const [softwareApplicationsCount, setSoftwareApplicationsCount] = useState(10);

  useEffect(() => {
    fetchSoftwareApplications();
  }, [softwareApplicationsCount]);

  const fetchSoftwareApplications = async () => {
    await fetch(`${window['env'].API_URL}/configuration/software-applications?count=${softwareApplicationsCount}`)
      .then(response => response.json())
      .then(data => {
        setIsSoftwareApplicationsFetched(true);
        setSoftwareApplications(data);
      });
  };

  const fetchMoreSoftwareApplications = () => {
    if (softwareApplicationsCount <= softwareApplications.length) {
      setSoftwareApplicationsCount(softwareApplicationsCount + 10);
    }
  };

  const deleteSoftwareApplication = async (id) => {
    await fetch(
      `${window['env'].API_URL}/configuration/software-applications/${id}`,
      {
        method: 'DELETE',
      },
    )
    .then(() => {
      fetchSoftwareApplications();
    });
  };

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Oprogramowanie
      </Box>
      <Box
        mb={3}
      >
        <Paper>
          <List
            isDataFetched={isSoftwareApplicationsFetched}
            data={softwareApplications}
            onDelete={deleteSoftwareApplication}
          />
          <Box
            py={1.5}
            textAlign="center"
          >
            <Link onClick={fetchMoreSoftwareApplications}>
              Pobierz więcej
            </Link>
          </Box>
        </Paper>
      </Box>
    </>
  );
}

export default SoftwareApplications;
