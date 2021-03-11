import React from 'react';

import Box from '@material-ui/core/Box';
import CircularProgress from '@material-ui/core/CircularProgress';
import List from '@material-ui/core/List';

import Log from '../../../log';

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
  }[];
};

const Logs = ({ isDataFetched, data }: Props) => {
  if (!isDataFetched) {
    return (
      <Box
        m={2}
        textAlign="center"
      >
        <CircularProgress />
      </Box>
    );
  }

  return (
    <List component="div">
      {
        data.length > 0
          ? data.map(log => {
            return (
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
          : null
      }
    </List>
  );
}

export default Logs;
