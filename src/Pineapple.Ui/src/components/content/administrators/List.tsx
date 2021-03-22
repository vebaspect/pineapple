import React from 'react';

import Box from '@material-ui/core/Box';
import CircularProgress from '@material-ui/core/CircularProgress';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';

interface Props {
  // Flaga określająca, czy lista administratorów została pobrana z API.
  isDataFetched: boolean,
  // Lista administratorów.
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
    // Flaga określająca, czy administrator został usunięty.
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
          data.filter((administrator) => !administrator.isDeleted).map((administrator, index) => (
            <TableRow key={administrator.id}>
              <TableCell>{index + 1}.</TableCell>
              <TableCell>{administrator.fullName}</TableCell>
              <TableCell>{administrator.login}</TableCell>
              <TableCell>{administrator.phone}</TableCell>
              <TableCell>{administrator.email}</TableCell>
            </TableRow>
          ))
        }
      </TableBody>
    </Table>
  );
}

export default List;
