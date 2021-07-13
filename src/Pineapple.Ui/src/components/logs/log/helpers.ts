import moment from 'moment';

import {
  KIND__PATCH,
  KIND__PRE_RELEASE,
  KIND__RELEASE,
} from '../../../helpers/componentVersionConstants';

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

// Funkcja tłumacząca rodzaj wersji komponentu.
export const translateComponentVersionKind = (kind: string) : string => {
  switch (kind) {
    case KIND__PATCH:
      return 'poprawkę';
    case KIND__PRE_RELEASE:
      return 'wersję przedpremierową';
    case KIND__RELEASE:
      return 'wersję';
    default:
      return '';
  }
};
