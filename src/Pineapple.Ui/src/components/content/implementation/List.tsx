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
    environmentName: {
      paddingRight: '5px',
    },
    environmentNameWrapper: {
      alignItems: 'center',
      display: 'flex',
    },
    warningIcon: {
      color: '#f50057',
    },
  }),
);

const List: React.FC<ListProps> = ({ isDataFetched, data, implementationId, onEdit, onDelete }: ListProps) => {
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
          <TableCell>Wdrożeniowiec</TableCell>
          <TableCell style={{ width: 100 }} />
        </TableRow>
      </TableHead>
      <TableBody>
        {
          data.filter((environment) => !environment.isDeleted).map((environment, index) => (
            <TableRow key={environment.id}>
              <TableCell>{index + 1}.</TableCell>
              <TableCell>
                <Box className={styles.environmentNameWrapper}>
                  <Link
                    className={styles.environmentName}
                    component={RouterLink}
                    to={`/implementations/${implementationId}/environments/${environment.id}`}
                  >
                    {environment.name}
                  </Link>
                  {
                    environment.isUpdateAvailable
                      ? (
                        <Tooltip title="Dostępne są nowsze wersje zainstalowanych komponentów!">
                          <WarningIcon className={styles.warningIcon} />
                        </Tooltip>
                      )
                      : null
                  }
                </Box>
              </TableCell>
              <TableCell style={{ fontFamily: 'Consolas' }}>{environment.symbol}</TableCell>
              <TableCell>
                {
                  environment.operatorId
                  ? (
                    <Link
                      component={RouterLink}
                      to={`/users/${environment.operatorId}`}
                    >
                      {environment.operatorFullName}
                    </Link>
                  )
                  : '–'
                }
              </TableCell>
              <TableCell align="right">
                <Tooltip title="Edytuj">
                  <IconButton
                    size="small"
                    onClick={() => onEdit(environment.id)}
                  >
                    <EditIcon />
                  </IconButton>
                </Tooltip>
                <Tooltip title="Usuń">
                  <IconButton
                    color="secondary"
                    size="small"
                    onClick={() => onDelete(environment.id, environment.name)}
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
