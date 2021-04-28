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

import {
  InstalledComponentsListProps,
} from './interfaces';

const InstalledComponentsList: React.FC<InstalledComponentsListProps> = ({ isDataFetched, data, onUninstall }: InstalledComponentsListProps) => {
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
          <TableCell>Produkt</TableCell>
          <TableCell>Komponent</TableCell>
          <TableCell>Wersja</TableCell>
          <TableCell style={{ width: 100 }} />
        </TableRow>
      </TableHead>
      <TableBody>
        {
          data?.map((installedComponent, index) => (
            <TableRow key={`${installedComponent.productId}_${installedComponent.componentId}_${installedComponent.componentVersionId}`}>
              <TableCell>{index + 1}.</TableCell>
              <TableCell>
                <Link
                  component={RouterLink}
                  to={`/products/${installedComponent.productId}`}
                >
                  {installedComponent.productName}
                </Link>
              </TableCell>
              <TableCell>
                <Link
                  component={RouterLink}
                  to={`/products/${installedComponent.productId}/components/${installedComponent.componentId}`}
                >
                  {installedComponent.componentName}
                </Link>
              </TableCell>
              <TableCell>
                <Link
                  component={RouterLink}
                  to={`/products/${installedComponent.productId}/components/${installedComponent.componentId}/component-versions/${installedComponent.componentVersionId}`}
                >
                  {installedComponent.componentVersionNumber}
                </Link>
              </TableCell>
              <TableCell align="right">
                <Tooltip title="Usuń">
                  <IconButton
                    color="secondary"
                    size="small"
                    onClick={() => onUninstall(installedComponent.componentVersionId)}
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
