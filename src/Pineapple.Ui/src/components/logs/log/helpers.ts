import moment from 'moment';

// Funkcja grupująca logi względem daty modyfikacji.
export const groupLogsByDate = (logs) => {
  let groupedLogs = {};

  if (logs && logs.length > 0) {
    logs.forEach((log) => {
      const modificationDate = moment(log.modificationDate).format('LL');

      if (groupedLogs[modificationDate]) {
        groupedLogs[modificationDate] = [
          ...groupedLogs[modificationDate],
          log,
        ];
      } else {
        groupedLogs = {
          ...groupedLogs,
          [modificationDate]: [log],
        };
      }
    });
  }
  
  return groupedLogs;
};
