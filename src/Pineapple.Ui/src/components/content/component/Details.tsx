import React from 'react';

import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableRow from '@material-ui/core/TableRow';

import {
  DetailsProps,
} from './interfaces';

const Details: React.FC<DetailsProps> = ({ name, type, description }: DetailsProps) => {
  return (
    <Table size="small">
      <TableBody>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 200 }}>Nazwa</TableCell>
          <TableCell>{name}</TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 200 }}>Typ</TableCell>
          <TableCell>{type}</TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 200 }}>Opis</TableCell>
          <TableCell>{description}</TableCell>
        </TableRow>
      </TableBody>
    </Table>
  )
}

export default Details;
