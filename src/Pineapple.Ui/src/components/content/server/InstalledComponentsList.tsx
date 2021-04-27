import React from 'react';

import Box from '@material-ui/core/Box';
import CircularProgress from '@material-ui/core/CircularProgress';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';

import {
  InstalledComponentsListProps,
} from './interfaces';

const InstalledComponentsList: React.FC<InstalledComponentsListProps> = ({ isDataFetched, data }: InstalledComponentsListProps) => {
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
            <TableRow key={`${installedComponent.componentId}_${installedComponent.componentVersionId}`}>
              <TableCell>{index + 1}.</TableCell>
              <TableCell>{installedComponent.componentName}</TableCell>
              <TableCell>{installedComponent.componentVersionNumber}</TableCell>
              <TableCell align="right" />
            </TableRow>
          ))
        }
      </TableBody>
    </Table>
  );
}

export default InstalledComponentsList;
