import React from 'react';

import Box from '@material-ui/core/Box';
import CircularProgress from '@material-ui/core/CircularProgress';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';

interface Props {
  // Flaga określająca, czy lista typów komponentów została pobrana z API.
  isDataFetched: boolean,
  // Lista typów komponentów.
  data: {
    // Identyfikator.
    id: string,
    // Nazwa.
    name: string,
    // Symbol.
    symbol: string,
    // Opis.
    description: string,
    // Flaga określająca, czy typ komponentu został usunięty.
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
          <TableCell>Symbol</TableCell>
          <TableCell>Opis</TableCell>
        </TableRow>
      </TableHead>
      <TableBody>
        {
          data.filter((componentType) => !componentType.isDeleted).map((componentType, index) => (
            <TableRow key={componentType.id}>
              <TableCell>{index + 1}.</TableCell>
              <TableCell>{componentType.name}</TableCell>
              <TableCell>{componentType.symbol}</TableCell>
              <TableCell>{componentType.description}</TableCell>
            </TableRow>
          ))
        }
      </TableBody>
    </Table>
  );
}

export default List;
