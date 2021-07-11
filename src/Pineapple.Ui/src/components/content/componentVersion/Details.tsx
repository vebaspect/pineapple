import moment from 'moment';
import React from 'react';

import Box from '@material-ui/core/Box';
import CircularProgress from '@material-ui/core/CircularProgress';
import Link from '@material-ui/core/Link';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableRow from '@material-ui/core/TableRow';

import {
  formatNumber,
  translateKind,
} from '../../../helpers/componentVersionHelpers';

import {
  DetailsProps,
} from './interfaces';

const Details: React.FC<DetailsProps> = ({ isDataFetched, kind, releaseDate, major, minor, patch, suffix, issueTrackingSystemTicketUrl, description, isImportant }: DetailsProps) => {
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
      <TableBody>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 220 }}>Rodzaj</TableCell>
          <TableCell>{translateKind(kind)}</TableCell>
          <TableCell
            align="center"
            rowSpan={9}
            style={{
              borderLeft: '1px',
              borderLeftColor: '#e0e0e0',
              borderLeftStyle: 'solid',
              fontSize: '2rem',
            }}
          >
            {formatNumber(major, minor, patch, suffix)}
          </TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 220 }}>Data wydania</TableCell>
          <TableCell>{moment(releaseDate).format('LLL')}</TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 220 }}>Major</TableCell>
          <TableCell>{major}</TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 220 }}>Minor</TableCell>
          <TableCell>{minor}</TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 220 }}>Patch</TableCell>
          <TableCell>{patch}</TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 220 }}>Przyrostek</TableCell>
          <TableCell>{suffix}</TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 220 }}>Zgłoszenie w systemie ITS</TableCell>
          <TableCell>
            {
              issueTrackingSystemTicketUrl
                ? (
                  <Link
                    href={issueTrackingSystemTicketUrl}
                    target="_blank"
                  >
                    {issueTrackingSystemTicketUrl}
                  </Link>
                )
                : '–'
            }
          </TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 220 }}>Opis</TableCell>
          <TableCell style={{ fontStyle: 'italic' }}>{description || '–'}</TableCell>
        </TableRow>
        <TableRow>
          <TableCell style={{ fontWeight: 500, width: 220 }}>Oznaczona jako &quot;Ważna&quot;</TableCell>
          <TableCell>{isImportant ? 'Tak' : 'Nie'}</TableCell>
        </TableRow>
      </TableBody>
    </Table>
  )
}

export default Details;
