import React, { useCallback, useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Paper from '@material-ui/core/Paper';

import {
  formatNumber,
} from '../../../helpers/componentVersionHelpers';

import Details from './Details';

const ComponentVersion: React.VFC = () => {
  // Identyfikator produktu.
  const { productId } = useParams();
  // Identyfikator komponentu.
  const { componentId } = useParams();
  // Identyfikator wersji komponentu.
  const { componentVersionId } = useParams();

  // Flaga określająca, czy wersja komponentu została pobrana z API.
  const [isComponentVersionFetched, setIsComponentVersionFetched] = useState(false);
  // Wersja komponentu.
  const [componentVersion, setComponentVersion] = useState(null);

  const fetchComponentVersion = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/products/${productId}/components/${componentId}/component-versions/${componentVersionId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsComponentVersionFetched(true);
        setComponentVersion(data);
      });
  }, [productId, componentId, componentVersionId]);

  useEffect(() => {
    fetchComponentVersion();
  }, [fetchComponentVersion]);

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Wersja komponentu
        {
          isComponentVersionFetched
            ? (
              <Box
                component="span"
                fontStyle="italic"
                px={0.5}
              >
                {formatNumber(componentVersion?.major, componentVersion?.minor, componentVersion?.patch, componentVersion?.suffix)}
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
            isDataFetched={isComponentVersionFetched}
            kind={componentVersion?.kind}
            releaseDate={componentVersion?.releaseDate}
            major={componentVersion?.major}
            minor={componentVersion?.minor}
            patch={componentVersion?.patch}
            suffix={componentVersion?.suffix}
            description={componentVersion?.description}
          />
        </Paper>
      </Box>
    </>
  );
}

export default ComponentVersion;
