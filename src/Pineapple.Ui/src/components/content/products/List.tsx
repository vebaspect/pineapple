import React from 'react';

import Box from '@material-ui/core/Box';
import CircularProgress from '@material-ui/core/CircularProgress';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';

interface Props {
  // Flaga określająca, czy lista produktów została pobrana z API.
  isDataFetched: boolean,
  // Lista produktów.
  data: {
    // Identyfikator.
    id: string,
    // Nazwa.
    name: string,
    // Opis.
    description: string,
    // Flaga określająca, czy produkt został usunięty.
    isDeleted: boolean,
  }[];
};

const List = ({ isDataFetched, data }: Props) => {
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
      <TableHead>
        <TableRow>
          <TableCell style={{ width: 60 }}>Lp</TableCell>
          <TableCell>Nazwa</TableCell>
          <TableCell>Opis</TableCell>
        </TableRow>
      </TableHead>
      <TableBody>
        {
          data.filter((product) => !product.isDeleted).map((product, index) => (
            <TableRow key={product.id}>
              <TableCell>{index + 1}.</TableCell>
              <TableCell>{product.name}</TableCell>
              <TableCell>{product.description}</TableCell>
            </TableRow>
          ))
        }
      </TableBody>
    </Table>
  );
}

export default List;
