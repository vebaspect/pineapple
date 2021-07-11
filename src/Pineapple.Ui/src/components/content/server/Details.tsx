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

const Details: React.FC<DetailsProps> = ({ isDataFetched, name, symbol, ipAddress, operatingSystemId, operatingSystemName, description }: DetailsProps) => {
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
          <TableCell style={{ fontWeight: 500, width: 220 }}>Nazwa</TableCell>
          <TableCell>{name}</TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 220 }}>Symbol</TableCell>
          <TableCell style={{ fontFamily: 'Consolas' }}>{symbol}</TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 220 }}>Adres IP</TableCell>
          <TableCell>{ipAddress}</TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 220 }}>System operacyjny</TableCell>
          <TableCell>
            <Link
              component={RouterLink}
              to={`/configuration/operating-systems/${operatingSystemId}`}
            >
              {operatingSystemName}
            </Link>
          </TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 220 }}>Opis</TableCell>
          <TableCell style={{ fontStyle: 'italic' }}>{description || '–'}</TableCell>
        </TableRow>
      </TableBody>
    </Table>
  )
}

export default Details;
