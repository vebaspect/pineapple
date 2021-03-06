import moment from 'moment';
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
  formatNumber,
  translateKind,
} from '../../../helpers/componentVersionHelpers';

import {
  ListProps,
} from './interfaces';

const List: React.FC<ListProps> = ({ isDataFetched, data, productId, componentId, onEdit, onDelete }: ListProps) => {
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
          <TableCell>Numer</TableCell>
          <TableCell>Rodzaj</TableCell>
          <TableCell>Data wydania</TableCell>
          <TableCell style={{ width: 100 }} />
        </TableRow>
      </TableHead>
      <TableBody>
        {
          data.filter((componentVersion) => !componentVersion.isDeleted).map((componentVersion, index) => (
            <TableRow
              key={componentVersion.id}
              style={
                componentVersion.isImportant
                  ? { backgroundColor: '#ffebee' }
                  : null
              }
            >
              <TableCell>{index + 1}.</TableCell>
              <TableCell>
                <Link
                  component={RouterLink}
                  to={`/products/${productId}/components/${componentId}/component-versions/${componentVersion.id}`}
                >
                  {formatNumber(componentVersion.major, componentVersion.minor, componentVersion.patch, componentVersion.suffix)}
                </Link>
              </TableCell>
              <TableCell>{translateKind(componentVersion.kind)}</TableCell>
              <TableCell>{moment(componentVersion.releaseDate).format('LLL')}</TableCell>
              <TableCell align="right">
                <Tooltip title="Edytuj">
                  <IconButton
                    size="small"
                    onClick={() => onEdit(componentVersion.id)}
                  >
                    <EditIcon />
                  </IconButton>
                </Tooltip>
                <Tooltip title="Usuń">
                  <IconButton
                    color="secondary"
                    size="small"
                    onClick={() => onDelete(componentVersion.id, formatNumber(componentVersion.major, componentVersion.minor, componentVersion.patch, componentVersion.suffix))}
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
