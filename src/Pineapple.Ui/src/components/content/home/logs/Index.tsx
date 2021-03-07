import moment from 'moment';
import React from 'react';

import Box from '@material-ui/core/Box';
import CircularProgress from '@material-ui/core/CircularProgress';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';

import Icon from '../../../log/Icon';
import Text from '../../../log/Text';

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
              <React.Fragment key={log.id}>
                <ListItem>
                  <ListItemIcon>
                    <Icon
                      type={log.type}
                      category={log.category}
                    />
                  </ListItemIcon>
                  <ListItemText>
                    <Box>
                      <Text
                        type={log.type}
                        category={log.category}
                        ownerFullName={log.ownerFullName}
                        entityName={log.entityName}
                      />
                    </Box>
                    <Box
                      color="text.disabled"
                      fontSize="0.8rem"
                      fontStyle="italic"
                    >
                      {moment(log.modifiedDate).format('LLL')}
                    </Box>
                  </ListItemText>
                </ListItem>
              </React.Fragment>
            )
          })
          : null
      }
    </List>
  );
}

export default Logs;
