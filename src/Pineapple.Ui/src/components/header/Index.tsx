import React from 'react';

import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';

const Header = () => {
  return (
    <List component="nav">
      <ListItem>
        <ListItemText>
          🍍 Pineapple.UI
        </ListItemText>
      </ListItem>
    </List>
  );
}

export default Header;
