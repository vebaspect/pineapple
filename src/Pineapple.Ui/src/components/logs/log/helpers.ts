import moment from 'moment';

// Funkcja grupująca logi względem daty modyfikacji.
export const groupLogsByDate = (logs) => {
  let groupedLogs = {};

  if (logs && logs.length > 0) {
    logs.forEach((log) => {
      const modifiedDate = moment(log.modifiedDate).format('LL');

      if (groupedLogs[modifiedDate]) {
        groupedLogs[modifiedDate] = [
          ...groupedLogs[modifiedDate],
          log,
        ];
      } else {
        groupedLogs = {
          ...groupedLogs,
          [modifiedDate]: [log],
        };
      }
    });
  }
  
  return groupedLogs;
};
