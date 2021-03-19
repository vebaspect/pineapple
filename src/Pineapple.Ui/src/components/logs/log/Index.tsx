import moment from 'moment';
import React from 'react';

import Box from '@material-ui/core/Box';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';

import Icon from './Icon';
import Text from './Text';

interface Props {
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
};

const Log = ({ modifiedDate, type, category, ownerFullName, entityName, parentEntityName }: Props) => {
  return (
    <ListItem component="div">
      <ListItemIcon>
        <Icon
          type={type}
          category={category}
        />
      </ListItemIcon>
      <ListItemText>
        <Box>
          <Text
            type={type}
            category={category}
            ownerFullName={ownerFullName}
            entityName={entityName}
            parentEntityName={parentEntityName}
          />
        </Box>
        <Box
          color="text.disabled"
          fontSize="0.8rem"
          fontStyle="italic"
        >
          {moment(modifiedDate).format('LLL')}
        </Box>
      </ListItemText>
    </ListItem>
  );
}

export default Log;
