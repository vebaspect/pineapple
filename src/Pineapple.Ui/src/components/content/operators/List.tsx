import React from 'react';

import Box from '@material-ui/core/Box';
import CircularProgress from '@material-ui/core/CircularProgress';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';

interface Props {
  // Flaga określająca, czy lista wdrożeniowców została pobrana z API.
  isDataFetched: boolean,
  // Lista wdrożeniowców.
  data: {
    // Identyfikator.
    id: string,
    // Imię i nazwisko.
    fullName: string,
    // Login.
    login: string,
    // Telefon.
    phone: string,
    // E-mail.
    email: string,
    // Flaga określająca, czy wdrożeniowiec został usunięty.
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
          <TableCell>Imię i nazwisko</TableCell>
          <TableCell>Login</TableCell>
          <TableCell>Telefon</TableCell>
          <TableCell>E-mail</TableCell>
        </TableRow>
      </TableHead>
      <TableBody>
        {
          data.filter((operator) => !operator.isDeleted).map((operator, index) => (
            <TableRow key={operator.id}>
              <TableCell>{index + 1}.</TableCell>
              <TableCell>{operator.fullName}</TableCell>
              <TableCell>{operator.login}</TableCell>
              <TableCell>{operator.phone}</TableCell>
              <TableCell>{operator.email}</TableCell>
            </TableRow>
          ))
        }
      </TableBody>
    </Table>
  );
}

export default List;
