import React from 'react';
import { Link as RouterLink } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import CircularProgress from '@material-ui/core/CircularProgress';
import Link from '@material-ui/core/Link';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableRow from '@material-ui/core/TableRow';

import {
  DetailsProps,
} from './interfaces';

const Details: React.FC<DetailsProps> = ({ isDataFetched, name, sourceCodeRepositoryUrl, packagesRepositoryPath, licensesRepositoryPath, componentTypeId, componentTypeName, description }: DetailsProps) => {
  if (!isDataFetched) {
    return (
      <Box
        p={2}
        textAlign="center"
      >
        <CircularProgress />
      </Box>
    );
  }

  return (
    <Table size="small">
      <TableBody>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 250 }}>Nazwa</TableCell>
          <TableCell>{name}</TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 250 }}>Typ</TableCell>
          <TableCell>
            <Link
              component={RouterLink}
              to={`/configuration/component-types/${componentTypeId}`}
            >
              {componentTypeName}
            </Link>
          </TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 250 }}>Repozytorium kodu źródłowego</TableCell>
          <TableCell>
            {
              sourceCodeRepositoryUrl
                ? (
                  <Link
                    href={sourceCodeRepositoryUrl}
                    target="_blank"
                  >
                    {sourceCodeRepositoryUrl}
                  </Link>
                )
                : '–'
            }
          </TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 250 }}>Repozytorium paczek</TableCell>
          <TableCell style={{ fontFamily: 'Consolas' }}>{packagesRepositoryPath || '–'}</TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 250 }}>Repozytorium licencji</TableCell>
          <TableCell style={{ fontFamily: 'Consolas' }}>{licensesRepositoryPath || '–'}</TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 250 }}>Opis</TableCell>
          <TableCell style={{ fontStyle: 'italic' }}>{description || '–'}</TableCell>
        </TableRow>
      </TableBody>
    </Table>
  )
}

export default Details;
