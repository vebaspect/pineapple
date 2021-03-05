import React, { useState } from 'react';
import { Link } from "react-router-dom";

import CircularProgress from '@material-ui/core/CircularProgress';
import Collapse from '@material-ui/core/Collapse';
import ExpandLess from '@material-ui/icons/ExpandLess';
import ExpandMore from '@material-ui/icons/ExpandMore';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';
import Tooltip from '@material-ui/core/Tooltip';

interface Props {
  // Flaga określająca, czy lista wdrożeń została pobrana z API.
  isDataFetched: boolean,
  // Lista wdrożeń.
  data: {
    // Identyfikator.
    id: string,
    // Nazwa.
    name: string,
    // Opis.
    description: string,
  }[];
};

const Implementations = ({ isDataFetched, data }: Props) => {
  // Flaga określająca, czy lista produktów jest rozwinięta.
  const [isExpanded, setIsExpanded] = useState(false);

  const onHeaderClick = () => {
    setIsExpanded(!isExpanded);
  };

  if (!isDataFetched) {
    return (
      <ListItem>
        <ListItemText>
          Wdrożenia
        </ListItemText>
        <CircularProgress size={20} />
      </ListItem>
    );
  }

  return (
    <>
      <ListItem button onClick={onHeaderClick}>
        <ListItemText>
          <Link
            to="/implementations"
            style={{ textDecoration: 'none'}}
          >
            Wdrożenia ({data.length})
          </Link>
        </ListItemText>
        {isExpanded ? <ExpandLess /> : <ExpandMore />}
      </ListItem>
      <Collapse
        in={isExpanded}
        style={{ paddingLeft: '16px' }}
      >
        <List component="div">
          {
            data.length > 0
            ? data.map(implementation => {
              return (
                <Tooltip key={implementation.id} title={implementation.description} placement="right">
                  <ListItem button>
                    <ListItemText>
                      <Link
                        to={`/implementations/${implementation.id}`}
                        style={{ fontSize: '0.9rem', textDecoration: 'none'}}
                      >
                        {implementation.name}
                      </Link>
                    </ListItemText>
                  </ListItem>
                </Tooltip>
              )
            })
            : null
          }
        </List>
      </Collapse>
    </>
  )
}

export default Implementations;
