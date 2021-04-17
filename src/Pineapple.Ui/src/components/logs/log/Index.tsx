import moment from 'moment';
import React from 'react';

import Box from '@material-ui/core/Box';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';

import Icon from './Icon';
import Text from './Text';

import {
  LogProps,
} from './interfaces';

const Log: React.FC<LogProps> = ({ modificationDate, type, category, ownerId, ownerFullName, entityId, entityName, parentEntities }: LogProps) => {
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
            ownerId={ownerId}
            ownerFullName={ownerFullName}
            entityId={entityId}
            entityName={entityName}
            parentEntities={parentEntities}
          />
        </Box>
        <Box
          color="text.disabled"
          fontSize="0.8rem"
          fontStyle="italic"
        >
          {moment(modificationDate).format('LLL')}
        </Box>
      </ListItemText>
    </ListItem>
  );
}

export default Log;
