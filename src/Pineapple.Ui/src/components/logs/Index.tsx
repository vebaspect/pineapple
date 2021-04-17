import React, { useEffect, useState } from 'react';

import Box from '@material-ui/core/Box';
import CircularProgress from '@material-ui/core/CircularProgress';
import List from '@material-ui/core/List';

import Log from './log';

import { groupLogsByDate } from './log/helpers';

import {
  LogsProps,
} from './interfaces';

const Logs: React.FC<LogsProps> = ({ isDataFetched, data }: LogsProps) => {
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
              modificationDate={log.modificationDate}
              type={log.type}
              category={log.category}
              ownerId={log.ownerId}
              ownerFullName={log.ownerFullName}
              entityId={log.entityId}
              entityName={log.entityName}
              parentEntityId={log.parentEntityId}
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
