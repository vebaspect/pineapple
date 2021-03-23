import React, { useState } from 'react';
import { Link as RouterLink } from 'react-router-dom';

import CircularProgress from '@material-ui/core/CircularProgress';
import Collapse from '@material-ui/core/Collapse';
import ExpandLess from '@material-ui/icons/ExpandLess';
import ExpandMore from '@material-ui/icons/ExpandMore';
import Link from '@material-ui/core/Link';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import Tooltip from '@material-ui/core/Tooltip';

import PowerIcon from '@material-ui/icons/Power';

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
    // Flaga określająca, czy wdrożenie zostało usunięte.
    isDeleted: boolean,
  }[],
};

const Implementations = ({ isDataFetched, data }: Props) => {
  // Flaga określająca, czy lista produktów jest rozwinięta.
  const [isExpanded, setIsExpanded] = useState(false);

  const onExpandLessButtonClick = () => {
    setIsExpanded(false);
  }

  const onExpandMoreButtonClick = () => {
    setIsExpanded(true);
  }

  if (!isDataFetched) {
    return (
      <ListItem>
        <ListItemIcon>
          <PowerIcon color="primary" />
        </ListItemIcon>
        <ListItemText>
          Wdrożenia
        </ListItemText>
        <CircularProgress size={20} />
      </ListItem>
    );
  }

  return (
    <>
      <ListItem button>
        <ListItemIcon>
          <PowerIcon color="primary" />
        </ListItemIcon>
        <ListItemText>
          <Link
            component={RouterLink}
            to="/implementations"
          >
            Wdrożenia ({data.filter(implementation => !implementation.isDeleted).length})
          </Link>
        </ListItemText>
        {
          data.length > 0
            ? (isExpanded ? <ExpandLess onClick={onExpandLessButtonClick} /> : <ExpandMore onClick={onExpandMoreButtonClick} />)
            : null 
        }
      </ListItem>
      <Collapse
        in={isExpanded}
        style={{ paddingLeft: '56px' }}
      >
        <List component="div">
          {
            data.length > 0
              ? data.filter(implementation => !implementation.isDeleted).map(implementation => {
                return (
                  <Tooltip key={implementation.id} title={implementation.description} placement="right">
                    <ListItem button>
                      <ListItemText>
                        <Link
                          component={RouterLink}
                          to={`/implementations/${implementation.id}`}
                          style={{ fontSize: '0.9rem' }}
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
