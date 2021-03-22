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
  // Flaga określająca, czy lista oprogramowania została pobrana z API.
  isDataFetched: boolean,
  // Lista oprogramowania.
  data: {
    // Identyfikator.
    id: string,
    // Nazwa.
    name: string,
    // Symbol.
    symbol: string,
    // Opis.
    description: string,
    // Flaga określająca, czy oprogramowanie zostało usunięte.
    isDeleted: boolean,
  }[],
  // Zdarzenie usunięcia oprogramowania.
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
          <TableCell>Nazwa</TableCell>
          <TableCell>Symbol</TableCell>
          <TableCell>Opis</TableCell>
          <TableCell style={{ width: 60 }} />
        </TableRow>
      </TableHead>
      <TableBody>
        {
          data.filter((softwareApplication) => !softwareApplication.isDeleted).map((softwareApplication, index) => (
            <TableRow key={softwareApplication.id}>
              <TableCell>{index + 1}.</TableCell>
              <TableCell>{softwareApplication.name}</TableCell>
              <TableCell>{softwareApplication.symbol}</TableCell>
              <TableCell>{softwareApplication.description}</TableCell>
              <TableCell align="right">
                <Tooltip title="Usuń">
                  <IconButton
                    color="secondary"
                    size="small"
                    onClick={() => onDelete(softwareApplication.id)}
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
