import React, { useEffect, useState } from 'react';

import Box from '@material-ui/core/Box';
import CircularProgress from '@material-ui/core/CircularProgress';
import List from '@material-ui/core/List';

import Log from './log';

import { groupLogsByDate } from './log/helpers';

interface Props {
  // Flaga określająca, czy lista logów została pobrana z API.
  isDataFetched: boolean,
  // Lista logów.
  data: {
    // Identyfikator.
    id: string,
    // Data modyfikacji.
    modifiedDate: Date,
    // Typ.
    type: string,
    // Kategoria.
    category: string,
    // Imię i nazwisko właściciela.
    ownerFullName: string,
    // Nazwa encji.
    entityName: string,
    // Nazwa encji nadrzędnej.
    parentEntityName: string,
    // Opis.
    description: string,
  }[],
}

const Logs: React.FC<Props> = ({ isDataFetched, data }: Props) => {
  // Logi zgrupowane względem daty modyfikacji.
  const [logsGroupedByDate, setLogsGroupedByDate] = useState({});

  useEffect(() => {
    setLogsGroupedByDate(groupLogsByDate(data));
  }, [data]);

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

  const logs = [];

  if (Object.keys(logsGroupedByDate).length > 0) {
    Object.keys(logsGroupedByDate).forEach((key) => {
      if (logsGroupedByDate[key] && logsGroupedByDate[key].length > 0) {
        logs.push(
          <Box
            key={key}
            my={2}
          >
            {key}
          </Box>
        );

        logsGroupedByDate[key].forEach((log) => {
          logs.push(
            <Log
              key={log.id}
              modifiedDate={log.modifiedDate}
              type={log.type}
              category={log.category}
              ownerFullName={log.ownerFullName}
              entityName={log.entityName}
              parentEntityName={log.parentEntityName}
            />
          );
        })
      }
    });
  }

  return (
    <List component="div">
      {logs}
    </List>
  );
}

export default Logs;
