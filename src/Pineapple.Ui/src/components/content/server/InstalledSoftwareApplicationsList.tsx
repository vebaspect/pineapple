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
  InstalledSoftwareApplicationsListProps,
} from './interfaces';

const InstalledSoftwareApplicationsList: React.FC<InstalledSoftwareApplicationsListProps> = ({ isDataFetched, data, onUninstall }: InstalledSoftwareApplicationsListProps) => {
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
          <TableCell>Oprogramowanie</TableCell>
          <TableCell style={{ width: 100 }} />
        </TableRow>
      </TableHead>
      <TableBody>
        {
          data?.map((installedSoftwareApplication, index) => (
            <TableRow key={installedSoftwareApplication.id}>
              <TableCell>{index + 1}.</TableCell>
              <TableCell>
                <Link
                  component={RouterLink}
                  to={`/configuration/software-applications/${installedSoftwareApplication.softwareApplicationId}`}
                > 
                  {installedSoftwareApplication.softwareApplicationName}
                </Link>
              </TableCell>
              <TableCell align="right">
                <Tooltip title="Odinstaluj">
                  <IconButton
                    color="secondary"
                    size="small"
                    onClick={() => onUninstall(installedSoftwareApplication.softwareApplicationId, installedSoftwareApplication.softwareApplicationName)}
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

export default InstalledSoftwareApplicationsList;
