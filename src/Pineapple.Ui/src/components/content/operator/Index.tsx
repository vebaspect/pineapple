import React, { useCallback, useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Paper from '@material-ui/core/Paper';

import Details from './Details';

const Operator: React.VFC = () => {
  // Identyfikator wdrożeniowca.
  const { operatorId } = useParams();

  // Flaga określająca, czy wdrożeniowiec został pobrany z API.
  const [isOperatorFetched, setIsOperatorFetched] = useState(false);
  // Wdrożeniowiec.
  const [operator, setOperator] = useState(null);

  const fetchOperator = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/users/${operatorId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsOperatorFetched(true);
        setOperator(data);
      });
  }, [operatorId]);

  useEffect(() => {
    fetchOperator();
  }, [fetchOperator]);

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Wdrożeniowiec
        {
          isOperatorFetched
            ? (
              <Box
                component="span"
                fontStyle="italic"
                px={0.5}
              >
                {operator?.fullName}
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
            isDataFetched={isOperatorFetched}
            fullName={operator?.fullName}
            login={operator?.login}
            phone={operator?.phone}
            email={operator?.email}
          />
        </Paper>
      </Box>
    </>
  );
}

export default Operator;
