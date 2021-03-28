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
import EditIcon from '@material-ui/icons/Edit';

interface Props {
  // Flaga określająca, czy lista programistów została pobrana z API.
  isDataFetched: boolean,
  // Lista programistów.
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
    // Flaga określająca, czy programista został usunięty.
    isDeleted: boolean,
  }[],
  // Zdarzenie edycji programisty.
  onEdit: Function,
  // Zdarzenie usunięcia programisty.
  onDelete: Function,
}

const List: React.FC<Props> = ({ isDataFetched, data, onEdit, onDelete }: Props) => {
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
          <TableCell style={{ width: 100 }} />
        </TableRow>
      </TableHead>
      <TableBody>
        {
          data.filter((developer) => !developer.isDeleted).map((developer, index) => (
            <TableRow key={developer.id}>
              <TableCell>{index + 1}.</TableCell>
              <TableCell>{developer.fullName}</TableCell>
              <TableCell>{developer.login}</TableCell>
              <TableCell>{developer.phone}</TableCell>
              <TableCell>{developer.email}</TableCell>
              <TableCell align="right">
                <Tooltip title="Edytuj">
                  <IconButton
                    size="small"
                    onClick={() => onEdit(developer.id)}
                  >
                    <EditIcon />
                  </IconButton>
                </Tooltip>
                <Tooltip title="Usuń">
                  <IconButton
                    color="secondary"
                    size="small"
                    onClick={() => onDelete(developer.id)}
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
