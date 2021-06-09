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
  InstalledComponentsListProps,
} from './interfaces';

const useStyles = makeStyles(() =>
  createStyles({
    componentVersionNumber: {
      paddingRight: '5px',
    },
    componentVersionNumberWrapper: {
      alignItems: 'center',
      display: 'flex',
    },
    product: {
      color: '#90a4ae',
    },
    separator: {
      paddingLeft: '5px',
      paddingRight: '5px',
    },
    warningIcon: {
      color: '#f50057',
    },
  }),
);

const InstalledComponentsList: React.FC<InstalledComponentsListProps> = ({ isDataFetched, data, onUpdate, onUninstall }: InstalledComponentsListProps) => {
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
          <TableCell>Komponent</TableCell>
          <TableCell>Wersja</TableCell>
          <TableCell style={{ width: 100 }} />
        </TableRow>
      </TableHead>
      <TableBody>
        {
          data?.map((installedComponent, index) => (
            <TableRow key={installedComponent.id}>
              <TableCell>{index + 1}.</TableCell>
              <TableCell>
                <Link
                  className={styles.product}
                  component={RouterLink}
                  to={`/products/${installedComponent.productId}`}
                >
                  {installedComponent.productName}
                </Link>
                <Box
                  className={styles.separator}
                  component="span"
                >
                  /
                </Box>
                <Link
                  component={RouterLink}
                  to={`/products/${installedComponent.productId}/components/${installedComponent.componentId}`}
                > 
                  {installedComponent.componentName}
                </Link>
              </TableCell>
              <TableCell>
                <Box className={styles.componentVersionNumberWrapper}>
                  <Link
                    className={styles.componentVersionNumber}
                    component={RouterLink}
                    to={`/products/${installedComponent.productId}/components/${installedComponent.componentId}/component-versions/${installedComponent.componentVersionId}`}
                  >
                    {installedComponent.componentVersionNumber}
                  </Link>
                  {
                    installedComponent.isUpdateAvailable
                      ? (
                        <Tooltip title="Dostępna jest nowsza wersja komponentu!">
                          <WarningIcon className={styles.warningIcon} />
                        </Tooltip>
                      )
                      : null
                  }
                </Box>
              </TableCell>
              <TableCell align="right">
                <Tooltip title="Edytuj">
                  <IconButton
                    size="small"
                    onClick={() => onUpdate(installedComponent.id)}
                  >
                    <EditIcon />
                  </IconButton>
                </Tooltip>
                <Tooltip title="Odinstaluj">
                  <IconButton
                    color="secondary"
                    size="small"
                    onClick={() => onUninstall(installedComponent.id, installedComponent.componentName)}
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

export default InstalledComponentsList;
