import React, { useState } from 'react';

import Collapse from '@material-ui/core/Collapse';
import ExpandLess from '@material-ui/icons/ExpandLess';
import ExpandMore from '@material-ui/icons/ExpandMore';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';
import Tooltip from '@material-ui/core/Tooltip';

interface Props {
  // Produkty.
  items: {
    // Identyfikator.
    id: string,
    // Nazwa.
    name: string,
    // Opis.
    description: string,
  }[];
};

const Products = ({ items }: Props) => {
  // Flaga określająca, czy lista produktów jest rozwinięta.
  const [isExpanded, setIsExpanded] = React.useState(true);

  const onHeaderClick = () => {
    setIsExpanded(!isExpanded);
  };

  return (
    <List component="nav">
      <ListItem button onClick={onHeaderClick}>
        <ListItemText>
          Produkty ({items.length})
        </ListItemText>
        {isExpanded ? <ExpandLess /> : <ExpandMore />}
      </ListItem>
      <Collapse in={isExpanded}>
        <List component="div">
          {
            items.length > 0
            ? items.map(item => {
              return (
                <Tooltip key={item.id} title={item.description}>
                  <ListItem button>
                    <ListItemText>
                      {item.name}
                    </ListItemText>
                  </ListItem>
                </Tooltip>
              )
            })
            : null
          }
        </List>
      </Collapse>
    </List>
  )
}

export default Products;
