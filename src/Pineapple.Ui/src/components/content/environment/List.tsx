import React from 'react';
import { Link as RouterLink } from 'react-router-dom';

import {
  createStyles,
  makeStyles,
} from '@material-ui/core/styles';

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
import WarningIcon from '@material-ui/icons/Warning';

import {
  ListProps,
} from './interfaces';

const useStyles = makeStyles(() =>
  createStyles({
    serverName: {
      paddingRight: '5px',
    },
    serverNameWrapper: {
      alignItems: 'center',
      display: 'flex',
    },
    warningIcon: {
      color: '#f50057',
    },
  }),
);

const List: React.FC<ListProps> = ({ isDataFetched, data, implementationId, environmentId, onEdit, onDelete }: ListProps) => {
  const styles = useStyles();

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
          <TableCell style={{ width: 100 }} />
        </TableRow>
      </TableHead>
      <TableBody>
        {
          data.filter((server) => !server.isDeleted).map((server, index) => (
            <TableRow key={server.id}>
              <TableCell>{index + 1}.</TableCell>
              <TableCell>
                <Box className={styles.serverNameWrapper}>
                  <Link
                    className={styles.serverName}
                    component={RouterLink}
                    to={`/implementations/${implementationId}/environments/${environmentId}/servers/${server.id}`}
                  >
                    {server.name}
                  </Link>
                  {
                    server.isUpdateAvailable
                      ? (
                        <Tooltip title="Dostępne są nowsze wersje zainstalowanych komponentów!">
                          <WarningIcon className={styles.warningIcon} />
                        </Tooltip>
                      )
                      : null
                  }
                </Box>
              </TableCell>
              <TableCell style={{ fontFamily: 'Consolas' }}>{server.symbol}</TableCell>
              <TableCell align="right">
                <Tooltip title="Edytuj">
                  <IconButton
                    size="small"
                    onClick={() => onEdit(server.id)}
                  >
                    <EditIcon />
                  </IconButton>
                </Tooltip>
                <Tooltip title="Usuń">
                  <IconButton
                    color="secondary"
                    size="small"
                    onClick={() => onDelete(server.id, server.name)}
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
