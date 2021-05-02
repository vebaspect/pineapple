import React from 'react';
import { Link as RouterLink } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import CircularProgress from '@material-ui/core/CircularProgress';
import IconButton from '@material-ui/core/IconButton';
import Link from '@material-ui/core/Link';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Tooltip from '@material-ui/core/Tooltip';

import DeleteIcon from '@material-ui/icons/Delete';
import EditIcon from '@material-ui/icons/Edit';

import {
  ListProps,
} from './interfaces';

const List: React.FC<ListProps> = ({ isDataFetched, data, productId, onEdit, onDelete }: ListProps) => {
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
          <TableCell>Aktualna wersja</TableCell>
          <TableCell>Typ</TableCell>
          <TableCell>Opis</TableCell>
          <TableCell style={{ width: 100 }} />
        </TableRow>
      </TableHead>
      <TableBody>
        {
          data.filter((component) => !component.isDeleted).map((component, index) => (
            <TableRow key={component.id}>
              <TableCell>{index + 1}.</TableCell>
              <TableCell>
                <Link
                  component={RouterLink}
                  to={`/products/${productId}/components/${component.id}`}
                >
                  {component.name}
                </Link>
              </TableCell>
              <TableCell>
                <Link
                  component={RouterLink}
                  to={`/products/${productId}/components/${component.id}/component-versions/${component.actualComponentVersionId}`}
                >
                  {component.actualComponentVersionNumber}
                </Link>
              </TableCell>
              <TableCell>
                <Link
                  component={RouterLink}
                  to={`/component-types/${component.componentTypeId}`}
                >
                  {component.componentTypeName}
                </Link>
              </TableCell>
              <TableCell>{component.description}</TableCell>
              <TableCell align="right">
                <Tooltip title="Edytuj">
                  <IconButton
                    size="small"
                    onClick={() => onEdit(component.id)}
                  >
                    <EditIcon />
                  </IconButton>
                </Tooltip>
                <Tooltip title="Usuń">
                  <IconButton
                    color="secondary"
                    size="small"
                    onClick={() => onDelete(component.id, component.name)}
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
