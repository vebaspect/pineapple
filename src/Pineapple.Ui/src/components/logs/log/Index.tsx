import moment from 'moment';
import React from 'react';

import Box from '@material-ui/core/Box';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';

import Icon from './Icon';
import Text from './Text';

import {
  LOG_TYPE__COMPONENT_VERSION,
} from './constants';

import {
  LogProps,
} from './interfaces';

const Log: React.FC<LogProps> = ({ modificationDate, type, category, ownerId, ownerFullName, entity, parentEntities }: LogProps) => {
  let style = {};
  if (type === LOG_TYPE__COMPONENT_VERSION) {
    if (entity.details.componentVersion.isImportant) {
      style = {
        backgroundColor: '#ffebee',
        border: '1px solid #ffcdd2',
        borderRadius: '4px',
      };
    }
  }

  return (
    <ListItem
      component="div"
      style={{
        marginBottom: '4px',
        ...style,
      }}
    >
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
            entity={entity}
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
