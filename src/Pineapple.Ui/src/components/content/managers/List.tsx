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
  // Flaga określająca, czy lista menedżerów została pobrana z API.
  isDataFetched: boolean,
  // Lista menedżerów.
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
    // Flaga określająca, czy menedżer został usunięty.
    isDeleted: boolean,
  }[],
  // Zdarzenie usunięcia menedżera.
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
          data.filter((manager) => !manager.isDeleted).map((manager, index) => (
            <TableRow key={manager.id}>
              <TableCell>{index + 1}.</TableCell>
              <TableCell>{manager.fullName}</TableCell>
              <TableCell>{manager.login}</TableCell>
              <TableCell>{manager.phone}</TableCell>
              <TableCell>{manager.email}</TableCell>
              <TableCell align="right">
                <Tooltip title="Usuń">
                  <IconButton
                    color="secondary"
                    size="small"
                    onClick={() => onDelete(manager.id)}
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
