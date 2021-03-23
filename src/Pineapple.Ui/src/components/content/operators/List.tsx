import React from 'react';

import Box from '@material-ui/core/Box';
import CircularProgress from '@material-ui/core/CircularProgress';
import IconButton from '@material-ui/core/IconButton';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Tooltip from '@material-ui/core/Tooltip';

import DeleteIcon from '@material-ui/icons/Delete';

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
  }[],
  // Zdarzenie usunięcia operatora.
  onDelete: Function,
};

const List = ({ isDataFetched, data, onDelete }: Props) => {
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
          <TableCell style={{ width: 60 }} />
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
              <TableCell align="right">
                <Tooltip title="Usuń">
                  <IconButton
                    color="secondary"
                    size="small"
                    onClick={() => onDelete(operator.id)}
                  >
                    <DeleteIcon />
                  </IconButton>
                </Tooltip>
              </TableCell>
            </TableRow>
          ))
        }
      </TableBody>
    </Table>
  );
}

export default List;
