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

const Details: React.FC<DetailsProps> = ({ isDataFetched, name, symbol, operatorId, operatorFullName, description }: DetailsProps) => {
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
          <TableCell style={{ fontWeight: 500, width: 200 }}>Nazwa</TableCell>
          <TableCell>{name}</TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 200 }}>Symbol</TableCell>
          <TableCell style={{ fontFamily: 'Consolas' }}>{symbol}</TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 200 }}>Wdrożeniowiec</TableCell>
          <TableCell>
            {
              operatorId
                ? (
                  <Link
                    component={RouterLink}
                    to={`/users/${operatorId}`}
                  >
                    {operatorFullName}
                  </Link>
                )
                : '–'
            }
          </TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 200 }}>Opis</TableCell>
          <TableCell style={{ fontStyle: 'italic' }}>{description || '–'}</TableCell>
        </TableRow>
      </TableBody>
    </Table>
  )
}

export default Details;
